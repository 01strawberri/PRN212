
CREATE DATABASE PRN212HotelManagement;
GO


USE PRN212HotelManagement;
GO

-- Bảng User
CREATE TABLE [User] (
  userId INT IDENTITY(1,1) PRIMARY KEY,
  userName VARCHAR(100) NOT NULL,
  userEmail VARCHAR(100) UNIQUE NOT NULL,
  userPassword VARCHAR(255) NOT NULL,
  userPhone VARCHAR(15),
  userRole INT NOT NULL,
  createdAt DATETIME DEFAULT GETDATE()
);

-- Bảng Rooms
CREATE TABLE Room (
  roomId INT IDENTITY(1,1) PRIMARY KEY,
  roomName VARCHAR(100) NOT NULL,
  roomType VARCHAR(50) NOT NULL,
  roomDescription VARCHAR(255),
  roomStatus VARCHAR(50) CHECK (roomStatus IN ('Available', 'Maintenance', 'Using')) NOT NULL,
  createdAt DATETIME DEFAULT GETDATE()
);

-- Bảng RoomPrices
CREATE TABLE RoomPrices (
  roomPriceId INT IDENTITY(1,1) PRIMARY KEY,
  roomId INT NOT NULL FOREIGN KEY REFERENCES Room(roomId),
  roomPricePerHour DECIMAL(10, 2) NOT NULL,
  roomPricePerDay DECIMAL(10, 2) NOT NULL,
  createdAt DATETIME DEFAULT GETDATE()
);

-- Bảng Booking
CREATE TABLE Booking (
  bookingId INT IDENTITY(1,1) PRIMARY KEY,
  userId INT NOT NULL FOREIGN KEY REFERENCES [User](userId),
  roomId INT NOT NULL FOREIGN KEY REFERENCES Room(roomId),
  bookingStartDay DATE NOT NULL,
  bookingEndDay DATE NOT NULL,
  bookingStartTime TIME NULL,
  bookingEndTime TIME NULL,
  bookingType VARCHAR(50) CHECK (bookingType IN ('ByHour', 'ByDay')) NOT NULL,
  totalPrice DECIMAL(10, 2) DEFAULT 0,
  bookingStatus VARCHAR(50) CHECK (bookingStatus IN ('Pending', 'Confirmed', 'Cancelled')) NOT NULL,
  createdAt DATETIME DEFAULT GETDATE()
);

-- Bảng Services
CREATE TABLE Services (
  serviceId INT IDENTITY(1,1) PRIMARY KEY,
  serviceType VARCHAR(50) NOT NULL,
  serviceName VARCHAR(100) NOT NULL,
  serviceDescription VARCHAR(255),
  servicePrice DECIMAL(10, 2) NOT NULL,
  serviceStatus VARCHAR(50) CHECK (serviceStatus IN ('Available', 'Unavailable')) NOT NULL,
  createdAt DATETIME DEFAULT GETDATE()
);


-- Bảng BookingServices
CREATE TABLE BookingServices (
  bookingServiceId INT IDENTITY(1,1) PRIMARY KEY,
  bookingId INT NOT NULL FOREIGN KEY REFERENCES Booking(bookingId),
  serviceId INT NOT NULL FOREIGN KEY REFERENCES Services(serviceId),
  servicePrice DECIMAL(10, 2) NOT NULL,
  createdAt DATETIME DEFAULT GETDATE()
);

-- Bảng PaymentMethod
CREATE TABLE PaymentMethod (
  methodId INT IDENTITY(1,1) PRIMARY KEY,
  methodName VARCHAR(50) NOT NULL
);

-- Bảng Payment
CREATE TABLE Payment (
  paymentId INT IDENTITY(1,1) PRIMARY KEY,
  bookingId INT NOT NULL FOREIGN KEY REFERENCES Booking(bookingId),
  methodId INT NOT NULL FOREIGN KEY REFERENCES PaymentMethod(methodId),
  totalPrice DECIMAL(10, 2) DEFAULT 0,
  paymentDate DATETIME DEFAULT GETDATE(),
  paymentStatus VARCHAR(50) CHECK (paymentStatus IN ('Pending', 'Completed')) NOT NULL
);

-- Bảng Transaction
CREATE TABLE [Transaction] (
  transactionId INT IDENTITY(1,1) PRIMARY KEY,
  bookingId INT NOT NULL FOREIGN KEY REFERENCES Booking(bookingId),
  userId INT NOT NULL FOREIGN KEY REFERENCES [User](userId),
  eventDescription VARCHAR(255),
  transactionType VARCHAR(50),
  transactionAmount DECIMAL(10, 2) DEFAULT 0,
  eventDate DATETIME DEFAULT GETDATE(),
  transactionStatus VARCHAR(50)
);

-- Bảng Feedback
CREATE TABLE Feedback (
  feedbackId INT IDENTITY(1,1) PRIMARY KEY,
  bookingId INT NOT NULL FOREIGN KEY REFERENCES Booking(bookingId),
  userId INT NOT NULL FOREIGN KEY REFERENCES [User](userId),
  rating INT CHECK (rating BETWEEN 1 AND 5),
  feedback VARCHAR(255),
  feedbackDate DATETIME DEFAULT GETDATE()
);
GO

--fill
INSERT INTO [User] (userName, userEmail, userPassword, userPhone, userRole) VALUES
('Admin', 'admin@example.com', '1', '123456789', 1),
('Staff', 'staff@example.com', '1', '123456789',2),
('Customer', 'customer@example.com', '1', '123456789', 3);

INSERT INTO Room (roomName, roomType, roomDescription, roomStatus) VALUES
('Deluxe Room', '2 beds', 'A luxurious room with sea view', 'Available'),
('Standard Room', '2 beds', 'A comfortable room with basic amenities', 'Available'),
('Suite Room', '1 bed', 'Spacious suite with premium services', 'Maintenance');

INSERT INTO RoomPrices (roomId, roomPricePerHour, roomPricePerDay) VALUES
(1, 25.00, 200.00),
(2, 15.00, 120.00),
(3, 50.00, 400.00);

INSERT INTO Services (serviceType,serviceName, serviceDescription, servicePrice, serviceStatus) VALUES
('Food & Drinks','Breakfast', 'Buffet breakfast with various options', 20.00, 'Available'),
('Transportation','Airport Pickup', 'Transportation from airport to hotel', 50.00, 'Available'),
('Wellness','Spa', 'Relaxing spa session for guests', 100.00, 'Unavailable');

INSERT INTO PaymentMethod (methodName) VALUES
('Credit Card'),
('Cash'),
('Online Banking');

