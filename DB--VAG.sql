create database VirtualArtGalleryDB

use VirtualArtGalleryDB

-- Artwork Table
CREATE TABLE Artwork (
    ArtworkID INT IDENTITY(1,1) PRIMARY KEY, -- Primary Key
    Title VARCHAR(255) NOT NULL,
    Description VARCHAR(500) NULL,
    CreationDate DATE NULL,
    Medium VARCHAR(255) NULL,
    ImageURL VARCHAR(500) NULL,
    ArtistID INT NOT NULL, -- Foreign Key
    CONSTRAINT FK_Artwork_Artist FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
);

-- Artist Table
CREATE TABLE Artist (
    ArtistID INT IDENTITY(1,1) PRIMARY KEY, -- Primary Key
    Name VARCHAR(255) NOT NULL,
    Biography VARCHAR(1000) NULL,
    BirthDate DATE NULL,
    Nationality VARCHAR(100) NULL,
    Website VARCHAR(255) NULL,
    ContactInformation VARCHAR(255) NULL
);

-- User Table (without ProfilePicture column)
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY, -- Primary Key
    Username VARCHAR(50) NOT NULL UNIQUE,
    [Password] VARCHAR(255) NOT NULL, -- Encrypted hash recommended
    Email VARCHAR(255) NOT NULL UNIQUE,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    DateOfBirth DATE NULL
);

-- Junction Table for User-Favorite-Artwork (Many-to-Many)
CREATE TABLE User_Favorite_Artwork (
    UserID INT NOT NULL, -- Foreign Key
    ArtworkID INT NOT NULL, -- Foreign Key
    CONSTRAINT PK_User_Favorite_Artwork PRIMARY KEY (UserID, ArtworkID),
    CONSTRAINT FK_User_Favorite_Artwork_User FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_User_Favorite_Artwork_Artwork FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID)
);

-- Gallery Table
CREATE TABLE Gallery (
    GalleryID INT IDENTITY(1,1) PRIMARY KEY, -- Primary Key
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(500) NULL,
    Location VARCHAR(255) NULL,
    Curator INT NOT NULL, -- Foreign Key
    OpeningHours VARCHAR(255) NULL,
    CONSTRAINT FK_Gallery_Curator FOREIGN KEY (Curator) REFERENCES Artist(ArtistID)
);

-- Junction Table for Artwork-Gallery (Many-to-Many)
CREATE TABLE Artwork_Gallery (
    ArtworkID INT NOT NULL, -- Foreign Key
    GalleryID INT NOT NULL, -- Foreign Key
    CONSTRAINT PK_Artwork_Gallery PRIMARY KEY (ArtworkID, GalleryID),
    CONSTRAINT FK_Artwork_Gallery_Artwork FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID),
    CONSTRAINT FK_Artwork_Gallery_Gallery FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
);




-- Insert sample data into Artist table
INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInformation)
VALUES 
('Raja Ravi Varma', 'Famous Indian painter and artist known for combining European techniques with Indian aesthetics.', '1848-04-29', 'Indian', 'https://rajaravivarma.com', 'raja.ravi@example.com'),
('Amrita Sher-Gil', 'One of the most famous female painters of India and a pioneer in modern Indian art.', '1913-01-30', 'Indian', 'https://amritashergil.com', 'amrita.shergil@example.com'),
('M.F. Husain', 'Modern Indian painter known for his bold and vibrant works.', '1915-09-17', 'Indian', 'https://mfhusain.com', 'mf.husain@example.com');

-- Insert sample data into Artwork table
INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES
('Shakuntala', 'A painting depicting Shakuntala, one of the heroines of Mahabharata.', '1870-01-01', 'Oil on Canvas', 'https://example.com/shakuntala.jpg', 1),
('Self Portrait', 'A self-portrait of Amrita Sher-Gil.', '1930-03-15', 'Oil on Canvas', 'https://example.com/selfportrait.jpg', 2),
('Mahabharata Series', 'A series of paintings depicting scenes from the Mahabharata.', '1950-06-11', 'Acrylic on Canvas', 'https://example.com/mahabharata.jpg', 3);

-- Insert sample data into User table
INSERT INTO [User] (Username, [Password], Email, FirstName, LastName, DateOfBirth)
VALUES
('rohan123', 'password_hash_1', 'rohan@example.com', 'Rohan', 'Sharma', '1995-08-15'),
('megha.kapoor', 'password_hash_2', 'megha.kapoor@example.com', 'Megha', 'Kapoor', '1990-02-20'),
('arjun.kumar', 'password_hash_3', 'arjun.kumar@example.com', 'Arjun', 'Kumar', '1985-11-05');

-- Insert sample data into User_Favorite_Artwork table
INSERT INTO User_Favorite_Artwork (UserID, ArtworkID)
VALUES
(1, 1), -- Rohan Sharma likes 'Shakuntala'
(2, 3), -- Megha Kapoor likes 'Mahabharata Series'
(3, 2); -- Arjun Kumar likes 'Self Portrait'

-- Insert sample data into Gallery table
INSERT INTO Gallery (Name, Description, Location, Curator, OpeningHours)
VALUES
('National Art Gallery', 'A gallery showcasing the best of Indian paintings and sculptures.', 'New Delhi, India', 1, '10:00 AM - 6:00 PM'),
('Modern Art Museum', 'A museum dedicated to showcasing contemporary and modern art.', 'Mumbai, India', 2, '9:00 AM - 5:00 PM'),
('Heritage Art Museum', 'A museum showcasing heritage artworks and antiques.', 'Chennai, India', 3, '11:00 AM - 7:00 PM');

-- Insert sample data into Artwork_Gallery table
INSERT INTO Artwork_Gallery (ArtworkID, GalleryID)
VALUES
(1, 1), -- 'Shakuntala' is displayed in 'National Art Gallery'
(2, 2), -- 'Self Portrait' is displayed in 'Modern Art Museum'
(3, 3); -- 'Mahabharata Series' is displayed in 'Heritage Art Museum'

select * from Artwork