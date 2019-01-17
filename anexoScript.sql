Create table clientes
(
id_cliente int auto_increment primary key,
nombre varchar(50) not null unique,
num_telefono varchar(10) default '',
direccion varchar(80) default '',
anexo varchar(50) default '',
id_cliente
)

create table puestos
(
id_puesto int primary key,
puesto varchar(50) not null,
)
create table empleados
(
id_empleado int auto_increment primary key,
nombre varchar(70) not null unique,
direccion varchar(80) default '',
num_telefono varchar(10) default '',
anexo varchar(10) default'',
id_puesto int default 1,
foreign key fk_idPuestoInEmpelados(id_puesto) references puestos(id_puesto)
)

