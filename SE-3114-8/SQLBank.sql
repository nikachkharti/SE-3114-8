CREATE PROCEDURE spGetAllCustomers
AS
BEGIN
	SELECT*FROM Customers
END


CREATE PROCEDURE spGetSingleCustomer
@customerId INT
AS
BEGIN
	SELECT*FROM Customers
	WHERE Id = @customerId
END

CREATE PROCEDURE spCreateCustomer
@name NVARCHAR(50),
@identityNumber CHAR(11),
@phoneNumber CHAR(9),
@email VARCHAR(50),
@customerType INT
AS
BEGIN
	INSERT INTO Customers(Name,IdentityNumber,PhoneNumber,Email,CustomerType)
	VALUES(@name,@identityNumber,@phoneNumber,@email,@customerType)
END



CREATE PROCEDURE spUpdateCustomer
@customerId INT,
@name NVARCHAR(50),
@identityNumber CHAR(11),
@phoneNumber CHAR(9),
@email VARCHAR(50),
@customerType INT
AS
BEGIN
	UPDATE Customers
	SET
		Name = @name,
		IdentityNumber = @identityNumber,
		PhoneNumber = @phoneNumber,
		Email = @email,
		CustomerType = @customerType
	WHERE Id = @customerId
END


CREATE PROCEDURE spDeleteCustomer
@customerId INT
AS
BEGIN
	DELETE FROM Customers
	WHERE Id = @customerId
END
