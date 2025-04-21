using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnect;
using CarConnect.dao;
using CarConnectApp.dao;
using CarConnectApp.Exceptions;

namespace CarConnectApp.Entity
{
    class ApplicationMenu
    {
        AuthenticationService authService = new AuthenticationService();
        CustomerService customerService = new CustomerService();
        VehicleService vehicleService = new VehicleService();
        AdminService adminService = new AdminService();
        ReservationService reservationService = new ReservationService();
        ReportGenerator report = new ReportGenerator();

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Vehicle Service");
                Console.WriteLine("2. Admin Service");
                Console.WriteLine("3. Reservation Service");
                Console.WriteLine("4. Customer Services");
                Console.WriteLine("5.Authentication Service");
                Console.WriteLine("6.ReportGenerator");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string? mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1": // VEHICLE SERVICE
                        while (true)
                        {
                            Console.WriteLine("\n--- Vehicle Service ---");
                            Console.WriteLine("1. View Vehicle by ID");
                            Console.WriteLine("2. View All Available Vehicles");
                            Console.WriteLine("3. Update Vehicle");
                            Console.WriteLine("0. Back to Main Menu");
                            Console.Write("Enter your choice: ");
                            string? vehicleChoice = Console.ReadLine();

                            switch (vehicleChoice)
                            {
                                case "1":
                                    try
                                    {
                                        Console.Write("Enter Vehicle ID: ");
                                        int id = Convert.ToInt32(Console.ReadLine()!);
                                        Vehicle v = vehicleService.GetVehicleById(id);
                                        if (v == null)
                                            throw new VehicleNotFoundException("Vehicle with the specified ID not found.");

                                        Console.WriteLine($"ID: {v.VehicleID}, {v.Make} {v.Model}, {v.DailyRate}/day, Available: {v.Availability}");
                                    }
                                    catch (VehicleNotFoundException ex)
                                    {
                                        Console.WriteLine("Vehicle Error: " + ex.Message);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("System Error: " + ex.Message);
                                    }
                                    break;

                                case "2":
                                    try
                                    {
                                        var available = vehicleService.GetAvailableVehicles();
                                        if (available.Count == 0)
                                            throw new VehicleNotFoundException("No available vehicles found.");

                                        foreach (var v in available)
                                            Console.WriteLine($"{v.VehicleID}: {v.Make} {v.Model} - {v.DailyRate}/day");
                                    }
                                    catch (VehicleNotFoundException ex)
                                    {
                                        Console.WriteLine("Vehicle Error: " + ex.Message);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("System Error: " + ex.Message);
                                    }
                                    break;

                                case "3":
                                    try
                                    {
                                        Console.WriteLine("\n--- Update Vehicle ---");

                                        Console.Write("Enter Vehicle ID to update: ");
                                        int vehicleId = int.Parse(Console.ReadLine()!);

                                        Console.Write("Enter Model: ");
                                        string model = Console.ReadLine()!;

                                        Console.Write("Enter Make: ");
                                        string make = Console.ReadLine()!;

                                        Console.Write("Enter Year: ");
                                        int year = int.Parse(Console.ReadLine()!);

                                        Console.Write("Enter Color: ");
                                        string color = Console.ReadLine()!;

                                        Console.Write("Enter Registration Number: ");
                                        string regNo = Console.ReadLine()!;

                                        Console.Write("Is the vehicle available? (1/0): ");
                                        int availability = (int.TryParse(Console.ReadLine(), out int a) && a == 1) ? 1 : 0;


                                        Console.Write("Enter Daily Rate: ");
                                        int rate = int.Parse(Console.ReadLine()!);

                                        Vehicle updatedVehicle = new Vehicle
                                        {
                                            VehicleID = vehicleId,
                                            Model = model,
                                            Make = make,
                                            Year = year,
                                            Color = color,
                                            RegistrationNumber = regNo,
                                            Availability = availability,
                                            DailyRate = rate
                                        };

                                        bool isUpdated = vehicleService.UpdateVehicle(updatedVehicle);
                                        if (isUpdated)
                                        {
                                            Console.WriteLine("Update completed !!!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Vehicle update failed. Please check the Vehicle ID.");
                                        }

                                    }
                                    catch (VehicleNotFoundException ex)
                                    {
                                        Console.WriteLine("Vehicle Error: " + ex.Message);
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Input Error: Please enter valid data types.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("System Error: " + ex.Message);
                                    }
                                    break;

                                case "0":
                                    goto EndVehicle;
                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }
                        }
                    EndVehicle:
                        break;

