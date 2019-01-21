SELECT Member.MemberID AS MemberID,
	Member.Title AS Title,
    Member.Gender AS Gender,
    Member.FirstName AS Firstname,
    Member.Surname AS Surname,
	Member.DOB AS DOB,
	Member.Address1 AS Address1,
	Member.Address2 AS Address2,
	Member.Town AS Town,
	Member.County AS County,
	Member.Postcode AS Postcode,
	Member.ContactHomeNo AS ContactHomeNo,
	Member.ContactMobileNo AS ContactMobileNo,
	Member.Email AS Email,
	Member.CardNo AS CardNo,
    PaymentCard.CardType AS CardType,
    PaymentCard.CardName AS CardName,
    PaymentCard.ExpiryMonth AS ExpiryMonth,
    PaymentCard.ExpiryYear AS ExpiryYear,
    Member.MembershipTypeID AS MembershipTypeID,
    MembershipType.MembershipName AS MembershipTypeName,
	MembershipType.MembershipLength AS MembershipLength,
    MembershipType.MembershipMonthlyCost AS MembershipMonthlyCost,
    MembershipType.MembershipSingleCost AS MembershipSingleCost
    FROM Member
    INNER JOIN MembershipType
    ON Member.MembershipTypeID=MembershipType.MembershipTypeID
	INNER JOIN PaymentCard
    ON Member.CardNo=PaymentCard.CardNo
    WHERE Member.MemberID = 2;