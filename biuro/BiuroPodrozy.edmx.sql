










































-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 01/21/2016 12:10:21

-- Generated from EDMX file: F:\Programowanie\code\HatefulVoyagers\biuro\BiuroPodrozy.edmx
-- Target version: 3.0.0.0

-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


--    ALTER TABLE `OsobyTowarzyszaceSet` DROP CONSTRAINT `FK_OsobyTowarzyszaceRezerwacje`;

--    ALTER TABLE `RezerwacjeSet` DROP CONSTRAINT `FK_RezerwacjeKlient`;

--    ALTER TABLE `RezerwacjeSet` DROP CONSTRAINT `FK_RezerwacjePokoje`;

--    ALTER TABLE `RezerwacjeSet` DROP CONSTRAINT `FK_RezerwacjeOferta`;

--    ALTER TABLE `OfertaSet` DROP CONSTRAINT `FK_ProgramOferta`;

--    ALTER TABLE `OfertaSet` DROP CONSTRAINT `FK_PunktWyjazduOferta`;

--    ALTER TABLE `OfertaSet` DROP CONSTRAINT `FK_MiejsceOferta`;

--    ALTER TABLE `NoclegSet` DROP CONSTRAINT `FK_MiejsceNocleg`;

--    ALTER TABLE `PokojeSet` DROP CONSTRAINT `FK_NoclegPokoje`;

--    ALTER TABLE `KlientSet` DROP CONSTRAINT `FK_UzytkownikKlient`;

--    ALTER TABLE `OpinieSet` DROP CONSTRAINT `FK_OpinieMiejsce`;


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;

    DROP TABLE IF EXISTS `OsobyTowarzyszaceSet`;

    DROP TABLE IF EXISTS `KlientSet`;

    DROP TABLE IF EXISTS `ProgramSet`;

    DROP TABLE IF EXISTS `PunktWyjazduSet`;

    DROP TABLE IF EXISTS `RezerwacjeSet`;

    DROP TABLE IF EXISTS `OfertaSet`;

    DROP TABLE IF EXISTS `MiejsceSet`;

    DROP TABLE IF EXISTS `NoclegSet`;

    DROP TABLE IF EXISTS `PokojeSet`;

    DROP TABLE IF EXISTS `UzytkownikSet`;

    DROP TABLE IF EXISTS `OpinieSet`;

SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `OsobyTowarzyszaceSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Imie` varchar (15) NOT NULL, 
	`Nazwisko` varchar (40) NOT NULL, 
	`DataUrodzenia` datetime NOT NULL, 
	`RezerwacjeID` int NOT NULL);

ALTER TABLE `OsobyTowarzyszaceSet` ADD PRIMARY KEY (ID);





CREATE TABLE `KlientSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Imie` varchar (15) NOT NULL, 
	`Nazwisko` varchar (40) NOT NULL, 
	`Adres` varchar (70) NOT NULL, 
	`DataUrodzenia` datetime NOT NULL, 
	`Telefon` varchar (15) NOT NULL, 
	`Email` varchar (40), 
	`NumerDowodu` varchar (30) NOT NULL, 
	`Uzytkownik_ID` int NOT NULL);

ALTER TABLE `KlientSet` ADD PRIMARY KEY (ID);





CREATE TABLE `ProgramSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Opis` varchar (500) NOT NULL);

ALTER TABLE `ProgramSet` ADD PRIMARY KEY (ID);





CREATE TABLE `PunktWyjazduSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Adres` varchar (70) NOT NULL);

ALTER TABLE `PunktWyjazduSet` ADD PRIMARY KEY (ID);





CREATE TABLE `RezerwacjeSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`KlientID` int NOT NULL, 
	`PokojeID` int NOT NULL, 
	`OfertaID` int NOT NULL);

ALTER TABLE `RezerwacjeSet` ADD PRIMARY KEY (ID);





CREATE TABLE `OfertaSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Cena` decimal( 9, 2 )  NOT NULL, 
	`DataWyjazdu` datetime NOT NULL, 
	`DataPowrotu` datetime NOT NULL, 
	`ProgramID` int NOT NULL, 
	`PunktWyjazduID` int NOT NULL, 
	`MiejsceID` int NOT NULL);

ALTER TABLE `OfertaSet` ADD PRIMARY KEY (ID);





CREATE TABLE `MiejsceSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Nazwa` varchar (30) NOT NULL, 
	`Opis` varchar (500) NOT NULL);

ALTER TABLE `MiejsceSet` ADD PRIMARY KEY (ID);





CREATE TABLE `NoclegSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Adres` varchar (70) NOT NULL, 
	`Standard` varchar (150) NOT NULL, 
	`MiejsceID` int NOT NULL, 
	`Nazwa` longtext NOT NULL);

ALTER TABLE `NoclegSet` ADD PRIMARY KEY (ID);





CREATE TABLE `PokojeSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Dostepny` bool NOT NULL, 
	`LiczbaMiejsc` smallint NOT NULL, 
	`NumerPokoju` smallint NOT NULL, 
	`NoclegID` int NOT NULL);

ALTER TABLE `PokojeSet` ADD PRIMARY KEY (ID);





CREATE TABLE `UzytkownikSet`(
	`ID` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Rola` smallint NOT NULL, 
	`Login` varchar (50) NOT NULL, 
	`Haslo` varchar (50) NOT NULL);

