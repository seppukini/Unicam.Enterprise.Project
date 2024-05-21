# Restaurant Order API

## Overview
This API facilitates restaurant ordering processes, allowing for the management of users and orders with role-based access controls and discount logic for complete meal orders.

## Technologies
- .NET Core
- SQL Server for data storage
- Docker for database and api deployment
- OpenAPI specification for API documentation and testing

## Features

### User Management
- **User Registration**: Allow client users to register without authentication. Users have the following properties:
  - Email
  - First Name
  - Last Name
  - Password
  - Role (Customer, Administrator)

### Authentication
- Users can authenticate using their email and password, receiving a JWT token for subsequent authenticated requests.

### Order Management
- **Create Order**: Users can place orders which include:
  - User identifier from JWT
  - Order date
  - Auto-incremented order number
  - Delivery address
  - List of ordered dishes (courses)
  - Total price displayed upon creation. If a complete meal is ordered (one of each course type: main, second, side, dessert), a 10% discount is applied for each complete set (in the case of multiple courses of one type, the most expensive one is chosen). Additional same course types are charged at full price.

### Order History
- Fetch order history with different visibility based on user role:
  - **Customers**: Can view only their orders.
  - **Administrators**: Can view all user orders.
  - Filters include:
    - Start Date (required)
    - End Date (required)
    - User ID (optional for administrators)
  - Support for pagination in results.

## Setup
For running the application, you can choose between using Docker or a local SQL Server instance.

### Docker
1. **Run with Docker Compose**: The application uses a Dockerized database which can be set up and run with Docker by running ``docker-compose up --build``.  This will launch the application and the database, and you can access the API documentation by navigating to `localhost:8080/swagger`.

_**Easy setup:** If on a *NIX machine with bash, just run ``./start.sh`` with docker installed and running._

### Local SQL Server
1. **Import the Database Dump:** Take the database dump file `db-init-full.sql` and import it into your local SQL Server instance.
2. **Update Connection String:** Update the connection string in the `appsettings.json` file to point to your local SQL Server instance.
3. **Run the Application:** Run the application on your IDE. The Swagger page will automatically open in your browser.

## How to Use
Regardless of the setup used you will be able to access the OpenAPI documentation by navigating to `localhost:8080/swagger` on the hosted API domain to test endpoints and view schema definitions.

This API provides a robust backend for restaurant order management, supporting advanced features like auto-incremented order tracking, role-based access control, and discount application logic for comprehensive meal orders.

### Database Tables
The database is pre-populated with some sample data to facilitate API testing.

  - **Users**:

    | Id | Name  | Surname | Email               | Password   | Role |
    |----|-------|---------|---------------------|------------|------|
    | 1  | Admin | Admin   | admin@email.it      | admin      | 1    |
    | 2  | Mario | Rossi   | mario.rossi@email.it| Mario1234. | 0    |

  - **Courses**:
    
    | Id | Name                          | Price | Type |
    |----|-------------------------------|-------|------|
    | 1  | Tortellini alla norcina       | 10    | 0    |
    | 2  | Tonnarelli cacio e pepe       | 9     | 0    |
    | 3  | Petto di pollo ai ferri       | 11    | 1    |
    | 4  | Grigliata mista               | 15    | 1    |
    | 5  | Patate fritte                 | 4     | 2    |
    | 6  | Patate arrosto                | 4     | 2    |
    | 7  | Verdure di stagione grigliate | 4     | 2    |
    | 8  | Tiramisu                      | 5     | 3    |
    | 9  | Panna cotta                   | 5     | 3    |

  - **Orders**:

    | Id | Date                     | Street            | City   | ZipCode | UserId |
    |----|--------------------------|-------------------|--------|---------|--------|
    | 5  | 2024-04-15 14:27:23.093  | Via Pappagalli, 12| Jesi   | 60035   | 2      |
    | 6  | 2024-05-10 14:27:47.377  | Via Roma, 21      | Ancona | 60121   | 2      |
    | 7  | 2024-05-18 14:28:19.820  | Via Pappagalli, 12| Jesi   | 60035   | 2      |

  - **OrderCourses**:

    | Id | OrdersId | CoursesId |
    |----|----------|-----------|
    | 33 | 5        | 1         |
    | 34 | 5        | 2         |
    | 35 | 5        | 3         |
    | 36 | 5        | 4         |
    | 37 | 5        | 5         |
    | 38 | 5        | 6         |
    | 39 | 5        | 7         |
    | 40 | 5        | 8         |
    | 41 | 5        | 9         |
    | 42 | 6        | 1         |
    | 43 | 6        | 4         |
    | 44 | 7        | 1         |
    | 45 | 7        | 2         |
    | 46 | 7        | 3         |
    | 47 | 7        | 5         |
    | 48 | 7        | 8         |
