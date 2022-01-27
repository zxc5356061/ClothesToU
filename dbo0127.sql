/*
 Navicat SQL Server Data Transfer

 Source Server         : sql2019
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : .\sql2019:1433
 Source Catalog        : ClothesToU
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 27/01/2022 16:00:04
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

INSERT INTO [dbo].[Members] ([Id], [Account], [Password], [Name], [IsConfirmed], [ConfirmCode], [Mobile], [Address]) VALUES (N'9', N'uuu@gmail.com', N'0759201E5C36F39352066DC605F957A4B38D8B550957C90D3210A5726EF554A2', N'uu', N'1', N'653dda10ff254a11bf894e788a38e8e1', N'0911845531', N'台北市中山區')
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

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'19', N'4', N'大地色復古百褶裙', N'大地色復古百褶裙', N'3500', N'0', N'07e477010caa43da9145bd3562d01c58.jfif', N'0', N'M', N'杏', N'2022-01-27 13:54:08.737')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'20', N'4', N'包臀長裙', N'包臀長裙', N'2600', N'0', N'15f2a59c0c0e42dd87ad1fc51c7b3ec8.jfif', N'0', N'M', N'黑', N'2022-01-27 14:00:40.553')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'21', N'10', N'白色素面法式內衣', N'白色素面法式內衣', N'3550', N'0', N'f09eceae5679445b8eecf80d3af0f61c.jfif', N'0', N'F', N'白', N'2022-01-27 14:01:57.357')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'23', N'6', N'酒紅鱷魚紋亮面小包', N'酒紅鱷魚紋亮面小包', N'2870', N'0', N'73cf3e081b8446abb2f4f4ff115f08cf.jfif', N'0', N'F', N'酒紅', N'2022-01-27 14:06:55.287')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'24', N'1', N'麻花針織毛衣', N'麻花針織毛衣', N'3500', N'0', N'b3293682fadc49e6a9bac110a6108452.jfif', N'0', N'F', N'咖', N'2022-01-27 14:11:29.157')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'25', N'9', N'華麗圈圈耳環', N'華麗圈圈耳環', N'1200', N'0', N'8a2d945a39774d9e82502c807e21d4aa.jfif', N'0', N'F', N'金', N'2022-01-27 14:12:37.540')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'26', N'7', N'經典撞色跟鞋', N'經典撞色跟鞋', N'4800', N'0', N'7bc28b6e881747359dbe5cba5e99c9e1.jfif', N'0', N'F', N'米白', N'2022-01-27 14:16:13.920')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'27', N'1', N'高領坑條保暖上衣', N'高領坑條保暖上衣', N'2850', N'0', N'99c30fd0bd784cd3a6878f0f0041f310.jfif', N'0', N'F', N'綠', N'2022-01-27 14:17:30.847')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'28', N'10', N'墨綠質感棉內衣', N'墨綠質感棉內衣', N'2680', N'0', N'b9b4d0ffaedc4389a6c1b7719848627a.jfif', N'0', N'L', N'墨綠', N'2022-01-27 14:18:51.247')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'29', N'10', N'平口綁帶素色內衣', N'平口綁帶素色內衣', N'5200', N'0', N'c11b0feaf0614553ac576652190c3c6f.jfif', N'0', N'M', N'紫', N'2022-01-27 14:20:12.023')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'30', N'8', N'法式女伶排扣洋裝', N'法式女伶排扣洋裝', N'6300', N'0', N'6fb9407b413945aa8ed1138f59966ccf.jfif', N'0', N'F', N'米白', N'2022-01-27 14:26:04.187')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'31', N'9', N'珍珠垂墜耳環', N'珍珠垂墜耳環', N'980', N'0', N'31166d42d306438cb72c02ea36faf5f1.jfif', N'0', N'F', N'白', N'2022-01-27 14:27:42.747')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'32', N'4', N'紅色花朵開岔短裙', N'紅色花朵開岔短裙', N'2900', N'0', N'54ab6a0aa8284ea594af30121f8d63ff.jfif', N'0', N'S', N'紅', N'2022-01-27 14:29:37.023')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'33', N'8', N'貼身緞面洋裝', N'貼身緞面洋裝', N'6500', N'0', N'14365c758f584caeb405c0275a8f56f3.jfif', N'0', N'F', N'白', N'2022-01-27 14:31:38.190')
GO

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Description], [Price], [Stock], [FileName], [Status], [Size], [Color], [ModifiedTime]) VALUES (N'34', N'7', N'楔形粗跟羅馬涼鞋', N'楔形粗跟羅馬涼鞋', N'5500', N'0', N'5100e317979540159cceb1f80a629dc9.jfif', N'0', N'F', N'深咖', N'2022-01-27 14:33:09.447')
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
DBCC CHECKIDENT ('[dbo].[Members]', RESEED, 9)
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
DBCC CHECKIDENT ('[dbo].[Products]', RESEED, 34)
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


-- ----------------------------
-- Foreign Keys structure for table Products
-- ----------------------------
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [FK__Products__Catego__4AB81AF0] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

