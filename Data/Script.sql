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
tipo_produto      int           not null,-- 0 = primário e 1 - adicional
tipo_medida       int           not null, -- 0 = ml e 1 =  quantidade
check(tipo_medida  in (0, 1)),
check(tipo_produto in (0, 1))
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
primary key (id_produtos,id_pedidos)
)
go

create table COMPRAS(
id_compras     int           not null  primary key  identity,
data_compra    smallDateTime      not null
)
go

create table PRODUTOS_COMPRAS(
id_produtos int not null references PRODUTOS,
id_compras  int not null references COMPRAS,
quantidade  decimal(10,2) not null,
primary key (id_produtos, id_compras)
)
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

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO FUNCIONARIO------------------------
--------------------------------------------------------------------------------------------

create view v_listaFuncionario
as
	select pe.id_pessoas, pe.nome, pe.celular, pe.email, pe.senha, pe.situacao, fun.salario, fun.cargo
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

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO PRODUTO----------------------------
--------------------------------------------------------------------------------------------

create view v_listaProduto
as
	select pro.id_produtos, pro.imagem, pro.situacao, pro.nome, pro.estoque, tpro.preco, tpro.tipo_produto, tpro.tipo_medida
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
	@nome		     varchar(100),
	@preco		     decimal(10,2)
)
as
begin
	update PRODUTOS set nome = @nome WHERE id_produtos = @id_produtos
	update TIPO_PRODUTOS set preco = @preco where id_tipo_produto = @id_produtos
end

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO ALTERAR PRODUTO----------------------------
--------------------------------------------------------------------------------------------

create view v_listaAltProduto
as
	select pro.situacao, pro.nome, pro.estoque, tpro.preco, tpro.tipo_produto
	from   PRODUTOS pro, TIPO_PRODUTOS tpro
	where  pro.id_produtos = tpro.id_tipo_produto
go

select * from v_listaAltProduto
go

--------------------------------------------------------------------------------------------
------------------------------------ DELETAR PRODUTOS --------------------------------------
--------------------------------------------------------------------------------------------

CREATE PROCEDURE delProduto
(
	@id_produto int,
	@situacao   bit
)
as
begin 
	UPDATE PRODUTOS SET situacao = @situacao  WHERE id_produtos = @id_produto 
end
go

exec delProduto 7, 0
go

--------------------------------------------------------------------------------------------
-----------------------------PROCEDURE CADASTRAR COMPRA-------------------------------------
--------------------------------------------------------------------------------------------

create procedure cadCompra
(
	@id_produtos int, -- tabela produtos_compras
	@data_compra datetime,
	@quantidade  int,
	@valor_total decimal(10,2),
	@estoque float
)
as
begin
	insert 	COMPRAS values(@data_compra)
	insert  PRODUTOS_COMPRAS values(@id_produtos, @quantidade, @valor_total, @@IDENTITY)
	UPDATE 	PRODUCT SET estoque = @estoque
end
go

--------------------------------------------------------------------------------------------
----------------------------------VIEW EXIBIÇÃO CADASTRO COMPRA-----------------------------
--------------------------------------------------------------------------------------------

create View v_listaCadCompra
as
	select com.data_compra, com.quantidade, pro.situacao, pro.nome, pro.estoque
	from COMPRAS com, PRODUTOS pro, PRODUTOS_COMPRAS pc
	where com.id_compras = pc.id_compras and pc.id_produtos = pro.id_produtos
go

select * from v_listaCadCompra
go

--------------------------------------------------------------------------------------------
--------------------------------PROCEDURE REGISTRO DE VENDA---------------------------------
--------------------------------------------------------------------------------------------

create procedure regPedidos
(
	@id_cliente        int,
	@id_funcionario    int,
	@cod_pedido        varchar(40),
	@observacoes       varchar(500),
	@situacao          bit,
	@data_venda        datetime,
	@pedido_lido       datetime,
	@pedido_produzindo datetime,
	@pedido_entregue   datetime
)
as
begin
	insert PEDIDOS values(@id_cliente, @id_funcionario, @cod_pedido, @observacoes, @situacao, @data_venda, @pedido_lido, @pedido_produzindo, @pedido_entregue)
end
go

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

--------------------------------------------------------------------------------------------
--------------------------------PROCEDURE ITENS PEDIDOS-------------------------------------
--------------------------------------------------------------------------------------------

create procedure itensPed(
	@id_produtos int,
	@id_pedidos  int,
	@quantidade  int
)
as
begin
	insert into PRODUTOS_PEDIDOS values (@id_produtos, @id_pedidos, @quantidade)
end
go

--------------------------------------------------------------------------------------------
--------------------------------VIEW ITENS PEDIDOS------------------------------------------
--------------------------------------------------------------------------------------------

