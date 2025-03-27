create database tech;
use   tech;
create table customers (customerid int primary key ,firstname varchar(50) ,lastname varchar(20),email varchar(50),phone varchar(20),address varchar(200));
create table products (productid int primary key ,productname varchar(100) not null ,description TEXT,price decimal (10,2)not null);
create table orders(orderid int primary key,customerid int,orderdate date not null ,totalamount decimal (10,2) not null, foreign key (customerid) references customers(customerid)); 
create table orderdetails(orderdetailid int primary key,orderid int,productid int,quantity int not null,foreign key (orderid) references orders(orderid),foreign key (productid) references products(productid));
create table inventory(inventoryid int primary key ,productid int,quantityinstock int not null, laststockupdate DATE,foreign key (productid) references products(productid)); 
insert into customers (customerid, firstname, lastname, email, phone, address)
VALUES
(1, 'John', 'Doe', 'john.doe@email.com', '555-1001', '1234 Elm St, Springfield'),
(2, 'Jane', 'Smith', 'jane.smith@email.com', '555-1002', '5678 Oak St, Rivertown'),
(3, 'Michael', 'Johnson', 'michael.johnson@email.com', '555-1003', '1357 Maple Ave, Pleasantville'),
(4, 'Emily', 'Davis', 'emily.davis@email.com', '555-1004', '2468 Pine St, Lakeside'),
(5, 'William', 'Brown', 'william.brown@email.com', '555-1005', '9876 Birch Rd, Highland Park'),
(6, 'Olivia', 'Miller', 'olivia.miller@email.com', '555-1006', '1359 Cedar Blvd, Summit City'),
(7, 'Daniel', 'Wilson', 'daniel.wilson@email.com', '555-1007', '3690 Willow Ln, Greenfield'),
(8, 'Sophia', 'Moore', 'sophia.moore@email.com', '555-1008', '7531 Maple Dr, Westbrook'),
(9, 'James', 'Taylor', 'james.taylor@email.com', '555-1009', '8642 Elmwood Ave, Crestwood'),
(10, 'Liam', 'Anderson', 'liam.anderson@email.com', '555-1010', '9753 Oakwood St, Redwood City');
insert into products (productid, productname, description, price) VALUES
(1, 'Laptop', 'A high-performance laptop', 899.99),
(2, 'Smartphone', 'A cutting-edge smartphone', 599.99),
(3, 'Headphones', 'Noise-cancelling headphones', 49.99),
(4, 'Mouse', 'Wireless mouse', 19.99),
(5, 'Keyboard', 'Mechanical keyboard', 29.99),
(6, 'Monitor', '24-inch LED monitor', 299.99),
(7, 'Charger', 'Fast charging USB charger', 14.99),
(8, 'Smartwatch', 'Fitness tracking smartwatch', 199.99),
(9, 'Tablet', '10-inch Android tablet', 349.99),
(10, 'External Hard Drive', '1TB external hard drive', 99.99);
insert into orders (orderid, customerid, orderdate, totalamount) VALUES
(1, 1, '2025-03-20', 899.99),
(2, 2, '2025-03-21', 1199.98),
(3, 3, '2025-03-22', 49.99),
(4, 4, '2025-03-22', 29.99),
(5, 5, '2025-03-23', 399.98),
(6, 6, '2025-03-23', 599.97),
(7, 7, '2025-03-24', 899.99),
(8, 8, '2025-03-24', 199.99),
(9, 9, '2025-03-25', 249.99),
(10, 10, '2025-03-25', 699.98);
insert into orderdetails (orderdetailid, orderid, productid, quantity) VALUES
(1, 1, 1, 1),  
(2, 2, 2, 2), 
(3, 3, 3, 1), 
(4, 4, 4, 1), 
(5, 5, 5, 2),  
(6, 6, 6, 2), 
(7, 7, 7, 1), 
(8, 8, 8, 1), 
(9, 9, 9, 1), 
(10, 10, 10, 2);
insert into inventory (inventoryid, productid, quantityinstock ,laststockupdate) VALUES
(1, 1, 50, '2025-03-20'),
(2, 2, 100, '2025-03-21'),
(3, 3, 150, '2025-03-22'),
(4, 4, 200, '2025-03-23'),
(5, 5, 120, '2025-03-23'),
(6, 6, 30, '2025-03-24'),
(7, 7, 250, '2025-03-25'),
(8, 8, 75, '2025-03-26'),
(9, 9, 60, '2025-03-27'),
(10, 10, 80, '2025-03-28');
select * from customers;


select * from products;
select * from orders;
select * from orderdetails;
select * from inventory;
-----aggregate
---- Retrieve all orders with customer details ----'
select o.orderid,o.orderdate,o.totalamount,c.firstname,c.lastname,c.email
from orders o
join customers c 
on o.customerid=c.customerid; 


