USE [SaludCloud]
GO

/****** Object:  Table [dbo].[cita]    Script Date: 17/05/2021 1:19:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Paciente] [varchar](255) NOT NULL,
	[Apellido_Paciente] [varchar](255) NOT NULL,
	[Motivo] [text] NULL,
	[Nota] [varchar](255) NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](6) NOT NULL,
	[Medico] [varchar](255) NOT NULL,
	[Centro_Salud] [varchar](255) NOT NULL,
	[Estatus] [varchar](255) NOT NULL,
	[Estatus_Correo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cita] ADD  DEFAULT (NULL) FOR [Nota]
GO



CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Apellido2] [varchar](50) NULL,
	[Usuario] [varchar](50) NULL,
	[Contrasena] [varchar](50) NULL,
	[Fk_TipoMedico] [int] NULL,
	[Fk_Especialidad_No1] [int] NULL,
	[Fk_Especialidad_No2] [int] NULL,
	[Fk_Especialidad_No3] [int] NULL,
	[Foto] [image] NULL,
	)