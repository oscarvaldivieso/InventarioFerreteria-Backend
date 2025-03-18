USE dbFerreteria
GO

--OSCAR--
--PROCEDIMIENTOS ALMACENADOS USUARIO


CREATE OR ALTER PROCEDURE Acce.SP_Usuario_Insertar
		@Usua_Nombre			VARCHAR(50),
		@Usua_Clave			VARCHAR(MAX),
		@Empl_Id				INT,
		@Role_Id				INT,
		@Usua_EsAdmin		BIT,
		@Usua_Creacion		INT,
		@Feca_Creacion		DATETIME
AS
BEGIN
	INSERT INTO Acce.tbUsuarios
	(
		Usua_Nombre,
		Usua_Clave,
		Empl_Id,
		Role_Id,
		Usua_EsAdmin,
		Usua_Creacion,
		Feca_Creacion
	)
	VALUES
	(
		@Usua_Nombre,
		CONVERT(VARCHAR(MAX), HASHBYTES('SHA2_512', @Usua_Clave), 2),
		@Empl_Id,
		@Role_Id,	
		@Usua_EsAdmin,
		@Usua_Creacion,
		@Feca_Creacion
	)
END
GO

CREATE OR ALTER PROCEDURE Acce.SP_Usuario_Actualizar
		@Usua_Id				INT,
		@Usua_Nombre			VARCHAR(50),
		@Empl_Id				INT,
		@Role_Id				INT,
		@Usua_EsAdmin		BIT,
		@Usua_Modificacion	INT,
		@Feca_Modificacion	DATETIME
AS
BEGIN
		UPDATE Acce.tbUsuarios
		SET	Usua_Nombre = @Usua_Nombre,
			Empl_Id = @Empl_Id,
			Role_Id = @Role_Id,
			Usua_EsAdmin =  @Usua_EsAdmin,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Usua_Id = @Usua_Id
END
GO

CREATE OR ALTER PROCEDURE Acce.SP_Usuario_Eliminar
		@Usua_Id			INT
AS
BEGIN
		UPDATE Acce.tbUsuarios
		SET	Usua_Estado = 0
		WHERE Usua_Id = @Usua_Id
END
GO


--PROCEDIMIENTOS ALMACENADOS ROLES
CREATE OR ALTER PROCEDURE Acce.SP_Rol_Insertar
	@Role_Descripcion		VARCHAR(100),
	@Usua_Creacion			INT,
	@Feca_Creacion			DATETIME
AS
BEGIN
	INSERT INTO Acce.tbRoles (Role_Descripcion,	 Usua_Creacion, Feca_Creacion)
	VALUES (@Role_Descripcion,	@Usua_Creacion,@Feca_Creacion)
END
GO


CREATE OR ALTER PROCEDURE Acce.SP_Rol_Actualizar
	@Role_Id					INT,
	@Role_Descripcion		VARCHAR (100),
	@Usua_Modificacion		INT,
	@Feca_Modificacion		DATETIME
AS
BEGIN
	UPDATE Acce.tbRoles
	SET Role_Descripcion = @Role_Descripcion,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Role_Id = @Role_Id
END

GO

CREATE OR ALTER PROCEDURE Acce.SP_Rol_Eliminar
	@Role_Id INT	
AS
BEGIN
	DECLARE @conteoRol INT = (SELECT COUNT(*) FROM Acce.tbUsuarios WHERE Role_Id = @Role_Id 
	AND Usua_Estado = 1)

	IF @conteoRol = 0 
	BEGIN
		UPDATE Acce.tbRoles
		SET Role_Estado = 0
		WHERE Role_Id = @Role_Id
	END
	ELSE
	BEGIN
		SELECT 'No se puede eliminar el rol, esta siendo utilizado por Usuarios' 
	END
END
GO


--PROCEDIMIENTOS ALMACENADOS PANTALLAS

CREATE OR ALTER PROCEDURE Acce.SP_Pantalla_Insertar
    @Pant_Descripcion		VARCHAR(100),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME
AS
BEGIN
    INSERT INTO Acce.tbPantallas
    (
        Pant_Descripcion,
        Usua_Creacion,
        Feca_Creacion
    )
    VALUES
    (
        @Pant_Descripcion,
        @Usua_Creacion,
        @Feca_Creacion
    )
END
GO

CREATE OR ALTER PROCEDURE Acce.SP_Pantalla_Actualizar
    @Pant_Id					INT,
    @Pant_Descripcion		VARCHAR(100),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Acce.tbPantallas
    SET
        Pant_Descripcion = @Pant_Descripcion,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE Pant_Id = @Pant_Id
END
GO

CREATE OR ALTER PROCEDURE Acce.SP_Pantalla_Eliminar
    @Pant_Id					INT
AS
BEGIN
	DELETE FROM Acce.tbPantallas WHERE Pant_Id = @Pant_Id
END
GO



