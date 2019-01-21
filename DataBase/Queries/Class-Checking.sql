DECLARE @SlotID AS INT =(SELECT Class.SlotID AS SlotID
	FROM Class
	INNER JOIN ClassType
	ON Class.ClassID = ClassType.ClassID
	WHERE ClassType.ClassType = @ClassName
	AND ClassType.ClassLevel = @ClassLevel
	AND Class.SlotStartTime = @ClassStartTime
	AND Class.SlotDay = @ClassDay);

SELECT COUNT(*) AS totalBooked
FROM Booking 
WHERE SlotID = @SlotID;