CREATE TABLE [dbo].[User] (
    [userID]   INT           IDENTITY (1, 1) NOT NULL,
    [fName]    VARCHAR (50)  NULL,
    [lName]    VARCHAR (50)  NULL,
    [gender]   VARCHAR (10)  NULL,
    [email]    VARCHAR (100) NULL,
    [pass]     VARCHAR (16)  NULL,
    [DOB]      DATETIME      NULL,
    [roleType] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);

