USE [Reporter]
GO

/****** Object:  Table [dbo].[CustomersAndVehicles]    Script Date: 14/02/2021 21:52:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomersAndVehicles](
	[CustomerId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
 CONSTRAINT [PK_CustomersAndVehicles] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomersAndVehicles]  WITH CHECK ADD  CONSTRAINT [FK_CustomersAndVehicles_CustomersAndVehicles] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerInformation] ([CustomerId])
GO

ALTER TABLE [dbo].[CustomersAndVehicles] CHECK CONSTRAINT [FK_CustomersAndVehicles_CustomersAndVehicles]
GO


