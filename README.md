# Exam ERP System

## Overview
This project is an ERP system for managing exams of middle school, developed using an n-layered architecture with ASP.NET Core Web API and ASP.NET Core MVC. The MVC layer consumes the API to provide a user-friendly interface.

## Features
- User Authentication and Authorization
- Exam Data Management
- Role-Based Access Control
- API Integration

## Technologies
- ASP.NET Core Web API
- ASP.NET Core MVC
- Entity Framework Core
- MSSQL Server

## Architecture
The project follows an n-layered architecture:

- **Presentation Layer (MVC)**: Consumes the Web API and provides the UI.
- **API Layer (API)**: It processes HTTP requests, interacting with the service layer to perform the necessary operations.
- **Service Layer**: Contains business logic.
- **Data Access Layer**: Interacts with the database using Entity Framework Core.
- **Core Layer**: Contains the core business entities.

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- MSSQL Server

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/josephguluzada/Exam-ERP-System.git

2. For testing app:
   Admin Username:
   ```sh
   SuperAdmin
3. Admin password:
   ```sh
   Admin123@   