                    case "2": // ADMIN SERVICE
                        while (true)
                        {
                            Console.WriteLine("\n--- Admin Service ---");
                            Console.WriteLine("1. Get Admin by Username");
                            Console.WriteLine("2. Update Admin");
                            Console.WriteLine("3. Delete Admin");
                            Console.WriteLine("0. Back to Main Menu");
                            Console.Write("Enter your choice: ");
                            string adminChoice = Console.ReadLine()!;

                            try
                            {
                                switch (adminChoice)
                                {
                                    case "1":
                                        Console.Write("Enter Username: ");
                                        string username = Console.ReadLine()!;
                                        var admin = adminService.GetAdminByUsername(username);
                                        if (admin != null)
                                            Console.WriteLine($"Username: {admin.Username}, Name: {admin.FirstName} {admin.LastName}, Email: {admin.Email}");
                                        else
                                            throw new AdminNotFoundException("Admin with the given username not found.");
                                        break;

                                    case "2":
                                        Console.Write("Enter Admin ID to update: ");
                                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                                            throw new AdminNotFoundException("Invalid Admin ID format.");

                                        var existing = adminService.GetAdminById(updateId);
                                        if (existing == null)
                                            throw new AdminNotFoundException("Admin with the given ID not found.");

                                        Console.Write("First Name: ");
                                        string firstName = Console.ReadLine()!;
                                        Console.Write("Last Name: ");
                                        string lastName = Console.ReadLine()!;
                                        Console.Write("Email: ");
                                        string email = Console.ReadLine()!;
                                        Console.Write("Phone Number: ");
                                        string phone = Console.ReadLine()!;
                                        Console.Write("Username: ");
                                        string newUsername = Console.ReadLine()!;
                                        Console.Write("Password: ");
                                        string password = Console.ReadLine()!;
                                        Console.Write("Role: ");
                                        string role = Console.ReadLine()!;
                                        Console.Write("Join Date (yyyy-mm-dd): ");
                                        DateTime joinDate = DateTime.Parse(Console.ReadLine()!);

                                        Admin updatedAdmin = new Admin
                                        {
                                            AdminID = updateId,
                                            FirstName = firstName,
                                            LastName = lastName,
                                            Email = email,
                                            PhoneNumber = phone,
                                            Username = newUsername,
                                            Password = password,
                                            Role = role,
                                            JoinDate = joinDate
                                        };

                                        adminService.UpdateAdmin(updatedAdmin);
                                        Console.WriteLine("Admin updated successfully.");
                                        break;

                                    case "3":
                                        Console.Write("Enter Admin ID to delete: ");
                                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                                            throw new AdminNotFoundException("Invalid Admin ID format.");

                                        var toDelete = adminService.GetAdminById(deleteId);
                                        if (toDelete == null)
                                            throw new AdminNotFoundException("Admin with the given ID not found.");

                                        adminService.DeleteAdmin(deleteId);
                                        Console.WriteLine("Admin deleted successfully.");
                                        break;

                                    case "0":
                                        goto EndAdmin;
                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        break;
                                }
                            }
                            catch (AdminNotFoundException ex)
                            {
                                Console.WriteLine("Admin Error: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("System Error: " + ex.Message);
                            }
                        }
                    EndAdmin:
                        break;

                    case "3": // RESERVATION SERVICE
                        while (true)
                        {
                            Console.WriteLine("\n--- Reservation Service ---");
                            Console.WriteLine("1. Get Reservation by ID");
                            Console.WriteLine("2. Get Reservations by Customer ID");
                            Console.WriteLine("3. Update Reservation");
                            Console.WriteLine("0. Back to Main Menu");
                            Console.Write("Enter your choice: ");
                            string resChoice = Console.ReadLine()!;

                            try
                            {
                                switch (resChoice)
                                {
                                    case "1":
                                        Console.Write("Enter Reservation ID: ");
                                        if (!int.TryParse(Console.ReadLine(), out int resId))
                                            throw new ReservationException("Invalid Reservation ID format.");

                                        var reservation = reservationService.GetReservationById(resId);
                                        if (reservation != null)
                                            Console.WriteLine($"ID: {reservation.ReservationID}, CustomerID: {reservation.CustomerID}, VehicleID: {reservation.VehicleID}, Status: {reservation.Status}");
                                        else
                                            throw new ReservationException("Reservation not found.");
                                        break;

                                    case "2":
                                        Console.Write("Enter Customer ID: ");
                                        if (!int.TryParse(Console.ReadLine(), out int customerId))
                                            throw new ReservationException("Invalid Customer ID format.");

                                        var reservations = reservationService.GetReservationsByCustomerId(customerId);
                                        if (reservations.Count == 0)
                                            throw new ReservationException("No reservations found for this customer.");

                                        foreach (var r in reservations)
                                        {
                                            Console.WriteLine($"ID: {r.ReservationID}, VehicleID: {r.VehicleID}, Dates: {r.StartDate:yyyy-MM-dd} - {r.EndDate:yyyy-MM-dd}, Status: {r.Status}");
                                        }
                                        break;

                                    case "3":
                                        Reservation updatedRes = new Reservation();

                                        Console.Write("Reservation ID to Update: ");
                                        int reservationid=Convert.ToInt32(Console.ReadLine());
                                        var existingReservation=reservationService.GetReservationById(reservationid);
                                        if (existingReservation==null)
                                        {
                                            throw new ReservationException("Reservationid not found,");
                                            
                                        }
                                        if (!int.TryParse(Console.ReadLine(), out int updateResId))
                                            throw new ReservationException("Invalid Reservation ID format.");
                                        updatedRes.ReservationID = updateResId;

                                        Console.Write("Customer ID: ");
                                        updatedRes.CustomerID = int.Parse(Console.ReadLine()!);

                                        Console.Write("Vehicle ID: ");
                                        updatedRes.VehicleID = int.Parse(Console.ReadLine()!);

                                        Console.Write("Start Date (yyyy-MM-dd): ");
                                        updatedRes.StartDate = DateTime.Parse(Console.ReadLine()!);

                                        Console.Write("End Date (yyyy-MM-dd): ");
                                        updatedRes.EndDate = DateTime.Parse(Console.ReadLine()!);

                                        Console.Write("Total Cost: ");
                                        updatedRes.TotalCost = int.Parse(Console.ReadLine()!);

                                        Console.Write("Status (Confirmed/Completed/Pending): ");
                                        updatedRes.Status = Console.ReadLine()!;

                                        reservationService.UpdateReservation(updatedRes);
                                        Console.WriteLine("Reservation updated successfully.");
                                        break;

                                    case "0":
                                        goto EndReservation;
                                    default:
                                        Console.WriteLine("Invalid option.");
                                        break;
                                }
                            }
                            catch (ReservationException rex)
                            {
                                Console.WriteLine("Reservation Error: " + rex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("System Error: " + ex.Message);
                            }
                        }
                    EndReservation:
                        break;

                    case "4": // Customer Service
                        Console.WriteLine("\n--- Customer Service ---");
                        Console.WriteLine("1. Register Customer");
                        Console.WriteLine("2. Update Customer");
                        Console.WriteLine("3. Delete Customer");
                        Console.Write("Enter your choice: ");
                        string custChoice = Console.ReadLine()!;

                        try
                        {
                            switch (custChoice)
                            {
                                case "1": // Register Customer
                                    Customer newCustomer = new Customer();

                                    Console.Write("First Name: ");
                                    newCustomer.FirstName = Console.ReadLine()!;

                                    Console.Write("Last Name: ");
                                    newCustomer.LastName = Console.ReadLine()!;

                                    Console.Write("Email: ");
                                    newCustomer.Email = Console.ReadLine()!;

                                    Console.Write("Phone Number: ");
                                    newCustomer.PhoneNumber = Console.ReadLine()!;

                                    Console.Write("Address: ");
                                    newCustomer.Address = Console.ReadLine()!;

                                    Console.Write("Username: ");
                                    newCustomer.Username = Console.ReadLine()!;

                                    Console.Write("Password: ");
                                    newCustomer.Password = Console.ReadLine()!;

                                    newCustomer.RegistrationDate = DateTime.Now;

                                    customerService.RegisterCustomer(newCustomer);
                                    Console.WriteLine("Customer registered successfully.");
                                    break;

                                case "2": // Update Customer
                                    Customer updatedCustomer = new Customer();

                                    Console.Write("Customer ID to update: ");
                                    updatedCustomer.CustomerID = int.Parse(Console.ReadLine()!);

                                    Console.Write("First Name: ");
                                    updatedCustomer.FirstName = Console.ReadLine()!;

                                    Console.Write("Last Name: ");
                                    updatedCustomer.LastName = Console.ReadLine()!;

                                    Console.Write("Email: ");
                                    updatedCustomer.Email = Console.ReadLine()!;

                                    Console.Write("Phone Number: ");
                                    updatedCustomer.PhoneNumber = Console.ReadLine()!;

                                    Console.Write("Address: ");
                                    updatedCustomer.Address = Console.ReadLine()!;

                                    Console.Write("Username: ");
                                    updatedCustomer.Username = Console.ReadLine()!;

                                    Console.Write("Password: ");
                                    updatedCustomer.Password = Console.ReadLine()!;

                                    updatedCustomer.RegistrationDate = DateTime.Now;

                                    customerService.UpdateCustomer(updatedCustomer);

                                    break;

                                case "3": // Delete Customer
                                    Console.Write("Enter Customer ID to delete: ");
                                    int customerIdToDelete = int.Parse(Console.ReadLine()!);
                                    customerService.DeleteCustomer(customerIdToDelete);
                                    Console.WriteLine("Customer deleted successfully.");
                                    break;


                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "5": // Aunthentication Service

                        Console.WriteLine("Select login type:");
                        Console.WriteLine("1. Customer");
                        Console.WriteLine("2. Admin");
                        Console.Write("Enter your choice: ");
                        int choice = int.Parse(Console.ReadLine()!);

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter username: ");
                                string custUsername = Console.ReadLine()!;

                                Console.Write("Enter password: ");
                                string custPassword = Console.ReadLine()!;

                                try
                                {
                                    Customer customer = authService.AuthenticateCustomer(custUsername, custPassword);
                                    if (customer == null)
                                    {
                                        throw new AuthenticationException("Invalid username or password.");
                                    }

                                    Console.WriteLine($"Welcome, {customer.FirstName}!");
                                }
                                catch (AuthenticationException ex)
                                {
                                    Console.WriteLine("Customer login failed: " + ex.Message);
                                }
                                break;

                            case 2:
                                Console.Write("Enter username: ");
                                string adminUsername = Console.ReadLine()!;

                                Console.Write("Enter password: ");
                                string adminPassword = Console.ReadLine()!;

                                try
                                {
                                    Admin admin = authService.AuthenticateAdmin(adminUsername, adminPassword);
                                    if (admin == null)
                                    {
                                        throw new AuthenticationException("Invalid username or password.");
                                    }

                                    Console.WriteLine($"Welcome, {admin.FirstName}!");
                                }
                                catch (AuthenticationException ex)
                                {
                                    Console.WriteLine("Admin login failed: " + ex.Message);
                                }
                                break;

                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        break;

                    case "6":

                        Console.WriteLine("---Report Generator---\n");

                        while (true)
                        {
                            Console.WriteLine("\nchoose an option:");
                            Console.WriteLine("1. Total Revenue");
                            Console.WriteLine("2. Reserved Vehicle Models");
                            Console.WriteLine("3. Reservation Status Count");
                            Console.WriteLine("4. Exit");
                            Console.Write("Enter your choice: ");
                            int Reportchoice;
                            if (!int.TryParse(Console.ReadLine(), out Reportchoice))
                            {
                                Console.WriteLine("Invalid input! Please enter a number.\n");
                                continue; // goes back to while loop
                            }

                            switch (Reportchoice)
                            {
                                case 1:
                                    Console.WriteLine("\nTotal Revenue:");
                                    Console.WriteLine(report.GetTotalRevenue()!);
                                    break;

                                case 2:
                                    Console.WriteLine("\nReserved Vehicle Models:");
                                    List<string> reservedModels = report.GetReservedVehicleModels();
                                    foreach (var model in reservedModels)
                                    {
                                        Console.WriteLine($"- {model}");
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("\nReservation Status Count:");
                                    report.PrintReservationStatusCount();
                                    break;

                                case 4:
                                    Console.WriteLine("\nExiting report generation...");
                                    break;

                                default:
                                    Console.WriteLine("\nInvalid option. Please choose a valid option.");
                                    break;
                            }
                        }
                    case "0":
                        Console.WriteLine("Exiting system...");
                        return;

                    default:
                        Console.WriteLine("Invalid main menu option.");
                        break;

                }
            }
        }
    }
}



