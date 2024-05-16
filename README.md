# Restaurant Order API

## Overview
This API facilitates restaurant ordering processes, allowing for the management of users and orders with role-based access controls and discount logic for complete meal orders.

## Technologies
- .NET Core
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
  - Total price displayed upon creation. If a complete meal is ordered (one of each course type: appetizer, main, side, dessert), a 10% discount is applied to the complete set. Additional same course types are charged at full price.

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
**Application + Database**: The application uses a Dockerized database which can be set up and run with Docker by running ``docker-compose up --build``.

## How to Use
- **Documentation and Interaction**: Access the OpenAPI documentation by navigating to `localhost:8080/swagger` on the hosted API domain to test endpoints and view schema definitions.

This API provides a robust backend for restaurant order management, supporting advanced features like auto-incremented order tracking, role-based access control, and discount application logic for comprehensive meal orders.

## Easy Setup
If on a *NIX machine with bash, just run ``./start.sh`` with docker installed and running.
