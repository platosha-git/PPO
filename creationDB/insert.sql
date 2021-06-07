/*INSERT INTO Booking (Customer, TourID, Login, Password) VALUES 
(1, '{}', '', ''),
(2, '{1, 4}', 'SergeiSinp', 'SPetrov15'),
(3, '{}', 'MrSklif', 'MrSklifqwer'),
(4, '{8}', 'Dealo', 'DealoProg1'),
(5, '{}', 'Koret', 'Koret97'),
(6, '{}', '', ''),
(7, '{}', '', ''),
(8, '{3}', 'MilaUkn', 'SarkisMil'),
(9, '{6}', 'GorVictor', 'Victor94'),
(10, '{}', '', '');

INSERT INTO Users (UserID, AccessLevel, Name, Surname, Year) VALUES 
(1, 0, 'Ivan', 'Ivanov', 1991),
(2, 1, 'Sergei', 'Petrov', 1992),
(3, 2, 'Denis', 'Sklifasovskii', 1990),
(4, 1, 'Pavel', 'Khetagurov', 1995),
(5, 2, 'Daniil', 'Suslikov', 1997),
(6, 0, 'Daria', 'Rusinova', 1999),
(7, 0, 'Maxim', 'Kozlov', 1998),
(8, 1, 'Milana', 'Sarkisyan', 1995),
(9, 1, 'Victor', 'Goryachev', 1994),
(10, 0, 'Dmitrii', 'Zhigalkin', 1993);
*/

/*INSERT INTO City (CityID, Name) VALUES
(1,	'Hollister'),
(2,	'Durango'),
(3,	'Winona'),
(4,	'Buffalo Grove'),
(5,	'Shelton'),
(6,	'Agoura Hills'),
(7,	'Northbrook'),
(8,	'Lindenwold'),
(9,	'La Mirada'),
(10, 'Calumet City');
*/

/*INSERT INTO Food (FoodID, Category, VegMenu, ChildrenMenu, Bar, Cost) VALUES 
(1, 'BB', TRUE, FALSE, TRUE, 2129),
(2,	'HB', TRUE, FALSE, FALSE, 499),
(3, 'AI+', TRUE, TRUE, FALSE, 1117),
(4, 'FB+', TRUE, FALSE, TRUE, 1233),
(5, 'HB+', TRUE, TRUE, FALSE, 2238),
(6, 'UAI', TRUE, TRUE, TRUE, 2282),
(7, 'HB+', FALSE, TRUE, FALSE, 804),
(8, 'BB', TRUE, FALSE, TRUE, 1427),
(9, 'FB', TRUE, TRUE, TRUE, 1958),
(10, 'HB', TRUE, TRUE, FALSE, 1401);
*/

/*INSERT INTO Hotel (HotelID, City, Name, Type, Class, SwimPool, Cost) VALUES 
(1,	10, 'Goodrich Corporation', 'Mini', 4, TRUE, 16895),
(2,	6, 'Profitpros', 'Resort', 5, FALSE, 7039),
(3,	5,	'Continental Airlines', 'Mini', 2, TRUE, 2368),
(4,	4, 'Quality Realty Service', 'B&B', 0, TRUE, 19073),
(5,	8, 'Master Builder Design Services', 'Mini', 3, TRUE, 19793),
(6,	2, 'Zoom Technologies', 'Mini', 0, TRUE, 23014),
(7,	1, 'Fellowship Investments', 'Apart', 4, TRUE, 21088),
(8,	9, 'CDI Corporation', 'Guest house', 3, FALSE, 7699),
(9,	3, 'Advansed Teksyztems',	'Mini', 5, TRUE, 15093),
(10, 7, 'Walgreens', 'Hostel', 5, TRUE, 6402);
*/

/*INSERT INTO BusTicket (BusTID, Seat, CityFrom, CityTo, DepartureTime, ArrivalTime, Luggage, Cost, Bus) VALUES
(0, 0, 1, 2, '00:00:00', '00:00:00', FALSE, 0, 0),
(1, 45, 4, 1, '10:23:00', '12:45:00', FALSE, 23012, 234),
(2, 34, 6, 8, '10:00:00', '11:45:00', TRUE, 14902, 174),
(3, 12, 1, 3, '01:13:00', '02:31:00', FALSE, 10029, 52),
(4, 9, 8, 7, '15:45:00', '17:04:00', FALSE, 7901, 5),
(5, 72, 9, 1, '09:31:00', '11:10:00', TRUE, 8102, 70),
(6, 3, 10, 3, '17:50:00', '18:53:00', TRUE, 15741, 41),
(7, 27, 2, 4, '06:29:00', '08:14:00', FALSE, 6204, 92),
(8, 10, 5, 9, '21:47:00', '23:07:00', TRUE, 3921, 13),
(9, 64, 3, 2, '19:56:00', '21:12:00', FALSE, 6193, 58),
(10, 71, 8, 1, '22:30:00', '23:58:00', TRUE, 5825, 48);
*/

