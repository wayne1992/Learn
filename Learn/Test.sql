
GO
CREATE TABLE [dbo].[Test] (
[TestId] int NOT NULL IDENTITY(1,1) ,
[TestName] varchar(255) NULL ,
[TestIsDeleted] bit NULL DEFAULT ((0)) ,
[TestCategoryId] int NULL 
)


GO

-- ----------------------------
-- Records of Test
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Test] ON
GO
SET IDENTITY_INSERT [dbo].[Test] OFF
GO

-- ----------------------------
-- Table structure for TestCategory
-- ----------------------------

GO
CREATE TABLE [dbo].[TestCategory] (
[TestCategoryId] int NOT NULL IDENTITY(1,1) ,
[TestCategoryName] varchar(255) NULL ,
[TestCategoryIsDeleted] bit NULL DEFAULT ((0)) 
)


GO

-- ----------------------------
-- Records of TestCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[TestCategory] ON
GO
SET IDENTITY_INSERT [dbo].[TestCategory] OFF
GO

-- ----------------------------
-- Indexes structure for table Test
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Test
-- ----------------------------
ALTER TABLE [dbo].[Test] ADD PRIMARY KEY ([TestId])
GO

-- ----------------------------
-- Indexes structure for table TestCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TestCategory
-- ----------------------------
ALTER TABLE [dbo].[TestCategory] ADD PRIMARY KEY ([TestCategoryId])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Test]
-- ----------------------------
ALTER TABLE [dbo].[Test] ADD FOREIGN KEY ([TestCategoryId]) REFERENCES [dbo].[TestCategory] ([TestCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
