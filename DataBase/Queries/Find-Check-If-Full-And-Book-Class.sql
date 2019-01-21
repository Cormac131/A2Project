USE Studio2_Systems_DB;

--DECLARE @SlotID AS INT =(SELECT Class.SlotID AS SlotID
--			FROM Class
--			INNER JOIN ClassType
--			ON Class.ClassID = ClassType.ClassID
--			WHERE ClassType.ClassType = @ClassName
--			AND ClassType.ClassLevel = @ClassLevel
--			AND Class.SlotStartTime = @ClassStartTime);

--DECLARE @TotalBookings AS INT = (SELECT COUNT(*)
--			FROM Booking 
--			WHERE SlotID = @SlotID);

--IF (@TotalBookings != 15)
--	INSERT INTO Payment
--	VALUES (15,'YES','12/11/1997')
--	INSERT INTO Booking
--	VALUES (1,@SlotID, 1, 'Y', '12/11/1997', 'NO')
	

DECLARE @SlotID AS INT =(SELECT Class.SlotID AS SlotID
			FROM Class
			INNER JOIN ClassType
			ON Class.ClassID = ClassType.ClassID
			WHERE ClassType.ClassType = @ClassName
			AND ClassType.ClassLevel = @ClassLevel
			AND Class.SlotStartTime = @ClassStartTime);

SELECT COUNT(*) AS totalBooked
FROM Booking 
WHERE SlotID = @SlotID
AND DateOfClass = @TodaysDate;