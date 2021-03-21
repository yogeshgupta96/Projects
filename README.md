# ShopBridge

Please read the below instructions and follow the steps mentioned to configure Web API project named ‘Shop Bridge’ in the system. 

Tech Stack: Database- MS SQL Server 2019, IDE- Visual Studio 2019, ASP. Net Web API, Entity Framework.
Entity Framework has been used to read the data from the SQL database. CRUD operations logic has been implemented in the methods of API using LINQ queries. As we already have a existing database with table schema defined therefore ‘Database first’ approach has been used to create the EDM(Entity Data Model). Project has separate layer named ‘Data Access layer’ which contains number of functions doing CRUD operation using Entity Framework. In case any error comes while interacting with database, an exception would be thrown back in the response. Proper exception handling has been implemented in the code so that in case any run time error comes, code will not break and service will be still running fine after handling the exception.  Custom Exception class has been created in the project which will be used to throw an exception whenever any runtime error comes due to any data issue.
Web API exposes below listed methods:
•	GetProduct
•	GetAllProducts
•	Post
•	Put
•	Delete
Below steps would be used to create the DB objects in the database required by Web API:
1.The table ‘ShopBridgeProducts’ would be created in the DB to store the product details. PFB the query used to create the table:
create table ShopBridgeProducts(ProductId int primary key,ProductDescription varchar(500),Price int,Category varchar(100),
Brand varchar(100),Color varchar(100),Size int
)
2. A table would be created to store the latest primary key available for all the tables:
create table TableKeys(TableName varchar(100),PrimaryKey int)
3.A following record would be inserted in the table ‘TableKeys’ for th table ‘ShopBridgeProducts’. It is a one time activity.
Query:: insert into TableKeys values('ShopBridgeProducts',1)
4. Stored procedure would be created to generate primary key for the tables available in the database.
Query: drop procedure if exists [dbo].[Generare_PK]
Go
Create proc [Generare_PK]
(
@TableName varchar(100)
)
as 
begin
declare @PrimaryKey int
set @PrimaryKey=(select max(primarykey)+1 from TableKeys where TableName=@TableName)
update TableKeys set PrimaryKey=@PrimaryKey where TableName=@TableName
select @PrimaryKey
end


Project files have already been provided in the GitHub and are available at the below path:

Copy the entire project in the server machine and create all the objects DB objects required. After configuring the project on the server, run the project and try to access the Web API link to check if the service is up and running fine.
Note: Database name should have to be changed in the code by  the database name of the server machine where this project would be running.
