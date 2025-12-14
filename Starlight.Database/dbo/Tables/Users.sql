CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] VARBINARY (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

