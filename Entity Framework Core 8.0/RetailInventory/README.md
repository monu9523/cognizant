# RetailInventory

A .NET console application demonstrating **Entity Framework Core 9.0** with **MySQL** database using the Pomelo provider. Covers EF Core fundamentals: model creation, migrations, data insertion, and querying.

---

## Tech Stack

| Technology | Version |
|---|---|
| .NET | 10.0 |
| C# | 13.0 |
| Entity Framework Core | 9.0.0 |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 |
| Database | MySQL |

---

## Project Structure

```
RetailInventory/
├── Data/
│   └── AppDbContext.cs         # EF Core DbContext with MySQL configuration
├── Migrations/
│   ├── 20260701093942_InitialCreate.cs
│   ├── 20260701093942_InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
├── Models/
│   ├── Category.cs             # Category entity model
│   └── Product.cs              # Product entity model
├── Program.cs                  # Entry point - seed data & queries
├── RetailInventory.csproj      # Project file & NuGet dependencies
└── README.md
```

---

## Models

### Category
| Property | Type | Description |
|---|---|---|
| Id | int | Primary key (auto-increment) |
| Name | string | Category name |
| Products | List\<Product\> | Navigation property (one-to-many) |

### Product
| Property | Type | Description |
|---|---|---|
| Id | int | Primary key (auto-increment) |
| Name | string | Product name |
| Price | decimal | Product price in ₹ |
| CategoryId | int | Foreign key → Category |
| Category | Category? | Navigation property |

---

## Database Configuration

**File:** `Data/AppDbContext.cs`

```csharp
var connectionString = "Server=localhost;Database=RetailInventoryDb;User=root;Password=your_password;";
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
```

---

## NuGet Packages

| Package | Version | Purpose |
|---|---|---|
| Microsoft.EntityFrameworkCore.Design | 9.0.0 | EF Core design-time tools (migrations) |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 | MySQL provider for EF Core |

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/installer/)
- EF Core CLI tools

Install EF Core CLI tools:
```bash
dotnet tool install --global dotnet-ef
```

---

## Setup & Run

### 1. Navigate to project folder
```bash
cd "Entity Framework Core 8.0/RetailInventory"
```

### 2. Update connection string
In `Data/AppDbContext.cs`, replace with your MySQL credentials:
```
Server=localhost;Database=RetailInventoryDb;User=root;Password=your_password;
```

### 3. Restore packages
```bash
dotnet restore
```

### 4. Create migration
```bash
dotnet ef migrations add InitialCreate
```

### 5. Apply migration (creates the database & tables)
```bash
dotnet ef database update
```

### 6. Run the application
```bash
dotnet run
```

---

## What the App Does

| Step | Operation | Description |
|---|---|---|
| 1 | Seed Check | Inserts data only if the database is empty |
| 2 | Insert Categories | Electronics, Groceries |
| 3 | Insert Products | 4 products linked to categories |
| 4 | ToListAsync() | Retrieves and displays all products |
| 5 | FindAsync(1) | Finds product by primary key ID = 1 |
| 6 | FirstOrDefaultAsync() | Finds first product with Price > ₹40,000 |

---

## Seed Data

### Categories
| Id | Name |
|---|---|
| 1 | Electronics |
| 2 | Groceries |

### Products
| Id | Name | Price | Category |
|---|---|---|---|
| 1 | Smartphone | ₹45,000 | Electronics |
| 2 | Wireless Headphones | ₹3,500 | Electronics |
| 3 | Cooking Oil (5L) | ₹900 | Groceries |
| 4 | Basmati Rice (10kg) | ₹1,500 | Groceries |

---

## Sample Output

```
Data inserted successfully!

===== All Products =====
ID       : 1
Name     : Smartphone
Price    : ₹45,000

ID       : 2
Name     : Wireless Headphones
Price    : ₹3,500

ID       : 3
Name     : Cooking Oil (5L)
Price    : ₹900

ID       : 4
Name     : Basmati Rice (10kg)
Price    : ₹1,500

===== Find Product (ID = 1) =====
Found Product : Smartphone
Price         : ₹45,000

===== First Product with Price > ₹40000 =====
Product : Smartphone
Price   : ₹45,000

Program completed successfully.
```

---

## Common Issues & Fixes

| Error | Cause | Fix |
|---|---|---|
| `Access denied for user 'root'` | Wrong MySQL password | Update password in connection string |
| `Unable to connect to MySQL` | MySQL service not running | Start MySQL via Services or MySQL Workbench |
| `Table already exists` | Tables exist from previous run | Run `dotnet ef database drop --force` then `dotnet ef database update` |
| `No migrations found` | Migrations folder is empty | Run `dotnet ef migrations add InitialCreate` |
| `Assets file doesn't have a target` | Packages not restored | Run `dotnet restore` |
| `dotnet ef not found` | EF CLI not installed | Run `dotnet tool install --global dotnet-ef` |