ALTER TABLE `UzytkownikSet` ADD PRIMARY KEY (ID);





CREATE TABLE `OpinieSet`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Opinia` longtext NOT NULL, 
	`MiejsceID` int NOT NULL, 
	`Nick` longtext NOT NULL);

ALTER TABLE `OpinieSet` ADD PRIMARY KEY (Id);







-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------


-- Creating foreign key on `RezerwacjeID` in table 'OsobyTowarzyszaceSet'

ALTER TABLE `OsobyTowarzyszaceSet`
ADD CONSTRAINT `FK_OsobyTowarzyszaceRezerwacje`
    FOREIGN KEY (`RezerwacjeID`)
    REFERENCES `RezerwacjeSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_OsobyTowarzyszaceRezerwacje'

CREATE INDEX `IX_FK_OsobyTowarzyszaceRezerwacje`
    ON `OsobyTowarzyszaceSet`
    (`RezerwacjeID`);



-- Creating foreign key on `KlientID` in table 'RezerwacjeSet'

ALTER TABLE `RezerwacjeSet`
ADD CONSTRAINT `FK_RezerwacjeKlient`
    FOREIGN KEY (`KlientID`)
    REFERENCES `KlientSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_RezerwacjeKlient'

CREATE INDEX `IX_FK_RezerwacjeKlient`
    ON `RezerwacjeSet`
    (`KlientID`);



-- Creating foreign key on `PokojeID` in table 'RezerwacjeSet'

ALTER TABLE `RezerwacjeSet`
ADD CONSTRAINT `FK_RezerwacjePokoje`
    FOREIGN KEY (`PokojeID`)
    REFERENCES `PokojeSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_RezerwacjePokoje'

CREATE INDEX `IX_FK_RezerwacjePokoje`
    ON `RezerwacjeSet`
    (`PokojeID`);



-- Creating foreign key on `OfertaID` in table 'RezerwacjeSet'

ALTER TABLE `RezerwacjeSet`
ADD CONSTRAINT `FK_RezerwacjeOferta`
    FOREIGN KEY (`OfertaID`)
    REFERENCES `OfertaSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_RezerwacjeOferta'

CREATE INDEX `IX_FK_RezerwacjeOferta`
    ON `RezerwacjeSet`
    (`OfertaID`);



-- Creating foreign key on `ProgramID` in table 'OfertaSet'

ALTER TABLE `OfertaSet`
ADD CONSTRAINT `FK_ProgramOferta`
    FOREIGN KEY (`ProgramID`)
    REFERENCES `ProgramSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramOferta'

CREATE INDEX `IX_FK_ProgramOferta`
    ON `OfertaSet`
    (`ProgramID`);



-- Creating foreign key on `PunktWyjazduID` in table 'OfertaSet'

ALTER TABLE `OfertaSet`
ADD CONSTRAINT `FK_PunktWyjazduOferta`
    FOREIGN KEY (`PunktWyjazduID`)
    REFERENCES `PunktWyjazduSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_PunktWyjazduOferta'

CREATE INDEX `IX_FK_PunktWyjazduOferta`
    ON `OfertaSet`
    (`PunktWyjazduID`);



-- Creating foreign key on `MiejsceID` in table 'OfertaSet'

ALTER TABLE `OfertaSet`
ADD CONSTRAINT `FK_MiejsceOferta`
    FOREIGN KEY (`MiejsceID`)
    REFERENCES `MiejsceSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_MiejsceOferta'

CREATE INDEX `IX_FK_MiejsceOferta`
    ON `OfertaSet`
    (`MiejsceID`);



-- Creating foreign key on `MiejsceID` in table 'NoclegSet'

ALTER TABLE `NoclegSet`
ADD CONSTRAINT `FK_MiejsceNocleg`
    FOREIGN KEY (`MiejsceID`)
    REFERENCES `MiejsceSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_MiejsceNocleg'

CREATE INDEX `IX_FK_MiejsceNocleg`
    ON `NoclegSet`
    (`MiejsceID`);



-- Creating foreign key on `NoclegID` in table 'PokojeSet'

ALTER TABLE `PokojeSet`
ADD CONSTRAINT `FK_NoclegPokoje`
    FOREIGN KEY (`NoclegID`)
    REFERENCES `NoclegSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_NoclegPokoje'

CREATE INDEX `IX_FK_NoclegPokoje`
    ON `PokojeSet`
    (`NoclegID`);



-- Creating foreign key on `Uzytkownik_ID` in table 'KlientSet'

ALTER TABLE `KlientSet`
ADD CONSTRAINT `FK_UzytkownikKlient`
    FOREIGN KEY (`Uzytkownik_ID`)
    REFERENCES `UzytkownikSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_UzytkownikKlient'

CREATE INDEX `IX_FK_UzytkownikKlient`
    ON `KlientSet`
    (`Uzytkownik_ID`);



-- Creating foreign key on `MiejsceID` in table 'OpinieSet'

ALTER TABLE `OpinieSet`
ADD CONSTRAINT `FK_OpinieMiejsce`
    FOREIGN KEY (`MiejsceID`)
    REFERENCES `MiejsceSet`
        (`ID`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_OpinieMiejsce'

CREATE INDEX `IX_FK_OpinieMiejsce`
    ON `OpinieSet`
    (`MiejsceID`);



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
