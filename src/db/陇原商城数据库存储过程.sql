--实现用户的注册信息，用户ID是自动生成的
use ShopLine
go
 --datepart函数表示指定日期的指定日期部分的整数。
 --@@RowCount函数返回受上一行影响的行数
create procedure p_RegisterUserLogin
(
@nickName varchar(30),
@loginPassWord varchar(32),
@faceID int,
@sex varchar(10),
@age varchar(50),
@country varchar(20),
@provicnce varchar(20),
@phone varchar(50),
@mobile varchar(50),
@email varchar(20),
@qq varchar(30),
@note varchar(100),
@userID int output,
@error int output
)
as
declare @count int
set @count=0
loop:  
	select @userID = rand( (datepart(mm, getdate()) *31230000 )
		+ (datepart(ss, getdate()) * 600000 )
		+ datepart(ms, getdate())) * 2000000 + 1010000000+@count
	select * from UserAccount where userID = @userID
	if @@RowCount<>0 
	begin
		set @count=@count+1
		if @count=20
	begin
		set @error=1
		return
	end
	goto loop
end
insert into UserAccount(userID,nickName,loginPassWord,insurePassWord,faceID,sex,age,country,provicnce,phone,mobile,email,qq,note,userType,userOrder)
values(@userID,@nickName,@loginPassword,@loginPassword,@faceID,@sex,@age,@country,@provicnce,@phone,@mobile,@email,@qq,@note,1,100)
set @error=0
go

--实现用户的登录
alter procedure p_UserLogin
(
@nickName varchar(30),
@loginPassWord varchar(32),
@userType int,
@lastLoginIP varchar(32),
@error varchar(50) output
)
as
declare @pwd varchar(32)
--1.根据用户名登录  2.根据用户邮箱登录
 if(@userType=1)
	begin
		select top 1 userID from UserAccount where nickName=@nickName
		if(@@Rowcount=0)
			begin
				set @error='用户不存在'
				return
			end
		select top 1 userID,nickName,userType from userAccount where nickName=@nickName and loginPassWord=@loginPassWord
		if(@@Rowcount=0)
			begin
				set @error='用户密码错误'
				return
			end
	end
else if(@userType=2)
	begin
		select top 1 userID from userAccount where email=@nickName
		if(@@Rowcount=0)
		begin
			set @error='此邮箱不存在'
			return
		end
	select top 1 userID,email,userType from userAccount where email=@nickName and loginPassWord=@loginPassWord
		if(@@Rowcount=0)
		begin
			set @error='用户密码错误'
			return
		end
	end
else
	begin
		return
	end
set @error=''
go

---实现管理员的注册功能
create procedure P_ReguisterAdmin
(
@adminName varchar(50),
@adminPwd varchar(32),
@adminType smallint,
@adminGroupID int,
@lastLoginIP varchar(32),
@lastLoginTime datetime,
@isEnabled smallint,
@result int output
)
as
if exists(select adminID from Admin where AdminName=@AdminName)
begin
	select @result=-2  --普通管理用户名已经存在
	return
end
insert into Admin(adminName,adminPwd,adminType,adminGroupID,lastLoginIP,lastLoginTime,isEnabled)
values(@adminName,@adminPwd,@adminType,@adminGroupID,@lastLoginIP,@lastLoginTime,@isEnabled)
if(@@rowcount=1)
	begin
		select @result=1 --普通管理用户名已经存在
		return
	end
else
	begin
		select @result=-1 --普通管理用户名已经存在
		return
	end
go

--删除管理员
create procedure p_DeleteAdmin
(
@adminID int
)
as
delete Admin where adminID=@adminID
go

--实现后台管理员的登录功能
create procedure P_AdminLogin
(
@adminName varchar(50),
@adminPwd varchar(32),
@lastLoginIP varchar(32),
@error varchar(50) output
)
as
declare @pwd varchar(32)
select top 1 adminID from Admin where adminName=@adminName and IsEnabled=1
if(@@rowcount=0)
begin
	set @error='管理员不存在或者被禁用'
	return
