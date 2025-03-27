create database crime
use crime
-- Create tables
create table Crime (CrimeID INT PRIMARY KEY,IncidentType VARCHAR(255),IncidentDate DATE,Location VARCHAR(255),Description TEXT,
Status VARCHAR(20));
create TABLE Victim (VictimID INT PRIMARY KEY,CrimeID INT,Name VARCHAR(255),ContactInfo VARCHAR(255),Injuries VARCHAR(255),
FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID));


INSERT INTO Crime ( crimeID,IncidentType, IncidentDate, Location, Description, Status)  
VALUES  
(1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
(2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'UnderInvestigation'),
(3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed')
(4,'Burglary', '2023-10-05', '101 Pine St, Metropolis', 'Break-in at a residential home', 'Open'),  
(5,'Fraud', '2023-11-12', '202 Maple St, Springfield', 'Credit card fraud at a local store', 'Under Investigation'),  
(6,'Assault', '2023-12-01', '303 Birch St, Riverdale', 'Physical assault reported at a bar', 'Closed'),  
(7,'Arson', '2024-01-15', '404 Cedar St, Greenville', 'Deliberate fire set in an abandoned warehouse', 'Under Investigation'),  
(8,'Kidnapping', '2024-02-20', '505 Walnut St, Lakeside', 'Missing person case suspected to be a kidnapping', 'Open'),  
(9,'Cyber Crime', '2024-03-05', 'Online', 'Unauthorized access to a corporate database', 'Closed'),  
(10,'Drug Possession', '2024-03-18', '606 Chestnut St, Hilltown', 'Illegal drug possession during a traffic stop', 'Under Investigation');
select* from crime
select*from suspect
INSERT INTO Victim (VictimID, CrimeID, Name, ContactInfo, Injuries)
VALUES
(1, 1, 'John Doe', 'johndoe@example.com', 'Minor injuries'),
(2, 2, 'Jane Smith', 'janesmith@example.com', 'Deceased'),
(3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None');(4,4, 'Michael Brown', 'michaelbrown@example.com', 'Severe head injury'),  
(5, 5,'Sarah Davis', 'sarahdavis@example.com', 'Bruises and cuts'),  
(6,6, 'Robert Wilson', 'robertwilson@example.com', 'No injuries reported'),  
(7,7, 'Emily Clark', 'emilyclark@example.com', 'Severe burns'),  
(8,8, 'David Lewis', 'davidlewis@example.com', 'Kidnapped, still missing'),  
(9, 9,'Sophia Martinez', 'sophiamartinez@example.com', 'Victim of cyber fraud'),  
(10, 10,'Daniel White', 'danielwhite@example.com', 'Minor injuries from altercation');
create TABLE Suspect (SuspectID INT PRIMARY KEY,CrimeID INT,Name VARCHAR(255),Description TEXT,CriminalHistory TEXT,FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID));
INSERT INTO Suspect (SuspectID, CrimeID, Name, Description, CriminalHistory)
VALUES
(101,1, 'Robber 1', 'Armed and masked robber', 'Previous robbery convictions'),  
(102,2, 'Unknown', 'Investigation ongoing', NULL),  
(103,3, 'Suspect 1', 'Shoplifting suspect', 'Prior shoplifting arrests'),  
(104,4, 'Burglar 1', 'Suspect caught on surveillance breaking in', 'Prior burglary cases'),  
(105,5, 'Fraudster X', 'Involved in multiple financial frauds', 'Fraud charges in 2019'),  
(106,6, 'Assault Suspect A', 'Bar fight participant, witnesses identified', 'History of violent behavior'),  
(107,7, 'Arsonist Z', 'Witnesses reported seeing the suspect near the fire site', 'Suspected in past arson cases'),  
(108,8, 'Kidnapper Y', 'Last seen with missing person', 'No prior criminal records'),  
(109,9, 'Hacker 007', 'Suspect of corporate cyberattack', 'Hacking-related offenses'),  
(110,10, 'Drug Dealer M', 'Caught selling illegal substances during a traffic stop', 'Multiple drug-related arrests');  
   



--1.Select all open incidents.
select*from crime where status='open'

--2. Find the total number of incidents.
select count(*) as tot_incident from crime;

--3. List all unique incident types.
select distinct IncidentType from crime

-- 4.Retrieve incidents that occurred between '2023-09-01' and '2023-09-10'.
select IncidentType from crime where incidentdate between '2023-09-01' and '2023-09-10';

-- 5.List persons involved in incidents in descending order of age.
alter table victim add age int
UPDATE victim SET Age = 25 WHERE VictimID = 1;
UPDATE victim SET Age = 30 WHERE VictimID = 2;
UPDATE victim SET Age = 22 WHERE VictimID = 3;
UPDATE victim SET Age = 25 WHERE VictimID = 4;
UPDATE victim SET Age = 30 WHERE VictimID = 5;
UPDATE victim SET Age = 22 WHERE VictimID = 6;
UPDATE victim SET Age = 28 WHERE VictimID = 7;
UPDATE victim SET Age = 26 WHERE VictimID = 8;
UPDATE victim SET Age = 34 WHERE VictimID = 9;
UPDATE victim SET Age = 35 WHERE VictimID = 10;
select*from victim
alter TABLE Suspect ADD Age INT;
UPDATE Suspect SET Age = 35 WHERE SuspectID = 101;  
UPDATE Suspect SET Age = 29 WHERE SuspectID = 102;  
UPDATE Suspect SET Age = 40 WHERE SuspectID = 103;  
UPDATE Suspect SET Age = 50 WHERE SuspectID = 104;  
UPDATE Suspect SET Age = 45 WHERE SuspectID = 105;  
UPDATE Suspect SET Age = 33 WHERE SuspectID = 106; 
UPDATE Suspect SET Age = 37 WHERE SuspectID = 107;  
UPDATE Suspect SET Age = 34 WHERE SuspectID = 108;  
UPDATE Suspect SET Age = 39 WHERE SuspectID = 109;  
UPDATE Suspect SET Age = 32 WHERE SuspectID = 110; 
select name,age from(select v.name,v.age from victim v join crime c on
v.crimeID=c.crimeID union select s.name,s.age from suspect s join crime c on s.crimeID=c.crimeID) as person_involved order by age desc;

-- 6.Find the average age of persons involved in incidents.

select avg(age) as avg_age from victim

-- 7.List incident types and their counts, only for open cases.

select incidenttype,count(incidenttype) from crime where status='open'
group by incidenttype

 --8.Find persons with names containing 'Doe'.

 select name from victim where name like '%doe%' 
 union select name from suspect where name like '%doe%'

 --9.Retrieve the names of persons involved in open cases and closed cases.

 select name,status from victim v join crime c on v.crimeID=c.CrimeID 
 where c.status in ('open','closed');

-- 10.List incident types where there are persons aged 30 or 35 involved.
select incidenttype from crime c join victim v on v.crimeID=c.crimeID where v.age
in (30,35);

-- 11.Find persons involved in incidents of the same type as 'Robbery'.
select name from victim v join crime c on v.crimeID=c.crimeID where incidenttype='robbery'
union select name from suspect s join crime c on s.crimeId=c.crimeID where incidenttype='robbery'

-- 12.List incident types with more than one open case.
select incidenttype from crime group by (incidenttype) having count('open')>1;

-- 13.List all incidents with suspects whose names also appear as victims in other incidents.

select c.incidenttype,s.name from crime c join suspect s on c.crimeID=s.crimeId
where s.name in(select name from victim v where v.crimeID!=c.crimeID)
 select* from victim
 select* from suspect

-- 14.Retrieve all incidents along with victim and suspect details.
select c.incidenttype,v.name as victimname,s.name as suspectname from crime c
left join victim v on c.crimeID=v.crimeID left join suspect s on c.crimeID=s.CrimeID;

--15. Find incidents where the suspect is older than any victim.
select c.incidenttype from crime c join suspect s on c.crimeID=s.crimeID 
join victim v on c.crimeID=v.crimeID where s.age>v.age;

--16. Find suspects involved in multiple incidents:
select s.name as suspectname,count(c.crimeID) as incident_count from suspect s join crime 
c on s.crimeID=c.crimeID group by s.name having count(c.crimeID)>1;

--17. List incidents with no suspects involved.
select incidenttype from crime c left join suspect s on 
c.crimeID=s.crimeID where s.suspectID is null

-- 18.List all cases where at least one incident is of type 'Homicide' and all other incidents are of type
--'Robbery'.
select incidenttype from crime where incidenttype in ('Homicide','robbery') group by
incidenttype having count(incidenttype)=1

-- 19.Retrieve a list of all incidents and the associated suspects, showing suspects for each incident, or
--'No Suspect' if there are none.
 select incidenttype,isnull (s.name,'NO Suspect') as suspectname from crime c left join
 suspect s on c.crimeID=s.crimeID;

-- 20.List all suspects who have been involved in incidents with incident types 'Robbery' or 'Assault'
select s.Name, c.incidenttype from suspect s join crime c ON s.CrimeID = c.CrimeID
where c.incidenttype in ('Robbery', 'Assault');
