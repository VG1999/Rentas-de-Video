CREATE DATABASE RENTAS;
USE RENTAS;

/*estructura tabla clientes*/
CREATE TABLE IF NOT EXISTS CLIENTE (
    id_cliente INT(6) NOT NULL AUTO_INCREMENT,
    id_membresia_cliente INT(6) NOT NULL,
    dpi_cliente VARCHAR(16) NOT NULL,
    nit_cliente INT(6) NOT NULL,
    nombre_cliente VARCHAR(30) NOT NULL,
    apellido_cliente VARCHAR(30) NOT NULL,
    telefono_cliente INT(8) NOT NULL,
    correo_cliente VARCHAR(35) NOT NULL,
    estado INT(1)NOT NULL,
    PRIMARY KEY (id_cliente),
    KEY (id_cliente)
)  ENGINE=INNODB DEFAULT CHARSET=LATIN1;

 /*Indices de la tabla `clientes*/
 ALTER TABLE CLIENTE
  ADD CONSTRAINT FK1_CLIENTE FOREIGN KEY (id_membresia_cliente) REFERENCES MEMBRESIA (id_membresia);
  

  /*estructura tabla  membresia*/
CREATE TABLE IF NOT EXISTS MEMBRESIA (
    id_membresia INT(6) NOT NULL AUTO_INCREMENT,
    estado_membresia INT(2) NOT NULL,
    descripcion_membresia VARCHAR(20) NOT NULL,
    puntos_membresia INT(6) NOT NULL,
    descuento_membresia INT(6) NOT NULL,
    PRIMARY KEY (id_membresia),
    KEY (id_membresia)
)  ENGINE=INNODB DEFAULT CHARSET=LATIN1;


/*estructura tabla  DETALLE_RENTA*/
CREATE TABLE IF NOT EXISTS DETALLE_R (
    id_detalle_renta INT(6) NOT NULL,
    id_renta INT(6) NOT NULL,
    id_video INT(6) NOT NULL,
    fecha_entrega DATE NOT NULL,
    cantidad_video INT(6) NOT NULL,
    total_renta DECIMAL(2) NOT NULL,
    PRIMARY KEY (id_detalle_renta),
    KEY (id_detalle_renta)
);

 /*Indices de la tabla detalle_renta*/
 ALTER TABLE DETALLE_R
  ADD CONSTRAINT FK1_detalle_renta FOREIGN KEY (id_renta) REFERENCES RENTA (id_renta);
  ALTER TABLE DETALLE_R
  ADD CONSTRAINT FK2_detalle_renta FOREIGN KEY (id_video) REFERENCES VIDEO (id_video);
  

/*estructura de la tabla Renta*/
CREATE TABLE IF NOT EXISTS RENTA (
    id_renta INT(6) NOT NULL AUTO_INCREMENT,
    id_cliente_renta INT(6) NOT NULL,
    id_empleado INT(6) NOT NULL,
    fecha_renta DATE NOT NULL,
    PRIMARY KEY (id_renta),
    KEY (id_renta)
); 

/*Indices de la tabla Renta*/
 ALTER TABLE RENTA
  ADD CONSTRAINT FK1_RENTA_CLIENTE FOREIGN KEY (id_cliente_renta) REFERENCES CLIENTE (id_cliente);
  
  ALTER TABLE RENTA
  ADD CONSTRAINT FK2_RENTA_EMPLEADO FOREIGN KEY (id_empleado) REFERENCES EMPLEADO (id_empleado);
  
/*Estructura de la tabla video*/
CREATE TABLE IF NOT EXISTS VIDEO (
    id_video INT(6) NOT NULL AUTO_INCREMENT,
    id_categoria_video INT(6) NOT NULL,
    titulo_video VARCHAR(40) NOT NULL,
    duracion_video VARCHAR(4) NOT NULL,
    formato_video VARCHAR(8) NOT NULL,
    estado_video INT(2) NOT NULL,
    anio_video DATE NOT NULL,
    precio DOUBLE,
    PRIMARY KEY (id_video),
    KEY (id_video)
);

/*Indices de la tabla video*/
 ALTER TABLE VIDEO
  ADD CONSTRAINT FK1_CATEGORIA_VIDEO FOREIGN KEY (id_categoria_video) REFERENCES CATEGORIA (id_categoria);

