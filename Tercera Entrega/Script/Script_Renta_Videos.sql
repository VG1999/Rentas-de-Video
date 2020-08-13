create database rentas;
use rentas;

/*estructura tabla clientes*/
create table if not exists cliente (
    id_cliente int(6) not null auto_increment,
    id_membresia int(6) not null,
    dpi varchar(16) not null,
    nit varchar(20) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    telefono int(8) not null,
    correo varchar(35) not null,
    estado int(1)not null,
    primary key (id_cliente),
    key (id_cliente)
);

  /*estructura tabla  membresia*/
create table if not exists membresia (
    id_membresia int(6) not null auto_increment,
    descripcion varchar(20) not null,
    puntos int(6) not null,
    descuento int(6) not null,
    estado int(1) not null,
    primary key (id_membresia),
    key (id_membresia)
);

/*Estructura de la tabla video*/
create table if not exists video (
    id_video int(6) not null auto_increment,
    id_categoria int(6) not null,
    titulo varchar(40) not null,
    duracion varchar(20) not null,
    formato varchar(20) not null,
    anio varchar(10) not null,
    precio double(12,2)not null,
    estado int(1) not null,
    primary key (id_video),
    key (id_video)
);

/*Estructura de la tabla Categoria*/
create table if not exists categoria_video (
    id_categoria int(6) not null auto_increment,
    nombre varchar(30) not null,
    estado int(1)not null,
    primary key (id_categoria),
    key (id_categoria)
);
/*Estructura de la tabla EMPLEADO*/
create table if not exists empleado (
    id_empleado int(6) not null auto_increment,
    id_cargo int(6) not null,
    id_usuario int(6) not null,
    dpi varchar(16) not null,
    nit varchar(20) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    correo varchar(45) not null,
    telefono int(8) not null,
    direccion varchar(45) not null,
    estado int(1)not null,
    primary key (id_empleado),
    key (id_empleado)
);

/*Estructura de la tabla CONTROL_USUARIO*/
create table if not exists control_usuario (
    id_usuario int(6) not null auto_increment,
    usuario varchar(20) not null,
    contrasenia varchar(30) not null,
    rol varchar(25) not null,
    estado int(1)not null,
    primary key (id_usuario),
    key (id_usuario)
);
/*Estructura de la tabla CARGO*/
create table if not exists cargo (
    id_cargo int(6) not null auto_increment,
    nombre varchar(20) not null,
    descripcion varchar(25),
    estado int(1)not null,
    primary key (id_cargo),
    key (id_cargo)
);
/*Estructura de la tabla ENCABEZADO_FACTURA*/
create table if not exists encabezado_factura (
    id_encabezado_factura int(6) not null auto_increment,
    id_cliente int(6) not null,
    id_empleado int(6) not null,
    no_serie varchar(10)not null,
    fecha varchar(10)not null,
    forma_pago int(1)not null,
    total_factura double(12,2) not null,
    tipo_doc int(1)not null,
    estado int(1) not null,
    primary key (id_encabezado_factura),
    key (id_encabezado_factura)
);

/*Estructura de la tabla DETALLE_FACTURA */
create table if not exists detalle_factura (
    id_encabezado_factura int(6)not null,
    cod_linea int(6)not null,
    id_video int(6) not null,
    cantidad double(12,2)not null,
    bon_desc int(1),
    subtotal_bon_desc double(4,2),
    subtotal double(12,2) not null,
    estado int(1)not null,
    primary key (cod_linea,id_encabezado_factura)
);


/*Estructura del DEVOLUCION*/
create table if not exists historial_rentas (
    id_historial int(6) not null auto_increment,
    id_encabezado_factura int(6) not null,
    primary key (id_historial),
    key (id_historial)
);

/*Estructura del VIDEO_ESTADO*/
create table if not exists video_estado (
    id_video_estado int(6) not null auto_increment,
    multa_unitaria double(12,2) not null,
    estado int(1) not null,
    primary key (id_video_estado),
    key (id_video_estado)
);
/*Estructura del PROVEEDOR*/
create table if not exists proveedor (
    id_proveedor int(6) not null auto_increment,
    razon_social varchar(100) not null,
    representante_legal varchar(30) not null,
    nit varchar(20)not null,
    telefono int(8) not null,
    correo varchar(40) not null,
    estado int(1)not null,
    primary key (id_proveedor),
    key (id_proveedor)
);
/*tabla 16*/
create table if not exists encabezado_compra (
    id_compra int(6) not null auto_increment,
    id_proveedor int(6) not null,
    fecha_compra int(6) not null,
    total_compra double(12,2)not null,
    estado int(1)not null,
    primary key (id_compra),
    key (id_compra)
);

/*tabla 17*/
create table if not exists detalle_compra (
    id_compra int(6) not null,
    cod_linea int(6)not null,
    id_video int(6) not null,
    cantidad int(6) not null,
    precio_unitario double(12,2) not null,
    subtotal double(12,2)not null,
    estado int(1)not null,
    primary key (id_compra,cod_linea)
);

/**/
create table if not exists control_recibido(
	id_factura_encabezado int(6)not null,
    fecha_emision varchar(10)not null,
    fecha_recibido varchar(10)not null,
    id_video_estado int(6)not null,
    estado int(1)not null,
    primary key (id_factura_encabezado),
    key (id_factura_encabezado)
);
create table bitacora(
	id_bitacora int(6)not null auto_increment,
    id_usuario int(6)not null,
    tabla varchar(25)not null,
    actividad varchar(25)not null,
    fecha varchar(10)not null,
    host_usuario varchar(20)not null,
    primary key(id_bitacora),
    key(id_bitacora)
);

 /*Indices de la tabla clientes*/
alter table cliente add constraint fk_cliente_membresia foreign key(id_membresia) references membresia(id_membresia);
alter table video add constraint fk_categoria_video foreign key(id_categoria) references categoria_video(id_categoria);
alter table empleado add constraint fk_empleado_cargo foreign key(id_cargo) references cargo(id_cargo);
alter table empleado add constraint fk_empleado_usuario foreign key(id_usuario) references control_usuario(id_usuario);
alter table encabezado_factura add constraint fk_encabezado_cliente foreign key(id_cliente) references cliente(id_cliente);
alter table encabezado_factura add constraint fk_encabezado_empleado foreign key(id_empleado) references empleado(id_empleado);
alter table detalle_factura add constraint fk_encabezado_detalle foreign key(id_encabezado_factura) references encabezado_factura(id_encabezado_factura);
alter table detalle_factura add constraint fk_video_detalle foreign key(id_video) references video(id_video);
alter table historial_rentas add constraint fk_factura_rentas foreign key(id_encabezado_factura) references encabezado_factura(id_encabezado_factura);
alter table encabezado_compra add constraint fk_compra_proveedor foreign key(id_proveedor) references proveedor(id_proveedor);
alter table detalle_compra add constraint fk_compra_detalle foreign key(id_compra) references encabezado_compra(id_compra);
alter table detalle_compra add constraint fk_video_compra_detalle foreign key(id_video) references video(id_video);
alter table control_recibido add constraint fk_video_estado_control foreign key(id_video_estado) references video_estado(id_video_estado);
alter table control_recibido add constraint fk_encabezado_control foreign key(id_factura_encabezado) references encabezado_factura(id_encabezado_factura);
alter table bitacora add constraint fk_bitacora_usuario foreign key(id_usuario) references control_usuario(id_usuario);
