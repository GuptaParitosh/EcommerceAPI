# EcommerceAPI
This repo will showcase the use of Clean Architecture in.NetCore Application using CQRS - Mediatr and Repository pattern. This Project can also act as a template for creating new APIs using CQRS and Repository pattern.

# Project Set Up
1. Make sure that database connection string is set up properly in AppSettings.Json
2. dotnet build
3. Run Migrations:
   - add-migration InitialMigration
   - update-database
  It will create the tables and seed data in the both product and category tables
5. dotnet run
6. Swagger will open with all the APIs
