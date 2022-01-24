/*
 Navicat Premium Data Transfer

 Source Server         : N1096810
 Source Server Type    : SQL Server
 Source Server Version : 15002080
 Source Host           : .\sql2019:1433
 Source Catalog        : ClothesToU
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002080
 File Encoding         : 65001

 Date: 22/01/2022 15:14:52
*/


-- ----------------------------
-- Table structure for CartItems
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CartItems]') AND type IN ('U'))
	DROP TABLE [dbo].[CartItems]
GO

CREATE TABLE [dbo].[CartItems] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [CartId] int  NOT NULL,
  [ProductId] int  NOT NULL,
  [Qty] int  NOT NULL
)
GO

ALTER TABLE [dbo].[CartItems] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of CartItems
-- ----------------------------
SET IDENTITY_INSERT [dbo].[CartItems] ON
GO

INSERT INTO [dbo].[CartItems] ([Id], [CartId], [ProductId], [Qty]) VALUES (N'1', N'1', N'3', N'2')
GO

INSERT INTO [dbo].[CartItems] ([Id], [CartId], [ProductId], [Qty]) VALUES (N'2', N'1', N'4', N'1')
GO

SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO


-- ----------------------------
-- Table structure for Carts
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Carts]') AND type IN ('U'))
	DROP TABLE [dbo].[Carts]
GO

CREATE TABLE [dbo].[Carts] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [MemberId] int  NOT NULL
)
GO

ALTER TABLE [dbo].[Carts] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Carts
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Carts] ON
GO

INSERT INTO [dbo].[Carts] ([Id], [MemberId]) VALUES (N'1', N'1')
GO

SET IDENTITY_INSERT [dbo].[Carts] OFF
GO


-- ----------------------------
-- Table structure for Categories
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type IN ('U'))
	DROP TABLE [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Name] nvarchar(20) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [DisplayOrder] int  NOT NULL
)
GO

ALTER TABLE [dbo].[Categories] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Categories
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Categories] ON
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'1', N'上身', N'1')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'4', N'下著', N'2')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'6', N'包包', N'3')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'7', N'鞋款', N'4')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'8', N'洋裝', N'5')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'9', N'飾品', N'6')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (N'10', N'內著', N'7')
GO

SET IDENTITY_INSERT [dbo].[Categories] OFF
GO


-- ----------------------------
-- Table structure for Members
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Members]') AND type IN ('U'))
	DROP TABLE [dbo].[Members]
GO

CREATE TABLE [dbo].[Members] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Account] nvarchar(20) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Password] nvarchar(64) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Name] nvarchar(20) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [IsConfirmed] bit DEFAULT 0 NOT NULL,
  [ConfirmCode] nvarchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS  NULL,
  [Mobile] nchar(10) COLLATE Chinese_Taiwan_Stroke_CI_AS  NULL,
  [Address] nvarchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Members] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'0: 未註冊; 1: 已註冊',
'SCHEMA', N'dbo',
'TABLE', N'Members',
'COLUMN', N'IsConfirmed'
GO


-- ----------------------------
-- Records of Members
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Members] ON
GO

INSERT INTO [dbo].[Members] ([Id], [Account], [Password], [Name], [IsConfirmed], [ConfirmCode], [Mobile], [Address]) VALUES (N'1', N'test@gmail.com', N'123', N'Tom', N'1', N'123', N'0900000000', N'TaipeiCity')
GO

INSERT INTO [dbo].[Members] ([Id], [Account], [Password], [Name], [IsConfirmed], [ConfirmCode], [Mobile], [Address]) VALUES (N'3', N'Barry@123.com', N'0759201E5C36F39352066DC605F957A4B38D8B550957C90D3210A5726EF554A2', N'Barry', N'1', N'd4efad3cdbb548b49db22c138eee9aa6', N'0900000000', N'TaipeiCity')
GO

INSERT INTO [dbo].[Members] ([Id], [Account], [Password], [Name], [IsConfirmed], [ConfirmCode], [Mobile], [Address]) VALUES (N'4', N'Tony@123.com.tw', N'0759201E5C36F39352066DC605F957A4B38D8B550957C90D3210A5726EF554A2', N'Tony', N'1', N'10f5e37656ba44719350bec5a3b739be', N'0900000000', N'Hsinchu')
GO

INSERT INTO [dbo].[Members] ([Id], [Account], [Password], [Name], [IsConfirmed], [ConfirmCode], [Mobile], [Address]) VALUES (N'5', N'Amy@123.com', N'0759201E5C36F39352066DC605F957A4B38D8B550957C90D3210A5726EF554A2', N'Amy', N'1', N'b312543e230b4943a33a30dcd62c1fc9', N'0900000000', N'New Taipei City')
GO

SET IDENTITY_INSERT [dbo].[Members] OFF
GO


-- ----------------------------
-- Table structure for OrderItems
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND type IN ('U'))
	DROP TABLE [dbo].[OrderItems]
GO

CREATE TABLE [dbo].[OrderItems] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [OrderId] int  NOT NULL,
  [ProductId] int  NOT NULL,
  [ProductName] nvarchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Qty] int  NOT NULL,
  [Price] int  NOT NULL
)
GO

ALTER TABLE [dbo].[OrderItems] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of OrderItems
-- ----------------------------
SET IDENTITY_INSERT [dbo].[OrderItems] ON
GO

INSERT INTO [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [Qty], [Price]) VALUES (N'1', N'2', N'4', N'testOrderItem', N'1', N'20')
GO

SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO


-- ----------------------------
-- Table structure for Orders
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type IN ('U'))
	DROP TABLE [dbo].[Orders]
GO

