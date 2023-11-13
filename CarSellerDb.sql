

USE CarSellerDb
go
CREATE TABLE Users (
    Id INT PRIMARY KEY identity(1,1),
    Username NVARCHAR(1024),
    PasswordHash NVARCHAR(1024),
    Email NVARCHAR(255)
);
go
CREATE TABLE CarGalleries (
    GalleryID INT PRIMARY KEY identity(1,1),
    Name NVARCHAR(1024),
    Location NVARCHAR(1024),
    ContactEmail NVARCHAR(255),
    ContactPhone NVARCHAR(20)
);
go
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

USE CarSellerDb;

INSERT INTO CarGalleries (Name, Location, ContactEmail, ContactPhone)
VALUES 
    ('Toyota Azerbaycan', 'Cefer Xandan 42B', 'toyotaazerbaycan@gmail.com', '+99450-555-11-22'),
    ('Xan Auto', 'Nizami kuc 2A', 'xanauto@gmail.com', '+99477-232-32-32');

INSERT INTO Cars (Make, Model, Year, Price, Mileage, Color, GalleryID)
VALUES 
    ('Toyota', 'Camry', 2020, 25000.00, 30000, 'Qara', 1),
    ('Toyota', 'Corolla', 2019, 22000.00, 25000, 'Qirmizi', 1),
    ('Hyundai', 'Elantra', 2021, 28000.00, 20000, 'Yas Asfalt', 2),
    ('Chevrolet', 'Malibu', 2018, 20000.00, 35000, 'Qara', 2),
    ('Mercedes-Benz', 'E-Class', 2022, 55000.00, 15000, 'Ag', 2);

