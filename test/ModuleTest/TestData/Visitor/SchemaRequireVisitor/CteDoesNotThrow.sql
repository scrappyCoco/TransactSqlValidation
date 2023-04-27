;
WITH I_CRM_SHOPS(CRM_SHOP_ID, CRM_SHOP_PREVIOUS_SHOP_ID) AS (SELECT CRM_SHOP_ID
                                                                  , CRM_SHOP_PREVIOUS_SHOP_ID
                                                             FROM dbo.CRM_SHOP_IMPORT
                                                             WHERE CRM_SHOP_ID = @CrmShopId
                                                             UNION ALL
                                                             SELECT t.CRM_SHOP_ID
                                                                  , t.CRM_SHOP_PREVIOUS_SHOP_ID
                                                             FROM dbo.CRM_SHOP_IMPORT AS t
                                                                      INNER JOIN I_CRM_SHOPS AS i ON i.CRM_SHOP_PREVIOUS_SHOP_ID = t.CRM_SHOP_ID)
SELECT COUNT(1)
     , SUM(CASE WHEN t.ITEM_FIRST_TIME_DATE_TIME_LOCAL >= CAST('20131001' AS DATETIME) THEN 1 ELSE 0 END)
FROM dbo.ITEM AS t
         INNER JOIN dbo.SHOP AS s ON s.SHOP_ID = t.ITEM_SHOP_ID
         INNER JOIN I_CRM_SHOPS AS c ON c.CRM_SHOP_ID = s.SHOP_NAME
WHERE t.ITEM_FIRST_TIME_DATE_TIME_LOCAL IS NOT NULL;