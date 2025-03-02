CREATE TABLE Notifications (
    NotificationID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
    NotificationType NVARCHAR(50) NOT NULL, -- (mention, like, retweet, follow, message)
    ReferenceID UNIQUEIDENTIFIER NOT NULL, -- (TweetID, UserID, MessageID)
    IsRead BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETUTCDATE()
);