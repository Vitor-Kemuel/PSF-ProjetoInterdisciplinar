Create database point_summer_foods_dev

go


use point_summer_foods_dev

go

create table PESSOAS (
id_pessoas   int         not null  primary key  identity,
nome         varchar(50) not null,
celular      varchar(14) not null  unique,
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

create table LOGRADOURO(
id_logradouro    int          not null  primary key  identity,
fk_clientes      int          not null  references CLIENTES,
estado           varchar(40)  not null,
endereco         varchar(40)  not null,
complemento      varchar(100) not null,
numero_endereco  varchar(10)  not null,
cidade           varchar(40)  not null,
bairro           varchar(40)  not null,
cep              varchar(10)  not null
)

go

create table PRODUTOS(
id_produtos     int         not null  primary key  identity,
cod_produto     varchar(40) not null,
situacao        bit         not null,-- 1=Ativo 2=Desativo
check (situacao in ( 1, 2))
)

go

create table COMPRAS(
id_compras     int         not null  primary key  identity,
data_compra    datetime    not null,
quantidade     Varchar(40) not null
)

go

/*
quantidade     = 2 
unidade_medida = 1,5
fisico         = 'balde'
*/

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
situacao          int            not null, -- 1=Leitura do pedido 2=Produzindo 3=Saiu pra entrega 4=Concluido 
valor_total       decimal(10,2)  not null,
data_venda        datetime       not null,
pedido_lido       datetime       not null, --Horario
pedido_produzindo datetime       not null, --Horario
pedido_entregue   datetime       not null, --horario
pedido_concluido  datetime       not null, --Horario
check   (situacao in (1, 2, 3, 4))
)

go


create table PRODUTOS_PEDIDOS(
id_produtos int      not null references PRODUTOS,
id_pedidos  int      not null references PEDIDOS,
quantidade  int      not null,
valor_total decimal(7,2)  not null, 
primary key (id_produtos,id_pedidos)              
)

go


create table TIPO_PRODUTO(
id_tipo_produto   int           not null  primary key  identity,
fk_produto        int           not null  references PRODUTOS,
descricao         varchar(100)  not null,
situacao          bit           not null, -- 1=Ativo 2=Desativo
quantidade        varchar(40)   not null, 
preco             decimal(10,2) not null,
estoque           int           not null,
check (situacao in ( 1, 2))
)

go


