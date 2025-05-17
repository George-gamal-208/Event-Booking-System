# Event-Booking-System

Event Booking System - Backend
Overview
This is the backend part of the Event Booking System, built with ASP.NET MVC using Clean Code Architecture. It handles event management, user authentication, and pagination logic, with a SQL Server database for persistence.
Features

Event Management: Admins can perform CRUD operations on events, including setting CurrentState (Active/Inactive).
Pagination: Displays 6 events per page, showing only active events (CurrentState = 1) for users.
Authentication: Role-based authentication for Users and Admins using ASP.NET Identity.
Database: Uses Entity Framework Core with SQL Server to store events and bookings.

Prerequisites

.NET 8 SDK: Ensure the .NET 8 SDK is installed. Download here.
SQL Server: A running SQL Server instance (local or remote). Download SQL Server Express if needed.
SQL Server Management Studio (SSMS) (optional): For managing the database.

Setup Instructions

Clone the Repository
git clone <repository-url>
cd EventBookingSolution


Navigate to the ProjectThe backend is part of the EventBooking.Web project:
cd EventBooking.Web


Install DependenciesRestore NuGet packages for the project:
Microsoft.EntityFrameworkCore.SqlServer,
Microsoft.EntityFrameworkCore.Tools,
Microsoft.EntityFrameworkCore.Design,
Newtonsoft.Json,
Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 8.0.2,
dotnet restore


Database Setup

Update Connection String: Open EventBooking.Web/appsettings.json and update the DefaultConnection string to point to your SQL Server instance:"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EventBookingDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}


Run Migrations: Apply database migrations to create the database and schema:dotnet ef database update --project EventBooking.Web


If you don’t have the EF Core tools installed, install them first:dotnet tool install --global dotnet-ef




Seed Data (Optional)

The project includes seed data for testing. Ensure your ApplicationDbContext or a seeding mechanism populates events with varying CurrentState values (e.g., 1 for active, 0 for inactive).


Run the Application
dotnet run --project EventBooking.Web




Authentication Setup

Default Roles: The app uses ASP.NET Identity with ApplicationUser.
Admin Access: Create an admin user via seeding or registration, then assign the "Admin" role.
User Access: Regular users can register/login to book events.

Troubleshooting

Database Connection Failed: Verify the connection string in appsettings.json matches your SQL Server setup. Check if SQL Server is running.
Migrations Fail: Ensure the EF Core tools are installed and the project references Microsoft.EntityFrameworkCore.Design.