/*INSERT INTO PlaneTicket (PlaneTID, Plane, Seat, Class, CityFrom, CityTo, DepartureTime, Luggage, Cost) VALUES
(0, 0, 0, 1, 1, 2, '00:00:00', FALSE, 0),
(1, 809, 45, 1, 4, 1, '10:23:00', FALSE, 23012),
(2, 713, 34, 2, 6, 8, '11:45:00', TRUE, 14902),
(3, 092, 12, 2, 1, 3, '01:13:00', FALSE, 10029),
(4, 7861, 9, 1, 8, 7, '17:04:00', FALSE, 7901),
(5, 975, 72, 1, 9, 1, '09:31:00', TRUE, 8102),
(6, 125, 3, 1, 10, 3, '18:53:00', TRUE, 15741),
(7, 92, 27, 2, 2, 4, '06:29:00', FALSE, 6204),
(8, 9871, 10, 1, 5, 9, '23:07:00', TRUE, 3921),
(9, 1930, 64, 2, 3, 2, '19:56:00', FALSE, 6193),
(10, 16, 71, 2, 8, 1, '23:58:00', TRUE, 5825);
*/

/*INSERT INTO TrainTicket (TrainTID, Train, Coach, Seat, CityFrom, CityTo, DepartureTime, ArrivalTime, Linens, Cost) VALUES
(0, 0, 1, 0, 1, 2, '00:00:00', '00:00:01', FALSE, 0),
(1, 809, 1, 4, 4, 1, '10:23:00', '12:45:00', FALSE, 2301),
(2, 713, 12, 3, 6, 8, '10:00:00', '11:45:00', TRUE, 1490),
(3, 092, 7, 12, 1, 3, '01:13:00', '02:31:00', FALSE, 1002),
(4, 7861, 3, 9, 8, 7, '15:45:00', '17:04:00', FALSE, 2901),
(5, 975, 8, 22, 9, 1, '09:31:00', '11:10:00', TRUE, 3102),
(6, 125, 2, 31, 10, 3, '17:50:00', '18:53:00', TRUE, 1574),
(7, 92, 6, 27, 2, 4, '06:29:00', '08:14:00', FALSE, 4204),
(8, 9871, 9, 10, 5, 9, '21:47:00', '23:07:00', TRUE, 3921),
(9, 1930, 10, 24, 3, 2, '19:56:00', '21:12:00', FALSE, 1193),
(10, 16, 11, 17, 8, 1, '22:30:00', '23:58:00', TRUE, 2825);
*/

/*INSERT INTO Transfer (TransferID, PlaneTicket, TrainTicket, BusTicket) VALUES
(1, 6, 0, 0),
(2, 4, 0, 7),
(3, 0, 3, 0),
(4, 0, 0, 10),
(5, 3, 1, 0),
(6, 0, 5, 8),
(7, 0, 0, 3),
(8, 6, 0, 0),
(9, 0, 4, 0),
(10, 0, 0, 1);
*/

/*INSERT INTO Tour (TourID, Food, Hotel, Transfer, Cost, DateBegin, DateEnd) VALUES
(1,	9,	4,	5, 32290,	'2020-01-14',	'2020-03-08'),
(2,	8,	5,	3, 54293,	'2020-07-19',	'2020-11-09'),
(3,	6,	6,	1, 91416,	'2021-05-25',	'2021-09-30'),
(4,	2,	1,	2, 31871,	'2020-08-27',	'2021-10-04'),
(5,	3,	10,	7, 93649,	'2021-04-02',	'2021-12-31'),
(6,	4,	2,	4, 26830,	'2021-01-27',	'2021-06-27'),
(7,	5,	9,	6, 9930,	'2020-07-24',	'2020-10-26'),
(8,	7,	3,	10, 13793,	'2021-05-26',	'2021-07-22'),
(9,	10,	8,	9, 82346,	'2021-04-17',	'2021-09-14'),
(10, 1,	7,	8, 42921,	'2020-10-09',	'2021-11-16');
*/









