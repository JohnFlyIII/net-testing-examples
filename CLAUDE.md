# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This repository contains a step-by-step example of incremental .NET testing strategies using a fictitious Calculator implementation. The project is organized into three progressive parts, each demonstrating different testing approaches as complexity increases.

Currently using .NET 9.0 across all projects with Central Package Management (CPM) enabled.

## Common Development Commands

### Building Projects

```bash
# Part 1 - Basic Calculator Library
cd part-1 && ./scripts/build.sh

# Part 2 - Web UI & API
cd part-2 && ./scripts/build.sh

# Part 3 - Database Integration
cd part-3 && ./scripts/build.sh
```

### Running Tests

```bash
# Part 1
cd part-1 && ./scripts/test.sh

# Part 2
cd part-2 && ./scripts/test.sh

# Part 3
cd part-3 && ./scripts/test.sh
```

### Running a Single Test
```bash
# Using dotnet test with filter
dotnet test --filter "FullyQualifiedName~TestClassName.TestMethodName"

# Example:
dotnet test ./test/calculatorTests/calculatorTests.csproj --filter "FullyQualifiedName~CalculatorTests.Calculator_Add_5_Plus_10_Equal_15"
```

### Database Operations (Part 3 only)

```bash
# Start PostgreSQL database
cd part-3/src/CalcDb && docker-compose up -d

# Add new EF migration
cd part-3/scripts && ./efmigrationadd.sh "MigrationName"

# List migrations
cd part-3/scripts && ./efmigrationslist.sh

# Generate SQL script from migrations
cd part-3/scripts && ./efmigrationsscript.sh
```

## Architecture Overview

### Part 1: Basic Calculator Library
- **Calculator.csproj**: Simple calculator class library with Add, Subtract, and AreaOfCircle methods
- **CalculatorTests.csproj**: XUnit tests for the calculator library
- Uses hardcoded constants

### Part 2: Web Application
- **CalcWeb.csproj**: ASP.NET Core MVC web application with:
  - MVC Calculator UI (`/Calculator`)
  - REST API endpoints (`/api/calc/*`)
- **Calculator.csproj**: Reused from Part 1
- **CalcWebTests.csproj**: Integration tests using TestServer
- **CalculatorTests.csproj**: Unit tests

### Part 3: Database-Backed Constants
- **Calculator.Data.csproj**: Entity Framework Core data layer
  - `CalculatorDbContext`: EF Core context for PostgreSQL
  - `IConstantsRepository`: Repository pattern for constants
  - Migrations for database schema
- **CalcWeb.csproj**: Enhanced with dependency injection for database services
  - `TestStartup.cs`: Special startup for integration testing
- **Calculator.Data.Tests.csproj**: Repository tests with SQLite in-memory database
- Uses Flyway for production database migrations alongside EF Core

## Testing Strategy

1. **Unit Tests**: XUnit for isolated class testing
2. **Integration Tests**: 
   - TestServer for API endpoint testing
   - In-memory SQLite for data layer testing
3. **Test Organization**: 
   - Tests use priority ordering (see `TestPriorityAttribute.cs`)
   - Test results output as .trx files for CI/CD integration

## Key Dependencies

- **Testing**: XUnit 2.9.3, Microsoft.AspNetCore.TestHost, Xunit.DependencyInjection
- **Database**: Entity Framework Core 9.0, PostgreSQL, SQLite (for testing)
- **Web**: ASP.NET Core 9.0 MVC
- **Logging**: Serilog 4.3.0 with ASP.NET Core integration

## Central Package Management

This project uses .NET's Central Package Management feature:
- `Directory.Packages.props`: Defines all package versions centrally
- `Directory.Build.props`: Sets common properties like TargetFramework (net9.0)
- All `.csproj` files reference packages without version attributes

## Migration Path

The project demonstrates progressive enhancement:
1. Start with simple hardcoded calculator logic
2. Add web UI and API layer
3. Introduce database for configurable constants
4. (Part 4 planned): Edge cases, overflow/underflow handling

## Build Notes

- Nullable reference types are enabled across the solution
- Documentation XML generation is enabled (with CS1591 warnings suppressed)
- Test projects are automatically detected via `IsTestProject` property