--6.Category Stock: Show the Category Name and the total number of units in stock for that category.
select c.CategoryName, SUM(p.UnitsInStock) as TotalNumberOfUnits from Categories c inner join Products p 
on c.CategoryID = p.CategoryID group by CategoryName;
--7.Customer Spend: List the Company Name and the total amount of money (Price * Quantity) they have spent across all orders.
select c.CompanyName, SUM(od.UnitPrice * od.Quantity) as TotalSpent from Customers c inner join Orders o on 
c.CustomerID = o.CustomerID inner join [Order Details] od on o.OrderID = od.OrderID group by CompanyName;
--8.Employee Performance: Display the Last Name of each employee and the total number of orders they have taken.
select e.LastName, Count(o.OrderID) as TotalOrders from Employees e inner join Orders o on 
e.EmployeeID = o.EmployeeID group by LastName;
--9.Shipping Costs: Find the total Freight charges paid to each Shipper company.
select s.CompanyName , SUM(o.Freight) as TotalFreight from Shippers s inner join Orders o 
on s.ShipperID = o.ShipVia group by CompanyName;
--10.Top Products: List the top 5 Product Names based on total quantity sold.
select top 5 p.ProductName, sum(od.Quantity) as TotalSold from Products p inner join [Order Details] od on 
p.ProductID = od.ProductID group by p.ProductName order by TotalSold DESC;