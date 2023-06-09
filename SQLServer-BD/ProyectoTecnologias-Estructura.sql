/****** Object:  Database [Tecnologias]    Script Date: 22/06/2023 08:42:10 p. m. ******/
CREATE DATABASE [Tecnologias]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_1', MAXSIZE = 170 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
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
/****** Object:  Table [dbo].[Academico]    Script Date: 22/06/2023 08:42:10 p. m. ******/
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
	[password] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAcademico] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComentarioGeneral]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentarioGeneral](
	[IdComentario] [int] IDENTITY(1,1) NOT NULL,
	[IdTutoria] [int] NOT NULL,
	[IdTutor] [int] NOT NULL,
	[descripcion] [varchar](700) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComentario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 22/06/2023 08:42:11 p. m. ******/
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
	[IdTutor] [int] NULL,
	[IdProgramaEducativo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExperienciaEducativa]    Script Date: 22/06/2023 08:42:11 p. m. ******/
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
/****** Object:  Table [dbo].[Materia]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[creditos] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeriodoEscolar]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodoEscolar](
	[IdPeriodoEscolar] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPeriodoEscolar] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Problematica]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problematica](
	[IdProblematica] [int] IDENTITY(1,1) NOT NULL,
	[IdTutoria] [int] NOT NULL,
	[IdTutor] [int] NOT NULL,
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
/****** Object:  Table [dbo].[ProblematicaPersonal]    Script Date: 22/06/2023 08:42:11 p. m. ******/
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
/****** Object:  Table [dbo].[ProgramaEducativo]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramaEducativo](
	[IdProgramaEducativo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[modalidad] [varchar](20) NOT NULL,
	[area] [varchar](20) NOT NULL,
	[IdAcademicoJefe] [int] NOT NULL,
	[IdCoordinador] [int] NOT NULL,
 CONSTRAINT [PK_ProgramaEducativo] PRIMARY KEY CLUSTERED 
(
	[IdProgramaEducativo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReporteTutoria]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReporteTutoria](
	[IdReporte] [int] IDENTITY(1,1) NOT NULL,
	[IdProgramaEducativo] [int] NOT NULL,
	[IdTutoria] [int] NOT NULL,
	[IdTutor] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[asistencia] [bit] NULL,
	[riesgo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReporte] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solucion]    Script Date: 22/06/2023 08:42:11 p. m. ******/
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
/****** Object:  Table [dbo].[TipoProblematica]    Script Date: 22/06/2023 08:42:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProblematica](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutoria]    Script Date: 22/06/2023 08:42:11 p. m. ******/
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
ALTER TABLE [dbo].[ComentarioGeneral]  WITH CHECK ADD FOREIGN KEY([IdTutoria])
REFERENCES [dbo].[Tutoria] ([IdTutoria])
GO
ALTER TABLE [dbo].[ComentarioGeneral]  WITH CHECK ADD FOREIGN KEY([IdTutor])
REFERENCES [dbo].[Academico] ([IdAcademico])
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_ProgramaEducativo] FOREIGN KEY([IdProgramaEducativo])
REFERENCES [dbo].[ProgramaEducativo] ([IdProgramaEducativo])
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
REFERENCES [dbo].[Materia] ([IdMateria])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_Materia]
GO
ALTER TABLE [dbo].[ExperienciaEducativa]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaEducativa_PeriodoEscolar] FOREIGN KEY([IdPeriodoEscolar])
REFERENCES [dbo].[PeriodoEscolar] ([IdPeriodoEscolar])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_PeriodoEscolar]
GO
ALTER TABLE [dbo].[ExperienciaEducativa]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaEducativa_ProgramaEducativo] FOREIGN KEY([IdProgramaEducativo])
REFERENCES [dbo].[ProgramaEducativo] ([IdProgramaEducativo])
GO
ALTER TABLE [dbo].[ExperienciaEducativa] CHECK CONSTRAINT [FK_ExperienciaEducativa_ProgramaEducativo]
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD FOREIGN KEY([IdExperienciaEducativa])
REFERENCES [dbo].[ExperienciaEducativa] ([IdExperienciaEducativa])
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TipoProblematica] ([IdTipo])
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD FOREIGN KEY([IdTutoria])
REFERENCES [dbo].[Tutoria] ([IdTutoria])
GO
ALTER TABLE [dbo].[Problematica]  WITH CHECK ADD FOREIGN KEY([IdTutor])
REFERENCES [dbo].[Academico] ([IdAcademico])
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
REFERENCES [dbo].[ProgramaEducativo] ([IdProgramaEducativo])
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
REFERENCES [dbo].[ProgramaEducativo] ([IdProgramaEducativo])
GO
ALTER DATABASE [Tecnologias] SET  READ_WRITE 
GO