--- Calculate total revenue for each electronic gadget 
select p.productname, sum(od.quantity * p.price) as total_revenue
from orderdetails od
join products p on od.productid = p.productid
group by p.productname;



-- Get customers who have made at least one purchase --
select distinct c.firstname,c.lastname, c.email
from customers c
join orders on c.customerid = orders.customerid;

--- Find the most popular electronic gadget 
select top 1 p.productname, sum(od.quantity) as total_quantity_ordered
from orderdetails od
join products p on od.productid = p.productid
group by p.productname
order by total_quantity_ordered desc;


---- List electronic gadgets with their categories ---
select productname, 'electronic gadgets' as category
from products
where productname in ('laptop', 'smartphone', 'headphones', 'mouse', 'keyboard', 'monitor', 'tablet', 'charger', 'smartwatch', 'external hard drive');





--- Compute the average order value per customer ---
select c.firstname,  avg(od.quantity * o.totalamount) as average_order_value
from customers c
join orders o on c.customerid = o.customerid
join orderdetails od on o.orderid = od.orderid
group by c.firstname;
select* from orders;

-- Find the order with the highest revenue --
select top 1  o.orderid,  c.firstname, sum(od.quantity * o.totalamount) as total_revenue
from orders o
join customers c on o.customerid = c.customerid
join orderdetails od on o.orderid = od.orderid
group by o.orderid, c.firstname
order by total_revenue desc;

--- Count the number of orders for each electronic gadget ---
select p.productname, count(od.orderid) as timesordered
from orderdetails od
join products p on od.productid = p.productid
group by p.productname
order by timesordered desc;


-- Get customers who purchased a specific gadget ---
select c.firstname, p.productname
from customers c
join orders o on c.customerid = o.customerid
join orderdetails od on o.orderid = od.orderid
join products p on od.productid = p.productid;


select c.firstname, p.productname
from customers c
join orders o on c.customerid = o.customerid
join orderdetails od on o.orderid = od.orderid
join products p on od.productid = p.productid
where p.productname = 'Laptop';

--- Compute total revenue for a given time range --
declare @start_date date = '2025-03-01', 
        @end_date date = '2025-03-25';
select sum(od.quantity * o.totalamount) as total_revenue
from orders o
join orderdetails od on o.orderid = od.orderid
where o.orderdate between @start_date and @end_date;

------------subqueries
--  Customers who have not placed any orders
select c.firstname, c.lastname
from customers c
where not exists ( select 1 from orders o where o.customerid = c.customerid
);

--  Total number of products available for sale
select count(*) as total_products
from products;

--  Total revenue generated by TechShop
select sum(od.quantity * p.price) as total_revenue
from orderdetails od
join products p on od.productid = p.productid;

--  Average quantity ordered for products in a specific category (parameterized)
select avg(od.quantity) as avg_quantity
from orderdetails od
join products p on od.productid = p.productid
where p.productname = 'Laptop';

--  Total revenue generated by a specific customer (parameterized)
 select sum(od.quantity * p.price) as totalrevenue
from orderdetails od
join orders o on od.orderid = o.orderid
join products p on od.productid = p.productid
where o.customerid = (select top 1 customerid from orders where customerid = 1);






-- --- Customers who have placed the most orders
select c.firstname, c.lastname, count(o.orderid) as order_count
from customers c
join orders o on c.customerid = o.customerid
group by c.customerid, c.firstname, c.lastname
having count(o.orderid) = ( select max(order_count) from (  select count(o1.orderid) as order_count  from orders o1   group by o1.customerid ) as order_counts
);



--  Most popular product category by total quantity ordered

select top 1 p.productid, p.productname, sum(od.quantity) as total_quantity
from orderdetails od
join products p on od.productid = p.productid
group by p.productid, p.productname
order by total_quantity desc;







--. Customer who spent the most on electronic gadgets
select c.firstname, c.lastname, sum(od.quantity * p.price) as total_spent
from orderdetails od
join orders o on od.orderid = o.orderid
join products p on od.productid = p.productid
join customers c on o.customerid = c.customerid
group by c.customerid, c.firstname, c.lastname
having sum(od.quantity * p.price) = (select top 1 sum(od1.quantity * p1.price)from orderdetails od1 join products p1 on od1.productid = p1.productid
join orders o1 on od1.orderid = o1.orderid group by o1.customerid order by sum(od1.quantity * p1.price) desc
);






--  Average order value for all customers

select c.firstname, c.lastname, avg(o.totalamount) as avg_order_value
from customers c
join orders o on c.customerid = o.customerid
group by c.customerid, c.firstname, c.lastname;


--  Total number of orders placed by each customer


select c.firstname, c.lastname, count(o.orderid) as order_count
from customers c join orders o on c.customerid = o.customerid
group by c.customerid, c.firstname, c.lastname;
