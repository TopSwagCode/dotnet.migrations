PRINT 'Creating Persons Test data';

CREATE TABLE Persons (
     PersonID int,
     LastName varchar(255),
     FirstName varchar(255),
     Address varchar(255),
     City varchar(255)
);

insert into Persons (PersonID LastName, FirstName, Address, City) values (1, 'Doe', 'John', '123 Main St', 'Seattle');

PRINT 'Persons Test Data created';


--