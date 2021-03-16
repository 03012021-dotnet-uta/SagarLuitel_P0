# pizzabox

PizzaBox is a console-based pizza ordering application.

## architecture (REQUIRED)

+ [solution] PizzaBox.sln
  + [project - console] PizzaBox.Client.csproj
  + [project - classlib] PizzaBox.Domain.csproj
    + [folder] Abstracts
    + [folder] Interfaces
    + [folder] Models
    + [folder] Singletons
  + [project - classlib ] PizzaBox.Storing.csproj
    + [folder] Repositories
  + [project - xunit] PizzaBox.Testing.csproj
    + [folder] Tests

## requirements

The application is centered around the interaction of 4 main objects:
- Customer
- Order
- Pizza
- Store

## technologies

+ .NET Core - C#
+ .NET Core - EF + SQL
+ .NET Core - xUnit

## timelines

  - able to place an order with 1 pizza
  - able have 10 total validation unit tests for Customer, Order, Pizza, Store
  - able to save a placed order including customer info, pizza info, store info


