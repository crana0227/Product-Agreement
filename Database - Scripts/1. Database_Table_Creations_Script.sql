Use [Product-Agreement]
GO
CREATE TABLE [dbo].[ProductGroup] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [GroupDescription] NVARCHAR (250) NOT NULL,
    [GroupCode]        NVARCHAR (50)  NOT NULL,
    [Active]           BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UC_ProductGroup_GroupCode] UNIQUE NONCLUSTERED ([GroupCode] ASC)
);

GO
CREATE TABLE [dbo].[Product] (
    [Id]                 INT              IDENTITY (1, 1) NOT NULL,
    [ProductGroupId]     INT    NOT       NULL,
    [ProductDescription] NVARCHAR (250)   NOT NULL,
    [ProductNumber]      NVARCHAR (50)	  NOT NULL,
    [Price]              DECIMAL  (18,2)  NOT NULL,
    [Active]             BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UC_Product_ProductNumber] UNIQUE NONCLUSTERED ([ProductNumber] ASC),
    CONSTRAINT [FK_Product_ProductGroup]  FOREIGN KEY ([ProductGroupId]) REFERENCES [dbo].[ProductGroup] ([Id])
);

GO
CREATE TABLE [dbo].[Agreement] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [UserId]         NVARCHAR (450) NOT NULL,
    [ProductGroupId] INT            NOT NULL,
    [ProductId]      INT            NOT NULL,
    [EffectiveDate]  DATETIME       NOT NULL,
    [ExpirationDate] DATETIME       NOT NULL,
    [ProductPrice]   DECIMAL (18,2) NOT NULL,
    [NewPrice]       DECIMAL (18,2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Agreement_ProductGroup] FOREIGN KEY ([ProductGroupId]) REFERENCES [dbo].[ProductGroup] ([Id]),
    CONSTRAINT [FK_Agreement_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);