USE pubs;
GO

CREATE OR ALTER PROC SelectAllTitles
AS
	BEGIN TRY
		SELECT * FROM pubs.dbo.titles
	END TRY  
	BEGIN CATCH  
		THROW 50000, 'Could not select Titles', 16
	END CATCH
GO

CREATE OR ALTER PROC UpdateTitleByTitleID
@titleID VARCHAR(6), @bookTitle VARCHAR(80), @type CHAR(12), @pubDate DATETIME,
@price MONEY = NULL, @advance MONEY = NULL, @royalty INT = NULL,
@sales INT = NULL, @notes VARCHAR(200) = NULL, @pubID CHAR(4) = NULL
AS
	BEGIN TRY
		UPDATE pubs.dbo.titles
		SET
		title = @bookTitle, type = @type, pub_id = @pubID,
		price = @price, advance = @advance, royalty = @royalty,
		ytd_sales = @sales, notes = @notes, PubDate = @pubDate
		WHERE title_id = @titleID
	END TRY  
	BEGIN CATCH  
		THROW 50000, 'Could not update Title', 16
	END CATCH
GO

CREATE OR ALTER PROC DeleteTitleByTitleID
@titleID VARCHAR(6)
AS
	BEGIN TRY
		DELETE FROM pubs.dbo.titles
		WHERE title_id = @titleID
	END TRY  
	BEGIN CATCH  
		THROW 50000, 'Could not delete Title', 16
	END CATCH
GO

CREATE OR ALTER PROC InsertTitle
@titleID VARCHAR(6), @bookTitle VARCHAR(80), @type CHAR(12), @pubDate DATETIME,
@price MONEY = NULL, @advance MONEY = NULL, @royalty INT = NULL,
@sales INT = NULL, @notes VARCHAR(200) = NULL, @pubID CHAR(4) = NULL
AS
	BEGIN TRY
		INSERT INTO pubs.dbo.titles
		VALUES 
		(
			@titleID, @bookTitle, @type, @pubID,
			@price, @advance, @royalty,
			@sales, @notes, @pubDate
		)
	END TRY  
	BEGIN CATCH  
		THROW 50000, 'Could not insert Title', 16
	END CATCH
GO

CREATE OR ALTER PROC SelectAllPublishers
AS
	BEGIN TRY
		SELECT * FROM pubs.dbo.publishers
	END TRY  
	BEGIN CATCH  
		THROW 50000, 'Could not select Publishers', 16
	END CATCH
GO