USE Studio2_Systems_DB;

SELECT Member.MemberID AS MemberID, 
	Member.FirstName AS Firstname, 
	Member.Surname AS Surname, 
	MembershipType.MembershipName AS MembershipType 
FROM Member 
INNER JOIN MembershipType 
ON Member.MembershipTypeID=MembershipType.MembershipTypeID 
WHERE Member.MembershipTypeID!=11 
AND (Member.MemberID = @memberID 
OR Member.FirstName = @firstName 
OR Member.Surname = @surame 
OR MembershipType.MembershipName = @memberType);