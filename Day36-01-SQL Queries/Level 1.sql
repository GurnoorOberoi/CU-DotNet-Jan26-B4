--1.Basic Linking: List all Product Names along with their Category Names.
select p.ProductName, c.CategoryName from Products p inner join Categories c on p.CategoryID = c.CategoryID;
--2.Order Details: Display every Order ID alongside the Company Name of the customer who placed it.
select o.OrderID, c.CompanyName from Orders o inner join Customers c on o.CustomerID = c.CustomerID;
--3.Supplier Tracking: Show all Product Names and the Company Name of their respective suppliers.
select p.ProductName, s.CompanyName from Products p inner join Suppliers s on p.SupplierID = s.SupplierID;
--4.Employee Sales: List all Orders (ID and Date) and the First/Last Name of the employee who processed them.
select o.OrderID, o.OrderDate,e.FirstName, e.LastName from Orders o inner join Employees e 
on o.EmployeeID = e.EmployeeID;
--5.International Logistics: Find all Orders shipped to "France," showing the Order ID and the Company Name of the Shipper (from the Shippers table).
select o.OrderID, s.CompanyName from Orders o inner join Shippers s on o.ShipVia = s.ShipperID 
where o.ShipCountry = 'France';