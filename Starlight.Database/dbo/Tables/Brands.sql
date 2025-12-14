CREATE TABLE [dbo].[Brands] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (200) NOT NULL,
    [Active]    BIT            DEFAULT ((1)) NOT NULL,
    [CreatedAt] DATETIME       DEFAULT (getdate()) NOT NULL,
    [UpdatedAt] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

