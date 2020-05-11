### Project Structure
<img src="https://github.com/sabbiryan/reconciliation/blob/master/Outputs/project-structure.png"/>
Simple project structure with several clients. Clients depends on "ReconcciliationApp.Service" for request and response execution. Which is responsible for core business logics. This client projects are created using Visual Studio Project Templates

### Newly Added
1. Recondiliation grid render to react client app
2. Edit inline table cell from react app

### Upcomming 
1. Recondiliation grid render to vue client app
2. Edit inline table cell from vue app

### Features
1. Reconciliation table grid
2. Inline table cell edit (angular & blazor)
3. On startup database table delete all rows and ensure tabels has only seed data

### Technologies
1. .Net Core 3.1
2. Entity Framework Core 3.1.3
3. AutoMapper 9.0.0
4. Angualr 9
5. Blazor
6. Blazor.Modal 4.1.0
7. Bootstrap 4
8. React 16.0.0

### Getting Start
1. Clone the repository
2. Open on visual studio(2019 recommended)
3. Select client Angular/Blazor and mark set as startup from visual studio solution explorer
4. Open "appsettings.json" of the selected client project and update the connection string server name with yours. Default is SQLExpress, if your server name is like SQLExpress, you can ignore this step
5. Run the project through Ctrl + F5 (if angular client is selected, for the very first time it will take some time to build and run for angular npm dependencies)
6. No need to worry about the database, on the startup of the application, it will be created automatically, also insert some seed data as like the output. So you will get the output exactly same as output sample of a client


### Reconciliation Outputs

#### Angular Client
<img src="https://github.com/sabbiryan/reconciliation/blob/master/Outputs/reconciliation.angular.home.png"/>

#### Blazor Client
<img src="https://github.com/sabbiryan/reconciliation/blob/master/Outputs/reconciliation.blazor.home.png"/>

#### React Client
<img src="https://github.com/sabbiryan/reconciliation/blob/master/Outputs/reconciliation.react.home.png"/>
