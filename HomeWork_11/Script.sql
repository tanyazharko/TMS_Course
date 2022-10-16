CREATE TABLE users
(
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(30) NOT NULL,
    Gender CHARACTER VARYING(30) NOT NULL,
    Date_of_Birth DATE,
    Age INTEGER CHECK(Age >= 16 AND Age < 100),
    Weight NUMERIC(9,2) NOT NULL,
    Height DECIMAL NOT NULL
);

CREATE TABLE food
(
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(30) NOT NULL,
    Callories INT NOT null ,
    Proteins INT NOT NULL,
    Fats INT NOT NULL,
    Carbohydates INT NOT NULL
);

CREATE TABLE activity
(
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(30) NOT NULL,
    Callories_per_Minute INT NOT NULL
);

CREATE TABLE Callories
(
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(30) NOT NULL,
    Callories_per_Minute INT NOT NULL
);

ALTER TABLE users
ADD Phone CHARACTER VARYING(20) NULL;

ALTER TABLE users
ADD Address CHARACTER VARYING(30) NOT NULL DEFAULT 'Неизвестно';

ALTER TABLE users
DROP COLUMN Address;

ALTER TABLE users
ADD UNIQUE (Phone);

INSERT INTO users (Name, Gender, Date_of_Birth,Age,Weight,Height,Phone)
VALUES
('Anya', 'female', '18.09.2001', 21,40,170,'66688'),
('Tanya', 'female', '18.09.2001', 21,555,170,'567'),
('Ben', 'male', '18.09.2001', 21,100,170,'456')

SELECT * FROM users;
SELECT Gender, Age FROM users;

SELECT * FROM users
WHERE Age = 21;

SELECT * FROM users
WHERE Height - Weight > 50;

SELECT * FROM users
WHERE Gender = 'male' AND Height - Weight > 50;

UPDATE users
SET Age = Age + 3;

SELECT * FROM users;

SELECT Gender
FROM users
ORDER BY Gender DESC;

SELECT AVG(Age) AS Average_Age FROM users ;

DELETE FROM users
WHERE Gender = 'male';

CREATE TABLE Customers
(
    Id SERIAL PRIMARY KEY,
    Age INTEGER, 
    FirstName VARCHAR(20) NOT NULL
);
  
CREATE TABLE Orders
(
    Id SERIAL PRIMARY KEY,
    CustomerId INTEGER REFERENCES Customers (Id),
    Quantity INTEGER
);



