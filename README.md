# HR.LeaveManagement.Vert

A **Vertical Slice Architecture**–based ASP.NET Core Web API for leave management, following SOLID principles and Clean Architecture, inspired by the “ASP.NET Core – SOLID and Clean Architecture” Udemy course.

## Table of Contents

- [Overview](#overview)  
- [Architecture](#architecture)  
- [Technologies](#technologies)  
- [Getting Started](#getting-started)  
- [Project Structure](#project-structure)  
- [Usage](#usage)  
- [Contributing](#contributing)  
- [License](#license)

---

## Overview

`HR.LeaveManagement.Vert` is an implementation of a leave management system API using the Vertical Slice Architecture. Instead of organizing code by technical layers, this architecture structures your codebase by feature or "slice," making it highly maintainable and scalable.

---

## Architecture

### What is Vertical Slice Architecture?

This approach organizes application logic around **features** by grouping all related components—such as API endpoints, business logic, validation, and persistence—within a single slice. Each slice corresponds to a specific use case, supporting independent development and deployment.

#### Key Benefits:
- **High cohesion, low coupling:** Features live in one place, minimizing dependencies across the system.  
- **Faster feature delivery:** Implement features without hopping between layers.  
- **Clean separation of concerns:** Natural alignment with CQRS through commands and queries per slice.  

---

## Technologies

This project incorporates:
- **ASP.NET Core**  
- **MediatR** for command/query handling (CQRS)  
- **FluentValidation** for slice-level validation  
- **AutoMapper** for object mapping  
- **Entity Framework Core** for persistence  

---

## Getting Started

1. **Clone the repository**  
   ```bash
   git clone https://github.com/angelkomarov/HR.LeaveManagement.Vert.git
   cd HR.LeaveManagement.Vert
   ```
---

2. **Build the solution**
```bash
dotnet build HR.LeaveManagement.Vert.sln
```
