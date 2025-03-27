use techshop
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


-- retrieve the names and emails of all customers
select FirstName, LastName, Email from customers;

-- list all orders with their order dates and corresponding customer names
select orders.orderid, orders.orderdate, customers.firstname, customers.lastname
from orders
join customers on orders.CustomerID = customers.customerid;


-- insert a new customer record into the "customers" table (example values)
insert into customers (customerid, firstname, lastname, email, phone, address) 
    values (111, 'ava', 'clark', 'ava.clark@email.com', '9456345672', '123 river st, brooktown');
select * from customers;

-- update the prices of all electronic gadgets in the "products" table by increasing them by 10%
select productid, productname, price as old_price, price * 1.10 as simulated_new_price
    from products where productname in ('laptop', 'smartphone', 'tablet', 'smartwatch', 'headphones', 'charger');

-- delete a specific order and its associated order details (user provides @orderid)
declare @orderid int = 3; delete from orderdetails where orderid = @orderid; 
delete from orders where orderid = @orderid;

-- insert a new order into the orders table
insert into orders (orderid, customerid, orderdate, totalamount) values (11, 5, '2025-03-26', 499.99);

-- update the contact information (email and address) of a specific customer in the customers table
declare @customerid int = 3; declare @newemail varchar(50) = 'updated.email@email.com'; 
declare @newaddress varchar(200) = 'updated address, new city'; 
update customers set email = @newemail, address = @newaddress where customerid = @customerid;

-- update the total cost of each order in the orders table based on the prices and quantities in the orderdetails table
select o.orderid, (select sum(od.quantity * p.price) 
    from orderdetails od, products p where od.productid = p.productid and od.orderid = o.orderid) as recalculated_total from orders o;

-- delete all orders and their associated order details for a specific customer
declare @customer_id int = 3; delete from orderdetails
    where orderid in (select orderid from orders where customerid = @customer_id); delete from orders where customerid = @customer_id; select * from customers;

-- insert a new electronic gadget product into the products table
insert into products (productid, productname, description, price) 
    values (11, 'wireless earbuds', 'bluetooth-enabled wireless earbuds with noise cancellation', 129.99);

-- add a state column to the orders table and update the order status
alter table orders add state varchar(20); declare @order_id int = 5;
declare @newstatus varchar(20) = 'shipped'; update orders set state = @newstatus where orderid = @order_id;

-- add an order_count column to the customers table and update it with the number of orders for each customer
alter table customers add order_count int default 0;
update customers set order_count = (select count(*) from orders o where o.customerid = customerid);

select*from customers
select*from orders
select*from orderDetails
select*from products
select*from Inventory
DBCC FREEPROCCACHE;
