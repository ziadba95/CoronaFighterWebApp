CREATE TABLE [dbo].[UserGroup] (
    [groupID] INT NOT NULL,
    [userID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([groupID] ASC, [userID] ASC),
    FOREIGN KEY ([groupID]) REFERENCES [dbo].[Group] ([groupID]),
    FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID])
);

