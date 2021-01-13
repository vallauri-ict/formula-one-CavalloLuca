CREATE TABLE `teams` (
  `ID` int PRIMARY KEY AUTO_INCREMENT,
  `teamName` varchar(255),
  `teamLogo` image,
  `base` varchar(255),
  `teamChief` varchar(255),
  `technicalChief` varchar(255),
  `powerUnit` varchar(255),
  `carImage` image,
  `countryID` int,
  `worldChampionships` int,
  `polePositions` int
);

CREATE TABLE `countries` (
  `ID` int PRIMARY KEY,
  `countryName` varchar(255)
);

CREATE TABLE `drivers` (
  `ID` int PRIMARY KEY,
  `number` int,
  `name` varchar(255),
  `dob` date,
  `helmetInage` image,
  `image` image,
  `teamID` int,
  `podiums` int,
  `countryID` int
);

CREATE TABLE `results` (
  `ID` int PRIMARY KEY,
  `teamID` int,
  `driverID` int,
  `number` int,
  `position` int,
  `points` int,
  `time` double,
  `fastestLapTime` double,
  `fastestLapSpeed` double
);

CREATE TABLE `circuits` (
  `ID` int PRIMARY KEY,
  `name` varchar(255),
  `location` varchar(255),
  `countryID` varchar(255),
  `lat` varchar(255),
  `long` varchar(255),
  `alt` double
);

CREATE TABLE `races` (
  `ID` int PRIMARY KEY,
  `round` int,
  `circuitID` int,
  `name` varchar(255),
  `date` date,
  `startTime` datetime,
  `totalTime` datetime
);

CREATE TABLE `constructorResults` (
  `ID` int PRIMARY KEY,
  `teamResult` int,
  `raceID` int,
  `driverID` int,
  `countryID` varchar(255)
);

ALTER TABLE `teams` ADD FOREIGN KEY (`ID`) REFERENCES `drivers` (`teamID`);

ALTER TABLE `teams` ADD FOREIGN KEY (`countryID`) REFERENCES `countries` (`ID`);

ALTER TABLE `drivers` ADD FOREIGN KEY (`countryID`) REFERENCES `countries` (`ID`);

ALTER TABLE `results` ADD FOREIGN KEY (`teamID`) REFERENCES `teams` (`ID`);

ALTER TABLE `results` ADD FOREIGN KEY (`driverID`) REFERENCES `drivers` (`ID`);

ALTER TABLE `constructorResults` ADD FOREIGN KEY (`raceID`) REFERENCES `races` (`ID`);

ALTER TABLE `constructorResults` ADD FOREIGN KEY (`driverID`) REFERENCES `drivers` (`ID`);

ALTER TABLE `constructorResults` ADD FOREIGN KEY (`countryID`) REFERENCES `countries` (`ID`);

ALTER TABLE `races` ADD FOREIGN KEY (`circuitID`) REFERENCES `circuits` (`ID`);

ALTER TABLE `drivers` ADD FOREIGN KEY (`number`) REFERENCES `results` (`number`);

ALTER TABLE `circuits` ADD FOREIGN KEY (`countryID`) REFERENCES `countries` (`ID`);
