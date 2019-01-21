SELECT Member.MemberID AS MemberID,
Member.FirstName AS Firstname,
Member.Surname AS Surname,
MembershipType.MembershipName AS MembershipType
FROM Member
INNER JOIN MembershipType
ON Member.MembershipTypeID=MembershipType.MembershipTypeID
WHERE Surname LIKE '[m]%';