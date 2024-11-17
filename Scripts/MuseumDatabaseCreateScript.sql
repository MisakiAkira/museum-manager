-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2024-01-14 15:31:19.802

-- tables
-- Table: Author
CREATE TABLE Author (
    PersonID int  NOT NULL,
    Description varchar(250)  NOT NULL,
    CONSTRAINT Author_pk PRIMARY KEY  (PersonID)
);

-- Table: Painting
CREATE TABLE Painting (
    PaintingID int  NOT NULL IDENTITY,
    AuthorID int  NOT NULL,
    Name varchar(50)  NOT NULL,
    PaintingDate date  NOT NULL,
    Description varchar(255)  NOT NULL,
    CONSTRAINT Painting_pk PRIMARY KEY  (PaintingID)
);

-- Table: Person
CREATE TABLE Person (
    PersonID int  NOT NULL IDENTITY,
    FirstName varchar(50)  NOT NULL,
    LastName varchar(50)  NOT NULL,
    Gender char(1)  NOT NULL,
    CONSTRAINT Person_pk PRIMARY KEY  (PersonID)
);

-- Table: Restoration
CREATE TABLE Restoration (
    RestorerID int  NOT NULL,
    PaintingID int  NOT NULL,
    Cost decimal(10,2)  NOT NULL,
    StartDate date  NOT NULL,
    EndDate date  NOT NULL,
    CONSTRAINT Restoration_pk PRIMARY KEY  (PaintingID,RestorerID)
);

-- Table: Restorer
CREATE TABLE Restorer (
    PersonID int  NOT NULL,
    Experience int  NOT NULL,
    CONSTRAINT Restorer_pk PRIMARY KEY  (PersonID)
);

-- Table: Role
CREATE TABLE Role (
    RoleID int  NOT NULL IDENTITY,
    RoleName varchar(50)  NOT NULL,
    CONSTRAINT Role_pk PRIMARY KEY  (RoleID)
);

-- Table: Ticket
CREATE TABLE Ticket (
    TicketID int  NOT NULL IDENTITY,
    DateOfVisitation date  NOT NULL,
    Price decimal(10,2)  NOT NULL,
    CONSTRAINT Ticket_pk PRIMARY KEY  (TicketID)
);

-- Table: User
CREATE TABLE "User" (
    UserID int  NOT NULL IDENTITY,
    Username varchar(50)  NOT NULL,
    Password varchar(255)  NOT NULL,
    Role_RoleID int  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (UserID)
);

-- Table: UserTicketMapping
CREATE TABLE UserTicketMapping (
    TicketID int  NOT NULL,
    UserID int  NOT NULL,
    Paid char(1)  NOT NULL,
    CONSTRAINT UserTicketMapping_pk PRIMARY KEY  (UserID,TicketID)
);

-- foreign keys
-- Reference: Author_Person (table: Author)
ALTER TABLE Author ADD CONSTRAINT Author_Person
    FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID);

-- Reference: Painting_Author (table: Painting)
ALTER TABLE Painting ADD CONSTRAINT Painting_Author
    FOREIGN KEY (AuthorID)
    REFERENCES Author (PersonID);

-- Reference: Restoration_Painting (table: Restoration)
ALTER TABLE Restoration ADD CONSTRAINT Restoration_Painting
    FOREIGN KEY (PaintingID)
    REFERENCES Painting (PaintingID);

-- Reference: Restoration_Restorer (table: Restoration)
ALTER TABLE Restoration ADD CONSTRAINT Restoration_Restorer
    FOREIGN KEY (RestorerID)
    REFERENCES Restorer (PersonID);

-- Reference: Restorer_Person (table: Restorer)
ALTER TABLE Restorer ADD CONSTRAINT Restorer_Person
    FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID);

-- Reference: UserTicketMapping_Ticket (table: UserTicketMapping)
ALTER TABLE UserTicketMapping ADD CONSTRAINT UserTicketMapping_Ticket
    FOREIGN KEY (TicketID)
    REFERENCES Ticket (TicketID);

-- Reference: UserTicketMapping_User (table: UserTicketMapping)
ALTER TABLE UserTicketMapping ADD CONSTRAINT UserTicketMapping_User
    FOREIGN KEY (UserID)
    REFERENCES "User" (UserID);

-- Reference: User_Role (table: User)
ALTER TABLE "User" ADD CONSTRAINT User_Role
    FOREIGN KEY (Role_RoleID)
    REFERENCES Role (RoleID);

-- End of file.