--PROCEDIMIENTOS ALMACENADOS ROLES POR PANTALLAS



CREATE OR ALTER PROCEDURE Acce.SP_PantallaPorRol_Insertar
    @Role_Id					INT,
    @Pant_Id					INT,
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME
AS
BEGIN
    INSERT INTO Acce.tbPantallasPorRol
    (
        Role_Id,
        Pant_Id,
        Usua_Creacion,
        Feca_Creacion
    )
    VALUES
    (
        @Role_Id,
        @Pant_Id,
        @Usua_Creacion,
        @Feca_Creacion
    )
END
GO

CREATE OR ALTER PROCEDURE Acce.SP_PantallaPorRol_Actualizar
    @RoPa_Id					INT,
    @Role_Id					INT,
    @Pant_Id					INT,
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Acce.tbPantallasPorRol
    SET
        Role_Id = @Role_Id,
        Pant_Id = @Pant_Id,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE RoPa_Id = @RoPa_Id
END
GO

CREATE OR ALTER PROCEDURE Acce.SP_PantallaPorRol_Eliminar
    @RoPa_Id					INT
AS
BEGIN
    UPDATE Acce.tbPantallasPorRol
    SET RoPa_Estado = 0
    WHERE RoPa_Id = @RoPa_Id
END
GO



--PROCEDIMIENTOS ALMACENADOS DEPARTAMENTOS

CREATE OR ALTER PROCEDURE Gral.SP_Departamento_Insertar
    @Depa_Codigo				VARCHAR(2),
    @Depa_Descripcion		VARCHAR(50),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME
AS
BEGIN
    INSERT INTO Gral.tbDepartamentos
    (
        Depa_Codigo,
        Depa_Descripcion,
        Usua_Creacion,
        Feca_Creacion
    )
    VALUES
    (
        @Depa_Codigo,
        @Depa_Descripcion,
        @Usua_Creacion,
        @Feca_Creacion
    )
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_Departamento_Actualizar
    @Depa_Codigo				VARCHAR(2),
    @Depa_Descripcion		VARCHAR(50),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Gral.tbDepartamentos
    SET
        Depa_Descripcion = @Depa_Descripcion,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE Depa_Codigo = @Depa_Codigo
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_Departamento_Eliminar
    @Depa_Codigo				VARCHAR(2)
AS
BEGIN
	DECLARE @depaConteo INT = (SELECT COUNT(*) FROM Gral.tbMunicipios WHERE Depa_Codigo = @Depa_Codigo)
	
	IF @depaConteo = 0
	BEGIN
	    DELETE FROM Gral.tbDepartamentos
		WHERE Depa_Codigo = @Depa_Codigo
	END
	ELSE
	BEGIN
		SELECT 'No se puede eliminar el departamento porque esta siendo utilizado en Municipios'
	END
END
GO



--PROCEDIMIENTOS ALMACENADOS MUNICIPIOS


CREATE OR ALTER PROCEDURE Gral.SP_Municipio_Insertar
    @Muni_Codigo				VARCHAR(4),
    @Muni_Descripcion		VARCHAR(50),
    @Depa_Codigo				VARCHAR(2),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME
AS
BEGIN
    INSERT INTO Gral.tbMunicipios
    (
        Muni_Codigo,
        Muni_Descripcion,
        Depa_Codigo,
        Usua_Creacion,
        Feca_Creacion
    )
    VALUES
    (
        @Muni_Codigo,
        @Muni_Descripcion,
        @Depa_Codigo,
        @Usua_Creacion,
        @Feca_Creacion
    )
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_Municipio_Actualizar
    @Muni_Codigo				VARCHAR(4),
    @Muni_Descripcion		VARCHAR(50),
    @Depa_Codigo				VARCHAR(2),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Gral.tbMunicipios
    SET
        Muni_Descripcion = @Muni_Descripcion,
        Depa_Codigo = @Depa_Codigo,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE Muni_Codigo = @Muni_Codigo
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_Municipio_Eliminar
    @Muni_Codigo				VARCHAR(4)
AS
BEGIN
	
	DECLARE @conteoMunicipios INT = (SELECT COUNT(*) FROM Gral.tbMunicipios WHERE @Muni_Codigo NOT IN (SELECT Muni_Codigo FROM Ferr.tbSucursales) AND @Muni_Codigo NOT IN (SELECT Muni_Codigo FROM Comp.tbProveedores) AND @Muni_Codigo NOT IN (SELECT Muni_Codigo FROM Gral.tbClientes) AND @Muni_Codigo NOT IN (SELECT Muni_Codigo FROM Ferr.tbEmpleados) AND Muni_Codigo  = @Muni_Codigo)
	IF @conteoMunicipios = 0 
	BEGIN
		DELETE FROM Gral.tbMunicipios
		WHERE Muni_Codigo = @Muni_Codigo
	END
	ELSE
	BEGIN 
		SELECT 'No se puede eliminar el municipio porque esta siendo usado en Clientes, Sucursales, Proveedor y Empleados'
	END
