--  1.	What is the total payroll cost of this organization? 

select SUM(Salary) As "Total Payroll Cost"  from Employees;

--  2.	Which employees make more money than their manager? 

Select emp.ID,emp.ManagerID,emp.Name,emp.title,emp.Salary 
from
Employees emp inner join Employees manager
on emp.ManagerId = manager.Id
where emp.Salary > manager.Salary;

-- 3.	Which managers have employees that make more than they do ? 

Select manager.ID,manager.ManagerID,manager.Name,manager.title,manager.Salary 
from
Employees emp inner join Employees manager
on emp.ManagerId = manager.Id
where emp.Salary > manager.Salary;

-- 4.	Which employees make more than the average salary of all employees? 

SELECT ID,ManagerID,Name,Title,Salary 
FROM Employees 
WHERE salary > (SELECT avg(salary) FROM Employees);

-- 5.	Which employees make more than the average salary of their immediate colleagues (i.e. they share the same manager)? 

Select ID,MangerID,Name,Title,Salary from Employees Where Salary>(select avg(salary)  from Employees emp inner join Employees manager
on emp.ManagerId = manager.Id)




-- 6.	Write a query to give all accountants a 10% raise 
 Update Employees set Salary=Salary + (Salary*0.1) where Title = 'Accountant'