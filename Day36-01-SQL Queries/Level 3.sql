--11.Above Average: List all Product Names whose UnitPrice is greater than the average price of all products.
select p.ProductName from Products p where UnitPrice > (select avg(UnitPrice) from Products); 
--12.The Bosses: Use a Self-Join on the Employees table to show each employee's name and their manager's name.
select e.FirstName +' ' + e.LastName as EmployeeName, m.FirstName + ' ' + m.LastName as ManagerName 
from Employees e left join Employees m on e.EmployeeID = m.EmployeeID;
--13.No Orders: Find all Customers (Company Name) who have never placed an order (Use NOT IN or NOT EXISTS).
select CompanyName from Customers c where not exists (select 1 from Orders o where o.CustomerID = c.CustomerID);
--14.High-Value Orders: Identify Order IDs where the total order value is higher than the average order value of the entire database.
 select o.OrderID from Orders o inner join [Order Details]od on o.OrderID = od.OrderID group by o.OrderID 
 having sum(od.UnitPrice*od.Quantity)> ( select avg(OrderTotal) from( select sum(UnitPrice*Quantity) 
 as OrderTotal from [Order Details] group by OrderID)T);
 --15.Late Bloomers: Select Product Names that have never been ordered after the year 1997.
 select p.ProductName from Products p where not exists(select 1 from Orders o inner join [Order Details] od 
 on o.OrderDate = od.OrderID where od.ProductID = p.ProductID and YEAR(o.OrderDate)>1997);