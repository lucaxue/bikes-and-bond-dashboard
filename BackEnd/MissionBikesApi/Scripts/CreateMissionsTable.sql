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
    ('Brawl in Brussels requires your Muscles','Brussels',1,'The Belgium mob are on the loose again and have pulled off another jewellery hiest. However this time time they have let their guard down and are picniccing on the river side near St Bartholomews, all you need to do is go there and round them up for questioning!','Master Kermit'),
    ('Hijacking in Honolulu','Honolulu',4,'Dr Cervelo and her minions have hijacked an aircraft carrying 300 puppies and are planning on flying it into one of Hawaiis volcanoes, figure out which volcano and stop them!', 'Dr Cervelo'),
    ('Problems in the Pacific','Northern Pacific', 5, 'The dolphins in the Northern Pacific region are holding a ship hostage, the ransom is 750kg of tuna - but we dont negotiate with terrorists. Something larger is afoot work out who is behind this, save the ship and shoot any rogue dolphins on sight', 'unknown');

