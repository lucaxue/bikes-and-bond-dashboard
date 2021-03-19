CREATE TABLE Bikes (
    Id SERIAL PRIMARY KEY,
    Genre TEXT,
    Author TEXT,
    Color TEXT,
    Title TEXT
);

INSERT INTO
    Bikes (Genre, Author, Color, Title)
VALUES
    ('Unicycle', 'Mr Trek', 'Red', 'Red-Roller'),
    ('Penny Farthing', 'Ms Raleigh ', 'Black', 'Tally Ho');
  
CREATE TABLE Missions (
    Id SERIAL PRIMARY KEY,
    Name TEXT,
    Location TEXT,
    Difficulty INT,
    Task TEXT,
    Villain TEXT
);

INSERT INTO
    Missions (Name, Location, Difficulty, Task, Villain)
VALUES
    ('Panic in Paris','Paris',3,'We’ve gathered intel that there’s a plot to steal the Eiffel Tower, get down there and stop it before it’s too late','Mr VanMoof'),
   
       ('Brawl in Brussels requires your Muscles','Brussels',1,'The Belgium mob are on the loose again and have pulled off another jewellery hiest. However this time time they have let their guard down and are picniccing on the river side near St Bartholomews, all you need to do is go there and round them up for questioning!','Master Kermit');