END
GO



--PROCEDIMIENTOS ALMACENADOS ESTADOS CIVILES


CREATE OR ALTER PROCEDURE Gral.SP_EstadoCivil_Insertar
    @EsCv_Descripcion		VARCHAR(100),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME
AS
BEGIN
    INSERT INTO Gral.tbEstadosCiviles
    (
        EsCv_Descripcion,
        Usua_Creacion,
        Feca_Creacion
    )
    VALUES
    (
        @EsCv_Descripcion,
        @Usua_Creacion,
        @Feca_Creacion
    )
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_EstadoCivil_Actualizar
    @EsCv_Id					INT,
    @EsCv_Descripcion		VARCHAR(100),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Gral.tbEstadosCiviles
    SET EsCv_Descripcion = @EsCv_Descripcion,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE EsCv_Id = @EsCv_Id
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_EstadoCivil_Eliminar
    @EsCv_Id					INT	
AS
BEGIN
	DECLARE @conteoEstadoCivil INT = (SELECT COUNT(*) FROM Gral.tbEstadosCiviles WHERE @EsCv_Id NOT IN (SELECT EsCv_Id FROM Gral.tbClientes) AND @EsCv_Id NOT IN (SELECT EsCv_Id FROM Ferr.tbEmpleados) AND @EsCv_Id  = EsCv_Id)
	IF @conteoEstadoCivil = 0 
	BEGIN
		DELETE FROM Gral.tbEstadosCiviles
		WHERE EsCv_Id = @EsCv_Id
	END
	ELSE
	BEGIN 
		SELECT 'No se puede eliminar el estado civil porque esta siendo usado en Clientes y Empleados'
	END
END
GO

--PROCEDIMIENTOS ALMACENADOS CLIENTES


CREATE OR ALTER PROCEDURE Gral.SP_Cliente_Insertar
    @Clie_DNI				VARCHAR(15),
	@Clie_Nombre				VARCHAR(100),
	@Clie_Apellido			VARCHAR(100),
	@Clie_Sexo				CHAR(1),
	@EsCv_Id					INT,
	@Muni_Codigo				VARCHAR(4), 
	@Clie_Direccion			VARCHAR(200),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME,
	@Usua_Modificacion		INT,
	@Feca_Modificacion		DATETIME
AS
BEGIN
	DECLARE @Clie INT = (SELECT COUNT(*) FROM Gral.tbClientes WHERE Clie_DNI = @Clie_DNI)

	IF @Clie = 0
	BEGIN
		INSERT INTO Gral.tbClientes 
		(
			Clie_DNI,
			Clie_Nombre,
			Clie_Apellido,
			Clie_Sexo,
			EsCv_Id,
			Muni_Codigo,
			Clie_Direccion,
	        Usua_Creacion,
		    Feca_Creacion
	    )
		VALUES
	    (
		    @Clie_DNI,
			@Clie_Nombre,
			@Clie_Apellido,
			@Clie_Sexo,
			@EsCv_Id,
			@Muni_Codigo,
			@Clie_Direccion,
			@Usua_Creacion,
	        @Feca_Creacion
		)
	END
	ELSE
	BEGIN
		UPDATE Gral.tbClientes
		SET Clie_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Clie_DNI = @Clie_DNI
	END
END
GO

CREATE OR ALTER PROCEDURE Gral.SP_Cliente_Actualizar
    @Clie_Id					INT,
    @Clie_DNI				VARCHAR(15),
	@Clie_Nombre				VARCHAR(100),
	@Clie_Apellido			VARCHAR(100),
	@Clie_Sexo				CHAR(1),
	@EsCv_Id					INT,
	@Muni_Codigo				VARCHAR(4), 
	@Clie_Direccion			VARCHAR(200),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Gral.tbClientes
    SET
        Clie_DNI = @Clie_DNI,
		Clie_Nombre = @Clie_Nombre,
		Clie_Apellido = @Clie_Apellido,
		Clie_Sexo = @Clie_Sexo,
		EsCv_Id = @EsCv_Id,
		Muni_Codigo = @Muni_Codigo,
		Clie_Direccion = @Clie_Direccion,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE Clie_Id = @Clie_Id
END
GO


CREATE OR ALTER PROCEDURE Gral.SP_Cliente_Eliminar
    @Clie_Id					INT
AS
BEGIN
	DECLARE @conteoClientes INT = (SELECT COUNT(*) FROM Vent.tbVentas WHERE Clie_Id = @Clie_Id
	AND Vent_Estado = 1)
	IF @conteoClientes = 0
	BEGIN
		UPDATE Gral.tbClientes
		SET Clie_Estado = 0
		WHERE Clie_Id = @Clie_Id
	END
	ELSE
	BEGIN 
		SELECT 'No se puede eliminar el cliente, esta siendo utilizado por Ventas'
	END
    