/*Estructura de la tabla Categoria*/
CREATE TABLE IF NOT EXISTS CATEGORIA (
    id_categoria INT(6) NOT NULL AUTO_INCREMENT,
    nombre_categoria VARCHAR(30) NOT NULL,
    estado INT(1)NOT NULL,
    PRIMARY KEY (id_categoria),
    KEY (id_categoria)
);

/*Estructura de la tabla EMPLEADO*/
CREATE TABLE IF NOT EXISTS EMPLEADO (
    id_empleado INT(6) NOT NULL AUTO_INCREMENT,
    id_cargo_empleado INT(6) NOT NULL,
    id_usuario_empleado INT(6) NOT NULL,
    dpi_empleado VARCHAR(16) NOT NULL,
    nit_empleado VARCHAR(10) NOT NULL,
    nombre_empleado VARCHAR(30) NOT NULL,
    apellido_empleado VARCHAR(30) NOT NULL,
    corre_empleado VARCHAR(45) NOT NULL,
    telefono_empleado INT(8) NOT NULL,
    direccion_empleado VARCHAR(45) NOT NULL,
    estado INT(1)NOT NULL,
    PRIMARY KEY (id_empleado),
    KEY (id_empleado)
);

/*Indices de la tabla EMPLEADO*/
 ALTER TABLE EMPLEADO
  ADD CONSTRAINT FK1_CARGO_EMPLEADO FOREIGN KEY (id_cargo_empleado) REFERENCES CARGO (id_cargo);
 ALTER TABLE EMPLEADO
  ADD CONSTRAINT FK2_USUARIO_EMPLEADO FOREIGN KEY (id_usuario_empleado) REFERENCES CONTROL_USUARIO (id_usuario);

/*Estructura de la tabla CONTROL_USUARIO*/
CREATE TABLE IF NOT EXISTS CONTROL_USUARIO (
    id_usuario INT(6) NOT NULL AUTO_INCREMENT,
    usuario VARCHAR(20) NOT NULL,
    contraseña_usuario VARCHAR(30) NOT NULL,
    rol_usuario VARCHAR(25) NOT NULL,
    estado INT(1)NOT NULL,
    PRIMARY KEY (id_usuario),
    KEY (id_usuario)
);

/*Estructura de la tabla CARGO*/
CREATE TABLE IF NOT EXISTS CARGO (
    id_cargo INT(6) NOT NULL AUTO_INCREMENT,
    nombre_cargo VARCHAR(20) NOT NULL,
    descripcion_cargo VARCHAR(25),
    estado INT(1)NOT NULL,
    PRIMARY KEY (id_cargo),
    KEY (id_cargo)
);

/*Estructura de la tabla ENCABEZADO_FACTURA*/
CREATE TABLE IF NOT EXISTS ENCABEZADO_FACTURA (
    id_encabezado_factura INT(6) NOT NULL,
    id_renta INT(6) NOT NULL,
    PRIMARY KEY (id_encabezado_factura),
    KEY (id_encabezado_factura)
);

/*Indices de la tabla ENCABEZADO_FACTURA*/
ALTER TABLE ENCABEZADO_FACTURA
  ADD CONSTRAINT FK1_ENCABEZADO_FACTURA FOREIGN KEY (id_renta) REFERENCES RENTA (id_renta);
  

/*Estructura de la tabla DETALLE_FACTURA */
CREATE TABLE IF NOT EXISTS DETALLE_FACTURA (
    id_detalle_factura INT(6) NOT NULL AUTO_INCREMENT,
    id_encabezado_factura INT(6) NOT NULL,
    tota_factura DOUBLE NOT NULL,
    PRIMARY KEY (id_detalle_factura),
    KEY (id_detalle_factura)
);

/*Indices de la tabla DETALLE_FACTURA*/
ALTER TABLE DETALLE_FACTURA
  ADD CONSTRAINT FK1_DETALLE_FACTURA FOREIGN KEY (id_encabezado_factura) REFERENCES ENCABEZADO_FACTURA (id_encabezado_factura);
  

