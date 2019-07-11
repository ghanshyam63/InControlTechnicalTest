/*
-- =============================================
-- Author 	  : Sam Shah
-- Create date: 09-07-2019
-- Description:	This Sored Procedure delete supplier using PK.
-- =============================================
*/

--   [dbo].[SP_Suppliers_DeleteByPK] @SupplierID = 1

CREATE PROCEDURE [dbo].[SP_Suppliers_DeleteByPK]

		@SupplierID 		int

AS

SET NOCOUNT ON;

BEGIN TRY
BEGIN TRAN

	DELETE FROM [dbo].[Suppliers]
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