END
GO

--PROCEDIMIENTOS ALMACENADOS SUCURSALES


CREATE OR ALTER PROCEDURE Ferr.SP_Sucursal_Insertar
    @Sucu_Nombre				VARCHAR(50),
	@Muni_Codigo				VARCHAR(4),
	@Sucu_DireccionExacta	VARCHAR(50),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME,
	@Usua_Modificacion		INT,
	@Feca_Modificacion		DATETIME
AS
BEGIN
	DECLARE @Sucu INT = (SELECT COUNT(*) FROM Ferr.tbSucursales WHERE Sucu_Nombre = @Sucu_Nombre)

	IF @Sucu = 0
	BEGIN
	    INSERT INTO Ferr.tbSucursales
		(
			Sucu_Nombre,
			Muni_Codigo,
			Sucu_DireccionExacta,
			Usua_Creacion,
	        Feca_Creacion
		)
		VALUES
	    (
		    @Sucu_Nombre,
			@Muni_Codigo,
			@Sucu_DireccionExacta,
			@Usua_Creacion,
		    @Feca_Creacion
	    )
	END
	ELSE
	BEGIN
		UPDATE Ferr.tbSucursales
		SET Sucu_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Sucu_Nombre = @Sucu_Nombre
	END
END
GO

CREATE OR ALTER PROCEDURE Ferr.SP_Sucursal_Actualizar
    @Sucu_Id					INT,
	@Sucu_Nombre				VARCHAR(50),
	@Muni_Codigo				VARCHAR(4),
	@Sucu_DireccionExacta	VARCHAR(50),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Ferr.tbSucursales
    SET Sucu_Nombre = @Sucu_Nombre,
		Muni_Codigo = @Muni_Codigo,
		Sucu_DireccionExacta = @Sucu_DireccionExacta,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE Sucu_Id = @Sucu_Id
END
GO


CREATE OR ALTER PROCEDURE Ferr.SP_Sucursal_Eliminar
    @Sucu_Id					INT
AS
BEGIN
    UPDATE Ferr.tbSucursales
    SET
        Sucu_Estado = 0
    WHERE Sucu_Id = @Sucu_Id
END
GO



--PROCEDIMIENTOS ALMACENADOS CARGOS


CREATE OR ALTER PROCEDURE Ferr.SP_Cargo_Insertar
    @Carg_Descripcion		VARCHAR(20),
    @Usua_Creacion			INT,
    @Feca_Creacion			DATETIME,
	@Usua_Modificacion		INT,
	@Feca_Modificacion		DATETIME
AS
BEGIN
	DECLARE @Cargo INT = (SELECT COUNT(*) FROM Ferr.tbCargos WHERE Carg_Descripcion = @Carg_Descripcion)

	IF @Cargo = 0
	BEGIN
		INSERT INTO Ferr.tbCargos(Carg_Descripcion,Usua_Creacion,Feca_Creacion, Carg_Estado)
		VALUES (@Carg_Descripcion,@Usua_Creacion,@Feca_Creacion, 1)
	END
	ELSE
	BEGIN
		UPDATE Ferr.tbCargos
		SET Carg_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Carg_Descripcion = @Carg_Descripcion
	END
END
GO

CREATE OR ALTER PROCEDURE Ferr.SP_Cargo_Actualizar
    @Carg_Id					INT,
    @Carg_Descripcion		VARCHAR(100),
    @Usua_Modificacion		INT,
    @Feca_Modificacion		DATETIME
AS
BEGIN
    UPDATE Ferr.tbCargos
    SET Carg_Descripcion = @Carg_Descripcion,
        Usua_Modificacion = @Usua_Modificacion,
        Feca_Modificacion = @Feca_Modificacion
    WHERE Carg_Id = @Carg_Id
END
GO


CREATE OR ALTER PROCEDURE Ferr.SP_Cargo_Eliminar
    @Carg_Id					INT
AS
BEGIN
	DECLARE @conteocargo INT = (SELECT COUNT(*) FROM Ferr.tbEmpleados
	WHERE Carg_Id = @Carg_Id AND Empl_Estado = 1)

	IF @conteoCargo = 0
	BEGIN 
		UPDATE Ferr.tbCargos
		SET Carg_Estado = 0
		WHERE Carg_Id = @Carg_Id
	END
	ELSE
	BEGIN
		SELECT 'No se puede eliminar el cargo, esta siendo utilizado por empleados'
	END
END
GO

