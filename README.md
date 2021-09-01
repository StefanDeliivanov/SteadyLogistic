# Steady Logistics

A simple web application for freight brokerage :truck: made with educational purposes,
as my graduation project for the SoftUni ASP.NET Core Web Development course August 2021 :dart:


## &copy; SteadyLogistics&trade; Logo
![](https://i.imgur.com/qsH3Lq1.jpg)


## :hammer_and_pick: **Built With**

- MS Visual Studio 2019
- MS SQL Server Management Studio 2017
- ASP.NET Core 5.0
- Entity Framework (EF) Core 5.0
- Microsoft SQL Server Express
- ASP.NET Identity System
- MVC Areas with Multiple Layouts
- Razor Pages, Sections, Partial Views
- Dependency Injection
- Sorting, Filtering, and Paging with EF Core
- Data Validation, both Client-side and Server-side
- In-Memory Cache
- Bootstrap Responsive Design
- HTML5
- CSS
- Google API
- Newtonsoft Json


## :gear: **Application Configurations**

### 1. The Connection string 
is in `appsettings.json`. If you don't use SQLEXPRESS, you should replace `Server=.\\SQLEXPRESS;` with `Server=.;`

### 2. Seeding sample data
would happen once you run the application, including Test Account:
  - Admin: "admin@steadylogistics.com" / password: admin123
  - 2 CargoSizes: "Full Load" and "Groupage"
  - 7 Trailer Types : "Box", "Flatbed", "Jumbo", "Mega", "Refrigerator", "Tank", "Tautliner" },
  - 46 Europe countries easily accessible by land for the needs of Road Transportation alongside their Alpha-2 code

## :floppy_disk: **Database Diagram**
![](https://imgur.com/799QcIq.jpg)


## **Backend**
The web project contains:
* 4 different areas: Identity, Admin, Manager, Member
* 4 Roles: Admin, Manager, Premium User, Regular Member
* 11 custom services with 60+ service methods
* 6 controllers
* 29+ views


## **Screenshots**
**SteadyLogistics - Login**
![SteadyLogistics - Login](https://imgur.com/O0aheqE.jpg)

**SteadyLogistics - Register**
![SteadyLogistics - Register](https://imgur.com/MBSyyjG.jpg)

**SteadyLogistics - Message Details**
![SteadyLogistics - Message Details](https://imgur.com/P6GeLTR.jpg)

**SteadyLogistics - News**
![SteadyLogistics - News](https://imgur.com/mO0tdYc.jpg)

**SteadyLogistics - Add an Article**
![SteadyLogistics - Add an Article](https://imgur.com/XtAuphu.jpg)

**SteadyLogistics - Contacts**
![SteadyLogistics - Contacts](https://imgur.com/ER6iIWD.jpg)

**SteadyLogistics - All Freights**
![SteadyLogistics - All Freights](https://imgur.com/8jiQ1l3.jpg)

**SteadyLogistics - Freight Detail**
![SteadyLogistics - Freight Details](https://imgur.com/qyiGnQI.jpg)

**SteadyLogistics - Add Freight**
![SteadyLogistics - Add Freight](https://imgur.com/2BanUGn.jpg)

**SteadyLogistics - User Details**
![SteadyLogistics - User Details](https://imgur.com/TLfoyVP.jpg)


## :v: **Show your opinion**

Give a :star: if you like this project


## **License**
This project is licensed under the MIT License - see the LICENSE.md file for details!
