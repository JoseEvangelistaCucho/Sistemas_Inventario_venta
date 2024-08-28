create database SistemaVenta;

go

create table Categorias
(
CategoriaId int primary key identity,
descripcion varchar
);
INSERT INTO Categorias (
    descripcion
) VALUES (
    'PROD002'
);

go
drop table Productos
create table Productos (
    CodigoUnico varchar(255) primary key,
    idcategoria int,  
    NombreDescripcion varchar(255),
    UnidadDeMedida varchar(100),
    PrecioVenta decimal(10,2),
    PrecioCompra decimal(10,2),
    TipoMoneda varchar(25),
    Cantidad int,
    RutaImagen varchar(120),
    foreign key (idcategoria) references Categorias(CategoriaId) 
);

go


create table Comprobantes
(
comprobanteId int primary key identity,
descripcion varchar(255),
estado int
);
select * from Comprobantes

insert into Comprobantes values('BB01',0);

create table Venta
(
vetaId int primary key identity,
cliente varchar(255),
observaciones varchar(255),
fechaEmision date,
serie varchar(255),
tipoOperacion varchar(255),
dsct decimal,
igv decimal,
comprobanteId int ,
    foreign key (comprobanteId) references Comprobantes(comprobanteId) 
);

select * from Venta

drop table Venta

create table VentaDetalle
(
VentaDetalleId int primary key identity,
vetaId int,
cantidad int,
CodigoUnico varchar(255) ,
    foreign key (CodigoUnico) references Productos(CodigoUnico) 
);





go

select * from Productos
update Productos
set RutaImagen = 'img1.avif',
Cantidad = 2
where CodigoUnico ='PROD003'

INSERT INTO Productos (
    CodigoUnico, 
    idcategoria, 
    NombreDescripcion, 
    UnidadDeMedida, 
    PrecioVenta, 
    PrecioCompra, 
    TipoMoneda, 
    Cantidad, 
    RutaImagen
) VALUES (
    'PROD003', 
    1,  -- Suponiendo que la categoría con CategoriaId 1 es 'Electrónica'
    'Televisor LED 32"', 
    'Unidad', 
    200.99, 
    100.00, 
    'USD', 
    2, 
    '/images/televisor-led-42.jpg'
);



drop procedure ConsultarProducto
CREATE PROCEDURE ConsultarProducto
    @CodigoUnico VARCHAR(255),
    @CodigoSalida INT OUTPUT,
    @MensajeSalida VARCHAR(255) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Intentamos consultar el producto
        IF EXISTS (SELECT 1 FROM Productos WHERE NombreDescripcion like  '%'+@CodigoUnico+'%')
        BEGIN
            SELECT 
                CodigoUnico,
                ca.CategoriaID,
				ca.descripcion as descripcionCategoria,
                NombreDescripcion,
                UnidadDeMedida,
                PrecioVenta,
                PrecioCompra,
                TipoMoneda,
                Cantidad,
                RutaImagen
            FROM 
                Productos pr inner join Categorias ca on pr.idcategoria=ca.CategoriaId 
            WHERE 
                NombreDescripcion like  '%'+@CodigoUnico+'%';

            -- Si la consulta fue exitosa, establecemos el código y el mensaje de éxito
            SET @CodigoSalida = 0; -- 0 indica éxito
            SET @MensajeSalida = 'Consulta realizada correctamente.';
        END
        ELSE
        BEGIN
            -- Si no se encontró el producto, devolvemos un mensaje de error
            SET @CodigoSalida = 1; -- 1 indica que no se encontró el producto
            SET @MensajeSalida = 'Producto no encontrado.';
        END
    END TRY
    BEGIN CATCH
        -- En caso de error, establecemos el código de error y el mensaje
        SET @CodigoSalida = 99; -- Código de error SQL Server
        SET @MensajeSalida = ERROR_MESSAGE(); -- Mensaje de error SQL Server
    END CATCH
END;
GO





CREATE PROCEDURE InsertarProducto
    @categoria NVARCHAR(100),
    @CodigoSalida INT OUTPUT,
    @MensajeSalida VARCHAR(255) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Intentamos insertar el producto
        INSERT INTO Productos (Categoria)
        VALUES (@categoria);

        -- Si todo va bien, establecemos el código y el mensaje de éxito
        SET @CodigoSalida = 0; -- 0 indica éxito
        SET @MensajeSalida = 'Producto insertado correctamente.';
    END TRY
    BEGIN CATCH
        -- En caso de error, establecemos el código de error y el mensaje
        SET @CodigoSalida = ERROR_NUMBER(); -- Código de error SQL Server
        SET @MensajeSalida = ERROR_MESSAGE(); -- Mensaje de error SQL Server
    END CATCH
END;

