# PoissaHR

PoissaHR is a modern HR management platform built with Blazor Server, MudBlazor, and Entity Framework Core.

The project is designed as a learning-focused application that can later evolve into a scalable SaaS HR platform.

---

# Features
### Current Features

- Employee management
- Department management
- Employment tracking
- Absence management
- MudBlazor UI
- SQLite database
- Entity Framework Core integration
- Layered architecture

---

# Tech Stack

- ASP.NET Core
- Blazor Server
- MudBlazor
- Entity Framework Core
- SQLite
- C#
- .NET 8 (LTS)

---

# Architecture

The application follows a layered architecture structure.

## Projects

```plaintext
PoissaHR  
│
├── PoissaHR                -> Blazor UI
├── PoissaHR.Application    -> Business logic and services
├── PoissaHR.Domain         -> Entities and enums
├── PoissaHR.Infrastructure -> Database and EF Core
├── PoissaHR.Shared         -> DTOs and shared contracts

```

---

# Main Entities (current)

- Company
- Department
- Employee
- Employment
- Absence

# Relationships

```plaintext
Company
├── Departments
├── Employees

Employees
├── Employments
├── Absences

```

---

# UI Design

The UI is built with MudBlazor using a modern HR SaaS-inspired layout.

### Design Principles

- Clean and minimal UI
- Responsive layout
- Sidebar navigation
- Data-focused views
- Scalable structure
- SaaS-oriented architecture

# Project Structure

```plaintext
Pages/
│
├── Dashboard/
├── Employees/
├── Departments/
├── Absences/

```

# Getting Started

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 (or newer) / Rider / VS Code

# Installation

### Clone Repository

```bash
git clone https://github.com/yourusername/PoissaHR.git
```

### Restore Packages
```bash
dotnet restore
```

### Run Application
```bash
dotnet run
```

---

# Database

The project currently uses SQLite. SaaS production will use SQL Server in Azure (TBD).

### Database File

```bash
poissahr.db
```

### Entity Framework Commands

```bash
dotnet ef migrations add InitialCreate
```

### Update Database
```bash
dotnet ef database update
```

# Database Seeding

The project uses a custom DbSeeder instead of EF Core HasData.

### Benefits
- Cleaner setup
- Easier maintenance
- Better support for dynamic data
- More flexible development workflow

---

# Planned Features

### HR Features

- Vacation requests
- Sick leave workflows
- Document management
- Employment contracts
- Approval workflows
- Manager hierarchy
- Notifications

### Technical Features
- Authentication and authorization
- ASP.NET Core Identity
- Role-based permissions
- Full DTO mapping
- API layer
- Multi-tenancy
- SaaS support
- Audit logging

---

# Learning Goals

This project is focused on learning:
- Blazor Server
- MudBlazor
- Entity Framework Core
- Clean architecture concepts
- DTO patterns
- Service layer architecture
- HR domain modeling
- SaaS application structure

---

# Status

Early development and learning project.
Architecture and features may evolve significantly during development.

# License

MIT License

# Author

Built as a personal learning project focused on modern .NET and Blazor development.