/*Estructura del VIDEO_PROVEEDOR*/
CREATE TABLE IF NOT EXISTS VIDEO_PROVEEDOR (
    id_video_proveedor INT(6) NOT NULL AUTO_INCREMENT,
    id_devolucion INT(6) NOT NULL,
    id_proveedor INT(6) NOT NULL,
    PRIMARY KEY (id_video_proveedor),
    KEY (id_video_proveedor)
);

/*Indices de la tabla VIDEO_PROVEEDOR*/
ALTER TABLE VIDEO_PROVEEDOR
  ADD CONSTRAINT FK1_VIDEO_PROVEEDOR FOREIGN KEY (id_devolucion) REFERENCES DEVOLUCION (id_devolucion);
  ALTER TABLE VIDEO_PROVEEDOR
  ADD CONSTRAINT FK2_VIDEO_PROVEEDOR FOREIGN KEY (id_proveedor) REFERENCES PROVEEDOR (id_proveedor);
  
  

/*Estructura del DEVOLUCION*/
CREATE TABLE IF NOT EXISTS DEVOLUCION (
    id_devolucion INT(6) NOT NULL AUTO_INCREMENT,
    id_renta INT(6) NOT NULL,
    mora DOUBLE NOT NULL,
    multa DOUBLE NOT NULL,
    PRIMARY KEY (id_devolucion),
    KEY (id_devolucion)
);

/*Indices de la tabla DEVOLUCION*/
ALTER TABLE DEVOLUCION
  ADD CONSTRAINT FK1_DEVOLUCION FOREIGN KEY (id_renta) REFERENCES RENTA (id_renta);
  
/*Estructura del VIDEO_ESTADO*/
CREATE TABLE IF NOT EXISTS VIDEO_ESTADO (
    id_video_estado INT(6) NOT NULL AUTO_INCREMENT,
    id_devolucion INT(6) NOT NULL,
    video_estado INT(2) NOT NULL,
    multa_unitaria DOUBLE NOT NULL,
    PRIMARY KEY (id_video_estado),
    KEY (id_video_estado)
);

/*Indices de la tabla VIDEO_ESTADO*/
ALTER TABLE VIDEO_ESTADO
  ADD CONSTRAINT FK1_VIDEO_ESTADO FOREIGN KEY (id_devolucion) REFERENCES DEVOLUCION (id_devolucion);

/*Estructura del PROVEEDOR*/
CREATE TABLE IF NOT EXISTS PROVEEDOR (
    id_proveedor INT(6) NOT NULL AUTO_INCREMENT,
    razon_social VARCHAR(20) NOT NULL,
    represante_legal VARCHAR(30) NOT NULL,
    nit VARCHAR(20) NOT NULL,
    telefono INT(8) NOT NULL,
    correo VARCHAR(40) NOT NULL,
    estado INT(1)NOT NULL,
    PRIMARY KEY (id_proveedor),
    KEY (id_proveedor)
);

/*tabla 16*/
CREATE TABLE IF NOT EXISTS ENCABEZADO_COMPRA (
    id_compra INT(6) NOT NULL AUTO_INCREMENT,
    id_proveedor INT(6) NOT NULL,
    fecha_compra INT(6) NOT NULL,
    PRIMARY KEY (id_compra),
    KEY (id_compra)
);

/*Indices de la tabla ENCABEZADO_COMPRA*/
ALTER TABLE ENCABEZADO_COMPRA
  ADD CONSTRAINT FK1_ENCABEZADO_COMPRA FOREIGN KEY (id_proveedor) REFERENCES PROVEEDOR (id_proveedor);
  
/*tabla 17*/
CREATE TABLE IF NOT EXISTS DETALLE_COMPRA (
    id_detalle_compra INT(6) NOT NULL AUTO_INCREMENT,
    id_video INT(6) NOT NULL,
    cantidad_compra INT(6) NOT NULL,
    precio_unitario_comptra DOUBLE NOT NULL,
    total_compra DOUBLE NOT NULL,
    PRIMARY KEY (id_detalle_compra),
    KEY (id_detalle_compra)
);

/*Indices de la tabla DETALLE_COMPRA*/
ALTER TABLE DETALLE_COMPRA
  ADD CONSTRAINT FK1_DETALLE_COMPRA FOREIGN KEY (id_video) REFERENCES VIDEO (id_video);
