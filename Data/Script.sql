Create database point_summer_foods_dev

go

use point_summer_foods_dev

go

create table PESSOAS (
id_pessoas   int         not null  primary key  identity,
nome         varchar(50) not null,
celular      varchar(14) not null,
email        varchar(50) not null  unique,
senha        varchar(50) not null
)

go

create table CLIENTES(
id_pessoas  int         not null primary key  references PESSOAS,
cpf         varchar(14) not null unique,
)

go

create table FUNCIONARIOS(
id_pessoas        int            not null primary key references PESSOAS,
salario           decimal(10,2)  not null,
cargo             varchar(50)    not null,
)

go

create table LOGRADOUROS(
id_clientes      int          not null  primary key references CLIENTES,
endereco         varchar(40)  not null,
complemento      varchar(100),
numero_endereco  varchar(10)  not null,
bairro           varchar(40)  not null,
cep              varchar(10)  not null
)

go

create table PRODUTOS(
id_produtos     int            not null  primary key  identity,
cod_produto     varchar(40)    not null,
situacao        bit            not null,-- 1=Ativo 2=Desativo
nome            varchar(100)   not null,
estoque         decimal(10,2)  not null,
check (situacao in ( 1, 2))
)

go

create table TIPO_PRODUTOS(
id_tipo_produto   int           not null  primary key references PRODUTOS, 
preco             decimal(10,2) not null,
tipo_produto      bit           not null,
)

go

create table PEDIDOS(
id_pedidos        int            not null   primary key   identity,
fk_clientes       int            not null   references    CLIENTES,
cod_pedidos       varchar(40)    not null,
quantidade        int            not null,
observacoes       varchar(500),
situacao          int            not null, -- 1=Leitura do pedido 2=Produzindo 3=Saiu pra entrega 
valor_total       decimal(10,2)  not null,
data_venda        datetime       not null,
pedido_lido       datetime       not null, --Horario
pedido_produzindo datetime       not null, --Horario
pedido_entregue   datetime       not null, --horario
check   (situacao in (1, 2, 3))
)

go

create table PRODUTOS_PEDIDOS(
id_produtos int           not null references PRODUTOS,
id_pedidos  int           not null references PEDIDOS,
quantidade  int           not null,
valor_total decimal(7,2)  not null, 
primary key (id_produtos,id_pedidos)              
)

go

create table COMPRAS(
id_compras     int           not null  primary key  identity,
data_compra    datetime      not null,
quantidade     decimal(10,2) not null
)

go

create table PRODUTOS_COMPRAS(
id_produtos int not null references PRODUTOS,
id_compras  int not null references COMPRAS,
primary key (id_produtos, id_compras)
)

go


--------------------------------------PROCEDURES


use point_summer_foods_dev
go

create procedure cadCliente(
	@nome			 varchar(50),
	@celular		 varchar(14),
	@email		     varchar(50),
	@senha			 varchar(50),
	@cpf			 varchar(14),
	@endereco		 varchar(40),
	@complemento	 varchar(100),
	@numero_endereco varchar(10),
	@bairro			 varchar(40),
	@cep			 varchar(10)
)
as 
begin

	declare @id as int

	insert into PESSOAS values(@nome, @celular,@email,@senha)
	set @id = @@identity
	insert into CLIENTES values(@id, @cpf)
	insert into LOGRADOUROS values(@id, @endereco, @complemento, @numero_endereco, @bairro, @cep)

end
go

exec cadCliente 'Guilherme Piovezan', '17 988840120', 'piovezan.guilherme@gmail.com', '1234567', '11111111111', 'av.São Paulo', 'mansão', '890', 'Centro', '15200000'

go

--------------------------------------------------------------------------------------------
-----------------------------VIEW LISTA CLIENTES--------------------------------------------
--------------------------------------------------------------------------------------------


create view v_listaClientes
as

	select p.nome, p.email, p.senha, p.celular, c.cpf, lg.endereco, lg.numero_endereco as numero, lg.bairro, lg.complemento, lg.cep
	from PESSOAS p, CLIENTES c, LOGRADOUROS lg
	where p.id_pessoas = c.id_pessoas and lg.id_clientes = c.id_pessoas

