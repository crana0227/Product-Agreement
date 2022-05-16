USE [PRODUCT-AGREEMENT]
GO
INSERT INTO [dbo].[ProductGroup] (GroupDescription,GroupCode,Active) VALUES ('FOOTWEAR','FW',1)
INSERT INTO [dbo].[ProductGroup] (GroupDescription,GroupCode,Active) VALUES ('ELECTRONIC','EC',1)
INSERT INTO [dbo].[ProductGroup] (GroupDescription,GroupCode,Active) VALUES ('PHARMACTUAL','PHM',1)
INSERT INTO [dbo].[ProductGroup] (GroupDescription,GroupCode,Active) VALUES ('COSMETICS','COS',1)
INSERT INTO [dbo].[ProductGroup] (GroupDescription,GroupCode,Active) VALUES ('TOBBECO','TBC',1)
GO
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (1,'BATA_SHOES','P0001',700,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (1,'ADIDAS_SHOES','P0002',900,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (1,'NIKE_SHOES','P0003',1000,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (1,'SKETCHERS_SHOES','P0004',900,1)
GO
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (2,'BAJAJ_BULB','P0005',700,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (2,'TUBE_LIGHT','P0006',900,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (2,'KETTLE','P0007',700,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (2,'ELECTRIC_STOVE','P0008',2800,1)
GO
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (3,'JHONSON&JHONSON','P0009',1000,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (3,'DUMRNY_COOL','P0010',1200,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (3,'KETOZOL','P0011',700,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (3,'MEDICATED_SOAP','P0012',3000,1)
GO
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (4,'EYE_LINER','P0013',1000,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (4,'COMPAQ','P0014',1200,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (4,'FOUNDATION','P0015',1500,1)
GO
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (5,'PAN_MASALA','P0016',1000,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (5,'GUTKA','P0017',1200,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (5,'TAJ_SOPARI','P0018',700,1)
INSERT INTO [dbo].[Product] (ProductGroupId,ProductDescription,ProductNumber,Price,Active) VALUES (5,'ASHWAGANDHA','P0019',3000,1)
