SELECT p.[Name] as ProductName, c.[Name] as CategoryName
FROM dbo.Products p
	LEFT JOIN dbo.Products2Categories p2c ON p2c.ProductID = p.ID
	LEFT JOIN dbo.Categories c ON p2c.CategoryID = c.ID