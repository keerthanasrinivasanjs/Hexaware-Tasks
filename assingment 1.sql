CREATE DATABASE TechShop;
USE TechShop
Create table Customers (CustomerID int PRIMARY KEY,FirstName varchar(50) NOT NULL,LastName varchar(50) NOT NULL,Email varchar(100) UNIQUE NOT NULL,Phone varchar(15),Address TEXT);
create table Products (ProductID int primary key,ProductName VARCHAR(100) NOT NULL,Description TEXT,Price DECIMAL(10,2) NOT NULL);
create table Orders(OrderID int primary key, CustomerID int,OrderDate date not null,TotalAmount DECIMAL(10,2), foreign key (CustomerID) REFERENCES Customers(CustomerID));
create table OrderDetails (OrderDetailID int PRIMARY KEY,OrderID INT,ProductID INT,Quantity INT NOT NULL,FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),FOREIGN KEY (ProductID) REFERENCES Products(ProductID));
create table Inventory (InventoryID int PRIMARY KEY,ProductID INT,QuantityInStock INT NOT NULL,LastStockUpdate DATE not null,FOREIGN KEY (ProductID) REFERENCES Products(ProductID));

INSERT INTO Customers(FirstName, LastName, Email, Phone, Address) VALUES
('Arun', 'Kumar', 'arun.kumar@example.com', '9876543210', '12, Anna Salai, Chennai'),
('Muthu', 'Velan', 'muthu.velan@example.com', '8765432109', '45, Gandhi Veethi, Madurai'),
('Chandra', 'Babu', 'chandra.babu@example.com', '7654321098', '23, Kovil Theru, Trichy'),
('Lakshmi', 'Narayanan', 'lakshmi.narayan@example.com', '6543210987', '78, Madhavi Nagar, Coimbatore'),
('Ramya', 'Manoharan', 'ramya.manohar@example.com', '5432109876', '90, Sundaram Veethi, Tirunelveli'),
('Kesavan', 'Perumal', 'kesavan.perumal@example.com', '4321098765', '34, Raja Veethi, Salem'),
('Priya', 'Sundaram', 'priya.sundaram@example.com', '3210987654', '56, Malligai Nagar, Vellore'),
('Ganesh', 'Sivakumar', 'ganesh.siva@example.com', '2109876543', '67, Nandhana Veethi, Kanchipuram'),
('Vignesh', 'Anand', 'vignesh.anand@example.com', '1098765432', '89, Kumaran Nagar, Karur'),
('Saravanan', 'Murali', 'saravanan.murali@example.com', '9988776655', '101, Thennam Maram Veethi, Pudukottai');
INSERT INTO Customers(customerid,FirstName, LastName, Email, Phone, Address) VALUES
(101,'Arun', 'Kumar', 'arun.kumar@example.com', '9876543210', '12, Anna Salai, Chennai'),
(102,'Muthu', 'Velan', 'muthu.velan@example.com', '8765432109', '45, Gandhi Veethi, Madurai'),
(103,'Chandra', 'Babu', 'chandra.babu@example.com', '7654321098', '23, Kovil Theru, Trichy'),
(104,'Lakshmi', 'Narayanan', 'lakshmi.narayan@example.com', '6543210987', '78, Madhavi Nagar, Coimbatore'),
(105,'Ramya', 'Manoharan', 'ramya.manohar@example.com', '5432109876', '90, Sundaram Veethi, Tirunelveli'),
(106,'Kesavan', 'Perumal', 'kesavan.perumal@example.com', '4321098765', '34, Raja Veethi, Salem'),
(107,'Priya', 'Sundaram', 'priya.sundaram@example.com', '3210987654', '56, Malligai Nagar, Vellore'),
(108,'Ganesh', 'Sivakumar', 'ganesh.siva@example.com', '2109876543', '67, Nandhana Veethi, Kanchipuram'),
(109,'Vignesh', 'Anand', 'vignesh.anand@example.com', '1098765432', '89, Kumaran Nagar, Karur'),
(110,'Saravanan', 'Murali', 'saravanan.murali@example.com', '9988776655', '101, Thennam Maram Veethi, Pudukottai');
select*from customers
INSERT INTO Products (productid,ProductName, Description, Price) VALUES
(121,'iphone', '500 mb cloud storage', 1200.00),
(122,'android samsung', '12mp camera', 800.00),
(123,'boat Headphones', 'bass audio quality', 200.00),
(124,' matrix Keyboard', 'smooth handles and good for fast typers', 100.00),
(125,'Mouse', 'Wireless mouse', 50.00),
(126,'dual Monitor', '27-inch 4K display', 300.00),
(127,'apple ipad', '10-inch tablet', 400.00),
(128,'iwatch', 'waterproof smartwatch', 250.00),
(129,'Printer', 'Wireless printer', 150.00),
(130,'USB Drive', '128GB USB ram storage', 30.00);
select *from products;
INSERT INTO Orders (CustomerID,orderid,orderdate,TotalAmount) VALUES
(101,1,'2025-03-22', 1300.00), (102,2,'2025-03-22', 850.00), (103,3,'2025-03-23', 250.00), (104,4,'2025-03-21', 1100.00), (105,5,'2025-03-16', 150.00),
(106,6,'2025-03-09' ,500.00), (107,7,'2025-03-07', 100.00), (108,8,'2025-03-19', 1600.00), (109,9,'2025-03-02', 1200.00), (110, 10,'2025-03-20',200.00);

select *from orders;
INSERT INTO OrderDetails (orderDetailId,OrderID, ProductID, Quantity) VALUES
(001,1,121, 1), (002,2,122, 5), (033,3,123, 2), (044,4,124, 3), (055,5,125, 6),
(066,6,126, 9), (077,7,127 ,1), (088,8,128, 4), (099,9,129 ,8), (010,10,130, 6);
select*from orderdetails;
INSERT INTO Inventory (InventoryId,ProductID, QuantityInStock,LastStockUpdate) VALUES
(201,121,20,'2025-03-28'), (202,122,30,'2025-03-26'), (203,123,40,'2025-03-22'), (204,124,25,'2025-03-23'), (205,125, 60,'2025-03-21'),
(206,126 ,20,'2025-03-29'), (207,127, 35,'2025-03-29'), (208,128, 15,'2025-03-23'), (209,129,10,'2025-03-21'), (210,130 ,80,'2025-03-26');
select*from customers;
select *from products;
select *from orders;
select*from orderdetails;
select*from Inventory;
