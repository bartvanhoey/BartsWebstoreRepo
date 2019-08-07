# EventCloud Step-by-step

Create & download your project first from https://aspnetboilerplate.com/Templates (Check One solution)

## dotnet core

1. Create a new Database EventCloudDb in SQL Server
 
2. Change ConnectionStrings->default: in appsettings.json of EventCloud.Web.Host project

3. In Package Manager Console, select the EntityFrameworkCore project and run `database-update` command

4. Set the EventCloud.Web.Host project as Startup project and run it.

5. Navigate to http://localhost:21021/swagger/index.html to see if swagger is working
 
## angular 
 
1. Open a terminal and navigate to the Angular project (where you find the angular.json file) and run `yarn`

2. Hit `npm start` to run the project

3. Navigate to http://localhost:4200 to see if application is running


