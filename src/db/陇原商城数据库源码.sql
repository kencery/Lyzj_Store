--创建陇原商城数据库
create database ShopLine
on
(
name='ShopLine_data',
filename='E:\大二第二学期\最后三周实训\Date\ShopLine_data.mdf',
size=3mb,
filegrowth=1mb,
maxsize=30mb
)
log on
(
name='ShopLine_log',
filename='E:\大二第二学期\最后三周实训\Date\ShopLine_log.ldf',
size=3mb,
filegrowth=1mb,
maxsize=30mb
)


use ShopLine
go
--创建用户表 (UserAccount)
create table UserAccount
(
id  int identity(1,1) primary key,
userID int not null ,
loginPassWord varchar(32) not null,
nickName varchar(50) not null,
userType int not null,
insurePassWord varchar(32) not null,
faceID int ,
sex varchar(10),
age varchar(50),
country varchar(20),
provicnce varchar(20),
phone varchar(50),
mobile varchar(50),
email varchar(20),
qq varchar(30),
note varchar(100),
userOrder int 
)
go

--创建管理员表(Admin)
create table Admin
(
adminID int identity(1,1) primary key,
adminName varchar(50) not null,
adminPwd varchar(32) not null,
adminType smallint not null,
adminGroupID int ,
lastLoginIP varchar(32),
lastLoginTime datetime,
isEnabled smallint
)
go

--用户接受货物地址表(AcceptAddr)
create table AcceptAddr
(
id int identity(1,1) primary key,
userID int,
realityName  varchar(50),
rowAddr varchar(200),
provinceID int,
province varchar(50),
cityID int,
city  varchar(50),
countryID int,
country varchar(50),
tel varchar(50),
handSet varchar(50),
zipCode varchar(20),
qqNum  varchar(30),
postTime datetime 
)
go

--公布告示表 (Bulletin)
create table Bulletin
(
id int identity(1,1) primary key,
bulletinTitle varchar(50),
bulletinContent varchar(2000),
isPost smallint, 
orderNum int,
postTime datetime
)
go

--集成表(Cart)
create table Cart
(
id int identity(1,1) primary key,
userID int,
CartID varchar(50),
productID int not null,
buyNum int not null,
buyTime datetime
)
go

--产品种类表(Category)
create table Category
(
productCategoryID int identity(1,1) primary key,
productCategoryName varchar(20),
parentID int,
categoryDepth int,
)
go

--产品表(Product)
create table Product
(
productID int identity(1,1) primary key,
proNumber varchar(50),
productName nvarchar(50) not null,
keyWord nvarchar(100),
productCategoryID int,
categoryName nvarchar(50),
parentIDRoute nvarchar(250),
parentNameRounte nvarchar(250),
productImage nvarchar(100) not null,
productsmallImage nvarchar(100) not null,
currentPrice smallmoney not null,
price smallmoney,
menberPrice smallmoney not null,
danwei nvarchar(10),
productStore int,
productDesc ntext,
remainDay int,
clickNum int,
isReviewEnable int,
isPost smallint,
isCommend smallint,
addTime datetime,
linkQQid varchar(30),
linkQQName nvarchar(30),
freightType char(1),
freight smallmoney,
AdminID int
)
go

--帮助分类表(HelpClass)
create table HelpClass
(
id int identity(1,1) primary key,
className varchar(50),
parentID int,
depth int,
rootid int,
orders int,
childCount int,
parentIDRount nvarchar(250),
parentNameRount nvarchar(250),
createTime datetime,
state int,
)
go

--订单明细表(OrderDetail)
create table OrderDetail
(
id bigint identity(1,1) primary key,
orderID nvarchar(50),
productID int,
proNumber varchar(20),
memberPrice money,
bugNum int,
discount float,
freignType char(1),
freign smallmoney
)
go

--订单记录表(OrderLog)
create table OrderLog
(
id int identity(1,1) primary key,
orderID nvarchar(50),
operateUserID int,
userType smallint,
operateType smallint,
clientIP varchar(50),
operateDepict nvarchar(50),
operateTime datetime
)
go

--订单或表(OrderList)
create table OrderList
(
orderID varchar(50) primary key,
userID int not null,
acceptName nvarchar(50),
acceptAddr varchar(200),
handset varchar(50),
tel varchar(50),
zipCode varchar(20),
orderTime datetime not null,
shippedTime datetime,
orderState smallint,
isNew smallint,
adminID int
)
go

--产品综合表
create table ProductClass
(
id int identity(1,1) primary key,
className varchar(50),
parentID int,
depth int,
rootID int,
orders int,
childCount int,
parentIDRoute nvarchar(250),
parentNameRoute nvarchar(250),
createTime datetime,
state int,
productNum int
)
go

--产品收集表
create table ProductCollection
(
id int identity(1,1) primary key,
userID int not null,
productID int not null,
postTime datetime
)
go

--产品图片表(ProductPhoto)
create table ProductPhoto
(
id int identity(1,1) primary key,
productID int,
productImages varchar(50),
productContent varchar(50),
addTime datetime
)
go

--网站帮助表
create table ShopHelp
(
helpID int identity(1,1) primary key,
helpTitle Nvarchar(50),
classID int,
className nvarchar(30),
parentIDRoute nvarchar(250),
parentNameRoute nvarchar(250),
helpContent ntext,
postTime datetime,
isPost smallint
)
go

--用户数量表(userScore)
create table UserScore
(
userID int identity(1,1) primary key,
bugScore int
)
go









