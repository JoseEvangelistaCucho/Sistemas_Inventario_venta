create database SistemaVenta;

go

create table Categorias
(
CategoriaId int primary key identity
descripcion varchar
);

go

create table Productos
(
 CodigoUnico int primary key identity,
 Categoria int ,
 CONSTRAINT FK_Productos_Categorias FOREIGN KEY (Categoria) REFERENCES Categorias(CategoriaId)

);

go

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

        -- Si todo va bien, establecemos el c�digo y el mensaje de �xito
        SET @CodigoSalida = 0; -- 0 indica �xito
        SET @MensajeSalida = 'Producto insertado correctamente.';
    END TRY
    BEGIN CATCH
        -- En caso de error, establecemos el c�digo de error y el mensaje
        SET @CodigoSalida = ERROR_NUMBER(); -- C�digo de error SQL Server
        SET @MensajeSalida = ERROR_MESSAGE(); -- Mensaje de error SQL Server
    END CATCH
END;