--ANGEL--
--TABLA 11--
--EMPLEADOS--
CREATE OR ALTER PROCEDURE Ferr.SP_Empleado_Insertar
	@Empl_DNI					NVARCHAR(15),
	@Empl_Nombre					NVARCHAR(100),
	@Empl_Apellido				NVARCHAR(100),
	@Empl_Sexo					CHAR(1),
	@EsCv_Id						INT,
	@Carg_Id						INT,
	@Muni_Codigo					VARCHAR(4),
	@Empl_Direccion				NVARCHAR(200),
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	DECLARE @Empl INT = (SELECT COUNT(*) FROM Ferr.tbEmpleados WHERE Empl_DNI = @Empl_DNI)

	IF @Empl = 0
	BEGIN
		INSERT INTO Ferr.tbEmpleados (Empl_DNI, Empl_Nombre, Empl_Apellido, Empl_Sexo, EsCv_Id, Carg_Id, Muni_Codigo, Empl_Direccion, Usua_Creacion, Feca_Creacion)
		VALUES (@Empl_DNI,@Empl_Nombre,@Empl_Apellido,@Empl_Sexo,@EsCv_Id,@Carg_Id	,@Muni_Codigo,@Empl_Direccion,@Usua_Creacion,@Feca_Creacion)
	END
	ELSE
	BEGIN
		UPDATE Ferr.tbEmpleados
		SET Empl_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Empl_DNI = @Empl_DNI
	END
END
GO

CREATE OR ALTER PROCEDURE Ferr.SP_Empleado_Actualizar
	@Empl_Id					INT,
	@Empl_DNI					NVARCHAR(15),
	@Empl_Nombre				NVARCHAR(100),
	@Empl_Apellido				NVARCHAR(100),
	@Empl_Sexo					CHAR(1),
	@EsCv_Id					INT,
	@Carg_Id					INT,
	@Muni_Codigo				VARCHAR(4),
	@Empl_Direccion				NVARCHAR(200),
	@Usua_Modificacion			INT,
	@Feca_Modificacion				DATETIME
AS
BEGIN
	UPDATE Ferr.tbEmpleados
	SET Empl_DNI = @Empl_DNI,
		Empl_Nombre = @Empl_Nombre,
		Empl_Apellido = @Empl_Apellido,
		Empl_Sexo = @Empl_Sexo,
		EsCv_Id	= @EsCv_Id,
		Carg_Id = @Carg_Id,
		Muni_Codigo	 = @Muni_Codigo,
		Empl_Direccion = @Empl_Direccion,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Empl_Id = @Empl_Id
END
GO

CREATE OR ALTER PROCEDURE Ferr.SP_Empleado_Eliminar
	@Empl_Id					INT
AS
BEGIN
	DECLARE @conteoEmpleado INT = (SELECT COUNT(*) FROM Acce.tbUsuarios WHERE Empl_Id = @Empl_Id AND Usua_Estado = 1)
	IF @conteoEmpleado = 0
	BEGIN 
		UPDATE Ferr.tbEmpleados
		SET Empl_Estado = 0
		WHERE Empl_Id = @Empl_Id
	END
	ELSE 
	BEGIN 
		SELECT 'No se puede eliminar el empleado porque esta siendo utilizado en Usuarios'
	END
	
END
GO

--TABLA 12--
--MARCAS--
CREATE OR ALTER PROCEDURE Prod.SP_Marca_Insertar
	@Marc_Descripcion			NVARCHAR(50),
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN

	DECLARE @Marc INT = (SELECT COUNT(*) FROM Prod.tbMarcas WHERE Marc_Descripcion = @Marc_Descripcion)

	IF @Marc = 0 
	BEGIN
		INSERT INTO Prod.tbMarcas (Marc_Descripcion, Usua_Creacion, Feca_Creacion)
		VALUES (@Marc_Descripcion, @Usua_Creacion, @Feca_Creacion)
	END
	ELSE
	BEGIN
		UPDATE Prod.tbMarcas
		SET Marc_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Marc_Descripcion = @Marc_Descripcion
	END
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Marca_Actualizar
	@Marc_Id					INT,
	@Marc_Descripcion			NVARCHAR(50),
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	UPDATE Prod.tbMarcas
	SET Marc_Descripcion = @Marc_Descripcion,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Marc_Id = @Marc_Id
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Marca_Eliminar
	@Marc_Id					INT
AS
BEGIN
	DECLARE @conteoMarca INT = (SELECT COUNT(*) FROM Prod.tbProductos WHERE Marc_Id = @Marc_Id AND Prod_Estado = 1)
	IF @conteoMarca = 0
	BEGIN 
		UPDATE Prod.tbMarcas
		SET Marc_Estado = 0
		WHERE Marc_Id = @Marc_Id
	END
	ELSE
	BEGIN 
		SELECT 'No se puede eliminar la marca porque esta siendo utilizada por Productos'
	END
END
GO

