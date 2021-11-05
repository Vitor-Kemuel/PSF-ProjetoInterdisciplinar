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

create table FUNCIONARIOS(
id_pessoas        int            not null primary key references PESSOAS,
salario           decimal(10,2)  not null,
cargo             varchar(50)    not null,
)

go

create table CLIENTES(
id_pessoas  int         not null primary key  references PESSOAS,
cpf         varchar(14) not null unique,
)

go

create table LOGRADOUROS(
id_clientes      int          not null  primary key references CLIENTES,
endereco         varchar(40)  not null,
complemento      varchar(100) not null,
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

create table PEDIDOS(
id_pedidos        int            not null   primary key   identity,
fk_clientes       int            not null   references  CLIENTES,
fk_produtos       int            not null   references  PRODUTOS,
cod_pedidos       varchar(40)    not null,
quantidade        int            not null,
observacoes       varchar(500),
situacao          int            not null, -- 1=Leitura do pedido 2=Produzindo 3=Saiu pra entrega 
valor_total       decimal(10,2)  not null,
data_venda        datetime       not null,
pedido_lido       datetime       not null, --Horario
pedido_produzindo datetime       not null, --Horario
pedido_entregue   datetime       not null  --horario
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


create table TIPO_PRODUTOS(
id_tipo_produto   int           not null  primary key references PRODUTOS, 
preco             decimal(10,2) not null,
tipo_produto      bit           not null,
)

go


/*
use point_summer_foods_dev
go

create procedure cadCliente(
	@nome			 varchar(50),
	@celular		 varchar(14),
	@email		     varchar(50),
	@senha			 varchar(50),
	@cpf			 varchar(14),
	@estado			 varchar(40),
	@endereco		 varchar(40),
	@complemento	 varchar(100),
	@numero_endereco varchar(10),
	@cidade			 varchar(40),
	@bairro			 varchar(40),
	@cep			 varchar(10)
)
as 
begin

	insert into PESSOAS values(@nome,@celular,@email,@senha)
	insert into CLIENTES values(@@identity,@cpf)
	insert into LOGRADOURO values(@@identity,@estado, @endereco, @complemento, @numero_endereco, @cidade, @bairro, @cep)

end
go

exec cadCliente 'Alex Gomes da Silva Filho', '17 988044110', 'alex.gsan11@gmail.com', '1234567', '46032190838', 'Sao Paulo', 'av.tarraf', 'sobrado', '3576', 'Mirassol', 'Portal Cidade Amiga', '15133296'

go

select * from CLIENTES, PESSOAS, LOGRADOURO

go
*/

--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRO CLIENTE-------------------------------------
--------------------------------------------------------------------------------------------

use point_summer_foods_dev
go

create procedure cadCliente(
	@nome			 varchar(50),
	@celular		 varchar(14),
	@email		     varchar(50),
	@senha			 varchar(50),
	@cpf			 varchar(14)
)
as 
begin

	insert into PESSOAS values(@nome,@celular,@email,@senha)
	insert into CLIENTES values(@@identity,@cpf)
end
go

exec cadCliente 'Guilherme Piovezan', '17991380595', 'guilherme.piovezan@fatec.sp.gov.br', '1234567', '48502555820'
go

exec cadCliente 'Vitor Kemuel Carreiro Ponte', '017 98804-4345', 'kemuel.vitor@gmail.com', '1234567', '12345789905'
go

CREATE PROCEDURE cadLogradouro
(
	@id_clientes int,
	@endereco    varchar(50),
	@complemento varchar(50),
	@numero      varchar(50),
	@bairro      varchar(50),
	@cep         varchar(50)
)
as 
begin
	insert into LOGRADOUROS VALUES (@id_clientes, @endereco, @complemento, @numero, @bairro, @cep)
end

EXEC cadLogradouro 5, 'Avenida São Paulo', 'Residencial', '890', 'Centro', '15200-000'

exec cadLogradouro 9, 'Avenida São Paulo', 'Residencial', '890', 'Centro', '15200-000'


select * from PESSOAS
select * from CLIENTES
select * from LOGRADOUROS


--------------------------------------------------------------------------------------------
-----------------------------VIEW EXIBIÇÃO CADASTRO CLIENTE---------------------------------
--------------------------------------------------------------------------------------------

create view v_listaClientes
as

	select p.nome, p.email, p.senha, p.celular, c.cpf, lg.endereco, lg.numero_endereco as numero, lg.bairro, lg.complemento, lg.cidade, lg.cep, lg.estado
	from PESSOAS p, CLIENTES c, LOGRADOUROS lg
	where p.id_pessoas = c.id_pessoas and lg.id_clientes = c.id_pessoas

go

select * from v_listaCliente


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

create procedure cadProduto
(
	@cod_produto  varchar(40),
	@situacao	  bit,-- 1=Ativo 2=Desativo
	@nome		  varchar(100),
	@estoque	  decimal(10,2)
)
as
begin

	insert into PRODUTOS values(@cod_produto, @situacao, @nome, @estoque)

end

create procedure cadTipoProduto
(	
	@id_tipo_produto int,
	@preco		     decimal(10,2),
	@tipo_produto    bit           -- define se o produto é do tipo normal ou adicional
)
as
begin

	insert into TIPO_PRODUTOS values( @id_tipo_produto, @preco, @tipo_produto)

end



exec cadProduto '1234', 1, 'açai premium', 22000.0
go

exec cadTipoProduto  1 , 122.00, 1  
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