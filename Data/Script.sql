Create database point_summer_foods_dev

go

use point_summer_foods_dev

go

create table PESSOAS (
id_pessoas   int         not null  primary key  identity,
nome         varchar(50) not null,
celular      varchar(14) not null,
email        varchar(50) not null  unique,
senha        varchar(50) not null,
situacao     bit         not null -- 1 = Ativo e 0 = Desativo     EXCLUIR TABELA PESSOAS E TODAS FK PRA ADICIONAR NOVAMENTE A TABELA COM O COMPO SITUACAO
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
imagem          varchar(100),
situacao        bit            not null,-- 0=Desativo 1=Ativo
nome            varchar(100)   not null,
estoque         decimal(10,2)  not null,
check (situacao in ( 0, 1))
)
go

create table TIPO_PRODUTOS(
id_tipo_produto   int           not null  primary key references PRODUTOS, 
preco             decimal(10,2) not null,
tipo_produto      int           not null, -- 1 = primário e 2 - adicional 
tipo_medida       int           not null, -- 1 = ml e 2 =  quantidade
check(tipo_produto in (1, 2)),
check(tipo_medida in (1, 2))
)
go


create table PEDIDOS(
id_pedidos        int            not null   primary key   identity,
id_clientes       int            not null   references    CLIENTES,
id_funcionarios   int            not null   references    FUNCIONARIOS,
cod_pedidos       varchar(40)    not null,
observacoes       varchar(500),
situacao          int            not null, -- 1=Leitura do pedido 2=Produzindo 3=Saiu pra entrega 
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
quantidade     decimal(10,2) not null,
valor_total    decimal(10,2) not null
)

go

create table PRODUTOS_COMPRAS(
id_produtos int not null references PRODUTOS,
id_compras  int not null references COMPRAS,
primary key (id_produtos, id_compras)
)
go

use point_summer_foods_dev
go

use point_summer_foods_dev
go

