create table tim
	(
		ID int NOT NULL primary key identity(1,1),
		ime  varchar(100) not null,
		bodovi int
	);

CREATE TABLE 
 mec
    ( ID int NOT NULL primary key identity(1,1),
		naziv varchar(100) not null,
	tip bit not null,
	aktivan bit,
    spreman bit,
	maxBrojIgraca int not null,
	prviTimID int not null,
	drugiTimID int not null,
	foreign key ( prviTimID ) references tim (ID),
	foreign key ( drugiTimID ) references tim (ID)
	);
	

	create table igra
	(
		ID int not null primary key identity(1,1),
		mecID int not null,
		killScore int,
		captureScore int,
		trajanje int,
		aktivna bit,
		foreign key ( mecID ) references mec (ID),
	);

	create table korisnik
	(
		ID int not null primary key identity(1,1),
		faceID varchar(200) not null,
		ime varchar(100) not null,
		prezime varchar(100) not null,
	);

	create table igrac
(
	ID int not null primary key identity(1,1),
	mrtav bit,
	geoDuljina varchar(100) not null,
	geoSirina varchar(100) not null,
	korisnikID int not null,
	foreign key ( korisnikID ) references korisnik (ID)
);

create table	timPripadnost
(
	ID int not null primary key identity(1,1),
	igracID int not null,
	timID int not null,
	foreign key ( timID ) references tim (ID),
	foreign key ( igracID ) references igrac (ID)
);

create table vrstaPrepreke
(
	ID int not null primary key identity(1,1),
	ime varchar(100) not null
);

create table prepreke
(
	ID int not null primary key identity(1,1),
	igraID int not null,
	preprekaID int not null,
	geoDuljina varchar(100) not null,
	geoSirina varchar(100) not null,
	foreign key ( igraID ) references igra (ID),
	foreign key ( preprekaID ) references vrstaPrepreke (ID)
);

create table suci
(
	ID int not null primary key identity(1,1),
	username varchar(100) not null,
	pass varchar(100) not null
);

