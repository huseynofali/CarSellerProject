

USE CarSellerDb
go
CREATE TABLE CarGalleries (
    GalleryID INT PRIMARY KEY identity(1,1),
    Name NVARCHAR(1024),
    Location NVARCHAR(1024),
    ContactEmail NVARCHAR(255),
    ContactPhone NVARCHAR(20)
);

CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    Make NVARCHAR(50),
    Model NVARCHAR(50),
    Year INT,
    Price DECIMAL(10, 2),
    Mileage INT,
    Color NVARCHAR(50),
    GalleryID INT,
    FOREIGN KEY (GalleryID) REFERENCES CarGalleries(GalleryID)
);
