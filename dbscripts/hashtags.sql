CREATE TABLE Hashtags (
    HashtagID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Hashtag NVARCHAR(100) UNIQUE NOT NULL
);