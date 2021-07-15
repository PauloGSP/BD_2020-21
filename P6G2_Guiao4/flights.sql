CREATE SCHEMA flights;

CREATE TABLE flights.Flight (
    Number INT,
    Airline VARCHAR(25),
    Weekdays TINYINT DEFAULT 1,
    
    PRIMARY KEY (Number)
);

CREATE TABLE flights.Airport (
    Airport_Code CHAR(7),
    City VARCHAR(25),
    State VARCHAR(25),
    Name VARCHAR(50) NOT NULL,
    
    PRIMARY KEY (Airport_Code)
);

CREATE TABLE flights.Airplane_Type (
    Type_Name VARCHAR(20),
    Max_Seats INT,
    Company VARCHAR(50),
    
    PRIMARY KEY (Type_Name)
);

CREATE TABLE flights.Fare (
    Code CHAR(7),
    Amount NUMERIC(7,2) NOT NULL,
    Restrictions TINYINT DEFAULT 0,
    Flight_Number INT NOT NULL,
    
    PRIMARY KEY (Code),
    FOREIGN KEY (Flight_Number) REFERENCES flights.Flight(Number)
);

CREATE TABLE flights.Airplane (
    Airplane_id INT,
    Total_no_of_seats INT NOT NULL,
    Type_Name VARCHAR(20),
    
    PRIMARY KEY (Airplane_id),
    FOREIGN KEY (Type_Name) REFERENCES flights.Airplane_Type(Type_Name)
);

CREATE TABLE flights.Can_Land (
    Airport_Code CHAR(7),
    Airplane_Type_Name VARCHAR(20),
    
    PRIMARY KEY (Airport_Code, Airplane_Type_Name),
    FOREIGN KEY (Airport_Code) REFERENCES flights.Airport(Airport_Code),
    FOREIGN KEY (Airplane_Type_Name) REFERENCES flights.Airplane_Type(Type_Name)
);

CREATE TABLE flights.Flight_Leg (
    Flight_Number INT,
    Leg_no INT,
    Scheduled_dep_time TIME,
    Scheduled_arr_time TIME,
    Departure_Airport_Code CHAR(7) NOT NULL,
    Arrival_Airport_Code CHAR(7) NOT NULL,
    
    PRIMARY KEY (Flight_Number, Leg_no),
    FOREIGN KEY (Flight_Number) REFERENCES flights.Flight(Number),
    FOREIGN KEY (Departure_Airport_Code) REFERENCES flights.Airport(Airport_Code),
    FOREIGN KEY (Arrival_Airport_Code) REFERENCES flights.Airport(Airport_Code)
);

CREATE TABLE flights.Leg_Instance (
    Flight_Number INT,
    Leg_no INT,
    Date Date,
    No_of_avail_seats INT NOT NULL,
    Departure_time TIME,
    Arrival_time TIME,
    Departure_Airport_Code CHAR(7) NOT NULL,
    Arrival_Airport_Code CHAR(7),
    Airplane_id INT NOT NULL,
    
    PRIMARY KEY (Flight_Number, Leg_no, Date),
    FOREIGN KEY (Flight_Number, Leg_no) REFERENCES flights.Flight_Leg(Flight_Number, Leg_no),
    FOREIGN KEY (Departure_Airport_Code) REFERENCES flights.Airport(Airport_Code),
    FOREIGN KEY (Arrival_Airport_Code) REFERENCES flights.Airport(Airport_Code),
    FOREIGN KEY (Airplane_id) REFERENCES flights.Airplane(Airplane_id)
);

CREATE TABLE flights.Seat (
    Flight_Number INT,
    Leg_no INT,
    Date Date,
    Seat_no INT NOT NULL,
    Customer_name VARCHAR(50) NOT NULL,
    Cphone VARCHAR(20),
    
    PRIMARY KEY (Flight_Number, Leg_no, Date, Seat_no),
    FOREIGN KEY (Flight_Number, Leg_no, Date) REFERENCES flights.Leg_Instance(Flight_Number, Leg_no, Date)
);
