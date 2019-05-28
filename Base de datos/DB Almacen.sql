create database Almacen;
use Almacen;

-- drop database Almacen;
create table Usuario(
    codigo          int(4)           primary key     not null       auto_increment,
    nombre          varchar(30)     not null,
    apellidoPaterno varchar(30)     not null,
    apellidoMaterno varchar(30)     not null,
    telefono        varchar(10)     not null,
    email           varchar(50),
    contrasenia     varchar(100)     not null,
    usuario         varchar(15)     not null unique,
    nivel           enum('Administrador', 'Empleado') not null
);

insert into Usuario values
(null,'Jesus','Garcia','Paramo','4454505232','chuy@gmail.com',sha1('root'),'chuy',1);
select * from Usuario;

create table Categoria(
    codigo          int(4)      primary key     not null        auto_increment,
    nombre          varchar(40) not null,
    descripcion		text
);

select * from categoria;
create table Producto(
    codigo          int(4)      primary key     not null        auto_increment,
    nombre          varchar(30)     not null,
    cantidad        int(4)          not null,
    precioCosto     decimal(5,2)    not null,
    precioPublico   decimal(5,2),
    precioMayoreo   decimal(5,2),
    categoria       int(4)          not null,    
    constraint foreign key(categoria) references Categoria(codigo)
);

create table Entrada(
    codigo              int(4)      primary key     not null        auto_increment,
    codigoProducto      int(4)      not null,
    cantidadProductos   int(4)      not null,
    precioUnitario		decimal(5,2),
    subtotal			decimal(5,2),
    codigoUsuario       int(4)      not null,  
    fecha           	varchar(10)            not null,
    constraint foreign key(codigoProducto) references Producto(codigo),
    constraint foreign key(codigoUsuario) references Usuario(codigo)
);

create table Salida(
    codigo              int(4)      primary key not null auto_increment,
    codigoProducto      int(4)      not null,
    cantidadProductos   int(4)      not null,
    razonSalida         enum('Salida a tienda','Defecto','Cambios') not null,
    fecha               varchar(10)        not null,
    codigoUsuario       int(4)      not null,
    constraint foreign key(codigoProducto) references Producto(codigo),
    constraint foreign key(codigoUsuario) references Usuario(codigo)
);

create table inventario
(
codigo int(4) primary key auto_increment,
codigoPro int(4) not null,
cantidad int not null,
inconsistencias int not null,
codigoEmp int(4) not null,
fecha varchar(10) not null,
constraint foreign key(codigoPro) references producto(codigo),
constraint foreign key(codigoEmp) references usuario(codigo)
);

create view ReporteInventario as
select i.codigoPro as CodigoProducto,
(select p.nombre from producto p where p.codigo=i.codigoPro) as Producto,
 i.Cantidad, i.Inconsistencias,
(
select concat(u.nombre," ",u.apellidoPaterno," ",u.apellidoMaterno) from usuario u where u.codigo=i.codigoEmp
)as Usuario,i.Fecha from inventario i;

select * from ReporteInventario;

 delimiter &&
 create procedure insertEntrada(in codigoP int, in cantidadPro int,in precioUni decimal,in subtotal decimal,in codigoUsu int,in fecha varchar(10))
begin 
	insert into entrada values(null,codigoP,cantidadPro,precioUni,subtotal,codigoUsu,fecha);
	update producto set cantidad=cantidad+cantidadPro where codigo=codigoP;
	
end &&
delimiter &&;

 delimiter &&
 create procedure insertSalida(in codigoP int, in cantidadPro int,in razonSalida text,in fecha varchar(10),in codigoUsu int)
begin 
	insert into salida values(null,codigoP,cantidadPro,razonSalida,fecha,codigoUsu);
	update producto set cantidad=cantidad-cantidadPro where codigo=codigoP;
	
end &&
delimiter &&;

create view ReporteEntrada as
select e.codigo as CodigoEntrada, e.codigoProducto as CodigoProducto,
(select p.nombre from producto p where p.codigo = e.codigoProducto) as NombreProducto,
e.cantidadProductos,e.precioUnitario,e.subtotal,e.fecha,
(select u.nombre from usuario u where u.codigo=e.codigoUsuario)as Empleado from entrada e;