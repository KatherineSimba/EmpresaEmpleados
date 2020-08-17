/****** Object:  UserDefinedFunction [dbo].[Cantidad_De_Categorias_Activos]    Script Date: 17-Mar-18 5:56:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Cantidad_De_Categorias_Activos]
(
	-- Add the parameters for the function here
	@EmpleadoId int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result int

	-- Add the T-SQL statements to compute the return value here
	SELECT @result = count(*)
	from EmpleadosCategorias
	where EmpleadoId = @EmpleadoId and Activo = 'true'

	-- Return the result of the function
	RETURN @result

END
GO


