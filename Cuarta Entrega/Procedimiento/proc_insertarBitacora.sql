CREATE PROCEDURE insertar_Bitacora(in id_usuario int(6), in tabla varchar(25), in actividad varchar(25), in fecha datetime, in host_ip varchar(20))
	insert into bitacora (id_usuario, tabla, actividad, fecha, host_ip) values (id_usuario, tabla, actividad, fecha, host_ip);