end
select top 1 adminID,adminName,adminType from Admin where adminName=@adminName and adminPwd=@adminPwd
if(@@rowcount=0)
begin
	set @error='管理员密码输入错误,请检查!'
	return
end
	set @error=''
go

--实现添加商品的功能
create procedure P_AddProduct
(
@proNumber varchar(50),
@ProductName nvarchar(50),
@keyWord nvarchar(100),
@productCategoryID int,
@categoryName nvarchar(50),
@parentIDRoute nvarchar(250),
@parentNameRoute nvarchar(250),
@productImage nvarchar(100),
@currentPrice smallmoney,
@price smallmoney,
@menberPrice smallmoney,
@danwei nvarchar(10),
@productStore int,
@productDesc ntext,
@remainDay int,
@clickNum int,
@isReviewEnable int,
@isPost smallint,
@isCommend smallint,
@addTime datetime,
@linkQQid varchar(30),
@linkQQName nvarchar(30),
@freightType char(1),
@freight smallmoney,
@AdminID int,
@result  int output
)
as
insert into Product(proNumber,ProductName,keyWord,productCategoryID,categoryName,parentIDRoute,parentNameRounte,productImage,currentPrice,price,menberPrice,danwei,productStore,productDesc,remainDay,clickNum,isReviewEnable,isPost,isCommend,addTime,linkQQid,linkQQName,freightType,freight,AdminID)
values(@proNumber,@ProductName,@keyWord,@productCategoryID,@categoryName,@parentIDRoute,@parentNameRoute,@productImage,@currentPrice,@price,@menberPrice,@danwei,@productStore,@productDesc,@remainDay,@clickNum,@isReviewEnable,@isPost,@isCommend,@addTime,@linkQQid,@linkQQName,@freightType,@freight,@AdminID)
if(@@rowCount=1)
begin
	update ProductClass set ProductNum=ProductNum+1 where Id=@ProductCategoryId
	declare @newParentIdRoute varchar(250)
	declare @lenValue int
	set @lenValue=len(ltrim(rtrim(@ParentIdRoute))) 
	
	if(@lenValue>2)
	begin 
		set @newParentIdRoute= substring(@ParentIdRoute,2,@lenValue-2) 
		update ProductClass set ProductNum=ProductNum+1 where Id in(@newParentIdRoute)
	end
	Select @result =1
	return
end
else
begin
	Select @result =-1
	return
end
go 

alter Procedure p_PageList
(
	@TableName		nvarchar(300),	/*表名*/
	@PKey			nvarchar(50),	/*主键 默认 id*/
	@FieldList		nvarchar(500),	/*需要搜索的字段 */
	@Condition		nvarchar(1000),	/*条件 比如 And a=1*/
	@OrderBy		nvarchar(250),	/*排序 Order By id*/
	@Sql			nvarchar(1000),	/*这个可以不传，也可以传，程序会自动生成搜索语句的*/
	@SqlGetRC		nvarchar(1000),	/*得到总数的SQL语句，可以不传，也可以指定*/
	@CurrPage		int,	/*当前页*/
	@PageSize		int, 	/*每页条目*/
	@RecordCount		int,	/*总数 可以传，也可以不传*/
	@Result			int	Output
)
AS
Declare @PageCount int


if @SqlGetRC=''
	Set @SqlGetRC = 'SELECT @RecordCount=COUNT(0) FROM ' + @TableName + @Condition
if @RecordCount=-1
	begin
	exec sp_executesql @SqlGetRC,N'@RecordCount int out',@RecordCount out
	end
	
Set @PageCount = (@RecordCount + @PageSize - 1) / @PageSize

if @CurrPage>@PageCount And @PageCount>0
	Set @CurrPage=@PageCount


if @Sql = ''
Begin
	if @PageSize=0
		Set @PageSize = 10
		
	if @CurrPage=1
		Set @Sql = 'SELECT TOP ' + Cast(@PageSize as nvarchar) + ' ' + @FieldList + ' FROM ' + @TableName + @Condition + ' ' + @OrderBy
	else
		Set @Sql = 'SELECT TOP ' + Cast(@PageSize as nvarchar) + ' ' + @FieldList + ' FROM ' + @TableName + ' WHERE ' + @Pkey + ' NOT IN (SELECT TOP ' + Cast((@CurrPage-1)*@PageSize as nvarchar) + ' ' + @Pkey + ' FROM ' + @TableName + ' ' + @Condition + ' ' + @OrderBy + ') ' + replace(@Condition,' WHERE 1=1',' ') + ' ' + @OrderBy
