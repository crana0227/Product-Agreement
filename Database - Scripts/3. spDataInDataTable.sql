USE [Product-Agreement]
GO
--EXEC [dbo].[spDataInDataTable] 'ProductNumber','DESC',0,10,'','a42205ed-4c2d-4749-813d-24631e12d59e'
GO
ALTER PROCEDURE [dbo].[spDataInDataTable] (  
     @sortColumn VARCHAR(50)  
    ,@sortOrder VARCHAR(50)  
    ,@OffsetValue INT  
    ,@PagingSize INT  
    ,@SearchText VARCHAR(50)  
	,@LogInUserId VARCHAR(450)
    )  
AS  
BEGIN  
    SELECT AG.ID  
		, UserName
		, GroupCode
		, GroupDescription
		, ProductNumber
		, ProductDescription
        , EffectiveDate
		, ExpirationDate
        , AG.ProductPrice
        , NEWPRICE  
        ,count(AG.ID) OVER () AS FilterTotalCount  
    FROM DBO.AGREEMENT AG
	INNER JOIN DBO.PRODUCT P ON AG.ProductId = P.ID
	INNER JOIN DBO.PRODUCTGROUP PG ON AG.ProductGroupId = PG.ID
	INNER JOIN DBO.AspNetUsers AU ON AG.UserId = AU.ID
    WHERE (  
            (  
                @SearchText <> ''  
                AND (  
                    PG.GroupCode LIKE '%' + @SearchText + '%'  
                    OR P.ProductNumber LIKE '%' + @SearchText + '%' 
					OR AU.UserName LIKE '%' + @SearchText + '%' 
                    )  
                )  
            OR (@SearchText = '')  
            )  
			AND AU.Id = @LogInUserId
    ORDER BY CASE   
            WHEN @sortOrder <> 'ASC'  
                THEN ''  
            WHEN @sortColumn = 'GroupCode'  
                THEN PG.GroupCode 
            END ASC  
        ,CASE   
            WHEN @sortOrder <> 'Desc'  
                THEN ''  
            WHEN @sortColumn = 'GroupCode'  
                THEN PG.GroupCode   
            END DESC  
        ,CASE   
            WHEN @sortOrder <> 'ASC'  
                THEN ''  
            WHEN @sortColumn = 'ProductNumber'  
                THEN P.ProductNumber  
            END ASC  
        ,CASE   
            WHEN @sortOrder <> 'DESC'  
                THEN ''  
            WHEN @sortColumn = 'ProductNumber'  
                THEN P.ProductNumber  
            END DESC  
        ,CASE   
            WHEN @sortOrder <> 'ASC'  
                THEN ''  
            WHEN @sortColumn = 'UserName'  
                THEN AU.UserName  
            END ASC  
        ,CASE   
            WHEN @sortOrder <> 'DESC'  
                THEN ''  
            WHEN @sortColumn = 'UserName'  
                THEN AU.UserName  
            END DESC OFFSET @OffsetValue ROWS  
  
    FETCH NEXT @PagingSize ROWS ONLY  
END  