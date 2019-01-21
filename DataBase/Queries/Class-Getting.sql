USE Studio2_Systems_DB;

SELECT ClassType.ClassType AS ClassName,
	ClassType.ClassLevel AS ClassLevel,
	Class.SlotStartTime AS ClassStartTime
	FROM Class
	INNER JOIN ClassType
	ON Class.ClassID = ClassType.ClassID
	WHERE Class.SlotID = @slotID
	OR (ClassType.ClassType = @className 
	AND ClassType.ClassType = @classLevel
	AND (Class.SlotID = @ID1 
	OR Class.SlotID = @ID2 
	OR Class.SlotID = @ID3 
	OR Class.SlotID = @ID4 
	OR Class.SlotID = @ID5 
	OR Class.SlotID = @ID6));
