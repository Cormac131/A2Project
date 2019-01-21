USE Studio2_Systems_DB;

SELECT Member.MemberID AS MemberID,
       Member.FirstName AS Firstname,
       Member.Surname AS Surname,
	   MembershipType.MembershipName AS MembershipType
FROM Member
INNER JOIN MembershipType
ON Member.MembershipTypeID=MembershipType.MembershipTypeID
WHERE Member.MembershipTypeID!=11 
AND Member.MemberID = 1 
OR Member.FirstName = 'Cormac' 
OR Member.Surname = 'McGrath'
OR MembershipType.MembershipName = 'Individual';