End
exec(@Sql)

Select RecordCount=@RecordCount,PageCount=@PageCount

Set  @Result=1


create Procedure D_PageList
(
	@TableName		nvarchar(300),	/*表名*/
	@PKey			nvarchar(50),	/*主键 默认 id*/
	@FieldList		nvarchar(500),	/*需要搜索的字段 */
	@Condition		nvarchar(1000),	/*条件 比如 And a=1*/
	@OrderBy		nvarchar(250),	/*排序 Order By id*/
	@Sql			nvarchar(1000),	/*这个可以不传，也可以传，程序会自动生成搜索语句的*/
	@SqlGetRC		nvarchar(1000),	/*得到总数的SQL语句，可以不传，也可以指定*/
	@CurrPage		int,	/*当前页*/
	@PageSize		int, 	/*每页条目*/
	@RecordCount		int,	/*总数 可以传，也可以不传*/
	@Result			int	Output
)
AS
Declare @PageCount int


if @SqlGetRC=''
	Set @SqlGetRC = 'SELECT @RecordCount=COUNT(0) FROM ' + @TableName + @Condition
if @RecordCount=-1
	begin
	exec sp_executesql @SqlGetRC,N'@RecordCount int out',@RecordCount out
	end
	
Set @PageCount = (@RecordCount + @PageSize - 1) / @PageSize

if @CurrPage>@PageCount And @PageCount>0
	Set @CurrPage=@PageCount


if @Sql = ''
Begin
	if @PageSize=0
		Set @PageSize = 10
		
	if @CurrPage=1
		Set @Sql = 'SELECT TOP ' + Cast(@PageSize as nvarchar) + ' ' + @FieldList + ' FROM ' + @TableName + @Condition + ' ' + @OrderBy
	else
		Set @Sql = 'SELECT TOP ' + Cast(@PageSize as nvarchar) + ' ' + @FieldList + ' FROM ' + @TableName + ' WHERE ' + @Pkey + ' NOT IN (SELECT TOP ' + Cast((@CurrPage-1)*@PageSize as nvarchar) + ' ' + @Pkey + ' FROM ' + @TableName + ' ' + @Condition + ' ' + @OrderBy + ') ' + replace(@Condition,' WHERE 1=1',' ') + ' ' + @OrderBy
End
exec(@Sql)

Select RecordCount=@RecordCount,PageCount=@PageCount

Set  @Result=1
go

--实现删除产品功能的存储过程
create Procedure p_DeleteProduct
(
	@TableName		varchar(50),
	@Conditions		varchar(500),
	@Result	int	Output
)
AS
declare   @delStr   varchar(650)   
Set @Result = -1
set   @delStr   =   'Delete From ['+@TableName+'] Where 1=1  '+@Conditions
 exec(@delStr) 
Set @Result=1
go

--实现上架产品的功能
alter procedure p_groundingShopPing
(
@TableName varchar(50),
@UpDateFields varchar(250),
@Conditions nvarchar(500),
@Result int output
)
as 
declare @sqlStr char(1000)
 Set @SqlStr = 'Update  ['+@TableName+'] Set '+ @UpDateFields+'  Where 1=1 '+@Conditions
exec (@sqlStr)
set @Result=1
go

select * from product

update product set  isPost=1  add isPost=0 and productID in(12)

--实现跳转页面的时候显示所有的信息
create procedure p_skipProduct
(
@productID int,
@Result int output
)
as 
if not exists(select productID from product where productID=@productID)
begin
	select @Result=-1
	return
end
update product set clickNum=clickNum+1 where productID=@productID
select * from product where productID=@productID
set @Result=1

