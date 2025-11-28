CREATE TABLE [dbo].[SocialLinks] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    [Logo] NVARCHAR (MAX) NOT NULL,
    [Url]  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

