IF EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.VIEWS 
    WHERE TABLE_NAME = 'vwProducts' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  DROP VIEW vwProducts
END
GO
CREATE VIEW vwProducts
AS
WITH TblImage AS (
  SELECT pi.ProductId, STRING_AGG(pi.ImageUrl,',') ImageUrls
  FROM ProductImages pi
  GROUP BY pi.ProductId
)
SELECT P.ProductId,P.CategoryCode,C.CategoryName,C.CategoryNameEN,P.ProductName,P.ProductNameEN,P.Description,P.ProductVersion,P.BasePrice,P.Rating,I.ImageUrls,P.IsActive,P.CreatedAt 
FROM Products p
LEFT JOIN Categories c ON p.CategoryCode = c.CategoryCode
LEFT JOIN TblImage I ON p.ProductId = I.ProductId
GO
IF EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.VIEWS 
    WHERE TABLE_NAME = 'vwProductVariants' AND TABLE_SCHEMA = 'dbo'
)
BEGIN
  DROP VIEW vwProductVariants
END
go
CREATE VIEW vwProductVariants
AS
WITH TblVariantImage AS (
  SELECT pvi.VariantId, STRING_AGG(pvi.ImageUrl,',') ImageUrls
  FROM ProductVariantImages pvi
  GROUP BY pvi.VariantId
)
SELECT pv.VariantId,pv.ProductId,p.ProductName,P.ProductNameEN,P.CategoryCode,c.CategoryName,c.CategoryNameEN,P.Description,P.ProductVersion,P.BasePrice,P.Rating,P.IsActive ProductIsActive,
pv.ColorCode,pv.Storages,pv.Price,pv.Discount,pv.NewPrice,pv.VariantVersion,pv.IsActive,pv.Stock,v.ImageUrls
FROM ProductVariants pv
LEFT JOIN Products p ON pv.ProductId = p.ProductId
LEFT JOIN Categories c ON p.CategoryCode = c.CategoryCode
LEFT JOIN TblVariantImage v ON v.VariantId = pv.VariantId
GO