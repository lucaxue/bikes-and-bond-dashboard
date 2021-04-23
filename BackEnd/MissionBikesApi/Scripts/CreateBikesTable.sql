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
    ('Penny Farthing', 'Ms Raleigh ', 'Black', 'Tally Ho'),
    ('BMX','Miss Bianchi','Purple','Cool Goose'),
    ('Electric', 'Mr VanMoof', 'Yellow with racing stripes', 'The Green Alternative');
  
