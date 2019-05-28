use Almacen;

delimiter &&
create procedure insertProducto (in nombre varchar(30),in cantidad int(4),in precioCosto decimal(5,2),in precioPublico decimal(5,2),
								in precioMayoreo decimal(5,2),in categoria int(4),in codigoUsuario int(4))
begin
	insert into Producto values(null,nombre,cantidad,precioCosto,precioPublico,precioMayoreo,categoria,codigoUsuario);    
    end &&
delimiter ;

create view ReporteSalidas as
select s.codigo as CodigoSalida,s.CodigoProducto,
(select p.nombre from producto p where p.codigo = s.codigoProducto) as NombreProducto,
s.CantidadProductos, s.RazonSalida,s.Fecha,
(select u.nombre from usuario u where u.codigo=s.codigoUsuario)as Empleado from Salida s;