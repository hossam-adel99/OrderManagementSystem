# 🛒 Order Management System - Technical Assessment

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-purple)
![Angular](https://img.shields.io/badge/Angular-21.0-red)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-blue)
![DDD](https://img.shields.io/badge/Pattern-DDD-green)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-yellow)

## 📋 Table of Contents
- [Overview](#-overview)
- [Architecture](#🏗️-architecture)
- [Features](#✨-features)
- [Tech Stack](#🛠️-tech-stack)
- [Project Structure](#📁-project-structure)
- [Setup & Installation](#🚀-setup--installation)
- [API Documentation](#🔌-api-documentation)
- [Frontend Screens](#🖥️-frontend-screens)
- [Business Rules](#📊-business-rules)
- [Testing](#🧪-testing)
- [Key Decisions](#🔑-key-decisions)
- [Author](#👨💻-author)

## 🎯 Overview

A full-stack Order Management System built as a technical assessment demonstrating **Clean Architecture**, **Domain-Driven Design**, and **SOLID principles**. The system manages products, customers, and orders for a small e-commerce platform.

**Assessment Requirements Met:**
- ✅ Clean Architecture with 4 layers
- ✅ Domain-Driven Design with rich domain models
- ✅ SOLID principles implementation
- ✅ Separation of concerns
- ✅ RESTful API with ASP.NET Core
- ✅ Angular frontend with services
- ✅ Entity Framework Core with SQL Server
- ✅ Unit tests for domain logic

## 🏗️ Architecture

### Clean Architecture Layers

┌─────────────────────────────────────────┐
<br>│ Presentation Layer │
<br>│ (Angular Frontend + ASP.NET Core API) │
<br>└───────────────────┬─────────────────────┘
<br>│
<br>┌───────────────────▼─────────────────────┐
<br>│ Application Layer │
<br>│ (Use Cases, DTOs, Interfaces) │
<br>└───────────────────┬─────────────────────┘
<br>│
<br>┌───────────────────▼─────────────────────┐
<br>│ Domain Layer │
<br>│ (Entities, Value Objects, Business) │
<br>└───────────────────┬─────────────────────┘
<br>│
<br>┌───────────────────▼─────────────────────┐
<br>│ Infrastructure Layer │
<br>│ (EF Core, Database, External Services) │
<br>└─────────────────────────────────────────┘


### Domain-Driven Design Implementation
- **Rich Domain Models** (No anemic models)
- **Value Objects**: `Money`, `Email`
- **Aggregate Roots**: `Order`, `Product`, `Customer`
- **Business Rules** enforced in domain layer
- **Repository Pattern** for data access

## ✨ Features

### Backend (ASP.NET Core)
- ✅ Retrieve products
- ✅ Create orders for customers
- ✅ Add items to orders
- ✅ Retrieve order details
- ✅ Calculate order total dynamically
- ✅ Business rules validation
- ✅ SQL Server with Entity Framework Core
- ✅ RESTful API with Swagger documentation

### Frontend (Angular)
- ✅ Product listing screen
- ✅ Create order screen
- ✅ Order details screen
- ✅ Angular services for API communication
- ✅ Bootstrap UI with responsive design
- ✅ Clear separation between UI, state, and data access

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server / SQL Server LocalDB
- **ORM**: Entity Framework Core 8.0
- **Architecture**: Clean Architecture, DDD
- **Testing**: xUnit, Moq
- **Tools**: Swagger, AutoMapper

### Frontend
- **Framework**: Angular 21.0
- **UI Library**: Bootstrap 5.3
- **State Management**: RxJS
- **Routing**: Angular Router
- **HTTP Client**: Angular HttpClient

## 📁 Project Structure
OrderManagementSystem/
<br>├── Backend/
<br>│ ├── OrderManagement.API/ # API Controllers, Middleware
<br>│ │ ├── Controllers/
<br>│ │ ├── Program.cs
<br>│ │ └── appsettings.json
<br>│ ├── OrderManagement.Application/ # Use Cases, DTOs
<br>│ │ ├── DTOs/
<br>│ │ ├── Interfaces/
<br>│ │ ├── Services/
<br>│ │ └── Exceptions/
<br>│ ├── OrderManagement.Domain/ # Business Logic
<br>│ │ ├── Entities/
<br>│ │ ├── ValueObjects/
<br>│ │ ├── Enums/
<br>│ │ └── Exceptions/
<br>│ ├── OrderManagement.Infrastructure/ # Data Access
<br>│ │ ├── Data/
<br>│ │ ├── Persistence/
<br>│ │ ├── Migrations
<br>│ │ └── Repositories.cs
<br>│ │         
<br>│ └── OrderManagement.sln # Solution File
<br>├── Frontend/
<br>│ ├── src/
<br>│ │ ├── app/
<br>│ │ │ ├── core/ # Shared Services & Models
<br>│ │ │ │ ├── models/
<br>│ │ │ │ └── services/
<br>│ │ │ ├── Products/ # Feature Modules
<br>│ │ │ │── orders/
<br>│ │ │ │
<br>│ │ │ └── shared/ # Shared Components
<br>│ │ ├── assets/
<br>│ │ ├── environments/
<br>│ │ └── index.html
<br>│ ├── angular.json
<br>│ ├── package.json
<br>│ └── README.md
<br>├── Documentation/
<br>│ ├── API_Endpoints.md
<br>│ └── Architecture_Decisions.md
<br>├── .gitignore
<br>└── README.md (this file)


## 🚀 Setup & Installation

### Prerequisites
- .NET 8.0 SDK
- Node.js 18+ & npm
- SQL Server / SQL Server LocalDB
- Visual Studio 2022 or VS Code
- Git

### Backend Setup
```bash
# 1. Navigate to Backend directory
cd backend

# 2. Restore packages
dotnet restore

# 3. Update database connection string in appsettings.json
#    Default: "Server=(localdb)\\mssqllocaldb;Database=OrderManagementDB"

# 4. Apply database migrations
dotnet ef database update

# 5. Run the API
dotnet run
Backend runs on: https://localhost:7067
Swagger UI: https://localhost:7067/swagger
```
Frontend Setup
```bash
# 1. Navigate to Frontend directory
cd frontend

# 2. Install dependencies
npm install

# 3. Update API URL in environments/environment.ts if needed
#    Default: apiBaseUrl: 'https://localhost:7067/api'

# 4. Run the Angular application
ng serve
Frontend runs on: http://localhost:4200
```
Database Seed Data
```bash
On first run, the system automatically seeds 5 sample products:

Beef Burger - $120

Chicken Burger - $130

Shawarma Sandwich - $65

Margherita Pizza - $110

French Fries - $30
```
🔌 API Documentation
Products Endpoints
Method	Endpoint	Description
```bash
GET	/api/products	Get all products
GET	/api/products/{id}	Get product by ID
POST	/api/products	Create new product
Orders Endpoints
Method	Endpoint	Description
GET	/api/orders	Get all orders
GET	/api/orders/{id}	Get order details
POST	/api/orders	Create new order
POST	/api/orders/{id}/items	Add item to order
DELETE	/api/orders/{id}/items/{productId}	Remove item from order
POST	/api/orders/{id}/complete	Mark order as completed

Sample API Request
json
POST /api/orders
{
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "items": [
    {
      "productId": "586a880b-a85f-4054-b809-246f28c9a84d",
      "quantity": 2
    }
  ]
}
```
🖥️ Frontend Screens
```bash
1. Products Screen (/products)
- Displays all available products
- Shows product name, description, and price
- Responsive card layout

2. Create Order Screen (/orders/create)
- Select customer from dropdown
- Add products with quantities
- Real-time total calculation
- Form validation

3. Order Details Screen (/orders/:id)
- View complete order information
- See order items with quantities and prices
- Complete order button (for pending orders)
- Order status display
```

📊 Business Rules
```bash
Domain Rules
- Product Price: Must be ≥ 0
- Order Total: Derived dynamically, not persisted
- Order Status: Completed orders cannot be modified
- Item Quantity: Must be > 0
- Customer Email: Must be valid format

Validation Rules
- Product name is required (max 200 characters)
- Order must have at least one item
- Cannot add/remove items from completed orders
- Unit price captured at time of order addition
```
🧪 Testing
Unit Tests
```bash
# Run backend tests
cd backend
dotnet test

# Test coverage includes:
# - Domain entities validation
# - Business rules enforcement
# - Value objects creation
# - Aggregate behavior

Test Scenarios
✅ Product creation with valid/invalid data
✅ Order creation and item management
✅ Business rule violations
✅ Value object validation
```

🔑 Key Decisions & Implementation Details
```bash
1. Why Clean Architecture?
- Separation of concerns: Each layer has clear responsibility
- Testability: Business logic is independent of frameworks
- Maintainability: Easy to modify without affecting other layers
- Flexibility: Can replace infrastructure without changing domain

2. DDD Implementation Choices
- Rich Domain Models: Entities contain behavior, not just data
- Value Objects: Money, Email with validation logic
- Aggregate Design: Order as aggregate root managing OrderItems
- Repository Pattern: Abstraction over data access

3. Frontend Architecture
- Feature-based structure: Modules for products and orders
- Service layer: All API communication through services
- No business logic in components: Only presentation logic
- Reactive programming: RxJS for state management

4. Database Design
- Code-first approach: EF Core migrations
- Relationships: Proper 1:Many and Many:1 relationships
- Seed data: Initial products for demonstration
- Concurrency: Optimistic concurrency handling
```
## 👨‍💻 Author
Hossam Adel Mostafa

## Contact
📧 Email: hossam.adel.dev@gmail.com
<br>💼 LinkedIn: inkedin.com/in/hossam-adel99
<br>🐙 GitHub: github.com/hossam-adel99