--TABLA 13--
--CATEGORIAS--
CREATE OR ALTER PROCEDURE Prod.SP_Categoria_Insertar
	@Cate_Descripcion			NVARCHAR(50),
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	DECLARE @Cate INT = (SELECT COUNT(*) FROM Prod.tbCategorias WHERE Cate_Descripcion = @Cate_Descripcion)

	IF @Cate = 0
	BEGIN
		INSERT INTO Prod.tbCategorias (Cate_Descripcion, Usua_Creacion, Feca_Creacion)
		VALUES (@Cate_Descripcion, @Usua_Creacion, @Feca_Creacion)
	END
	ELSE
	BEGIN
		UPDATE Prod.tbCategorias
		SET Cate_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Cate_Descripcion = @Cate_Descripcion
	END
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Categoria_Actualizar
	@Cate_Id					INT,
	@Cate_Descripcion			NVARCHAR(50),
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	UPDATE Prod.tbCategorias
	SET 	Cate_Descripcion = @Cate_Descripcion,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Cate_Id = @Cate_Id
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Categoria_Eliminar
	@Cate_Id					INT
AS
BEGIN
	DECLARE @conteoCategoria INT = (SELECT COUNT(*) FROM Prod.tbProductos WHERE Cate_Id = @Cate_Id AND Prod_Estado = 1)
	IF @conteoCategoria = 0
	BEGIN
		UPDATE Prod.tbCategorias
		SET Cate_Estado = 0
		WHERE Cate_Id = @Cate_Id
	END
	ELSE
	BEGIN
		SELECT 'No se puede eliminar la categoria porque esta siendo utilizada en productos'
	END
END
GO

--TABLA 14--
--PROVEEDORES--
CREATE OR ALTER PROCEDURE Comp.SP_Proveedor_Insertar
	@Prov_Nombre				NVARCHAR(50),
	@Prov_Contacto				NVARCHAR(30),
	@Muni_Codigo				VARCHAR(4),
	@Prov_DireccionExacta		NVARCHAR(200),
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	DECLARE @Prov INT = (SELECT COUNT(*) FROM Comp.tbProveedores WHERE Prov_Nombre = @Prov_Nombre)

	IF @Prov = 0
	BEGIN
		INSERT INTO Comp.tbProveedores (Prov_Nombre	, Prov_Contacto, Muni_Codigo	, Prov_DireccionExacta, Usua_Creacion, Feca_Creacion)
		VALUES (@Prov_Nombre	,@Prov_Contacto,@Muni_Codigo	,@Prov_DireccionExacta,@Usua_Creacion,@Feca_Creacion)
	END
	ELSE
	BEGIN
		UPDATE Comp.tbProveedores
		SET Prov_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Prov_Nombre = @Prov_Nombre
	END
END
GO

CREATE OR ALTER PROCEDURE Comp.SP_Proveedor_Actualizar
	@Prov_Id					INT,
	@Prov_Nombre				NVARCHAR(50),
	@Prov_Contacto				NVARCHAR(30),
	@Muni_Codigo				VARCHAR(4),
	@Prov_DireccionExacta		NVARCHAR(200),
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	UPDATE Comp.tbProveedores
	SET Prov_Nombre = @Prov_Nombre,
		Prov_Contacto = @Prov_Contacto,
		Muni_Codigo	= @Muni_Codigo,
		Prov_DireccionExacta = @Prov_DireccionExacta,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Prov_Id = @Prov_Id
END
GO

CREATE OR ALTER PROCEDURE Comp.SP_Proveedor_Eliminar
	@Prov_Id					INT
AS
BEGIN
	DECLARE @conteoProveedor INT = (SELECT COUNT(*) FROM Comp.tbProveedores WHERE @Prov_Id NOT IN (SELECT Prov_Id FROM Prod.tbProductos) AND @Prov_Id NOT IN (SELECT Prov_Id FROM Comp.tbCompras) AND Prov_Id = @Prov_Id)
	IF @conteoProveedor = 0
	BEGIN 

		UPDATE Comp.tbProveedores
		SET Prov_Estado = 0 
		WHERE Prov_Id = @Prov_Id
	END
	ELSE 
	BEGIN 
		SELECT 'No se puede eliminar el proveedor porque esta siendo utilizado en Productos y Compras'
	END
END
GO

--TABLA 15--
--PRODUCTOS--
CREATE OR ALTER PROCEDURE Prod.SP_Producto_Insertar
	@Prod_Descripcion			NVARCHAR(50),
	@Marc_Id						INT,
	@Cate_Id						INT,
	@Prov_Id						INT,
	@Prod_Modelo					NVARCHAR(50),
	@Prod_Cantidad				INT,
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME,
	@Prod_URLImg					VARCHAR(MAX)
