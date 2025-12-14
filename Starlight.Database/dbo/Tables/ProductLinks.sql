CREATE TABLE [dbo].[ProductLinks] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT            NOT NULL,
    [PlatformId] INT            NOT NULL,
    [Url]        NVARCHAR (500) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[Platforms] ([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

