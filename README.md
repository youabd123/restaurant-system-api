 ## 🍽️ Restaurant System API

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen?style=for-the-badge)
![Pattern](https://img.shields.io/badge/Pattern-CQRS-blue?style=for-the-badge)
![ORM](https://img.shields.io/badge/ORM-Entity_Framework_Core-orange?style=for-the-badge)
![Auth](https://img.shields.io/badge/Auth-JWT-black?style=for-the-badge)
![Docs](https://img.shields.io/badge/Docs-Swagger_UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

> RESTful Web API för ett restaurangsystem byggt med .NET 8.  
> Följer strikt **Clean Architecture** och **CQRS-principer** med JWT-autentisering och rollbaserad åtkomstkontroll.

---

## 📂 Projektstruktur

```text
restaurant-system-api/
├── RestaurantSystem.Domain/           # Entiteter
│   └── Entities/                      # Category, MenuItem, Order, OrderItem, AppUser
├── RestaurantSystem.Application/      # CQRS · Commands · Queries · Handlers
│   ├── Features/
│   │   ├── Auth/Commands/             # Login, Register
│   │   ├── Categories/                # Commands & Queries
│   │   ├── MenuItems/                 # Commands & Queries
│   │   └── Orders/                    # Commands & Queries
│   └── Common/
│       ├── Behaviors/                 # ValidationBehavior (Pipeline)
│       ├── Interfaces/                # IGenericRepository, ICategoryRepository osv
│       └── Mappings/                  # AutoMapper MappingProfile
├── RestaurantSystem.Infrastructure/   # EF Core · Repositories · JWT
│   ├── Data/                          # AppDbContext, Migrations
│   ├── Repositories/                  # GenericRepository + specifika
│   └── Services/                      # JwtService
├── RestaurantSystem.API/              # Controllers · Program.cs
│   └── Controllers/                   # AuthController, CategoriesController osv
├── RestaurantSystem.Tests/            # xUnit tester
└── docs/                              # UML-diagram, User Flow Diagram
```

---

## 🏗️ Arkitekturlager

| # | Lager | Ansvar |
|---|-------|--------|
| 1 | **Domain** | Entiteter och kärnlogik |
| 2 | **Application** | CQRS handlers, validators, interfaces, DTOs |
| 3 | **Infrastructure** | EF Core, repositories, JWT-tjänst |
| 4 | **API** | Controllers, Program.cs, DI-konfiguration |

---

## 🛠️ Teknikstack

| Teknologi | Användning |
|-----------|------------|
| **ASP.NET Core Web API** | .NET 8 |
| **Entity Framework Core** | ORM, SQL Server, Code-First |
| **MediatR** | CQRS via Mediator-mönstret |
| **FluentValidation** | Validering av commands |
| **AutoMapper** | Mappning mellan entiteter och DTOs |
| **ASP.NET Core Identity** | Användarhantering |
| **JWT** | Autentisering och auktorisering |
| **xUnit + Moq + FluentAssertions** | Enhetstester |
| **Swagger** | API-dokumentation |

### Designmönster
- **Clean Architecture** — tydliga lager utan cirkulära beroenden
- **CQRS** — separerade Commands och Queries via MediatR
- **Generic Repository** — återanvändbar bas för alla repositories
- **Pipeline Behaviour** — automatisk validering innan handlers körs
- **RBAC** — rollbaserad åtkomstkontroll (Admin / User)

---

## 🚦 API Endpoints

| Metod | Endpoint | Auth |
|-------|----------|------|
| `POST` | `/api/auth/register` | Public |
| `POST` | `/api/auth/login` | Public |
| `GET` | `/api/categories` | Public |
| `GET` | `/api/categories/{id}` | Public |
| `POST` | `/api/categories` | Admin |
| `PUT` | `/api/categories/{id}` | Admin |
| `DELETE` | `/api/categories/{id}` | Admin |
| `GET` | `/api/menuitems` | Public |
| `GET` | `/api/menuitems/{id}` | Public |
| `POST` | `/api/menuitems` | Admin |
| `PUT` | `/api/menuitems/{id}` | Admin |
| `DELETE` | `/api/menuitems/{id}` | Admin |
| `GET` | `/api/orders` | Admin |
| `GET` | `/api/orders/{id}` | Authenticated |
| `POST` | `/api/orders` | Authenticated |
| `PUT` | `/api/orders/{id}` | Admin |
| `DELETE` | `/api/orders/{id}` | Admin |

---

## 🚀 Kom igång

### Förutsättningar
- .NET 8 SDK
- SQL Server eller LocalDB

### Installation

**1. Klona repositoryt**
```bash
git clone https://github.com/youabd123/restaurant-system-api.git
cd restaurant-system-api
```

**2. Kontrollera anslutningssträngen**

Öppna `RestaurantSystem.API/appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RestaurantSystemDb;Trusted_Connection=True;"
}
```

**3. Kör migrationer**
```bash
dotnet ef database update --project RestaurantSystem.Infrastructure --startup-project RestaurantSystem.API
```

**4. Starta API:et**
```bash
dotnet run --project RestaurantSystem.API
```

**5. Öppna Swagger**

Navigera till `https://localhost:7134/swagger`

### Autentisering
1. Registrera via `POST /api/auth/register`
2. Logga in via `POST /api/auth/login` — få JWT token
3. Klicka **Authorize** i Swagger och klistra in token

---

## 🧪 Tester

```bash
dotnet test
```
