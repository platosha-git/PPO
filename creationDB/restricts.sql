ALTER TABLE Tour
ADD CONSTRAINT FK_TF FOREIGN KEY (Food) REFERENCES Food(FoodID),
ADD CONSTRAINT FK_TH FOREIGN KEY (Hotel) REFERENCES Hotel(HotelID),
ADD CONSTRAINT FK_TT FOREIGN KEY (Transfer) REFERENCES Transfer(TransferID);

ALTER TABLE Users 
ADD CONSTRAINT FK_UB FOREIGN KEY (UserID) REFERENCES Booking(Customer);

ALTER TABLE Hotel 
ADD CONSTRAINT UK_H UNIQUE (Name),
ADD CONSTRAINT FK_HC FOREIGN KEY (City) REFERENCES City(CityID);

ALTER TABLE City 
ADD CONSTRAINT UK_C UNIQUE (Name);

ALTER TABLE Transfer
ADD CONSTRAINT FK_TP FOREIGN KEY (PlaneTicket) REFERENCES PlaneTicket(PlaneTID),
ADD CONSTRAINT FK_TT FOREIGN KEY (TrainTicket) REFERENCES TrainTicket(TrainTID),
ADD CONSTRAINT FK_TB FOREIGN KEY (BusTicket) REFERENCES BusTicket(BusTID);

ALTER TABLE PlaneTicket
ADD CONSTRAINT FK_PCF FOREIGN KEY (CityFrom) REFERENCES City(CityID),
ADD CONSTRAINT FK_PCT FOREIGN KEY (CityTo) REFERENCES City(CityID);

ALTER TABLE TrainTicket
ADD CONSTRAINT FK_TCF FOREIGN KEY (CityFrom) REFERENCES City(CityID),
ADD CONSTRAINT FK_TCT FOREIGN KEY (CityTo) REFERENCES City(CityID);

ALTER TABLE BusTicket
ADD CONSTRAINT FK_BCF FOREIGN KEY (CityFrom) REFERENCES City(CityID),
ADD CONSTRAINT FK_BCT FOREIGN KEY (CityTo) REFERENCES City(CityID);


/*CHECK*/
ALTER TABLE Food
ADD CONSTRAINT FCost_CHK CHECK (Cost >= 0);

ALTER TABLE Tour 
ADD CONSTRAINT TCost_CHK CHECK (Cost >= 0),
ADD CONSTRAINT TDate_CHK CHECK (DateBegin <= DateEnd);

ALTER TABLE Users
ADD CONSTRAINT UAL_CHK CHECK (AccessLevel >= 0 AND AccessLevel <= 3);

ALTER TABLE Hotel 
ADD CONSTRAINT HCost_CHK CHECK (Cost >= 0),
ADD CONSTRAINT HType_CHK CHECK (Type = 'Hostel' OR Type = 'Mini' OR 
				Type = 'Resort' OR Type = 'Guest house' OR 
				Type = 'Apart' OR Type = 'B&B' OR 
				Type = 'Business' OR Type = 'Motel' OR Type = 'Spa'),
ADD CONSTRAINT HClass_CHK CHECK (Class >= 0 AND Class <= 5);

ALTER TABLE PlaneTicket
ADD CONSTRAINT PTCost_CHK CHECK (Cost >= 0),
ADD CONSTRAINT PTClass_CHK CHECK (Class = 1 OR Class = 2);

ALTER TABLE TrainTicket
ADD CONSTRAINT TTCost_CHK CHECK (Cost >= 0),
ADD CONSTRAINT TTCoach_CHK CHECK (Coach >= 1 AND Coach <= 20), 
ADD CONSTRAINT TTTime_CHK CHECK (DepartureTime <= ArrivalTime);

ALTER TABLE BusTicket
ADD CONSTRAINT BTCost_CHK CHECK (Cost >= 0),
ADD CONSTRAINT TTTime_CHK CHECK (DepartureTime <= ArrivalTime);





