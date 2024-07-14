# Project Name: FinTransact API



## Technologies Used
- ASP.NET Core v-7.0
- MSSQL Server
- JSON Web Tokens (JWT)
- RESTful APIs
- Entity Framework Core v-7.0.20


## Architecture & Design
- Microservices Architecture
- Repository Pattern
- Generic Repository
- Entity Framework Core v-7.0.20
- Entity Framework Core v-7.0.20

## Project Description

### Auth API
- Handles user authentication and management.
- Generates JWT tokens upon successful login.

### Transaction API
- Manages bank accounts and transactions.
- Supports operations like adding, updating, and retrieving account and transaction details.

### API Gateway
- Routes requests to appropriate microservices (Auth API and Transaction API).

## Setup Instructions

GitHub Link: https://github.com/mmraihan/Financial-Tansactions

- Download or clone the project source code from the GitHub Link:

- To run FinTransact API, change the connection string, and update the database from a migration file, you can follow these steps.

- Open your ASP.NET Core API project in your preferred Integrated Development Environment (IDE) such as Visual Studio 2022

- Locate the appsettings.json file in your project, which typically contains configuration settings, including the database connection string. Modify the connection string to point to your desired database.

- Update Database from Migration File:

## Routes
--------------Auth API---------------------

URL: Auth API		

https://localhost:7000/auth-module/Account/register
https://localhost:7000/auth-module/Account/login

https://localhost:7000/auth-module/users/get-all-users
https://localhost:7000/auth-module/users/get-user/{id}


---------------TransactionAPI----------------

URL: BankAccount Controller

https://localhost:7000/transaction-module/bankAccount/get-all-bankAccounts

https://localhost:7000/transaction-module/bankAccount/get-bankAccount/1

https://localhost:7000/transaction-module/bankAccount/add-bankAccount  (Update logic- accountNumber Unique)

https://localhost:7000/transaction-module/bankAccount/update-bankAccount/1

https://localhost:7000/transaction-module/bankAccount/6


		URL: Transaction Controller

https://localhost:7000/transaction-module/transaction/get-all-transactions

https://localhost:7000/transaction-module/transaction/get-transaction/{id}

https://localhost:7000/transaction-module/transaction/add-transaction

https://localhost:7000/transaction-module/transaction/update-transaction/{id}

https://localhost:7000/transaction-module/transaction/{id}






