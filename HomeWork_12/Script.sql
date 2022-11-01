CREATE TABLE Users
(
    Id SERIAL PRIMARY KEY,
    UserName CHARACTER VARYING(30) UNIQUE,
    Name CHARACTER VARYING(30) NOT NULL,
    Gender CHARACTER VARYING(30) NOT NULL,
    Date_of_Birth DATE,
    Age INTEGER CHECK(Age >= 2 AND Age < 110),
    Weight NUMERIC(9,2) NOT NULL,
    Height DECIMAL NOT NULL
);
CREATE TABLE Food
(
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(30) NOT NULL,
    Callories INT NOT null ,
    Proteins INT NOT NULL,
    Fats INT NOT NULL,
    Carbohydates INT NOT NULL,
	Weight NUMERIC(9,3) NOT NULL
);

CREATE TABLE Activity
(
    Id SERIAL PRIMARY KEY,
    Name CHARACTER VARYING(30) NOT NULL,
    Callories_per_Minute INT NOT NULL
);

CREATE TABLE Exercise
(
    Id SERIAL PRIMARY KEY,
	Start TIME ,
	Finish TIME,
	UserId SERIAL REFERENCES Users (Id),
	ActivityId SERIAL REFERENCES Activity (Id)
);

CREATE TABLE Meal
(
    Id SERIAL PRIMARY KEY,
	MealTime TIME ,
	UserId SERIAL REFERENCES Users (Id),
	FoodId SERIAL REFERENCES Food (Id)
);

INSERT INTO users (UserName,Name, Gender, Date_of_Birth,Age,Weight,Height)
VALUES
('Anya11','Anya', 'female', '18.09.2001', 21,40,170),
('Tanya11','Tanya', 'female', '18.09.2001', 21,555,170),
('Ben_22','Ben', 'male', '18.09.2001', 21,100,170),
('Tan11','Kate', 'female', '18.09.2001', 21,555,170),
('Bn_22','Ben', 'male', '18.09.2001', 21,100,170)

SELECT * FROM food;

INSERT INTO Food(Name, Callories, Proteins,Fats,Carbohydates,Weight)
VALUES
('Cake', 125, 21,40,170,44),
('water', 1, 21,555,170,44),
('coca-coa', 50,21,100,170,88),
('tomate', 15,21,555,170,55),
('cucumber', 10, 21,100,170,55)

INSERT INTO Activity(Name, Callories_per_Minute)
VALUES
('run', 125),
('swimming', 1),
('bike', 15),
('swimming', 4),
('swimming', 10),
('bike', 15)

INSERT INTO Exercise(Start, Finish)
VALUES
('14:00', '14:50'),
('15:00', '19:50'),
('1:00', '2:50')

INSERT INTO Meal(MealTime)
VALUES
('14:50'),
( '19:50'),
('1:00')

SELECT Name, COUNT(*) AS CountActivity
FROM Activity
GROUP BY Name
having COUNT(*) > 2;

SELECT Users.Name,Activity.Name as NameOfActivity, Exercise.Start, Exercise.Finish
FROM Exercise
JOIN Users ON Users.Id = Exercise.UserId
JOIN Activity ON Activity.Id = Exercise.ActivityId;

CREATE TABLE Users
(
    Id SERIAL PRIMARY KEY,
    UserName CHARACTER VARYING(30) UNIQUE,
    Name CHARACTER VARYING(30) NOT NULL,
    Gender CHARACTER VARYING(30) NOT NULL,
    Date_of_Birth DATE,
    Age INTEGER CHECK(Age >= 2 AND Age < 110),
    Weight NUMERIC(9,2) NOT NULL,
    Height DECIMAL NOT NULL
);

CREATE PROCEDURE AddUsers
(
	c_Id INT,
    c_UserName CHARACTER VARYING(30),
    c_Name CHARACTER VARYING(30),
    c_Gender CHARACTER VARYING(30),
    c_Date_of_Birth DATE,
    c_Age INTEGER,
    c_Weight NUMERIC(9,2),
    c_Height DECIMAL
)
LANGUAGE SQL
AS $$
INSERT INTO Users (UserName,Name ,Gender,Date_of_Birth,Age,Weight,Height)
VALUES
(    c_UserName,
    c_Name,
    c_Gender,
    c_Date_of_Birth,
    c_Age,
    c_Weight,
    c_Height
)
$$;