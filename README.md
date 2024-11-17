
---

# Pharmacy Management System

## Project Overview

The Pharmacy Management System is a Windows Forms desktop application designed to streamline the management of pharmacy operations. The application is built using an N-tier architecture, ensuring a modular and maintainable codebase.

### Core Features
- **Inventory Management**: Track inventory levels, manage batches, suppliers, and receive stock alerts.
- **Sales Management**: Handle sales transactions, customer management, and generate invoices.
- **Prescription Management**: Record and validate prescriptions, with alerts for potential drug interactions.
- **Reporting and Analytics**: Generate sales, inventory, and financial reports.
- **User and Role Management**: Define roles with specific permissions, manage users, and audit logs.
- **Order and Supplier Management**: Process orders, manage deliveries, and track supplier performance.
- **Billing and Payment Management**: Handle billing, payment processing, and generate receipts.

## Project Structure

The project is organized into several layers following the N-tier architecture:

- **Presentation Layer**: Contains all the forms, UI components, and interactions with the user.
- **Business Logic Layer**: Implements the core functionality, rules, and operations of the system.
- **Data Access Layer**: Handles all database operations, including CRUD operations for different entities.
- **Database Layer**: The SQL Server database where all data is stored.

### Folder Structure

```
PharmacyManagementSystem/
│
├── Presentation/
│   ├── Forms/
│   ├── Controls/
│   └── Resources/
│
├── BusinessLogic/
│   ├── Services/
│   ├── Models/
│   └── Validators/
│
├── DataAccess/
│   ├── Repositories/
│   └── DataContext/
│
└── Database/
    └── Migrations/
```

## Getting Started

### Prerequisites

- **Development Environment**: Visual Studio with .NET Framework.
- **Database**: SQL Server for database management.
- **Version Control**: Git for source code management.

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/PharmacyManagementSystem.git
    ```
   
2. Navigate to the project directory:
    ```bash
    cd PharmacyManagementSystem
    ```

3. Restore NuGet packages:
    ```bash
    nuget restore
    ```

4. Build the solution:
    ```bash
    msbuild PharmacyManagementSystem.sln
    ```

5. Update the database with migrations:
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

## Git Workflow

### Branching Strategy

- **`main` branch**: Contains production-ready code.
- **`develop` branch**: Integration branch for features and hotfixes.
- **`feature/your-feature-name`**: For developing new features.
- **`hotfix/your-hotfix-name`**: For critical hotfixes.

### Essential Git Commands

1. **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/PharmacyManagementSystem.git
    ```

2. **Create a new feature branch:**
    ```bash

    git checkout -b feature/your-feature-name
    ```

3. **Add your changes:**
    ```bash
    git add .
    ```

4. **Commit your changes:**
    ```bash
    git commit -m "Add a meaningful commit message"
    ```

5. **Push the feature branch to the remote repository:**
    ```bash
    git push origin feature/your-feature-name
    ```

6. **Create a pull request (PR) on GitHub** to merge your feature branch into `develop`.

7. **Merge the PR** after review and approval:
    ```bash
    git checkout develop
    git pull origin develop
    git merge feature/your-feature-name
    ```

8. **Push the updated `develop` branch to the remote repository:**
    ```bash
    git push origin develop
    ```

9. **After merging to `main`, create a tag for the new release:**
    ```bash
    git checkout main
    git pull origin main
    git merge develop
    git tag -a v1.0.0 -m "Release version 1.0.0"
    git push origin main --tags
    ```

10. **For hotfixes**, create a hotfix branch from `main`:
    ```bash
    git checkout -b hotfix/your-hotfix-name main
    ```

11. **After completing the hotfix, merge it back into `main` and `develop`:**
    ```bash
    git checkout main
    git merge hotfix/your-hotfix-name
    git checkout develop
    git merge hotfix/your-hotfix-name
    ```

12. **Push the changes:**
    ```bash
    git push origin main
    git push origin develop
    ```
