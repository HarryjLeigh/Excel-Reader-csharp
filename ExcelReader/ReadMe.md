# Excel Reader

---

## Overview

---

This project focuses on transferring data from an Excel spreadsheet into an SQL server database using the EPPlus library and displaying the retrieved data to the user with the help of Spectre.Console.


## Project Setup 

---
1. Update appSettings.json:

- Navigate to bin/debug/net9.0/appSettings.json.
- Modify the DefaultConnection string to match your SQL Server details. 
- Replace with your SQL Server name and connection details:

> "Server=your-server;Database=MovieDb;
> TrustServerCertificate=True;
> Trusted_Connection=True;"

2. Set File Path in Program:

- Update the filepath variable in the Program.cs file to point to the location of your saved MovieData Excel file.

## Requirements

---
- This is an application that will read data from an Excel spreadsheet into a database
- When the application starts, it should delete the database if it exists, create a new one, create all tables, read from Excel, seed into the database.
- You need to use EPPlus package
- You shouldn't read into Json first.
- You can use SQLite or SQL Server (or MySQL if you're using a Mac)
- Once the database is populated, you'll fetch data from it and show it in the console.
- You don't need any user input
- You should print messages to the console letting the user know what the app is doing at that moment (i.e. reading from Excel; creating tables, etc.)
- The application will be written for a known table, you don't need to make it dynamic.
- When submitting the project for review, you need to include a xls file that can be read by your application.

## Features

---

- The application ensures the database is reset on startup by deleting and recreating it using Entity Framework.
- Dependency injection is configured in the Startup.cs file to manage services.
- Reads data from MovieData Excel file using the EPPlus library.
- Inserts data into SQL Server through calls to the controller and repository.
- Retrieves MovieData from SQL Server via the controller and repository.
- Displays the data to the user in the console using Spectre.Console.

## Lessons learned

---

1. File Handling with EPPlus
   - Learned how to read and process Excel files using the EPPlus library.
2. Database Integration
   - Built skills in database management with Entity Framework Core, including table creation, data seeding, and querying.
3. Console Feedback
   - Implemented clear status updates using Spectre.Console for better user experience.
4. Project Structure
   - Gained experience in organizing a scalable project with separate concerns for file reading, data mapping, database interaction, and display.
5.  Automation
    - Automated database setup, ensuring seamless execution each time the app runs.