AS
BEGIN
	DECLARE @Prod INT = (SELECT COUNT(*) FROM Prod.tbProductos WHERE Prod_Descripcion = @Prod_Descripcion) 

	IF @Prod = 1
	BEGIN
		INSERT INTO Prod.tbProductos (Prod_Descripcion, Marc_Id, Cate_Id, Prov_Id, Prod_Modelo, Prod_Cantidad, Usua_Creacion, Feca_Creacion, Prod_URLImg)
		VALUES (@Prod_Descripcion, @Marc_Id, @Cate_Id, @Prov_Id, @Prod_Modelo, @Prod_Cantidad, @Usua_Creacion, @Feca_Creacion, @Prod_URLImg)
	END
	ELSE
	BEGIN
		UPDATE Prod.tbProductos
		SET Prod_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Prod_Descripcion = @Prod_Descripcion
	END
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Producto_Actualizar
	@Prod_Id					INT,
	@Prod_Descripcion			NVARCHAR(50),
	@Marc_Id					INT,
	@Cate_Id					INT,
	@Prov_Id					INT,
	@Prod_Modelo				NVARCHAR(50),
	@Prod_Cantidad				INT,
	@Prod_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	UPDATE Prod.tbProductos
	SET Prod_Descripcion = @Prod_Descripcion,
		Marc_Id	 = @Marc_Id,
		Cate_Id	 = @Cate_Id,
		Prov_Id	 = @Prov_Id,
		Prod_Modelo	 = @Prod_Modelo,
		Prod_Cantidad = @Prod_Cantidad,
		Usua_Modificacion = @Prod_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Prod_Id = @Prod_Id
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Producto_Eliminar
	@Prod_Id					INT
AS
BEGIN
	DECLARE @conteoProducto INT = (SELECT COUNT(*) FROM Prod.tbProductos WHERE @Prod_Id NOT IN (SELECT Prod_Id FROM Comp.tbComprasDetalles) AND @Prod_Id NOT IN (SELECT Prov_Id FROM Vent.tbVentasDetalles) AND Prod_Id = @Prod_Id)
	IF @conteoProducto = 0
	BEGIN 
		UPDATE Prod.tbProductos
		SET Prod_Estado = 0
		WHERE Prod_Id = @Prod_Id
	END
	ELSE
	BEGIN 
		SELECT 'No se puede eliminar el producto porque esta siendo utilizado en Compras y Ventas'
	END
END
GO

--TABLA 16 Y 17--
--COMPRAS--
CREATE OR ALTER PROCEDURE Comp.SP_Compra_Insertar
	@Prov_Id						INT,
	@Comp_Fecha					DATE,
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,

	@Prod_Id						INT,
	@CpDe_Cantidad				INT,
	@CpDe_Precio					FLOAT,
	@CpDe_Creacion				INT,
	@Feca_Creacion2				DATETIME
AS
BEGIN
	INSERT INTO Comp.tbCompras (Prov_Id, Comp_Fecha, Usua_Creacion, Feca_Creacion)
	VALUES (@Prov_Id, @Comp_Fecha, @Usua_Creacion, @Feca_Creacion)

	DECLARE @Comp_Id INT
	SET @Comp_Id = SCOPE_IDENTITY();

	INSERT INTO Comp.tbComprasDetalles (Comp_Id, Prod_Id, CpDe_Cantidad, CpDe_Precio, Usua_Creacion, Feca_Creacion)
	VALUES (@Comp_Id	,@Prod_Id,@CpDe_Cantidad,@CpDe_Precio,@CpDe_Creacion,@Feca_Creacion2	)
END
GO

CREATE OR ALTER PROCEDURE Comp.SP_Compra_Actualizar
	@Comp_Id						INT,
	@Prov_Id						INT,
	@Comp_Fecha					DATE,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME,

	@Prod_Id						INT,
	@CpDe_Cantidad				INT,
	@CpDe_Precio					FLOAT,
	@CpDe_Modificacion			INT,
	@Feca_Modificacion2			DATETIME
AS
BEGIN
	UPDATE Comp.tbCompras
	SET Prov_Id	 = @Prov_Id,
		Comp_Fecha = @Comp_Fecha,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Comp_Id = @Comp_Id

	UPDATE Comp.tbComprasDetalles
	SET Prod_Id	= @Prod_Id,
		CpDe_Cantidad = @CpDe_Cantidad,
		CpDe_Precio = @CpDe_Precio,
		Usua_Modificacion = @CpDe_Modificacion,
		Feca_Modificacion = @Feca_Modificacion2	
	WHERE Comp_Id = @Comp_Id
END
GO

CREATE OR ALTER PROCEDURE Comp.SP_Compra_Eliminar
	@Comp_Id					INT,
	@CpDe_Id					INT
AS
BEGIN
	UPDATE Comp.tbCompras
	SET Comp_Estado = 0
	WHERE Comp_Id = @Comp_Id

	UPDATE Comp.tbComprasDetalles
	SET CpDe_Estado = 0
	WHERE CpDe_Id = @CpDe_Id
END
GO

--TABLA 18 Y 19--
--VENTAS--
CREATE OR ALTER PROCEDURE Vent.SP_Venta_Insertar
	@Clie_Id					INT,
	@Vent_Fecha				DATE,
	@Usua_Creacion			INT,
	@Feca_Creacion			DATETIME,

	@Prod_Id					INT,
	@VtDe_Cantidad			INT,
	@VtDe_Precio				FLOAT,
	@VtDe_Creacion			INT,
	@Feca_Creacion2			DATETIME
