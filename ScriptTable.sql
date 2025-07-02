IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_ValueList' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE SYS_ValueList (
    ListName varchar(50),
    Language NVARCHAR(10) UNIQUE NOT NULL,
    Value NVARCHAR(max) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_SYS_ValueList PRIMARY KEY (ListName, Language)
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_Color' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE SYS_Color (
    ColorCode varchar(20) PRIMARY KEY,
    ColorName nvarchar(100),
    ColorName2 nvarchar(100),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Categories (
    CategoryCode varchar(20) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    CategoryNameEN NVARCHAR(100),
    Description NVARCHAR(255),
    IsActive BIT DEFAULT (1),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_StorageGroup' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE SYS_StorageGroup (
    StorageGroupCode varchar(20) PRIMARY KEY,
    StorageGroupName nvarchar(100),
    StorageGroupName2 nvarchar(100),
    CategoryCode varchar(20) FOREIGN KEY REFERENCES Categories(CategoryCode),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_Storage' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE SYS_Storage (
    StorageCode varchar(20) PRIMARY KEY,
    StorageName nvarchar(100),
    StorageName2 nvarchar(100),
    StorageGroupCode varchar(20) FOREIGN KEY REFERENCES SYS_StorageGroup(StorageGroupCode),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
);
END


IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    Phone NVARCHAR(20),
    Role NVARCHAR(20) DEFAULT 'User',
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY,
    CategoryCode VARCHAR(20) FOREIGN KEY REFERENCES Categories(CategoryCode),
    ProductName NVARCHAR(200) NOT NULL,
    ProductNameEN NVARCHAR(200),
    Description NVARCHAR(MAX),
    ProductVersion INT not NULL,
    BasePrice DECIMAL(18,2),
    Rating FLOAT,
    IsActive BIT DEFAULT (1),
    CreatedAt DATETIME DEFAULT GETDATE()
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductVariants' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
CREATE TABLE ProductVariants (
    VariantId INT PRIMARY KEY IDENTITY,
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    ColorCode VARCHAR(20) FOREIGN KEY REFERENCES SYS_Color(ColorCode),
    Storages NVARCHAR(200), -- (chip1,ram1,rom2,...)
    Price DECIMAL(18,2),
    Discount FLOAT CHECK (Discount >= 0),--0.12
    NewPrice AS (1.0*Price - Price*Discount) PERSISTED,
    VariantVersion INT not NULL,
    IsActive BIT DEFAULT (1),
    Stock INT
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductImages' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE ProductImages (
      ImageId INT PRIMARY KEY IDENTITY,
      ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
      ImageUrl NVARCHAR(255)
  );
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductVariantImages' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE ProductVariantImages (
      ImageId INT PRIMARY KEY IDENTITY,
      VariantId INT FOREIGN KEY REFERENCES ProductVariants(VariantId),
      ImageUrl NVARCHAR(255)
  );
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductTracking' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE ProductTracking (
    ID BIGINT PRIMARY KEY IDENTITY,
    ProductId INT,
    ProductVersion INT,
    CategoryCode VARCHAR(20) FOREIGN KEY REFERENCES Categories(CategoryCode),
    ProductName NVARCHAR(200) NOT NULL,
    ProductNameEN NVARCHAR(200),
    Description NVARCHAR(MAX),
    BasePrice DECIMAL(18,2),
    Rating FLOAT,
    CreatedAt DATETIME DEFAULT GETDATE()
);

  ALTER TABLE ProductTracking
  ADD CONSTRAINT UQ_ProductTracking_ProductId_ProductVersion UNIQUE (ProductId, ProductVersion);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductVariantTracking' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
CREATE TABLE ProductVariantTracking (
    ID BIGINT PRIMARY KEY IDENTITY,
    VariantId INT,
    VariantVerion INT,
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Color NVARCHAR(50),
    Storage NVARCHAR(50),
    Price DECIMAL(18,2),
    Discount INT CHECK (Discount >= 0),
    NewPrice AS (Price - Price*Discount) PERSISTED,
    Stock INT
);

  ALTER TABLE ProductVariantTracking
  ADD CONSTRAINT UQ_ProductVariantTracking_VariantId_VariantVerion UNIQUE (VariantId, VariantVerion);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Carts' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Carts (
    CartId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    CreatedAt DATETIME DEFAULT GETDATE()
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CartItems' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE CartItems (
    CartItemId INT PRIMARY KEY IDENTITY,
    CartId INT FOREIGN KEY REFERENCES Carts(CartId),
    VariantId INT FOREIGN KEY REFERENCES ProductVariants(VariantId),
    VariantVersion INT,
    Quantity INT
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Favorites' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Favorites (
      FavoriteId INT PRIMARY KEY IDENTITY,
      UserId INT FOREIGN KEY REFERENCES Users(UserId),
      VariantId INT FOREIGN KEY REFERENCES ProductVariants(VariantId)
      -- luôn lấy phiên bản mới nhất của sản phẩm
  );
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Vouchers' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Vouchers (
    VoucherId INT PRIMARY KEY IDENTITY,
    Code NVARCHAR(50) UNIQUE NOT NULL,
    Description NVARCHAR(255),
    DiscountType NVARCHAR(20), -- Percentage, FixedAmount
    DiscountValue DECIMAL(18,2),
    MinOrderAmount DECIMAL(18,2),
    StartDate DATE,
    EndDate DATE,
    IsActive BIT DEFAULT 1
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Orders' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Pending',
    TotalAmount DECIMAL(18,2),
    VoucherId INT NULL FOREIGN KEY REFERENCES Vouchers(VoucherId)
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'OrderItems' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    CREATE TABLE OrderItems (
    OrderItemId INT PRIMARY KEY IDENTITY,
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
    VariantId INT FOREIGN KEY REFERENCES ProductVariants(VariantId),
    VariantVersion INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShippingInfo' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
CREATE TABLE ShippingInfo (
    ShippingInfoId INT PRIMARY KEY IDENTITY,
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
    RecipientName NVARCHAR(100),
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Note NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);
END

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Reviews' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE Reviews (
      ReviewId INT PRIMARY KEY IDENTITY,
      UserId INT FOREIGN KEY REFERENCES Users(UserId),
      ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
      Rating INT CHECK (Rating BETWEEN 1 AND 5),
      Comment NVARCHAR(1000),
      CreatedAt DATETIME DEFAULT GETDATE()
  );
END


IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserVouchers' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  CREATE TABLE UserVouchers (
    UserVoucherId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    VoucherId INT FOREIGN KEY REFERENCES Vouchers(VoucherId),
    UsedAt DATETIME DEFAULT GETDATE()
);
END