--实现产品的更新功能
create procedure p_UpdateShopping
(
@productID int,
@proNumber varchar(50),
@ProductName nvarchar(50),
@keyWord nvarchar(100),
@productCategoryID int,
@categoryName nvarchar(50),
@parentIDRoute nvarchar(250),
@parentNameRounte nvarchar(250),
@productImage nvarchar(100),
@currentPrice smallmoney,
@price smallmoney,
@menberPrice smallmoney,
@danwei nvarchar(10),
@productStore int,
@productDesc ntext,
@remainDay int,
@clickNum int,
@isReviewEnable int,
@isPost smallint,
@isCommend smallint,
@addTime datetime,
@linkQQid varchar(30),
@linkQQName nvarchar(30),
@freightType char(1),
@freight smallmoney,
@AdminID int,
@result  int output
)
as
If Not Exists(Select ProductID From Product Where ProductId = @ProductId)
Begin
	Select @Result = -2
	Return
End

update product set proNumber=@proNumber,ProductName=@ProductName,
keyWord=@keyWord,productCategoryID=@productCategoryID,
categoryName =@categoryName,parentIDRoute=@parentIDRoute,
parentNameRounte=@parentNameRounte,productImage=@productImage,
currentPrice=@currentPrice,price=@price,menberPrice=@menberPrice,
danwei=@danwei,productStore=@productStore,productDesc=@productDesc,
remainDay=@remainDay,clickNum=@clickNum,isReviewEnable=@isReviewEnable,
isPost=@isPost,isCommend=@isCommend,addTime=@addTime,linkQQid=@linkQQid,
linkQQName=@linkQQName,freightType=@freightType,freight=@freight,
adminId = @AdminId where productID=@productID
if(@@rowcount=1)
begin
	select @result=1
	return
end
	select @result=-1
go


