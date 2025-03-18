CREATE SCHEMA Acce
GO

CREATE SCHEMA Gral
GO

CREATE SCHEMA Ferr
GO

CREATE SCHEMA Prod
GO

CREATE SCHEMA Vent
GO

CREATE SCHEMA Comp
GO

--OSCAR--
--TABLA 1--
CREATE TABLE Acce.tbUsuarios
(
	Usua_Id					INT IDENTITY (1,1),
	Usua_Nombre				VARCHAR(50) UNIQUE NOT NULL,
	Usua_Clave				VARCHAR(MAX) NOT NULL,
	Empl_Id					INT NOT NULL,
	Role_Id 				INT NOT NULL,
	Usua_EsAdmin			BIT DEFAULT 0,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Usua_Estado				BIT DEFAULT 1,
	
	CONSTRAINT PK_Acce_tbUsuarios_Usua_Id PRIMARY KEY (Usua_Id)
);
GO

--CONSTRAINT TABLA 1--
ALTER TABLE Acce.tbUsuarios
ADD CONSTRAINT FK_Acce_tbUsuarios_Acce_tbRoles FOREIGN KEY (Role_Id) REFERENCES Acce.tbRoles(Role_Id),
	CONSTRAINT FK_Acce_tbUsuarios_Ferr_tbEmpleados FOREIGN KEY (Empl_Id) REFERENCES Ferr.tbEmpleados(Empl_Id)
GO

--TABLA 2--
CREATE TABLE Acce.tbRoles
(
	Role_Id					INT IDENTITY(1,1),
	Role_Descripcion		VARCHAR(100) NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Role_Estado				BIT DEFAULT 1,
	

	CONSTRAINT PK_Acce_tbRoles_Role_Id PRIMARY KEY (Role_Id),
	CONSTRAINT FK_Acce_tbRoles_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios(Usua_Id),
	CONSTRAINT FK_Acce_tbRoles_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios(Usua_Id)
);
GO

--TABLA 3--
CREATE TABLE Acce.tbPantallas
(
	Pant_Id					INT IDENTITY(1,1),
	Pant_Descripcion			VARCHAR(100) NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,

	CONSTRAINT PK_Acce_tbPantallas_Pant_Id PRIMARY KEY (Pant_Id),
	CONSTRAINT FK_Acce_tbPantallas_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Acce_tbPantallas_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
);
GO

--TABLA 4--
CREATE TABLE Acce.tbRolesPorPantalla
(
	RoPa_Id					INT IDENTITY(1,1),
	Role_Id					INT NOT NULL,
	Pant_Id					INT NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	RoPa_Estado				BIT DEFAULT(1),
	

	CONSTRAINT PK_Acce_tbRolesPorPantalla_Acce_tbRoles_Role_Id FOREIGN KEY (Role_Id)
		REFERENCES Acce.tbRoles(Role_Id),
	CONSTRAINT PK_Acce_tbRolesPorPantalla_Pant_Id_Acce_tbPants_Pant_Id FOREIGN KEY (Pant_Id)
		REFERENCES Acce.tbPantallas(Pant_id),
	CONSTRAINT FK_Acce_RolesPorPantalla_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios(Usua_Id),
	CONSTRAINT FK_Acce_RolesPorPantalla_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios(Usua_Id)
);
GO

