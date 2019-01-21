USE Studio2_Systems_DB;

--INSERT INTO Member
--VALUES (@title,@surname,@firstname,@address1,@address2
--		,@town,@postcode,@contactHomeNo,@contactMobileNo,
--		@email,@cardNo,@membershipTypeID,@country,@gender);

--INSERT INTO PaymentCard
--VALUES (@cardNo,@cardType,@cardName,@expiryMonth,@expiryYear);

INSERT INTO Member (Title,Surname,FirstName,Address1,Address2,Town,Postcode,
			ContactHomeNo,ContactMobileNo,Email,MembershipTypeID,Gender,County)
VALUES (@title,@surname,@firstname,@address1,@address2
		,@town,@postcode,@contactHomeNo,@contactMobileNo,
		@email,@membershipTypeID,@gender,@county);