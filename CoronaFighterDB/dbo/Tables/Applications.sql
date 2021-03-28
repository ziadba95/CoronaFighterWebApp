CREATE TABLE [dbo].[Applications] (
    [appID]     INT           IDENTITY (1, 1) NOT NULL,
    [firstName] VARCHAR (50)  NULL,
    [lastName]  VARCHAR (50)  NULL,
    [email]     VARCHAR (200) NULL,
    [doc]       VARBINARY (1) NULL,
    [subDate]   DATETIME      NULL,
    [appStatus] BIT           NULL,
    PRIMARY KEY CLUSTERED ([appID] ASC)
);

