# ERP - Exam
# Exam Repository ERP System

## Overview
This project is an ERP system for managing exam repositories, developed using an n-layered architecture with ASP.NET Core Web API and ASP.NET Core MVC. The MVC layer consumes the API to provide a user-friendly interface.

## Features
- User Authentication and Authorization
- Exam Data Management
- Reporting and Analytics
- Role-Based Access Control
- API Integration

## Technologies
- ASP.NET Core Web API
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

## Architecture
The project follows an n-layered architecture:

- **Presentation Layer (MVC)**: Consumes the Web API and provides the UI.
- **Service Layer**: Contains business logic.
- **Data Access Layer**: Interacts with the database using Entity Framework Core.
- **Domain Layer**: Contains the core business entities.

## Getting Started

### Prerequisites
- .NET 6.0 SDK
- SQL Server

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/exam-repository-erp.git
   cd exam-repository-erp