--TABLA 5--
CREATE TABLE Gral.tbDepartamentos
(
	Depa_Codigo				VARCHAR(2) NOT NULL,
	Depa_Descripcion			VARCHAR(50) NOT NULL,
	
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,

	CONSTRAINT PK_Gral_tbDepartamentos_Depa_Codigo PRIMARY KEY (Depa_Codigo),
	CONSTRAINT FK_Gral_tbDepartamentos_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)	
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)	
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 6--
CREATE TABLE Gral.tbMunicipios 
(
	Muni_Codigo				VARCHAR(4) NOT NULL,
	Muni_Descripcion			NVARCHAR(50) NOT NULL,
	Depa_Codigo				VARCHAR(2) NOT NULL,
	
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,

	CONSTRAINT PK_Gral_tbMunicipios_Muni_Codigo PRIMARY KEY (Muni_Codigo),
	CONSTRAINT FK_Gral_tbMunicipios_Depa_Codigo_Gral_tbDepartamentos_Depa_Codigo FOREIGN KEY (Depa_Codigo)
		REFERENCES Gral.tbDepartamentos (Depa_Codigo),
	CONSTRAINT FK_Gral_tbMunicipios_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)	
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)	
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 7--
CREATE TABLE Gral.tbEstadosCiviles
(
	EsCv_Id					INT IDENTITY(1,1),
	EsCv_Descripcion		NVARCHAR(50) NOT NULL,
	Usua_Creacion		INT NOT NULL,
	Fecha_Creacion		DATETIME NOT NULL,
	Usua_Modificacion	INT,
	Fecha_Modificacion	DATETIME,

	CONSTRAINT PK_Gral_tbEstadosCiviles_EsCv_Id PRIMARY KEY (EsCv_Id),
	CONSTRAINT FK_Gral_tbEstadosCiviles_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Gral_tbEstadosCiviles_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 8--
CREATE TABLE Gral.tbClientes
(
	Clie_Id					INT IDENTITY(1,1),
	Clie_DNI				NVARCHAR(15) UNIQUE NOT NULL,
	Clie_Nombre				NVARCHAR(100) NOT NULL,
	Clie_Apellido			NVARCHAR(100) NOT NULL,
	Clie_Sexo				CHAR(1) NOT NULL,
	EsCv_Id					INT NOT NULL,
	Muni_Codigo				VARCHAR(4) NOT NULL,
	Clie_Direccion			NVARCHAR(200) NOT NULL,
	Usua_Creacion		INT NOT NULL,
	Fecha_Creacion		DATETIME NOT NULL,
	Usua_Modificacion	INT,
	Fecha_Modificacion	DATETIME,
	Clie_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Gral_tbCLientes_Clie_Id PRIMARY KEY (Clie_Id),
	CONSTRAINT CK_Gral_tbClientes_Clie_Sexo CHECK (Clie_Sexo IN ('M', 'F')),

	CONSTRAINT FK_Gral_tbClientes_Gral_tbEstadosCiviles_EsCv_Id FOREIGN KEY (EsCv_Id) REFERENCES Gral.tbEstadosCiviles(EsCv_Id),
	CONSTRAINT FK_Gral_tbClientes_Gral_tbMunicipios_Muni_Codigo FOREIGN KEY (Muni_Codigo) REFERENCES Gral.tbMunicipios(Muni_Codigo),
	CONSTRAINT FK_Gral_tbClientes_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Gral_tbClientes_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 9--
CREATE TABLE Ferr.tbSucursales
(
	Sucu_Id					INT IDENTITY (1,1),
	Sucu_Nombre				NVARCHAR(50) NOT NULL,
	Muni_Codigo				VARCHAR(4)	 NOT NULL,
	Sucu_DireccionExacta		NVARCHAR(50) NOT NULL,
	Usua_Creacion		INT NOT NULL,
	Fecha_Creacion		DATETIME,
	Usua_Modificacion	INT,
	Fecha_Modificacion	DATETIME,
	Sucu_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Gral_tbSucursales_Sucu_Id	PRIMARY KEY (Sucu_Id),
	CONSTRAINT FK_Gral_tbSucursales_Muni_Codigo_Gral_tb_Municipios_Muni_Codigo FOREIGN KEY (Muni_Codigo)
		REFERENCES Gral.tbMunicipios (Muni_Codigo),
	CONSTRAINT FK_Gral_tbSucursales_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Gral_tbSucursales_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
) 
GO

--ANGEL--
--TABLA 10--
CREATE TABLE Ferr.tbCargos
(
	Carg_Id					INT IDENTITY (1,1),
	Carg_Descripcion			NVARCHAR(20) NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Carg_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Gral_tbCargos_Carg_Id PRIMARY KEY (Carg_Id),
	CONSTRAINT FK_Gral_tbCargos_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Gral_tbCargos_Carg_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 11--
CREATE TABLE Ferr.tbEmpleados
(
	Empl_Id					INT IDENTITY(1,1),
	Empl_DNI					NVARCHAR(15) UNIQUE NOT NULL,
	Empl_Nombre				NVARCHAR(100) NOT NULL,
	Empl_Apellido			NVARCHAR(100) NOT NULL,
	Empl_Sexo				CHAR(1) NOT NULL,
	EsCv_Id					INT NOT NULL,
	Carg_Id					INT NOT NULL,
	Muni_Codigo				VARCHAR(4) NOT NULL,
	Empl_Direccion			NVARCHAR(200) NOT NULL,
	Empl_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Empl_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Empl_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Ferr_tbEmpleados_Empl_Id PRIMARY KEY (Empl_Id),
	CONSTRAINT CK_Ferr_tbEmpleados_Empl_Sexo CHECK (Empl_Sexo IN ('M', 'F')),
	CONSTRAINT FK_Ferr_tbEmpleados_EsCv_Id_Gral_tbEstadosCiviles_EsCv_Id FOREIGN KEY (EsCv_Id)
		REFERENCES Gral.tbEstadosCiviles (EsCv_Id),
	CONSTRAINT FK_Ferr_tbEmpleados_Carg_Id_Ferr_tbCargos_Carg_Id FOREIGN KEY (Carg_Id)
		REFERENCES Ferr.tbCargos (Carg_Id),
	CONSTRAINT FK_Ferr_tbEmpleados_Muni_Codigo_Gral_tbMunicipios_Muni_Codigo FOREIGN KEY (Muni_Codigo)
		REFERENCES Gral.tbMunicipios (Muni_Codigo),
	CONSTRAINT FK_Ferr_tbEmpleados_Empl_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Empl_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Ferr_tbEmpleados_Empl_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Empl_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 12--
CREATE TABLE Prod.tbMarcas
(
	Marc_Id					INT IDENTITY(1,1),
	Marc_Descripcion			NVARCHAR(50) NOT NULL,
	Marc_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Marc_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Marc_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Prod_tbMarcas_Marc_Id PRIMARY KEY (Marc_Id),
	CONSTRAINT FK_Prod_tbMarcas_Marc_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Marc_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Prod_tbMarcas_Marc_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Marc_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 13--
CREATE TABLE Prod.tbCategorias
(
	Cate_Id					INT IDENTITY(1,1),
	Cate_Descripcion		NVARCHAR(50) NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Cate_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Prod_tbCategorias_Cate_Id PRIMARY KEY (Cate_Id),
	CONSTRAINT FK_Prod_tbCategorias_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Prod_tbCategorias_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO
--TABLA 14--
CREATE TABLE Comp.tbProveedores
(
	Prov_Id					INT IDENTITY(1,1),
	Prov_Nombre				NVARCHAR(50) NOT NULL,
	Prov_Contacto			NVARCHAR(30) NOT NULL,
	Muni_Codigo				VARCHAR(4) NOT NULL,
	Prov_DireccionExacta		NVARCHAR(200) NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Prov_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Comp_tbProveedores_Prov_Id PRIMARY KEY (Prov_Id),
	CONSTRAINT FK_Comp_tbProveedores_Muni_Codigo_Gral_tbMunicipios_Muni_Codigo FOREIGN KEY (Muni_Codigo)
		REFERENCES Gral.tbMunicipios (Muni_Codigo),
	CONSTRAINT FK_Comp_tbProveedores_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Comp_tbProveedores_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 15--
CREATE TABLE Prod.tbMedidas
(
	Medi_Id					INT IDENTITY(1,1),
	Medi_Descripcion		VARCHAR(20) NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,

	CONSTRAINT PK_Prod_tbMedidas_Medi_Id PRIMARY KEY (Medi_Id),
	CONSTRAINT FK_Prod_tbMedidas_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Prod_tbMedidas_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 16--
CREATE TABLE Prod.tbProductos
(
	Prod_Id					INT IDENTITY(1,1),
	Prod_Descripcion			NVARCHAR(50) NOT NULL,
	Marc_Id					INT NOT NULL,
	Cate_Id					INT NOT NULL,
	Prov_Id					INT NOT NULL,
	Prod_Modelo				NVARCHAR(50) NOT NULL,
	Prod_Cantidad			INT NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Prod_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Prod_tbProductos_Prod_Id PRIMARY KEY (Prod_Id),
	CONSTRAINT FK_Prod_tbProductos_Marc_Id_Prod_tbMarcas_Marc_Id FOREIGN KEY (Marc_Id)
		REFERENCES Prod.tbMarcas (Marc_Id),
	CONSTRAINT FK_Prod_tbProductos_Cate_Id_Prod_tbCategorias_Cate_Id FOREIGN KEY (Cate_Id)
		REFERENCES Prod.tbCategorias (Cate_Id),
	CONSTRAINT FK_Prod_tbProductos_Prov_Id_Comp_tbProveedores_Prov_Id FOREIGN KEY (Prov_Id)
		REFERENCES Comp.tbProveedores (Prov_Id),
	CONSTRAINT FK_Prod_tbProductos_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Prod_tbProductos_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--IMAGENES PRODUCTOS--
ALTER TABLE Prod.tbProductos
ADD Prod_URLImg				VARCHAR(MAX)
GO

--MEDIDAS--
ALTER TABLE Prod.tbProductos
ADD Medi_Id					INT NOT NULL,
	CONSTRAINT FK_Prod_tbProductos_Medi_Id_Prod_tbMedidas_Medi_Id FOREIGN KEY (Medi_Id)
		REFERENCES Prod.tbMedidas (Medi_Id)
GO

--TABLA 17--
CREATE TABLE Comp.tbCompras
(
	Comp_Id					INT IDENTITY(1,1),
	Prov_Id					INT NOT NULL,
	Comp_Fecha				DATE NOT NULL,
	Comp_Total				FLOAT NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Comp_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Comp_tbCompras_Comp_Id PRIMARY KEY (Comp_Id),
	CONSTRAINT FK_Comp_tbCompras_Prov_Id_Comp_tbProveedores_Prov_Id FOREIGN KEY (Prov_Id)
		REFERENCES Comp.tbProveedores (Prov_Id),
	CONSTRAINT FK_Comp_tbCompras_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Comp_tbCompras_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 18--
CREATE TABLE Comp.tbComprasDetalles
(
	CpDe_Id					INT IDENTITY(1,1),
	Comp_Id					INT NOT NULL,
	Prod_Id					INT NOT NULL,
	CpDe_Cantidad			INT NOT NULL,
	CpDe_Precio				FLOAT NOT NULL,
	CpDe_SubTotal			FLOAT NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	CpDe_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Comp_tbComprasDetalles_CpDe_Id PRIMARY KEY (CpDe_Id),
	CONSTRAINT FK_Comp_tbComprasDetalles_Comp_Id_Comp_tbCompras FOREIGN KEY (Comp_Id)
		REFERENCES Comp.tbCompras (Comp_Id),
	CONSTRAINT FK_Comp_tbComprasDetalles_Prod_Id_Prod_tbProductos_Prod_Id FOREIGN KEY (Prod_Id)
		REFERENCES Prod.tbProductos (Prod_Id),
	CONSTRAINT FK_Comp_tbComprasDetalles_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Comp_tbComprasDetalles_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 19--
CREATE TABLE Vent.tbVentas
(
	Vent_Id					INT IDENTITY(1,1),
	Clie_Id					INT NOT NULL,
	Vent_Fecha				DATE NOT NULL,
	Vent_Total				FLOAT NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	Vent_Estado				BIT DEFAULT 1,

	CONSTRAINT PK_Vent_tbVentas_Vent_Id PRIMARY KEY (Vent_Id),
	CONSTRAINT FK_Vent_tbVentas_Clie_Id_Clie_tbClientes_Clie_Id FOREIGN KEY (Clie_Id)
		REFERENCES Gral.tbClientes (Clie_Id),
	CONSTRAINT FK_Vent_tbVentas_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Vent_tbVentas_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO

--TABLA 20--
CREATE TABLE Vent.tbVentasDetalles
(
	VtDe_Id					INT IDENTITY(1,1),
	Vent_Id					INT NOT NULL,
	Prod_Id					INT NOT NULL,
	VtDe_Cantidad			INT NOT NULL,
	VtDe_Precio				FLOAT NOT NULL,
	VtDe_SubTotal			FLOAT NOT NULL,
	Usua_Creacion			INT NOT NULL,
	Fecha_Creacion			DATETIME NOT NULL,
	Usua_Modificacion		INT,
	Fecha_Modificacion		DATETIME,
	VtDe_Estado				BIT DEFAULT 1,
	
	CONSTRAINT PK_Vent_tbVentasDetalles_VtDe_Id PRIMARY KEY (VtDe_Id),
	CONSTRAINT FK_Vent_tbVentasDetalles_Vent_Id_Vent_tbVentas_Vent_Id FOREIGN KEY (Vent_Id)
		REFERENCES Vent.tbVentas (Vent_Id),
	CONSTRAINT FK_Vent_tbVentasDetalles_Prod_Id_Prod_tbProductos_Prod_Id FOREIGN KEY (Prod_Id)
		REFERENCES Prod.tbProductos (Prod_Id),
	CONSTRAINT FK_Vent_tbVentasDetalles_Usua_Creacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Creacion)
		REFERENCES Acce.tbUsuarios (Usua_Id),
	CONSTRAINT FK_Vent_tbVentasDetalles_Usua_Modificacion_Acce_tbUsuarios_Usua_Id FOREIGN KEY (Usua_Modificacion)
		REFERENCES Acce.tbUsuarios (Usua_Id)
)
GO