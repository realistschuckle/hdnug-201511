DROP TABLE IF EXISTS Appointments;

CREATE TABLE Appointments (
    Id SERIAL PRIMARY KEY,
    StartsAt timestamp without time zone NOT NULL,
    Title text NOT NULL,
    FifteenMinuteMultiplier smallint NOT NULL
);

ALTER TABLE Appointments OWNER TO hdnug;

INSERT INTO Appointments(StartsAt, Title, FifteenMinuteMultiplier)
VALUES('2015-11-11 08:45:00', 'Scrum', 1);
