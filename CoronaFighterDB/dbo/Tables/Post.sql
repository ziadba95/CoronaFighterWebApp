CREATE TABLE [dbo].[Post] (
    [postID]      INT           IDENTITY (1, 1) NOT NULL,
    [groupID]     INT           NULL,
    [userID]      INT           NULL,
    [postTitle]   VARCHAR (100) NULL,
    [postContent] VARCHAR (MAX) NULL,
    [postDate]    DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([postID] ASC),
    FOREIGN KEY ([groupID]) REFERENCES [dbo].[Group] ([groupID]),
    FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID])
);

