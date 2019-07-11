/*
-- =============================================
-- Author 	  : Sam Shah
-- Create date: 09-07-2019
-- Description:	This stored procedure is generated to Insert record in Supplier table.
-- =============================================
*/

-- Call  [dbo].[SP_Suppliers_UpdateByPK] @SupplierID = 1, @CompanyName = 'CompanyName', @ContactName = 'ContactName', @ContactTitle = 'ContactTitle', @Address = 'Address', @City = 'City', @Region = 'Region', @PostalCode = 'PostalCode', @Country = 'Country', @Phone = 'Phone', @Fax = 'Fax', @HomePage = 'HomePage'

CREATE PROCEDURE [dbo].[SP_Suppliers_UpdateByPK]

		@SupplierID   		int,
		@CompanyName  		nvarchar (40),
		@ContactName  		nvarchar (30),
		@ContactTitle 		nvarchar (30),
		@Address      		nvarchar (60),
		@City         		nvarchar (15),
		@Region       		nvarchar (15),
		@PostalCode   		nvarchar (10),
		@Country      		nvarchar (15),
		@Phone        		nvarchar (24),
		@Fax          		nvarchar (24),
		@HomePage     		ntext

AS

SET NOCOUNT ON;

BEGIN TRY
BEGIN TRAN

UPDATE [dbo].[Suppliers]
SET
		[CompanyName] = @CompanyName,
		[ContactName] = @ContactName,
		[ContactTitle] = @ContactTitle,
		[Address] = @Address,
		[City] = @City,
		[Region] = @Region,
		[PostalCode] = @PostalCode,
		[Country] = @Country,
		[Phone] = @Phone,
		[Fax] = @Fax,
		[HomePage] = @HomePage
WHERE [dbo].[Suppliers].[SupplierID] = @SupplierID

COMMIT TRAN
END TRY

BEGIN CATCH
ROLLBACK TRAN

DECLARE @ErrorNumber_INT INT;
DECLARE @ErrorSeverity_INT INT;
DECLARE @ErrorProcedure_VC VARCHAR(200);
DECLARE @ErrorLine_INT INT;
DECLARE @ErrorMessage_NVC NVARCHAR(4000);

SELECT
		@ErrorMessage_NVC = ERROR_MESSAGE(),
		@ErrorSeverity_INT = ERROR_SEVERITY(),
		@ErrorNumber_INT = ERROR_NUMBER(),
		@ErrorProcedure_VC = ERROR_PROCEDURE(),
		@ErrorLine_INT = ERROR_LINE()

RAISERROR(@ErrorMessage_NVC,@ErrorSeverity_INT,1);

END CATCH

GO