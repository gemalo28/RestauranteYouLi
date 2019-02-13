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

flag_pagado int not null default 0,

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


create table bitacora_rec(
  
id_detalle_bit int auto_increment primary key,
  
id_receta int not null,
  
fecha timestamp default current_timestamp
  
);

create table detalle_bitacora(
  
id_detalle_bit int not null,
  
id_ingrediente int not null, 
  
cantidad int not null,
  
foreign key fk_bitacoraInDetalleBitacora(id_detalle_bit) references bitacora_rec(id_detalle_bit),
  
primary key(id_detalle_bit, id_ingrediente)
  
);

create table clientes(
id_cliente int auto_increment primary key,
nombre varchar(50) not null default '',
direccion varchar(100) not null default '',
referencia varchar(100) not null default '',
num_telefono varchar(10) not null default ''
);



Delimiter $$
CREATE PROCEDURE `ActualizarInventario` (IN IdReceta int)
BEGIN
insert into bitacora_rec(id_receta)
values ( IdReceta ); 

insert into detalle_bitacora(id_detalle_bit, id_ingrediente, cantidad)
select last_insert_id(), id_ingrediente, cantidad
from detalle_receta
where id_receta = IdReceta;

update inventario I, (select id_ingrediente, cantidad from detalle_bitacora where id_detalle_bit = last_insert_id()) src
set I.cantidad = (I.cantidad - src.cantidad)
where I.id_ingrediente = src.id_ingrediente;

END
$$

Delimiter $$
CREATE TRIGGER tr_Insert_Detalle 
AFTER INSERT ON you_li.detalle_orden FOR EACH ROW
BEGIN
   update ordenes o, (select sum(p.precio) as Total
						from detalle_orden d
						join productos p on p.id_producto = d.id_producto
						where d.id_orden = new.id_orden) src
   set o.total = src.Total
   where o.id_orden = new.id_orden;
END 
$$

Delimiter $$
CREATE TRIGGER tr_Delete_Detalle 
AFTER DELETE ON you_li.detalle_orden FOR EACH ROW
BEGIN
   update ordenes o, (select coalesce((select sum(p.precio) 
						from detalle_orden d
						join productos p on p.id_producto = d.id_producto
						where d.id_orden = old.id_orden), 0 ) as Total) src
   set o.total = src.Total
   where o.id_orden = old.id_orden;
END 
$$

Delimiter $$
CREATE TRIGGER tr_Update_Detalle 
AFTER UPDATE ON detalle_orden FOR EACH ROW
BEGIN   
   select coalesce((select count(flag_pagado) 
   from detalle_orden
   where id_orden = new.id_orden and flag_pagado = 0),0) into @nopagados;   
   
   if @nopagados = 0 then   
   update ordenes set flag_pagado = 1
   where id_orden = new.id_orden;
   end if;
END 
$$