create procedure cadCliente(
	@nome			 varchar(50),
	@celular		 varchar(14),
	@email		     varchar(50),
	@senha			 varchar(50),
	@situacao        bit,         -- 0 = Ativo e 1 = Desativo
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

	insert into PESSOAS values(@nome, @celular, @email, @senha, @situacao)
	set @id = @@identity
	insert into CLIENTES values(@id, @cpf)
	insert into LOGRADOUROS values(@id, @endereco, @complemento, @numero_endereco, @bairro, @cep)

end
go

exec cadCliente 'Guilherme Piovezan', '17 988840120', 'piovezan.guilherme@gmail.com', '1234567', 0, '11111111111', 'av.São Paulo', 'mansão', '890', 'Centro', '15200000'

go

exec cadCliente 'Vitor kemuel Carreiro Ponte', '17 988840120', 'pikvezan.guilherme@gmail.com', '1234567', 0, '11111111112', 'av.São Paulo', 'mansão', '890', 'Centro', '15200000'

go

exec cadCliente 'Alex Gomes da Silva Filho', '17 988840120', 'puovezan.guilherme@gmail.com', '1234567', 0, '11112111111', 'av.São Paulo', 'mansão', '890', 'Centro', '15200000'

go

exec cadCliente 'Heitor Piva Carreira', '17 988840120', 'fjkavezan.guilherme@gmail.com', '1234567', 0, '1111213111', 'av.São Paulo', 'mansão', '890', 'Centro', '15200000'

go


--------------------------------------------------------------------------------------------
-----------------------------VIEW LISTA CLIENTES--------------------------------------------
--------------------------------------------------------------------------------------------


create view v_listaClientes

as
    select p.id_pessoas, p.nome, p.email, p.senha, p.situacao, p.celular, c.cpf, lg.endereco, lg.numero_endereco as numero, lg.bairro, lg.complemento, lg.cep
    from PESSOAS p, CLIENTES c, LOGRADOUROS lg
    where p.id_pessoas = c.id_pessoas and lg.id_clientes = c.id_pessoas

go

select * from v_listaClientes
order by nome asc
go
--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRO FUNCIONARIO---------------------------------
--------------------------------------------------------------------------------------------

create procedure cadFuncionario 
(
	@nome     varchar(50),
	@celular  varchar(14),
	@email    varchar(50),
	@senha	  varchar(50), -- lembrando que senha deve ser maior que 6 caracteres
	@situacao bit,         -- 0 = Ativo e 1 = Desativo
	@salario  decimal(10,2),
	@cargo    varchar(50)
)
as
begin

	insert into PESSOAS      values(@nome, @celular, @email, @senha, @situacao)
	insert into FUNCIONARIOS values(@@identity, @salario, @cargo)

end 

exec cadFuncionario 'Heitor Piva Carreira', '017 98804-4110', 'piva.heitor@gmail.com', '1234567', 1, 2500.00, 'Atendente'
go
exec cadFuncionario 'Dener Gabriel de Matos', '017 98804-2353', 'delete.email@gmail.com', '1234567', 1,  2500.00, 'Atendente'
go
exec cadFuncionario 'João Gustavo', '017 98804-1243', 'gustavo.joao@gmail.com', '1234567', 1,  1800.00, 'Motorista'
go

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO FUNCIONARIO------------------------
--------------------------------------------------------------------------------------------

create view v_listaFuncionario
as

	select pe.nome, pe.celular, pe.email, pe.senha, pe.situacao, fun.salario, fun.cargo
	from PESSOAS pe, FUNCIONARIOS fun
	where pe.id_pessoas = fun.id_pessoas

go

select * from v_listaFuncionario
order by nome asc
go


--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRO PRODUTO-------------------------------------
--------------------------------------------------------------------------------------------

create procedure cadProduto
(
	@imagem          varchar(100),
	@situacao	     bit,-- 1=Ativo 2=Desativo
	@nome		     varchar(100),
	@estoque	     decimal(10,2),
	@preco		     decimal(10,2),
	@tipo_produto    bit,         -- define se o produto é do tipo normal ou adicional
    @tipo_medida     bit          -- define se a medida do produto é do tipo ml ou quantidade
)
as
begin

	insert into PRODUTOS values(@imagem, @situacao, @nome, @estoque)
	insert into TIPO_PRODUTOS values( @@IDENTITY, @preco, @tipo_produto, @tipo_medida)
end


exec cadProduto '1234', 1, 'açai premium', 22000.0, 122.00, 1  
go

exec cadProduto '5678', 1, 'Banana nanica', 2.0, 2.00, 1  
go


--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO PRODUTO----------------------------
--------------------------------------------------------------------------------------------

create view v_listaProduto
as
	select pro.imagem, pro.situacao, pro.nome, pro.estoque, tpro.preco, tpro.tipo_produto, tpro.tipo_medida
	from PRODUTOS pro, TIPO_PRODUTOS tpro
	where pro.id_produtos = tpro.id_tipo_produto
go

select * from v_listaProduto
order by nome asc
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

exec altProduto 2, '4321', 2, 'açai dourado', 19000.00, 2, 119.00, 2
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

--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRAR COMPRA-------------------------------------
--------------------------------------------------------------------------------------------

create procedure cadCompra
(
	@id_produtos int, -- tabela produtos_compras
	@data_compra datetime,
	@quantidade  int,
	@valor_total decimal(10,2)
)
as
begin

	insert COMPRAS values(@data_compra, @quantidade, @valor_total)
	insert  PRODUTOS_COMPRAS values(@id_produtos, @@IDENTITY)
	
end
go

exec cadCompra 1, '20211109' , 30, 20.00;
go

exec cadCompra 2, '20211109' , 30, 20.00;
go

exec cadCompra 3, '20211109' , 30, 20.00;
go


--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO COMPRA-----------------------------
--------------------------------------------------------------------------------------------


create View v_listaCadCompra
as

	select com.data_compra, com.quantidade, pro.cod_produto, pro.situacao, pro.nome, pro.estoque
	from COMPRAS com, PRODUTOS pro, PRODUTOS_COMPRAS pc
	where com.id_compras = pc.id_compras and pc.id_produtos = pro.id_produtos

go

select * from v_listaCadCompra
go

--------------------------------------------------------------------------------------------
--------------------------------PROCEDURE REGISTRO DE VENDA---------------------------------
--------------------------------------------------------------------------------------------

create procedure regVenda
(
	@id_cliente        int,
	@id_funcionario    int,
	@cod_pedido        varchar(40),
	@observacoes       varchar(500),
	@situacao          bit,
	@data_venda        datetime,
	@pedido_lido       datetime,
	@pedido_produzindo datetime,
	@pedido_entregue   datetime,
	@id_produto        int,
	@quantidade        int,         -- existem dois campos com o memso nome, deveriamos trocar o nome dos campos para não haver interferencia
	@valor_total       decimal(7,1) -- existem dois campos com o memso nome, deveriamos trocar o nome dos campos para não haver interferencia
)
as 
begin

	insert PEDIDOS values(@id_cliente, @id_funcionario, @cod_pedido, @observacoes, @situacao, @data_venda, @pedido_lido, @pedido_produzindo, @pedido_entregue)
	insert PRODUTOS_PEDIDOS values(@id_produto, @@IDENTITY, @quantidade, @valor_total)
	
end
go


exec regVenda 1, 3, '30265', 'Tirar a cebola', 1, '20211110 18:42', '20211110 18:42', '20211110 18:50', '20211110 00:00', 2, 1, 15.50


create view v_listaRegVendas
as

	select ped.cod_pedidos, ped.observacoes, ped.situacao, ped.data_venda, ped.pedido_lido, ped.pedido_produzindo, ped.pedido_entregue, prop.id_produtos, prop.quantidade, prop.valor_total,pe.id_pessoas, pe.celular, pe.email, pe.nome, pe.senha, cli.cpf, fun.cargo, fun.salario
	from PEDIDOS ped, PRODUTOS_PEDIDOS prop, PESSOAS pe, CLIENTES cli, FUNCIONARIOS fun
	where pe.id_pessoas = cli.id_pessoas and pe.id_pessoas = ped.id_clientes and ped.id_pedidos = prop.id_pedidos

go

select * from v_listaRegVendas
go

--------------------------------------------------------------------------------------------
--------------------------------PROCEDURE DELETAR CLIENTE------------------------------------
--------------------------------------------------------------------------------------------

create procedure delCliente(
	@id_pessoas int,
	@situacao   bit
)
as
	update PESSOAS set situacao = @situacao
	where id_pessoas = @id_pessoas

go