go

select * from v_listaClientes
--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRO FUNCIONARIO---------------------------------
--------------------------------------------------------------------------------------------

create procedure cadFuncionario 
(
	@nome    varchar(50),
	@celular varchar(14),
	@email   varchar(50),
	@senha	 varchar(50), -- lembrando que senha deve ser maior que 6 caracteres
	@salario decimal(10,2),
	@cargo   varchar(50)
)
as
begin

	insert into PESSOAS      values(@nome, @celular, @email, @senha)
	insert into FUNCIONARIOS values(@@identity, @salario, @cargo)

end 

exec cadFuncionario 'Heitor Piva Carreira', '017 98804-4110', 'piva.heitor@gmail.com', '1234567', 2500.00, 'Atendente'
go
exec cadFuncionario 'Dener Gabriel de Matos', '017 98804-2353', 'gabriel.dener@gmail.com', '1234567', 2500.00, 'Atendente'
go
exec cadFuncionario 'João Gustavo', '017 98804-1243', 'gustavo.joao@gmail.com', '1234567', 1800.00, 'Motorista'
go

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO FUNCIONARIO------------------------
--------------------------------------------------------------------------------------------

create view v_listaFuncionario
as

	select pe.nome, pe.celular, pe.email, pe.senha, fun.salario, fun.cargo
	from PESSOAS pe, FUNCIONARIOS fun
	where pe.id_pessoas = fun.id_pessoas

go

select * from v_listaFuncionario


--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRO PRODUTO-------------------------------------
--------------------------------------------------------------------------------------------

drop procedure cadProduto
go

create procedure cadProduto
(
	@cod_produto     varchar(40),
	@situacao	     bit,-- 1=Ativo 2=Desativo
	@nome		     varchar(100),
	@estoque	     decimal(10,2),
	@preco		     decimal(10,2),
	@tipo_produto    bit           -- define se o produto é do tipo normal ou adicional
)
as
begin

	insert into PRODUTOS values(@cod_produto, @situacao, @nome, @estoque)
	insert into TIPO_PRODUTOS values( @@IDENTITY, @preco, @tipo_produto)


end

exec cadProduto '1234', 1, 'açai premium', 22000.0, 122.00, 1  
go


--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO PRODUTO----------------------------
--------------------------------------------------------------------------------------------

create view v_listaProduto
as
	select pro.cod_produto, pro.situacao, pro.nome, pro.estoque, tpro.preco, tpro.tipo_produto
	from PRODUTOS pro, TIPO_PRODUTOS tpro
	where pro.id_produtos = tpro.id_tipo_produto

go

select * from v_listaProduto
go
--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE ALTERAR PRODUTO-------------------------------------
--------------------------------------------------------------------------------------------

create procedure altProduto
(
	@id_produtos     int,       
	@cod_produto     varchar(40),
	@situacao	     bit,          -- 1=Ativo 2=Desativo
	@nome		     varchar(100),
	@estoque         decimal(10,2),
	@id_tipo_produto int,
	@preco		     decimal(10,2),
	@tipo_produto    bit           -- define se o produto é do tipo normal ou adicional
)
as
begin
	
	update PRODUTOS set cod_produto = @cod_produto, situacao = @situacao, nome = @nome, estoque = @estoque
	update TIPO_PRODUTOS set preco = @preco, tipo_produto = @tipo_produto

end

exec altProduto 2, '4321', 2, 'açai dourado', 19000.00, 119.00, 2
go

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO ALTERAR PRODUTO----------------------------
--------------------------------------------------------------------------------------------


create view v_listaAltProduto
as
	
	select pro.cod_produto, pro.situacao, pro.nome, pro.estoque, tpro.preco, tpro.tipo_produto
	from   PRODUTOS pro, TIPO_PRODUTOS tpro
	where  pro.id_produtos = tpro.id_tipo_produto

go

select * from v_listaAltProduto

go
