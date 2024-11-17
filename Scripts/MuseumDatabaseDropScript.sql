-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2024-01-14 15:31:19.802

-- foreign keys
ALTER TABLE Author DROP CONSTRAINT Author_Person;

ALTER TABLE Painting DROP CONSTRAINT Painting_Author;

ALTER TABLE Restoration DROP CONSTRAINT Restoration_Painting;

ALTER TABLE Restoration DROP CONSTRAINT Restoration_Restorer;

ALTER TABLE Restorer DROP CONSTRAINT Restorer_Person;

ALTER TABLE UserTicketMapping DROP CONSTRAINT UserTicketMapping_Ticket;

ALTER TABLE UserTicketMapping DROP CONSTRAINT UserTicketMapping_User;

ALTER TABLE "User" DROP CONSTRAINT User_Role;

-- tables
DROP TABLE Author;

DROP TABLE Painting;

DROP TABLE Person;

DROP TABLE Restoration;

DROP TABLE Restorer;

DROP TABLE Role;

DROP TABLE Ticket;

DROP TABLE "User";

DROP TABLE UserTicketMapping;

-- End of file.

