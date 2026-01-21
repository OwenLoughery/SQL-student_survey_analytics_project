# Student Survey Analytics (SQL + Data Visualization)

## Overview
**Student Survey Analytics** is a data-driven web application that analyzes anonymized student survey data stored in a cloud-hosted SQL Server database. The project focuses on querying, aggregating, and visualizing real-world survey data to uncover trends related to student stress, academic experience, and overall well-being.

This project was completed as a final project for **CSC 365 (Database Systems)** and emphasizes SQL-driven analytics, clean data access patterns, and clear visual communication of insights.

---

## Key Features
- Programmatic connection to an **Azure SQL Server** database
- SQL **stored procedures** used for all data queries
- Clean separation between database access, business logic, and presentation
- Interactive data visualizations rendered in a web application
- Aggregated metrics such as averages, ranges, and response distributions

---

## Tech Stack
- **Backend:** C# / ASP.NET Core MVC  
- **Database:** Azure SQL Server  
- **Query Layer:** SQL Stored Procedures  
- **Frontend:** Razor Views (HTML/CSS)  
- **Data Access:** Custom service layer (ADO.NET / ODBC-style connection)

---

## Data Analysis & Visualizations
The application generates multiple analytical views, including:
- Average survey responses across key dimensions such as stress, workload, career outlook, and enjoyment of CS
- Response ranges and variability, highlighting dispersion and consistency in student answers
- Time-series trends showing how average stress and workload change over the quarter
- Category-based analysis, such as how career outlook varies with enjoyment of computer science

### Example Visualizations

- Average response scores by survey category  
- Response range comparison across questions  
- Stress vs. workload trends over time  
- Career outlook grouped by CS enjoyment level  

---

## Technologies & Concepts

- SQL Server (Azure)
- SQL Stored Procedures
- C# / ASP.NET Core MVC
- Cloud database connectivity
- Data aggregation & analytics
- Service-layer architecture
- MVC design pattern
- Secure credential handling
- Data visualization & insight communication
- Real-world survey data analysis

---

## Security & Access Notes

- The live Azure SQL database used for this project is **private**
- Connection strings and credentials are **not included** in this repository
- Configuration files are sanitized for public sharing
- Screenshots are used to demonstrate functionality safely

---

## What This Project Demonstrates

- Real-world experience querying **cloud-hosted databases**
- Writing SQL for analytics, not just CRUD operations
- Translating raw data into **actionable insights**
- Building maintainable, production-style data applications
- Communicating technical results to non-technical stakeholders
*(Add screenshots here — recommended for portfolio use)*

Example:
