USE [Reporter]
GO

/****** Object:  Table [dbo].[VehicleInformation]    Script Date: 14/02/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleInformation](
	[VehicleId] [int] NOT NULL,
	[Manufacturer] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[RegistrationDate] [date] NULL,
	[EngineSize] [int] NULL,
	[InteriorColor] [nvarchar](50) NULL,
 CONSTRAINT [PK_VehicleInformation] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


