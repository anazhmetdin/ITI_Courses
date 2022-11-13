USE AdventureWorks2012;

-- 1.	Display the SalesOrderID, ShipDate of the SalesOrderHeader table (Sales schema) to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’
SELECT SOH.SalesOrderID, SOH.ShipDate
FROM Sales.SalesOrderHeader SOH
WHERE SOH.ShipDate BETWEEN '7/28/2002' AND '7/29/2014';

-- 2.	Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)
SELECT P.ProductID, P.Name FROM Production.Product P
WHERE P.StandardCost < 110;

-- 3.	Display ProductID, Name if its weight is unknown
SELECT P.ProductID, P.Name FROM Production.Product P
WHERE P.Weight IS NULL;

-- 4.	 Display all Products with a Silver, Black, or Red Color
SELECT P.ProductID, P.Name FROM Production.Product P
WHERE P.Color IN ('Silver', 'Black', 'Red');

-- 5.	 Display any Product with a Name starting with the letter B
SELECT P.ProductID, P.Name FROM Production.Product P
WHERE P.Name LIKE 'B%';

-- 6.	Display any Product description with underscore value in its description.
SELECT PD.Description FROM Production.ProductDescription PD
WHERE PD.Description LIKE '%[_]%';

-- 7.	Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table for the period between  '7/1/2001' and '7/31/2014'
SELECT SUM(SOH.TotalDue) Total FROM Sales.SalesOrderHeader  SOH
WHERE SOH.ShipDate BETWEEN '7/1/2002' AND '7/31/2014';

-- 8.	 Display the Employees HireDate (note no repeated values are allowed)
SELECT DISTINCT E.HireDate FROM HumanResources.Employee E;

-- 9.	Calculate the average of the unique ListPrices in the Product table
SELECT AVG(ULP.ListPrice) FROM
(SELECT DISTINCT ListPrice FROM Production.Product) ULP;

SELECT AVG(distinct ListPrice) FROM Production.Product;

-- 10.	Display the Product Name and its ListPrice within the values of 100 and 120 
SELECT CONCAT_WS(' ', 'The', P.Name, 'is only!', P.ListPrice)
FROM Production.Product P
ORDER BY P.ListPrice;

-- 11.
-- a) Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.Store table  in a newly created table named [store_Archive]
SELECT rowguid ,Name, SalesPersonID, Demographics
INTO store_Archive
FROM Sales.Store;
-- 701 ROWS

-- b)	Try the previous query but without transferring the data? 
SELECT rowguid ,Name, SalesPersonID, Demographics
INTO store_Archive1
FROM Sales.Store
WHERE 1=2;

-- 12.	Using union statement, retrieve the today’s date in different styles using convert or format funtion.
SELECT FORMAT(getdate(), 'dd-MM-yy') as date
UNION
SELECT FORMAT(getdate(), 'dd/MM/yyyy')
UNION ALL
SELECT CONVERT(nvarchar, getdate(), 7);