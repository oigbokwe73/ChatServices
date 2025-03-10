CREATE TABLE Retweets (
    RetweetID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
    OriginalTweetID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Tweets(TweetID) ON DELETE CASCADE,
    RetweetText NVARCHAR(280) NULL,
    RetweetedAt DATETIME DEFAULT GETUTCDATE()
);