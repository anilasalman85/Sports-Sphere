
# Sports Sphere – E-Commerce Platform for Sports Products

## Overview

Sports Sphere is a modular e-commerce web application developed using **ASP.NET 7** and **Blazor Server**.  
It is specifically designed for sports-related products, offering both user and admin interfaces. The application follows a layered architecture consisting of class libraries and Blazor apps, backed by **Microsoft SQL Server** for persistent data storage.  

---

## Features

- Secure authentication and authorization for both users and administrators.  
- Admin dashboard to manage categories, products, users, and stock refills.  
- Dynamic product listing with category filters and recommendation system.  
- Cart management and order confirmation modules for users.  
- Intuitive UI with custom branding, animations, and banners for promotions.

---

## Tech Stack

| Technology       | Description                                 |
|------------------|---------------------------------------------|
| Frontend         | Blazor Server (.NET 7)                      |
| Backend          | ASP.NET Core                                |
| Database         | Microsoft SQL Server                        |
| Architecture     | Layered – Class Libraries & Blazor Apps     |

---

## Use Cases / Applications

- Acts as a full-featured e-commerce solution for selling sports goods online.  
- Provides a dedicated portal for admins to manage inventory and user data.  
- Designed for scalability and future integration of advanced features like payment gateways.  

---

## System Architecture

### Class Libraries

- **SportsSphere.DataModel**  
  Contains model classes for core entities like Product, Category, User, Cart, Admin, and StockRefill.

- **SportsSphere.DataAccessLayer**  
  Implements the Data Access Layer (DAL) with CRUD operations for each model class.

### Blazor Server Applications

- **SportsSphere.Users**  
  Handles user-facing features such as registration, login, product browsing, cart, and order confirmation. Code is modular and well-commented for maintainability.

- **SportsSphere.Admin**  
  Provides admin-side functionalities including product and category management, stock updates, and user/admin control panels. Maintains clear separation of concerns with comprehensive inline documentation.

---

## Planned Features

- Integration of payment gateways (e.g., PayPal, Stripe) for order processing.

---

## Contact Me

**Anila Salman**  
Email: aneylasalman85@gmail.com
