CREATE TABLE [dbo].[Lecture] (
    [lectureID]          INT           IDENTITY (1, 1) NOT NULL,
    [userID]             INT           NULL,
    [groupID]            INT           NULL,
    [lectureTitle]       VARCHAR (200) NULL,
    [lectureDescription] VARCHAR (MAX) NULL,
    [lectureDate] DATETIME NULL, 
    [lectureLink] VARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([lectureID] ASC),
    FOREIGN KEY ([groupID]) REFERENCES [dbo].[Group] ([groupID]),
    FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID])
);