CREATE TABLE [dbo].[Orders] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [MemberId] int  NOT NULL,
  [Subtotal] int  NOT NULL,
  [CreatedTime] datetime DEFAULT getdate() NOT NULL,
  [Status] bit DEFAULT 1 NOT NULL,
  [RequestRefund] bit DEFAULT 0 NOT NULL,
  [RequestRefundTime] datetime DEFAULT getdate() NOT NULL,
  [Recipient] nvarchar(20) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [ShippingAddress] nvarchar(200) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [RecipientMobile] nchar(10) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Orders] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'0: 尚未出貨；1: 已出貨',
'SCHEMA', N'dbo',
'TABLE', N'Orders',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0: 未提出退貨；1: 要退貨。',
'SCHEMA', N'dbo',
'TABLE', N'Orders',
'COLUMN', N'RequestRefund'
GO


-- ----------------------------
-- Records of Orders
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Orders] ON
GO

INSERT INTO [dbo].[Orders] ([Id], [MemberId], [Subtotal], [CreatedTime], [Status], [RequestRefund], [RequestRefundTime], [Recipient], [ShippingAddress], [RecipientMobile]) VALUES (N'2', N'1', N'20', N'2022-01-17 16:59:22.000', N'0', N'0', N'2022-01-17 16:59:30.000', N'Irene', N'HsinchuCity', N'0900000000')
GO

SET IDENTITY_INSERT [dbo].[Orders] OFF
GO


-- ----------------------------
-- Table structure for Products
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type IN ('U'))
	DROP TABLE [dbo].[Products]
GO

CREATE TABLE [dbo].[Products] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [CategoryId] int  NOT NULL,
  [Name] nvarchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Description] nvarchar(2000) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Price] int  NOT NULL,
  [Stock] int DEFAULT 1 NOT NULL,
  [FileName] nvarchar(50) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Status] bit DEFAULT 1 NOT NULL,
  [Size] nvarchar(2) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [Color] nvarchar(10) COLLATE Chinese_Taiwan_Stroke_CI_AS  NOT NULL,
  [ModifiedTime] datetime DEFAULT getdate() NOT NULL
)
GO

ALTER TABLE [dbo].[Products] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'預設是1',
'SCHEMA', N'dbo',
'TABLE', N'Products',
'COLUMN', N'Stock'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0: 商品下架；1: 商品上架',
'SCHEMA', N'dbo',
'TABLE', N'Products',
'COLUMN', N'Status'
GO


-- ----------------------------
-- Records of Products
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Products] ON
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'3', N'1', N'testProduct', N'This is a test.', N'12', N'5', N'none', N'1', N'XL', N'Tiffany藍', N'2022-01-18 13:50:52.000')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'4', N'1', N'testProduct', N'This is another test.', N'120', N'3', N'none', N'1', N'M', N'粉紅', N'2022-01-18 13:50:48.000')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'7', N'1', N'testProduct4', N'test', N'8', N'8', N'none', N'1', N'M', N'白色', N'2022-01-18 13:52:02.253')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'11', N'0', N'ttt', N'ttt', N'1580', N'0', N'd3cdd56728b14ace81c73b48485a60c4.jfif', N'0', N'M', N'Black', N'2022-01-20 14:35:55.567')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'12', N'0', N'DRDTRHGUYGUYGU', N'rfdjeiorvjdsfjnvcjkijik', N'5200', N'0', N'f82fa4ed941a40d59aacce5ecd2023da.jfif', N'0', N'S', N'綠', N'2022-01-20 15:31:27.483')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'13', N'303', N'321', N'321321', N'11121', N'0', N'20c9d9940b3342e095b1e7468b42efe7.jfif', N'0', N'M', N'Black', N'2022-01-20 15:33:12.627')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'14', N'3', N'qqq', N'qqq', N'1111', N'0', N'0bc356bc86cd4b238aa739ac5310849f.jfif', N'0', N'M', N'White', N'2022-01-20 15:39:37.353')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'15', N'9', N'ppp', N'ppp', N'999', N'0', N'0dc2647091c74791a7ea5b1b1487b21e.jfif', N'0', N'M', N'Red', N'2022-01-20 15:42:48.383')
GO

SET IDENTITY_INSERT [dbo].[Products] OFF
GO


-- ----------------------------
-- Auto increment value for CartItems
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[CartItems]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table CartItems
-- ----------------------------
ALTER TABLE [dbo].[CartItems] ADD CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Carts
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Carts]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Carts
-- ----------------------------
ALTER TABLE [dbo].[Carts] ADD CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Categories
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Categories]', RESEED, 11)
GO


-- ----------------------------
-- Primary Key structure for table Categories
-- ----------------------------
ALTER TABLE [dbo].[Categories] ADD CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Members
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Members]', RESEED, 5)
GO


-- ----------------------------
-- Indexes structure for table Members
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_Members]
ON [dbo].[Members] (
  [Account] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Members
-- ----------------------------
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for OrderItems
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[OrderItems]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table OrderItems
-- ----------------------------
ALTER TABLE [dbo].[OrderItems] ADD CONSTRAINT [PK__OrderIte__3214EC07BA16DD61] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Orders
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Orders]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table Orders
-- ----------------------------
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Products
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Products]', RESEED, 15)
GO


-- ----------------------------
-- Primary Key structure for table Products
-- ----------------------------
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table CartItems
-- ----------------------------
ALTER TABLE [dbo].[CartItems] ADD CONSTRAINT [FK_CartItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[CartItems] ADD CONSTRAINT [FK_CartItems_Carts] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Carts] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Carts
-- ----------------------------
ALTER TABLE [dbo].[Carts] ADD CONSTRAINT [FK_Carts_Members] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table OrderItems
-- ----------------------------
ALTER TABLE [dbo].[OrderItems] ADD CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[OrderItems] ADD CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Orders
-- ----------------------------
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_Members] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

