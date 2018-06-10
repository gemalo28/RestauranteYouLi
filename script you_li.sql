drop database if exists you_li;
create database you_li;

use you_li;


create table usuarios(

usuarios varchar(30) not null unique,

contraseña varchar(30) not null

);



create table productos(

id_producto int auto_increment primary key,

nombre varchar(50) not null unique,

descripcion varchar(100),

precio float(7,2) not null

);



create table ordenes(

id_orden int auto_increment primary key,

propietario varchar(50) default '0',

fecha timestamp default current_timestamp,

descripcion varchar(100),

total float(7,2) default 0,

flag_pagado bit default 0

);



create table detalle_orden(

id_detalleOrden int auto_increment primary key,

id_orden int not null,

id_producto int not null,

foreign key fk_ondenesInDetalleOrden(id_orden) references ordenes(id_orden),

foreign key fk_ProductosInDetalleOrden(id_producto) references productos(id_producto)

);



create table notas(

id_nota int auto_increment primary key,

propietario varchar(50) default '0',

fecha timestamp default current_timestamp,

descripcion varchar(100),

total float(7,2) not null,

id_orden int not null,

id_factura varchar(30),

foreign key fk_ordenesInNotas(id_orden) references ordenes(id_orden)

);



create table detalle_nota(

id_detalleNota int auto_increment primary key,

id_nota int not null,

id_producto int not null,

foreign key fk_notasInDetalleNota(id_nota) references notas(id_nota),

foreign key fk_productosInDetalleNota(id_producto) references productos(id_producto)

);



create table inventario(

id_ingrediente int auto_increment primary key,

nombre varchar(50) not null unique,

cantidad int not null

);



create table recetas(

id_receta int auto_increment primary key,

nombre varchar(50) not null unique

);



create table detalle_receta(

id_receta int not null,

id_ingrediente int not null,

cantidad int not null,

foreign key fk_recetasInDetalleReceta(id_receta) references recetas(id_receta),

foreign key fk_inventarioInDetalleReceta(id_ingrediente) references inventario(id_ingrediente),

primary key(id_receta,id_ingrediente)

);


