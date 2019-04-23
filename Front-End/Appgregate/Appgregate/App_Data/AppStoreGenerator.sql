SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], 
                [Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL  THEN 'N/A' ELSE CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2))) END) 
                FROM AppTable LEFT JOIN CommentsTable  ON CommentsTable.appID = AppTable.appID 
                WHERE AppTable.Name LIKE '%4.50%' OR  
                AppTable.Description LIKE '%4.50%' OR  
                AppTable.Organization LIKE '%4.50%' OR 
                AppTable.[Platform(s)] LIKE '%4.50%' OR 
                AppTable.[Version(s)] LIKE '%4.50%' 		
				GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID
				UNION
SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], 
                [Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL  THEN 'N/A' ELSE CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2))) END) 
                FROM AppTable LEFT JOIN CommentsTable  ON CommentsTable.appID = AppTable.appID 
				GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID
				HAVING CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2)) LIKE '%4.50%'
				UNION
				SELECT AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], 
                [Rating] = (CASE WHEN AVG(appRating) < 1 OR AVG(appRating) IS NULL  THEN 'N/A' ELSE CONVERT(VARCHAR(5), CAST(AVG(CAST(appRating AS DECIMAL(10,2))) AS DECIMAL(10,2))) END) 
                FROM AppTable LEFT JOIN CommentsTable  ON CommentsTable.appID = AppTable.appID 
				GROUP BY AppTable.appID, AppTable.Name, AppTable.Description, AppTable.Organization, AppTable.[Platform(s)], AppTable.[Version(s)], AppTable.appID
				HAVING (AVG(appRating) < 1 OR AVG(appRating) IS NULL) AND 'N/A'  LIKE '%4.50%' 
