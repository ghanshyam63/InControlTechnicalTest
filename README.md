

Structure of Repo is based on task mentioned in InControl-Test(Vb.Net) File.

Sepearate subfolder is created in Main repo with Task as a Name of SubFolder.(Ex Task1 Subfolder)

databse used is Northwind available to download from 
https://drive.google.com/file/d/0B4l9SwfspAj_aUtKTWxBNXVPdzg/edit 

below is a task file I copied from given document.

To complete this test, you will need an instance of the Northwind database. The Northwind database can be downloaded here: https://drive.google.com/file/d/0B4l9SwfspAj_aUtKTWxBNXVPdzg/edit 

Please setup a ASP.NET MVC project using VB.Net. Create an appropriate layout and structure to complete the following tasks.

•	Create a Backend REST API service with JSON communication.
•	Web page design and style is not important standard HTML file is ok. Use Javascript as required.
•	Use a mix of EntityFramework and Embedded SQL to retrieve data

Task 1

Write a simple windows service in VB.Net. It must be able to run as a console. It will call a Rest Api and retrieve all products which require reordering. This call must be repeat once a day. Write the output to a log file to show product name, reorder level and amount in stock.

Task 2

Create a Web page for Suppliers, Category and Products:
-	Create search options for all the grids – Suppliers, Category & Product and export (xls, pdf) based on search results.
-	to add a new record to “dbo.Suppliers”
-	to edit record in “dbo.Suppliers”
-	to delete a record in “dbo.Suppliers”

Task 3

SQL Stored Procedure

-	Provide a script to add a record to “dbo.Suppliers” using a stored procedure
-	Provide a script to update a record in “dbo.Suppliers” using a stored procedure
-	Provide a script to delete a record in “dbo.Suppliers” . If no rows were deleted return zero else return the number of rows deleted 

Task 4
SQL Queries
Please write the SQL statements to answer the questions below. 

ID	    ManagerID	          Name	    Title	                  Salary
1     	NULL	              Slate	    CEO	                    50000000
2	      1	                  Quary	Foreman	                    250000
3	      2	                  Gravel	Supervisor	              200000
4	      2	                  Granite	Lead Operator	            300000
5	      2	                  Flintstone	Dino Operator	        30000
6	      4	                  Rubble	Foreman	                  20000
7	      3	                  Onyx	Dino Washer	                20000
8	      3	                  Opal	Dino Operator	              20000
9	      1	                  Quartz	Accountant	              60000
10	    1	                  Mica	Accountant	                60000
11	    9	                  Sandstone	Clerk	                  60000
12	    1	                  Tuft	Hairdresser	                60000
13	    4	                  Ruby	Assistant Operator	        350000
14	    3	                  Saracen	Clock Watcher	            60000
15	    3	                  Sandstone	Polisher	              27000

Provide queries to find the answers to the following: 

1.	What is the total payroll cost of this organization? 
2.	Which employees make more money than their manager? 
3.	Which managers have employees that make more than they do ? 
4.	Which employees make more than the average salary of all employees? 
5.	Which employees make more than the average salary of their immediate colleagues (i.e. they share the same manager)? 
6.	Write a query to give all accountants a 10% raise 