AS
BEGIN
	INSERT INTO Vent.tbVentas (Clie_Id, Vent_Fecha, Usua_Creacion, Feca_Creacion)
	VALUES (@Clie_Id, @Vent_Fecha, @Usua_Creacion, @Feca_Creacion)

	DECLARE @Vent_Id INT
	SET @Vent_Id = SCOPE_IDENTITY()

	INSERT INTO Vent.tbVentasDetalles (Vent_Id, Prod_Id, VtDe_Cantidad, VtDe_Precio, Usua_Creacion, Feca_Creacion)
	VALUES (@Vent_Id, @Prod_Id, @VtDe_Cantidad, @VtDe_Precio, @VtDe_Creacion, @Feca_Creacion2)
END
GO

CREATE OR ALTER PROCEDURE Vent.SP_Venta_Actualizar
	@Vent_Id					INT,
	@Clie_Id					INT,
	@Vent_Fecha				DATE,
	@Vent_Modificacion		INT,
	@Feca_Modificacion		DATETIME,

	@Prod_Id					INT,
	@VtDe_Cantidad			INT,
	@VtDe_Precio				FLOAT,
	@VtDe_Modificacion		INT,
	@Feca_Modificacion2		DATETIME
AS
BEGIN
	UPDATE Vent.tbVentas
	SET Clie_Id = @Clie_Id,
		Vent_Fecha = @Vent_Fecha,
		Usua_Modificacion = @Vent_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Vent_Id = @Vent_Id

	UPDATE Vent.tbVentasDetalles
	SET Prod_Id = @Prod_Id,
		VtDe_Cantidad = @VtDe_Cantidad,
		VtDe_Precio = @VtDe_Precio,
		Usua_Modificacion = @VtDe_Modificacion,
		Feca_Modificacion = @Feca_Modificacion2
	WHERE Vent_Id = @Vent_Id
END
GO

CREATE OR ALTER PROCEDURE Vent.SP_Venta_Eliminar
	@Vent_Id				INT,
	@VtDe_Id				INT
AS
BEGIN
	UPDATE Vent.tbVentas
	SET Vent_Estado = 0
	WHERE Vent_Id = @Vent_Id

	UPDATE Vent.tbVentasDetalles
	SET VtDe_Estado = 0
	WHERE VtDe_Id = @VtDe_Id
END
GO

--TABLA 20--
--MEDIDAS--
CREATE OR ALTER PROCEDURE Prod.SP_Medida_Insertar
	@Medi_Descripcion			VARCHAR(20),
	@Usua_Creacion				INT,
	@Feca_Creacion				DATETIME,
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	DECLARE @Medi INT = (SELECT COUNT(*) FROM Prod.tbMedidas WHERE Medi_Descripcion = @Medi_Descripcion)

	IF @Medi = 0
	BEGIN
		INSERT INTO Prod.tbMedidas (Medi_Descripcion, Usua_Creacion, Feca_Creacion)
		VALUES (@Medi_Descripcion, @Usua_Creacion, @Feca_Creacion)
	END
	ELSE
	BEGIN
		UPDATE Prod.tbMedidas
		SET Medi_Estado = 1,
			Usua_Modificacion = @Usua_Modificacion,
			Feca_Modificacion = @Feca_Modificacion
		WHERE Medi_Descripcion = @Medi_Descripcion
	END
END
GO

ALTER TABLE Prod.tbMedidas
ADD Medi_Estado			BIT DEFAULT 1
GO

CREATE OR ALTER PROCEDURE Prod.SP_Medida_Actualizar
	@Medi_Id					INT,
	@Medi_Descripcion			VARCHAR(20),
	@Usua_Modificacion			INT,
	@Feca_Modificacion			DATETIME
AS
BEGIN
	UPDATE Prod.tbMedidas
	SET Medi_Descripcion = @Medi_Descripcion,
		Usua_Modificacion = @Usua_Modificacion,
		Feca_Modificacion = @Feca_Modificacion
	WHERE Medi_Id = @Medi_Id
END
GO

CREATE OR ALTER PROCEDURE Prod.SP_Medida_Eliminar
	@Medi_Id					INT
AS
BEGIN
	DECLARE @Medi INT = (SELECT COUNT(*) FROM Prod.tbMedidas
	WHERE Medi_Id = @Medi_Id AND Medi_Estado = 1)

	IF @Medi = 0
	BEGIN 
		UPDATE Prod.tbMedidas
		SET Medi_Estado = 0
		WHERE Medi_Id = @Medi_Id
	END
	ELSE
	BEGIN
		SELECT 'No se puede eliminar la medida, esta siendo utilizado por productos'
	END
END
GO