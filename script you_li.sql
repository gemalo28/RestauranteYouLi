
create table usuarios(
usuarios varchar(30) not null unique,
contraseña varchar(30) not null
);

create table productos(
id_producto int indentity(1,1) primary key,
nombre varchar(50) not null unique,
descripcion varchar(100),
precio float(7,2) not null
);

create table ordenes(
id_orden int indentity(1,1) primary key,
propietario varchar(50) default '0',
fecha timestamp,
descripcion varchar(100),
total float(7,2) not null,
flag_pagado bit default 0
)

create table detalle_orden(
id_detalleOrden int identity(1,1) primary key,
id_orden int not null,
id_producto int not null,
foreign key id_orden references ordenes(id_orden),
foreign key id_producto references productos(id_producto)
)

create table notas(
id_nota int identity(1,1) primary key,
propietario varchar(50) default '0',
fecha timestamp,
descripcion varchar(100),
total float(7,2) not null,
id_orden int not null,
id_factura varchar(30),
foreign key id_orden references ordenes(id_orden)
);

create table detalle_nota(
id_detalleNota int identity primary key,
id_nota int not null,
id_producto int not null,
foreign key id_nota references notas(id_nota),
foreign key id_producto references productos(id_producto)
);

create table inventario(
id_ingrediente int indentity(1,1) primary key,
nombre varchar(50) not null unique,
cantidad int not null
);

create table recetas(
id_receta int identity(1,1) primary key,
nombre varchar(50) not null unique
);

create table detalle_receta(
id_receta int not null,
id_ingrediente int not null,
cantida int not null,
foreign key(id_receta) references recetas(id_receta),
foreign key(id_ingrediente) references productos(id_ingrediente),
primary key(id_receta,id_ingrediente)
);