--实现前台推荐产品的绑定   
alter procedure p_indexBindtuijian
(
@classID int,   --产品类别
@isType smallint,  --种类
@TopNum varchar(50)  --取几条记录
)
as
if(@isType=1)
begin
	exec('select '+@TopNum+' productID,productName,productImage,currentPrice,menberPrice,danwei,remainDay,addTime from product
	where isCommend=1 and isPost=1 order by addTime desc')
end
go

--实现前台绑定的热门热荐商品 
alter procedure p_indexBindhottuijian
(
@classID int,   --产品类别
@isType smallint,  --种类
@TopNum varchar(50)  --取几条记录
)
as
if(@isType=1)
begin
	exec('select '+@TopNum+' productID,productName,productImage,currentPrice,menberPrice,danwei,remainDay,addTime from product
	where isCommend=1 and isPost=1 and remainDay<60 order by addTime desc')
end
go


--实现前台绑定各种类型的所有商品的个数   
alter procedure L_ProductListByIsTypeIndexShow
(
--1：IT数码  2：时尚饰品  3：玩具  4：美容护肤   5：家居生活  
--6：食品保健   7：图书音像 8：户外健身  9：服装鞋帽
@IsType smallint,
@topNum varchar(50) --从数据库中取几个数据
)
As
if(@IsType=1)   --IT数码
begin
	exec('Select '+ @topNum+' productID,productName,productImage,price,currentPrice,menberPrice,danwei,remainDay,addTime from product
		where ispost=1 and  CategoryName=''IT数码'' order by AddTime desc')
	return
end
if(@IsType=2)   --2：时尚饰品  
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addtime from product
		where ispost=1 and CategoryName=''鞋包饰品'' order by AddTime desc')
	return
end
if(@IsType=3)   --3：玩具 
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''玩具'' order by AddTime desc')
		return
end
if(@IsType=4)   --4：美容护肤 
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''美容护肤'' order by AddTime desc')
		return
end
if(@IsType=5)   --5：家居生活 
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''家居生活'' order by AddTime desc')
		return
end
if(@IsType=6)   --6：食品保健
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''食品保健'' order by AddTime desc')
		return
end
if(@IsType=7)   --   7：图书音像 
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''图书音像'' order by AddTime desc')
		return
end
if(@IsType=8)   -- 8：户外健身
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''户外健身'' order by AddTime desc')
		return
end
if(@IsType=9)   --  9：服装鞋帽
begin
	exec('Select '+@topNum+' productID,productName,productImage,price,currentPrice,menberprice,danwei,remainDay,addTime from product
		where ispost=1 and CategoryName=''服装鞋帽'' order by AddTime desc')
		return
end
go

--根据商品编号查询商品信息
create procedure p_ProductGetInfoByProduct
(
	@productID int,
	@result int output
)
as
if not exists(select productID from product where productID=@productID)
begin 
	select @result=-1
	return
end

update product set clickNum=clickNum+1 where productID=@productID
select * from product where productID=@productID
set @result=1
go

--将产品加入到购物车
create procedure p_CartCreat
(
@userID int,
@CartID varchar(50),
@productID int,
@buyNum int,
@buyTime datetime,
@result int output
)
as
declare @countItems int
select @countItems=Count(productID) from Cart where productID=@productID and userID=@userID

if @countItems>0
	begin
	    select @result=20  --此产品在购物车中已经存在
		return;
	end
else
	begin
		declare @NewCardId varchar(50)
		select top 1 @NewCardId=CartID From Cart where userID=@userID
		if(@NewCardId is null)
			begin
				set @NewCardId=@CartID
			end
		Insert into Cart(userID,CartID,productID,buyNum,buyTime) 
		values(@userID,@CartID,@productID,@buyNum,@buyTime)
		if(@@rowcount=1)
			begin
				select @result=10  --加入购物车成功
				return;
			end
		else
			begin
				select @result=-1
				return;
			end
	end
go

--下订单的时候读取总共购买所花的钱数  *重点注意对象
alter procedure p_DisplayShoppingCartInfo
(
	@userID int
)
as
	select pro.productID,pro.ProductName,pro.ProductImage as ProSmallPath,
	cartID,buyNum,buyTime,pro.menberPrice,pro.danwei,
	(pro.menberPrice*buyNum) as MoneyAmount,Pro.freight
    from Product as pro inner join Cart on userID=@userID
where cart.ProductID=pro.ProductID and userID=@userID order by buyTime

/*计算购物总金额*/
select  sum(pro.menberprice*cart.buyNum+pro.freight) as MoneyTotle,
sum(pro.freight) as freightTotal from Product
 as pro Inner join cart on userID=@userID where 
cart.productID=pro.ProductID and userID=@userID
go

--删除购物车中的不需要的产品
create procedure p_DeleteShoppingCartItem
(
	@userID int,
	@cartID varchar(50),
	@productID int
)
as
Delete From Cart where userID=@userID and ProductID=@productID
go


--修改购买商品的数量的总数，并返回总的钱数
create procedure p_UpdateShoppingNumMoney
(
@userID int,
@productID int,
@buyNum int,
@MoneyTotal SmallMoney output
)
as
Update Cart Set buyNum=@buyNum where userID=@userID and productID=@productID  

--刷新购物列表
exec p_DisplayShoppingCartInfo @userID
go

--添加收货地址
create procedure P_AcceptAddrInsert
(
@userID int,
@realityName varchar(50),
@rowAddr varchar(200),
@provinceID int,
@province varchar(50),
@cityID int,
@city varchar(50),
@countryID int,
@country varchar(50),
@tel varchar(50),
@handSet varchar(50),
@zipCode varchar(20),
@qqNum varchar(30),
@postTime datetime,
@result int output
)
as
Declare @CountItems int
Select @CountItems=count(id) from AcceptAddr where userID=@userID
if(@CountItems>=10)
begin
	select @result=0
	return
end
Insert Into AcceptAddr(userID,realityName,rowAddr,provinceID,province,cityID,city,countryID,country,tel,handSet,zipCode,qqNum,postTime)
values(@userID,@realityName,@rowAddr,@provinceID,@province,@cityID,@city,@countryID,@country,@tel,@handSet,@zipCode,@qqNum,@postTime)
if(@@Rowcount=1)
	begin
		select @result=1
		return
	end
else
	begin
		select @result=2
		return
	end
go

--修改收货地址  有充分的判断条件
alter procedure P_AcceptAddrUpdate
(
	@ID int,
	@userID int,
	@realityName varchar(50),
	@rowAddr varchar(200),
	@provinceID int,
	@province varchar(50),
	@cityID int,
	@city varchar(50),
	@countryID int,
	@country varchar(50),
	@tel varchar(50),
	@handSet varchar(50),
	@zipCode varchar(20),
	@qqNum varchar(30),
	@postTime datetime,
	@result int output
)
as

if not exists(select id From AcceptAddr where id=@id)
	begin
		select @result=-1
		return
	end
Update AcceptAddr Set realityName=@realityName,rowAddr=@rowAddr,
		provinceID=@provinceID,province=@province,cityID=@cityID,
		city=@city,countryID=@countryID,country=@country,tel=@tel,handSet=@handSet,
		zipCode=@zipCode,qqNum=@qqNum,postTime=@postTime 
		where id=@ID and userID=@userID
if(@@rowcount=1)
	begin
		Select @result=1
	end
else
	begin
		select @result=-1
	end
go

--根据编号删除订单信息
create procedure P_EmptyShoppingCart
(
	@CartID varchar(50)
)
AS
Delete From Cart where CartID=@CartID

--提交订单信息
alter procedure p_OrderListCreate
(
	@orderID varchar(50),
	@userID int,
	@acceptName nvarchar(50),
	@acceptAddr varchar(200),
	@handset varchar(50),
	@tel varchar(50),
	@zipCode varchar(20),
	@orderTime Datetime,
	@shippedTime Datetime,
	@orderState smallint,
	@isNew smallint,
	@adminID int,
	@result int output
)
as
Declare @cartID varchar(50)
Select top 1 @cartID=cartID From Cart where userID=@userID
if(@cartID is null)
	begin
		select @result=-3   --还没有购物车
		return
	end
if exists(Select orderID From OrderList where orderID=@orderID)
	begin
		select @result=0 --订单的编号重复
		return
	end
if not exists(Select id From Cart where userID=@userID and cartID=@cartID)
	begin
		Select @result=-2 --购物车中还没有产品
		return
	end

Begin Tran OrderAdd
Insert Into OrderList(orderID,userID,acceptName,acceptAddr,handset,
		tel,zipCode,orderTime,orderState,isNew,adminID)
values(@orderID,@userID,@acceptName,@acceptAddr,@handset,
		@tel,@zipCode,@orderTime,@orderState,@isNew,@adminID)

Insert Into OrderDetail
(
	orderID,productID,proNumber,memberPrice,bugNum,discount,freignType,freign
)
Select @orderID,Cart.productID,Product.ProNumber,
Product.MenberPrice,BuyNum,1 as discount,freightType,
freight From Cart Inner Join Product on Cart.productID=Product.productID 
where CartID=@cartID and userID=@userID 

exec P_EmptyShoppingCart @CartID

if(@@Error=0) --如果前一个SQL 语句执行没有错误，则返回 0。
	begin
		Commit Tran OrderAdd
		Select @result=10  --提交订单成功
		return
	end
else
	begin
		RollBack Tran OrderAdd
		Select @result=-1  --提交订单失败
		return
	end
go

--取消订单的时候将这些信息添加在OrderLog数据库中
create procedure p_orderLogUpdate
(
@orderID nvarchar(50),
@operateUserID int,
@userType smallint,
@operateType smallint,
@clientIP varchar(50),
@operateDepict nvarchar(50),
@operateTime datetime
)
AS
Insert Into OrderLog(orderID,operateUserID,userType,operateType,clientIp,operateDepict,operateTime)
values(@orderID,@operateUserID,@userType,@operateType,@clientIP,@operateDepict,@operateTime)
go

--用户修改自己本身的密码
create procedure p_ChangePwd
(
@nickName varchar(30),
@loginPassWord varchar(32)
)
as
update Users set loginPassWord=@loginPassWord where nickName=@nickName
go

--判断用户名密码是否正确
create proc p_CheckUser
@UserName varchar(16),
@Pwd varchar(32)
as
select * from Users where UserName=@UserName and Pwd=@Pwd