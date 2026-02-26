--16.Territory Coverage: List all Employees and the names of the Regions they cover (requires joining Employees, EmployeeTerritories, Territories, and Region).
 select e.FirstName + ' ' + e.LastName as Employee, r.RegionDescription from Employees e inner join EmployeeTerritories et 
 on e.EmployeeID = et.EmployeeID inner join Territories t on et.TerritoryID = t.TerritoryID inner join
 Region r on t.RegionID = r.RegionID;
 --17.Duplicate Cities: Find Customers and Suppliers who are located in the same city.
 select c.CompanyName as Customer , s.CompanyName as Supplier, c.City from Customers c inner join Suppliers s 
 on c.City = s.City;
 --18.Multi-Category Customers: List Customers who have purchased products from more than 3 different categories.
 select c.CompanyName from Customers c inner join Orders o on c.CustomerID = o.CustomerID inner join [Order Details] od 
 on o.OrderID = od.OrderID inner join Products p on od.ProductID = p.ProductID group by c.CompanyName
 having count(distinct p.CategoryID)>3;
 --19.Discontinued Sales: Calculate the total revenue generated only by products that are currently Discontinued.
 select sum(od.UnitPrice * od.Quantity) as DiscontinuedRevenue from Products p inner join [Order Details] od 
 on p.ProductID = od.ProductID where p.Discontinued =1;
 --20.Correlated Subquery: For each Category, list the most expensive product name and its price.
 select c.CategoryName, p.ProductName, p.UnitPrice from Categories c inner join Products p 
 on c.CategoryID = p.CategoryID where p.UnitPrice = 
 (select max(p1.UnitPrice) from Products p1 where p1.CategoryID =c.CategoryID);