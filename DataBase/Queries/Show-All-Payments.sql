USE Studio2_Systems_DB;

SELECT Payment.PaymentID AS paymentID,
	Payment.PaidAmount AS paidAmount,
	Payment.DateOfPayment AS dateOfPayment
	--Member.FirstName AS firstname,
	--Member.Surname AS surname
FROM Payment
--INNER JOIN Member
--ON Booking.MemberID = Member.MemberID
INNER JOIN Booking
ON Payment.PaymentID = Booking.PaymentID
ORDER BY Booking.PaymentID ASC;

--SELECT Payment.PaymentID AS paymentID,
--	Payment.PaidAmount AS paidAmount,
--	Payment.DateOfPayment AS dateOfPayment
--FROM Payment
--ORDER BY PaymentID ASC;