En realidad no se como empezar esto, no te asustes, solo escucha .
Esto de escribir se me dificulta un poco mucho pero esta vez voy a  hacerlo, lleva sentimiento de por medio lo cual hace que tenga sentido para mi aunque no sea el mejor escrito , cosa que no pretende hacer.
Ya no somos niños Elda y me gustaría decirte algunas cosas, hace días en uno de esos días con un poco de melancolía mis ojos se nublaron un poco, quitando el horizonte de mi vista de a apoco y llenando mi mente de recuerdos llegó a la mente una imagen de una tarde de días después que te conocí, tengo un recuerdo muy claro esa imagen, yo estaba afuera de la casa con mamá había una reunión familiar entonces tu saliste de tu casa caminando detrás de una de tus hermanas, vestías un shorts de mezclilla color azul, una blusa negra y unas sandalias blancas con negro y una cola, una cola de mucho cabello un poco alta con tus cabellos chinos un poco esponjados, ese peinado que sabes que me gusta.. recuerdo que le afirmé a mamá “tsss mamá que bonita está Elda, cuerpazo..” con un cosquilleo en el pecho, mamá volteó y me vio como si tuviese algo raro en la frente y me preguntó “Se te hace?”.. entonces me quedé callado y me dijo  “Si esta bonita, un poco delgada pero se ve que es buena niña”, me dio risa y pensé que estaba equivocado lo que yo había dicho(yo), si mamá no creía lo que yo pues entonces no estoy en la correcto,me afirmé, después entendí que estaba en lo correcto y después de todo el tiempo transcurrido me sigues pareciendo preciosa y para ser sincero cada vez mas. A pesar de lo madura que eres ahora, el montón de cambios que has temimos, que hemos tenido te veo y me es difícil encontrar diferencias entre aquella Elda de 12 años y esta Elda de 24 años que tengo enfrente. Sigues siendo esa niña pequeña y frágil que se mete dentro de su armadura para protegerse ,esa niña que decide tomar el mando para que las cosas se hagan bien, no porque le guste mandar aunque me queda la duda(ups), esa imagen la tengo muy presente y cuando vienen recuerdos sobre ti a la mente no tarda en aparecer.. me parece uno bueno, me hace sonreír.
No se en que tiempo poner la siguiente  frase, pondré 3, eres, fuiste y serás parte importante de mi para toda mi vida, una parte de mi eres tu, una parte de mi es tu y soy lo que soy en parte por ti y no hablo solamente de lo que siento por ti y el echo que te llevo a donde voy, si no, mirame soy tan parecido a ti en algunos aspectos. Aprendí de ti,, aprendí por ti , para ser mejor para ti y hasta aprendimos juntos.. y no quiero sonar a cliché pero quiero decirte gracias, por ser quien eres y estar donde has estado en el tiempo de conocernos, y hablo en todas las etapas.. has sido mi compañera cuando eh necesitado de alguien para llegar a algún lado, has sido mi amiga cuando amistad eh necesitado, has sido mi pilar cuando eh flaqueado, has sido mi guía cuando me eh perdido, has sido lo que eh necesitado en las buenas y en las malas o lo intentaste y esa es la mejor parte y por eso significas lo que significas. casi media vida tengo conociéndote, como lo compartir tanto verdad?, básicamente me formé contigo y tengo tanto bastante que agradecerte. Muchas gracias, cabezona te quiero mucho.. gracias por enseñarme lo sencillo e ingenuo que es el cariño sincero, un abrazo fuerte, un beso en la frente, por otro lado lo complicado y duro que puede ser aveces querer a alguien en las buenas y en las malas, pero también lo gratificante que puede ser un cariño completo e integral, con todo y los altibajos.. gracias por acompañarme en mis momentos difíciles, por demostrarme que el cariño no se mide en cosas materiales como muchas veces llegamos a creer lo hombre por inseguridades y complejos que la sociedad nos enseña desde pequeños, gracias por caminar tantas noches conmigo, por acompañarme con paciencia durante esos ratos de ansioso y de agobio que me suceden en ocasiones :$,  ser mi almohada cuando mas sueño tenía y por cuidar de mi a la sombra en pequeños y grandes detalles que ni siquiera yo me daba cuenta en su momento pero realmente te lo reconozco, son esos pequeños detalles los que se quedaron guardados en mi cora y me ponen a pensar si hice o no todo lo que estuvo en mis manos como correspondencia pero ese es otro asunto. 
Elda, me siento orgulloso de ti, nunca ah sido fácil para ti, nunca has tenido nada a manos llenas, nunca has obtenido las cosas de gratis, sin haber un esfuerzo de por medio , me sorprende aveces la determinación interior que tienes para hacer las cosas, tal es así que tu te convertiste en alguien organizada, limpia y disciplinada en tu vida, tienes esas bases bien establecidas y puedes y estas construyendo algo muy grande, un poco abrumador a la hora de seguirte el paso para alguien tan inseguro como yo, pero me parece fascinante observarte y ver como te desarrollas como afrontas con naturalidad circunstancias que salen de tu zona de confort cosa por cosa, una a la vez y a tu manera, te reconozco.. 
Es día del amor y la amistad, y como ya dije no pretendo conseguir algo con esto mas allá de decirte que por todo lo fuiste y eres te aprecio y te admiro como la persona que eres, independientemente de las circunstancias de nuestra relación, mantengo un cariño por ti que no tengo por nadie ni de lejos.
De nuevo “gracias” por absolutamente todo, te quiero mucho y te amo.

Nunca cambies  expresión al verme cada nuevo día .

