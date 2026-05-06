- The completed project is under the master branch, not the main branch sir. It also contains my commits and ST10296234 commits while the main branch contains ST10439133, ST10451026 and ST10446909 commits. 
  
# Smart Retail Analytics Dashboard

Overcats Coding Company

Joshua Gerald Chetty - ST10296234

Suvan Samlall - ST10441359 (Grp Leader)

Camryn Deyuri Naidoo - ST10439133

Calib Laaiton Frank - ST10451026

Caleb Ragevan - ST10446909


## Requirements Met

- REST API: COMPLETE
- Docker Containerisation: COMPLETE
- SOLID Principles: COMPLETE
- Layered Architecture: COMPLETE


## API Endpoints

- GET /api/analytics/sales/daily - Daily sales for line chart
- GET /api/analytics/inventory/low-stock - Low stock alerts
- GET /api/analytics/products/top - Top 5 selling products
- GET /api/analytics/kpi/summary - KPI summary cards


## How to Run

Option 1: Visual Studio (No Docker)

1. Open SmartRetailAnalytics.sln
2. Set SmartRetail.API as startup project
3. Press F5
4. Go to https://localhost:7000/index.html

Option 2: Docker

docker-compose up --build

Then open: http://localhost:5000/index.html

Option 3: Command Line (No Docker)

cd SmartRetail.API
dotnet run

Then open: https://localhost:7000/index.html


## SOLID Principles Applied

Single Responsibility: AnalyticsUseCase.cs - Class only handles analytics calculations

Open/Closed: Metrics methods - New metrics can be added without modifying existing code

Liskov Substitution: MockSalesRepository - Can replace any ISalesRepository implementation

Interface Segregation: ISalesRepository, IProductRepository, IInventoryRepository - Small, focused interfaces instead of one large interface

Dependency Inversion: AnalyticsUseCase - Depends on abstractions (interfaces), not concrete classes


## Dashboard Features

- KPI Cards: Total sales, transactions, average order value, items sold
- Daily Sales Trend: Line chart of last 7 days
- Top Products: Pie chart of best selling items
- Low Stock Alerts: Table of products needing reorder
- Auto-refresh: Updates every 30 seconds


## Technologies Used

- .NET 10 for Framework
- ASP.NET Core Web API for REST API
- xUnit for Unit testing
- Docker for Containerisation
- Chart.js for Dashboard charts
