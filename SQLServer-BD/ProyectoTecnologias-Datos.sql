/****** Object:  Database [Tecnologias]    Script Date: 04/06/2023 07:08:50 p. m. ******/
CREATE DATABASE [Tecnologias]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_Gen5_2', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [Tecnologias] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Tecnologias] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tecnologias] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tecnologias] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tecnologias] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tecnologias] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tecnologias] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tecnologias] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tecnologias] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tecnologias] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tecnologias] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tecnologias] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tecnologias] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tecnologias] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tecnologias] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Tecnologias] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tecnologias] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Tecnologias] SET  MULTI_USER 
GO
ALTER DATABASE [Tecnologias] SET ENCRYPTION ON
GO
ALTER DATABASE [Tecnologias] SET QUERY_STORE = ON
GO
ALTER DATABASE [Tecnologias] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Academico]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Academico](
	[IdAcademico] [int] IDENTITY(1,1) NOT NULL,
	[noPersonal] [varchar](15) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
	[apellidoPaterno] [varchar](30) NOT NULL,
	[apellidoMaterno] [varchar](30) NOT NULL,
	[correoPersonal] [varchar](70) NOT NULL,
	[correoInstitucional] [varchar](70) NOT NULL,
	[pasword] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAcademico] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComentarioGeneral]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentarioGeneral](
	[IdComentario] [int] IDENTITY(1,1) NOT NULL,
	[IdReporte] [int] NOT NULL,
	[descripcion] [varchar](70) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComentario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[matricula] [varchar](10) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
	[apellidoPaterno] [varchar](30) NOT NULL,
	[apellidoMaterno] [varchar](30) NOT NULL,
	[correoPersonal] [varchar](50) NOT NULL,
	[correoInstitucional] [varchar](50) NOT NULL,
	[IdTutor] [int] NOT NULL,
	[IdProgramaEducativo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExperienciaEducativa]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperienciaEducativa](
	[IdExperienciaEducativa] [int] IDENTITY(1,1) NOT NULL,
	[nrc] [varchar](7) NOT NULL,
	[bloque] [varchar](10) NOT NULL,
	[IdAcademico] [int] NOT NULL,
	[IdPeriodoEscolar] [int] NOT NULL,
	[IdMateria] [int] NOT NULL,
	[IdProgramaEducativo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdExperienciaEducativa] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMAteria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[creditos] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMAteria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeriodoEscolar]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodoEscolar](
	[IdPEriodoEscolar] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPEriodoEscolar] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Problematica]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problematica](
	[IdProblematica] [int] IDENTITY(1,1) NOT NULL,
	[IdReporte] [int] NOT NULL,
	[descripcion] [varchar](70) NOT NULL,
	[titulo] [varchar](70) NOT NULL,
	[noIncidencias] [int] NOT NULL,
	[IdTipo] [int] NOT NULL,
	[IdExperienciaEducativa] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProblematica] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProblematicaPersonal]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProblematicaPersonal](
	[IdProblematicaPersonal] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NULL,
	[IdProblematica] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL,
 CONSTRAINT [PK_ProblematicaPersonal] PRIMARY KEY CLUSTERED 
(
	[IdProblematicaPersonal] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramaEducativo]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramaEducativo](
	[IdPRogramaEducativo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[modalidad] [varchar](20) NOT NULL,
	[area] [varchar](20) NOT NULL,
	[IdAcademicoJefe] [int] NOT NULL,
	[IdCoordinador] [int] NOT NULL,
 CONSTRAINT [PK_ProgramaEducativo] PRIMARY KEY CLUSTERED 
(
	[IdPRogramaEducativo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReporteTutoria]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReporteTutoria](
	[IdReporte] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](80) NOT NULL,
	[IdProgramaEducativo] [int] NOT NULL,
	[IdTutoria] [int] NOT NULL,
	[IdTutor] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[asistencia] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReporte] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solucion]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solucion](
	[IdSolucion] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](20) NOT NULL,
	[descripcion] [varchar](80) NOT NULL,
	[IdProgramaEducativo] [int] NOT NULL,
	[IdProblematica] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSolucion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProblematica]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProblematica](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutoria]    Script Date: 04/06/2023 07:08:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutoria](
	[IdTutoria] [int] IDENTITY(1,1) NOT NULL,
	[fechaSesion] [date] NOT NULL,
	[noSesion] [varchar](5) NOT NULL,
	[IdPeriodoEscolar] [int] NOT NULL,
	[fechaEntrega] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTutoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Academico] ON 

INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (1, N'NP001', N'Juan', N'González', N'Pérez', N'juan@gmail.com', N'juan.gonzalez@uv.mx', N'contraseña1')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (2, N'NP002', N'María', N'López', N'Sánchez', N'maria@gmail.com', N'maria.lopez@uv.mx', N'contraseña2')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (3, N'NP003', N'Pedro', N'Martínez', N'Rodríguez', N'pedro@gmail.com', N'pedro.martinez@uv.mx', N'contraseña3')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (4, N'NP004', N'Ana', N'Hernández', N'García', N'ana@gmail.com', N'ana.hernandez@uv.mx', N'contraseña4')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (5, N'NP005', N'Carlos', N'Díaz', N'Torres', N'carlos@gmail.com', N'carlos.diaz@uv.mx', N'contraseña5')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (6, N'NP006', N'Luis', N'Hernández', N'López', N'luis@gmail.com', N'luis.hernandez@uv.mx', N'contraseña6')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (7, N'NP007', N'Laura', N'García', N'Vargas', N'laura@gmail.com', N'laura.garcia@uv.mx', N'contraseña7')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (8, N'NP008', N'Sergio', N'Flores', N'Mendoza', N'sergio@gmail.com', N'sergio.flores@uv.mx', N'contraseña8')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (9, N'NP009', N'Fernanda', N'Díaz', N'Torres', N'fernanda@gmail.com', N'fernanda.diaz@uv.mx', N'contraseña9')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (10, N'NP010', N'Roberto', N'Morales', N'Guzmán', N'roberto@gmail.com', N'roberto.morales@uv.mx', N'contraseña10')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (11, N'NP011', N'Diana', N'Luna', N'Pérez', N'diana@gmail.com', N'diana.luna@uv.mx', N'contraseña11')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (12, N'NP012', N'Héctor', N'Sánchez', N'Nava', N'hector@gmail.com', N'hector.sanchez@uv.mx', N'contraseña12')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (13, N'NP013', N'Paulina', N'Mejía', N'Ríos', N'paulina@gmail.com', N'paulina.mejia@uv.mx', N'contraseña13')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (14, N'NP014', N'Ricardo', N'Jiménez', N'Mendoza', N'ricardo@gmail.com', N'ricardo.jimenez@uv.mx', N'contraseña14')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (15, N'NP015', N'Carmen', N'Navarro', N'Santos', N'carmen@gmail.com', N'carmen.navarro@uv.mx', N'contraseña15')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (16, N'NP016', N'José', N'Hernández', N'López', N'jose@gmail.com', N'jose.hernandez@uv.mx', N'contraseña16')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (17, N'NP017', N'Martha', N'Gómez', N'Vargas', N'martha@gmail.com', N'martha.gomez@uv.mx', N'contraseña17')
INSERT [dbo].[Academico] ([IdAcademico], [noPersonal], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [pasword]) VALUES (18, N'root', N'admin', N'admin', N'admin', N'admin@admin.com', N'admin@root.com', N'123456')
SET IDENTITY_INSERT [dbo].[Academico] OFF
GO
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (1, N'zs889900', N'Gabriel', N'Roy', N'Martin', N'gabriel@gmail.com', N'zs889900@estudiantes.uv.mx', 10, 5)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (2, N'zs123456', N'Juan', N'Pérez', N'Gómez', N'juan@gmail.com', N'zs123456@estudiantes.uv.mx', 1, 1)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (3, N'zs789012', N'María', N'López', N'Sánchez', N'maria@gmail.com', N'zs789012@estudiantes.uv.mx', 2, 1)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (4, N'zs345678', N'Pedro', N'García', N'Ramírez', N'pedro@gmail.com', N'zs345678@estudiantes.uv.mx', 3, 2)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (5, N'zs901234', N'Ana', N'Hernández', N'Torres', N'ana@gmail.com', N'zs901234@estudiantes.uv.mx', 4, 2)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (6, N'zs567890', N'Luis', N'Rodríguez', N'Fernández', N'luis@gmail.com', N'zs567890@estudiantes.uv.mx', 5, 3)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (7, N'zs234567', N'Laura', N'González', N'Vargas', N'laura@gmail.com', N'zs234567@estudiantes.uv.mx', 6, 3)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (8, N'zs890123', N'Carlos', N'Martínez', N'Morales', N'carlos@gmail.com', N'zs890123@estudiantes.uv.mx', 7, 4)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (9, N'zs456789', N'Sofía', N'Jiménez', N'Castillo', N'sofia@gmail.com', N'zs456789@estudiantes.uv.mx', 8, 4)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (10, N'zs012345', N'Diego', N'Ruiz', N'Ortega', N'diego@gmail.com', N'zs012345@estudiantes.uv.mx', 9, 5)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (11, N'zs678901', N'Elena', N'Vargas', N'Soto', N'elena@gmail.com', N'zs678901@estudiantes.uv.mx', 10, 5)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (12, N'zs123412', N'Alejandro', N'Guzmán', N'Pérez', N'alejandro@gmail.com', N'zs123412@estudiantes.uv.mx', 1, 1)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (13, N'zs567856', N'Fernanda', N'Mendoza', N'Luna', N'fernanda@gmail.com', N'zs567856@estudiantes.uv.mx', 2, 1)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (14, N'zs901290', N'Roberto', N'Sánchez', N'Díaz', N'roberto@gmail.com', N'zs901290@estudiantes.uv.mx', 3, 2)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (15, N'zs345634', N'Marcela', N'Cortés', N'Jiménez', N'marcela@gmail.com', N'zs345634@estudiantes.uv.mx', 4, 2)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (16, N'zs789078', N'Daniel', N'Romero', N'Vargas', N'daniel@gmail.com', N'zs789078@estudiantes.uv.mx', 5, 3)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (17, N'zs234523', N'Valeria', N'Ortega', N'González', N'valeria@gmail.com', N'zs234523@estudiantes.uv.mx', 6, 3)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (18, N'zs678789', N'Renata', N'Morales', N'Ramos', N'renata@gmail.com', N'zs678789@estudiantes.uv.mx', 7, 4)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (19, N'zs012901', N'Miguel', N'Castillo', N'Hernández', N'miguel@gmail.com', N'zs012901@estudiantes.uv.mx', 8, 4)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (20, N'zs456523', N'Carmen', N'Ortega', N'Santos', N'carmen@gmail.com', N'zs456523@estudiantes.uv.mx', 9, 5)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (21, N'zs890678', N'Javier', N'Soto', N'González', N'javier@gmail.com', N'zs890678@estudiantes.uv.mx', 10, 5)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (22, N'zs112233', N'Pierre', N'Dubois', N'Lefebvre', N'pierre@gmail.com', N'zs112233@estudiantes.uv.mx', 1, 1)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (23, N'zs445566', N'Sophie', N'Martin', N'Laurent', N'sophie@gmail.com', N'zs445566@estudiantes.uv.mx', 2, 1)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (24, N'zs778899', N'Alexandre', N'Rousseau', N'Dupont', N'alexandre@gmail.com', N'zs778899@estudiantes.uv.mx', 3, 2)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (25, N'zs001122', N'Camille', N'Mercier', N'Moreau', N'camille@gmail.com', N'zs001122@estudiantes.uv.mx', 4, 2)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (26, N'zs334455', N'Juliette', N'Leroy', N'Garcia', N'juliette@gmail.com', N'zs334455@estudiantes.uv.mx', 5, 3)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (27, N'zs667788', N'Lucas', N'Chevalier', N'Leclerc', N'lucas@gmail.com', N'zs667788@estudiantes.uv.mx', 6, 3)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (28, N'zs990011', N'Chloé', N'Dupuis', N'Bertrand', N'chloe@gmail.com', N'zs990011@estudiantes.uv.mx', 7, 4)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (29, N'zs223344', N'Maxime', N'Girard', N'Dubois', N'maxime@gmail.com', N'zs223344@estudiantes.uv.mx', 8, 4)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (30, N'zs556677', N'Emma', N'Lefevre', N'Morel', N'emma@gmail.com', N'zs556677@estudiantes.uv.mx', 9, 5)
INSERT [dbo].[Estudiante] ([IdEstudiante], [matricula], [nombre], [apellidoPaterno], [apellidoMaterno], [correoPersonal], [correoInstitucional], [IdTutor], [IdProgramaEducativo]) VALUES (35, N'6', N'6', N'1', N'1', N'6', N'5', 4, 4)
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (1, N'Literacidad digit', 6)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (2, N'ingles', 6)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (3, N'matematicas discr', 9)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (4, N'introduccion a la', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (5, N'Fundamentos de in', 5)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (6, N'Estructuras de da', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (7, N'Álgebra lineal', 9)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (8, N'Habilidades de co', 4)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (9, N'Arquitectura de c', 9)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (10, N'Diseño y programa', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (11, N'Principios de con', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (12, N'Principios de dis', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (13, N'Diseño de softwar', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (14, N'tecnologías para ', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (15, N'Sistemas operativ', 6)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (16, N'Inteligencia arti', 4)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (17, N'Proyecto guiado', 10)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (18, N'Inteligencia arti', 5)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (19, N'introduccion a la', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (20, N'probabilidad y es', 6)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (21, N'introduccion a la', 5)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (22, N'enrutamiento basi', 5)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (23, N'base de datos', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (24, N'enrutamiento aban', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (25, N'internet de las c', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (26, N'pentesting', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (27, N'arquitectura de r', 5)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (28, N'criptografia', 7)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (29, N'computo en la nub', 8)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (30, N'comunicacion de l', 4)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (31, N'computo forense', 9)
INSERT [dbo].[Materia] ([IdMAteria], [nombre], [creditos]) VALUES (32, N'devops', 5)
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[PeriodoEscolar] ON 

INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (1, N'ENEJUN2023', CAST(N'2023-01-01' AS Date), CAST(N'2023-06-30' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (2, N'AGODIC2023', CAST(N'2023-08-01' AS Date), CAST(N'2023-12-31' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (3, N'ENEJUN2024', CAST(N'2024-01-01' AS Date), CAST(N'2024-06-30' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (4, N'AGODIC2024', CAST(N'2024-08-01' AS Date), CAST(N'2024-12-31' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (5, N'ENEJUN2025', CAST(N'2025-01-01' AS Date), CAST(N'2025-06-30' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (6, N'AGODIC2025', CAST(N'2025-08-01' AS Date), CAST(N'2025-12-31' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (7, N'ENEJUN2026', CAST(N'2026-01-01' AS Date), CAST(N'2026-06-30' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (8, N'AGODIC2026', CAST(N'2026-08-01' AS Date), CAST(N'2026-12-31' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (9, N'ENEJUN2027', CAST(N'2027-01-01' AS Date), CAST(N'2027-06-30' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (10, N'AGODIC2027', CAST(N'2027-08-01' AS Date), CAST(N'2027-12-31' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (11, N'ENEJUN2028', CAST(N'2028-01-01' AS Date), CAST(N'2028-06-30' AS Date))
INSERT [dbo].[PeriodoEscolar] ([IdPEriodoEscolar], [nombre], [fechaInicio], [fechaFin]) VALUES (12, N'AGODIC2028', CAST(N'2028-08-01' AS Date), CAST(N'2028-12-31' AS Date))
SET IDENTITY_INSERT [dbo].[PeriodoEscolar] OFF
GO
SET IDENTITY_INSERT [dbo].[ProgramaEducativo] ON 

INSERT [dbo].[ProgramaEducativo] ([IdPRogramaEducativo], [nombre], [modalidad], [area], [IdAcademicoJefe], [IdCoordinador]) VALUES (1, N'Ingsoft', N'Escolarizado', N'Económico Admin', 5, 10)
INSERT [dbo].[ProgramaEducativo] ([IdPRogramaEducativo], [nombre], [modalidad], [area], [IdAcademicoJefe], [IdCoordinador]) VALUES (2, N'Redes', N'Escolarizado', N'Económico Admin', 6, 11)
INSERT [dbo].[ProgramaEducativo] ([IdPRogramaEducativo], [nombre], [modalidad], [area], [IdAcademicoJefe], [IdCoordinador]) VALUES (3, N'Informática', N'Escolarizado', N'Económico Admin', 7, 12)
INSERT [dbo].[ProgramaEducativo] ([IdPRogramaEducativo], [nombre], [modalidad], [area], [IdAcademicoJefe], [IdCoordinador]) VALUES (4, N'Tecnologías Comp', N'Escolarizado', N'Económico Admin', 8, 13)
INSERT [dbo].[ProgramaEducativo] ([IdPRogramaEducativo], [nombre], [modalidad], [area], [IdAcademicoJefe], [IdCoordinador]) VALUES (5, N'Estadística', N'Mixto', N'Económico Admin', 9, 14)
SET IDENTITY_INSERT [dbo].[ProgramaEducativo] OFF
GO
SET IDENTITY_INSERT [dbo].[ReporteTutoria] ON 

INSERT [dbo].[ReporteTutoria] ([IdReporte], [descripcion], [IdProgramaEducativo], [IdTutoria], [IdTutor], [IdEstudiante], [asistencia]) VALUES (0, N'reporteprueba', 1, 1, 2, 23, 0)
SET IDENTITY_INSERT [dbo].[ReporteTutoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Tutoria] ON 

INSERT [dbo].[Tutoria] ([IdTutoria], [fechaSesion], [noSesion], [IdPeriodoEscolar], [fechaEntrega]) VALUES (0, CAST(N'2023-06-01' AS Date), N'001', 1, CAST(N'2023-06-05' AS Date))
INSERT [dbo].[Tutoria] ([IdTutoria], [fechaSesion], [noSesion], [IdPeriodoEscolar], [fechaEntrega]) VALUES (1, CAST(N'2023-06-06' AS Date), N'002', 1, CAST(N'2023-06-10' AS Date))
INSERT [dbo].[Tutoria] ([IdTutoria], [fechaSesion], [noSesion], [IdPeriodoEscolar], [fechaEntrega]) VALUES (2, CAST(N'2023-06-11' AS Date), N'003', 1, CAST(N'2023-06-15' AS Date))
INSERT [dbo].[Tutoria] ([IdTutoria], [fechaSesion], [noSesion], [IdPeriodoEscolar], [fechaEntrega]) VALUES (3, CAST(N'2023-06-15' AS Date), N'004', 1, CAST(N'2023-06-20' AS Date))
INSERT [dbo].[Tutoria] ([IdTutoria], [fechaSesion], [noSesion], [IdPeriodoEscolar], [fechaEntrega]) VALUES (4, CAST(N'2023-06-21' AS Date), N'005', 1, CAST(N'2023-06-25' AS Date))
INSERT [dbo].[Tutoria] ([IdTutoria], [fechaSesion], [noSesion], [IdPeriodoEscolar], [fechaEntrega]) VALUES (5, CAST(N'2023-06-26' AS Date), N'006', 1, CAST(N'2023-06-30' AS Date))
SET IDENTITY_INSERT [dbo].[Tutoria] OFF
GO
ALTER TABLE [dbo].[ComentarioGeneral]  WITH CHECK ADD FOREIGN KEY([IdReporte])
REFERENCES [dbo].[ReporteTutoria] ([IdReporte])
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_ProgramaEducativo] FOREIGN KEY([IdProgramaEducativo])
REFERENCES [dbo].[ProgramaEducativo] ([IdPRogramaEducativo])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_ProgramaEducativo]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Tutoria] FOREIGN KEY([IdTutor])
REFERENCES [dbo].[Academico] ([IdAcademico])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_Tutoria]
GO
ALTER TABLE [dbo].[ExperienciaEducativa]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaEducativa_Academico] FOREIGN KEY([IdAcademico])
REFERENCES [dbo].[Academico] ([IdAcademico])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_Academico]
GO
ALTER TABLE [dbo].[ExperienciaEducativa]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaEducativa_Materia] FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([IdMAteria])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_Materia]
GO
ALTER TABLE [dbo].[ExperienciaEducativa]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaEducativa_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([IdPEriodoEscolar])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_PeriodoEscolar]
GO
ALTER TABLE [dbo].[ExperienciaEducativa]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaEducativa_ProgramaEducativo] FOREIGN KEY([IdProgramaEducativo])
REFERENCES [dbo].[ProgramaEducativo] ([IdPRogramaEducativo])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_ProgramaEducativo]
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD FOREIGN KEY([IdExperienciaEducativa])
REFERENCES [dbo].[ExperienciaEducativa] ([IdExperienciaEducativa])
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD FOREIGN KEY([IdReporte])
REFERENCES [dbo].[ReporteTutoria] ([IdReporte])
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD  CONSTRAINT [FK_Problematica_TipoProblematica] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TipoProblematica] ([IdTipo])
GO
ALTER TABLE [dbo].[Problematica] CHECK CONSTRAINT [FK_Problematica_TipoProblematica]
GO
ALTER TABLE [dbo].[ProblematicaPersonal]  WITH CHECK ADD FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[ProblematicaPersonal]  WITH CHECK ADD FOREIGN KEY([IdProblematica])
REFERENCES [dbo].[Problematica] ([IdProblematica])
GO
ALTER TABLE [dbo].[ProgramaEducativo]  WITH CHECK ADD FOREIGN KEY([IdAcademicoJefe])
REFERENCES [dbo].[Academico] ([IdAcademico])
GO
ALTER TABLE [dbo].[ProgramaEducativo]  WITH CHECK ADD FOREIGN KEY([IdCoordinador])
REFERENCES [dbo].[Academico] ([IdAcademico])
GO
ALTER TABLE [dbo].[ReporteTutoria]  WITH CHECK ADD FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[ReporteTutoria]  WITH CHECK ADD FOREIGN KEY([IdProgramaEducativo])
REFERENCES [dbo].[ProgramaEducativo] ([IdPRogramaEducativo])
GO
ALTER TABLE [dbo].[ReporteTutoria]  WITH CHECK ADD FOREIGN KEY([IdTutoria])
REFERENCES [dbo].[Tutoria] ([IdTutoria])
GO
ALTER TABLE [dbo].[ReporteTutoria]  WITH CHECK ADD FOREIGN KEY([IdTutor])
REFERENCES [dbo].[Academico] ([IdAcademico])
GO
ALTER TABLE [dbo].[Solucion]  WITH CHECK ADD FOREIGN KEY([IdProblematica])
REFERENCES [dbo].[Problematica] ([IdProblematica])
GO
ALTER TABLE [dbo].[Solucion]  WITH CHECK ADD FOREIGN KEY([IdProgramaEducativo])
REFERENCES [dbo].[ProgramaEducativo] ([IdPRogramaEducativo])
GO
ALTER DATABASE [Tecnologias] SET  READ_WRITE 
GO
