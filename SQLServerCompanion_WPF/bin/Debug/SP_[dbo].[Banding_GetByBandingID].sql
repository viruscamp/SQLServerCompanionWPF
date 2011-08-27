/****** Object:  StoredProcedure [dbo].[Banding_GetByBandingID]    Script Date: 08/20/2011 21:16:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banding_GetByBandingID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Banding_GetByBandingID]
GOSET ANSI_NULLS OFF

--Author : M Punglia
--Date : 4/1/2010

CREATE PROCEDURE Banding_GetByBandingID
@BandingID int 
AS

SELECT BandingID, Code, Name, Complexity, LastChanged FROM [Banding]
WHERE BandingID = @BandingID

GO

