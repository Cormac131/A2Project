USE Studio2_Systems_DB;

SELECT ClassLevel AS classLevel, ClassType AS classType FROM ClassType WHERE ClassID = (SELECT ClassID FROM ( 
	SELECT TOP 1 * 
	FROM Class  
	WHERE SlotDay = @todaysDate
	AND SlotStartTime >= @timeNow
) AS classID);