create view v_itensPed
as
	select pp.id_produtos, pp.id_pedidos, pp.quantidade
	from PRODUTOS_PEDIDOS pp
	where pp.id_produtos = pp.id_pedidos
go

select * from v_itensPed
go

--------------------------------------------------------------------------------------------
--------------------------------PROCEDURE CADASTRAR COMPRAS---------------------------------
--------------------------------------------------------------------------------------------

create procedure cadCompras(
	@id_compras int,
	@data_compra datetime
)
as
begin
	insert into COMPRAS values(@id_compras, @data_compra)
end
go

--------------------------------------------------------------------------------------------
--------------------------------VIEW CADASTRAR COMPRAS--------------------------------------
--------------------------------------------------------------------------------------------

create view v_cadCompra
as
	select com.id_compras, com.data_compra
	from COMPRAS com
go

select * from v_cadCompra
go

--------------------------------------------------------------------------------------------
-------------------------------PROCEDURE ITENS COMPRAS--------------------------------------
--------------------------------------------------------------------------------------------

create procedure itensCompras(
	@id_compras  int,
	@id_produtos int,
	@quantidade  int,
	@valor_total int
)
as
begin
	insert COMPRAS values (@id_compras)
	insert PRODUTOS_PEDIDOS values (@id_produtos, @quantidade)
end
go

--------------------------------------------------------------------------------------------
------------------------------------VIEW ITENS COMPRAS--------------------------------------
--------------------------------------------------------------------------------------------

create view v_itensCompras
as
	select c.id_compras, prop.id_produtos, prop.quantidade
	from COMPRAS c, PRODUTOS_PEDIDOS prop
	where c.id_compras = prop.id_produtos
go

select * from v_itensCompras
go

--------------------------------------------------------------------------------------------
-------------------------------PROCEDURE ALTERAR CLIENTES-----------------------------------
--------------------------------------------------------------------------------------------

create procedure altClientes(
	@nome			 varchar(50),
	@celular		 varchar(14),
	@email		     varchar(50),
	@senha			 varchar(50),
	@situacao        bit,         -- 0 = Ativo e 1 = Desativo
	@id_pessoas      int,
	@cpf			 varchar(14),
	@endereco		 varchar(40),
	@complemento	 varchar(100),
	@numero_endereco varchar(10),
	@bairro			 varchar(40),
	@cep			 varchar(10)
)
as
begin
	update PESSOAS     set nome = @nome, celular = @celular, email = @email, senha = @senha, situacao=  @situacao where id_pessoas = @id_pessoas
	update CLIENTES    set cpf =  @cpf where id_pessoas = @id_pessoas
	update LOGRADOUROS set endereco = @endereco, complemento = @complemento, numero_endereco = @numero_endereco, bairro = @bairro, cep = @cep where id_clientes = @id_pessoas
end
go


---------------------------------------------------------------------------------------
----------------------------PROCEDURE E VIEW   ----------------------------------------
---------------------------------------------------------------------------------------


create procedure cadCompra
(
	@id_produto int, -- tabela produtos_compras
	@data_compra datetime,
	@quantidade  decimal(10,2),
	@estoque decimal(10,2)
)
as
begin
	insert 	COMPRAS values(@data_compra)
	insert  PRODUTOS_COMPRAS values(@id_produto, @@IDENTITY, @quantidade )
	UPDATE 	PRODUTOS SET estoque = @estoque where id_produtos = @id_produto
end
go

exec cadCompra   3, '20211116 18:24', 15.00, 15.00
go

CREATE VIEW V_LISTACOMPRAS
AS
	select c.id_compras, P.nome, P.estoque, TP.preco, c.data_compra, pc.quantidade, (TP.preco * PC.quantidade) AS valor_total
	from COMPRAS c
	INNER JOIN PRODUTOS_COMPRAS pc
	ON C.id_compras = PC.id_compras
	INNER JOIN PRODUTOS P
	on P.id_produtos = PC.id_produtos
	INNER JOIN TIPO_PRODUTOS TP
	ON TP.id_tipo_produto = P.id_produtos
GO

select * from V_LISTACOMPRAS

---------------------------------------------------------------------------------------
----------------------------PROCEDURE ALTERA FUNCIONÁRIO   ----------------------------
---------------------------------------------------------------------------------------

create procedure altFuncionario(
	@nome			 varchar(50),
	@celular		 varchar(14),
	@email		     varchar(50),
	@senha			 varchar(50),
	@situacao        bit,         -- 0 = Ativo e 1 = Desativo
	@id_pessoas      int,
	@salario         float,
	@cargo			 varchar(100)	
)
as
begin
	update PESSOAS     set nome = @nome, celular = @celular, email = @email, senha = @senha, situacao = @situacao where id_pessoas = @id_pessoas
	update FUNCIONARIOS   set salario =  @salario, cargo = @cargo where id_pessoas = @id_pessoas
end
go




