Description API (AmadeusWebAPI):



The API was developed in .NET Core 8 using the following:



* Entity Framework Core with a SQL Server database.
* Identity.EntityFrameworkCore and Authentication.JwtBearer for authentication and authorization.
* Swagger for documentation and visualization of exposed endpoints.



Theme:

The project is focused on the airline domain. The Airlines table was created, and a complete CRUD operation was implemented on it.



Endpoints:

The main controller is Airlines, available at the URL: https://localhost:7052/Airlines



   Public methods:



* GET (list airlines)
* GET /Airlines/{id} (query airline by ID)



   Restricted methods (require authorization):



* POST (create airline)
* PUT (update airline)
* DELETE (delete airline) → This method requires the user with admin role.



Testing (AmadeusWebAPI.Tests):

A unit test project using xUnit was added to validate the API's functionality.



Configuration:

To run the project, you need to:



Verify the database connection in the appsettings.json or appsettings.Development.json file, as appropriate (configure the server name in the configuration file).



The ApplicationDbContext.cs class includes initial data for a user with the admin role, useful for access validations.

Run the migrations using the following commands:

* Add-Migration First
* Update-Database





-----------------------------------------------------------------------------------------



Descripción del API (AmadeusWebAPI):



Se desarrolló la API en .NET Core 8 utilizando las siguientes tecnologías:

•   EntityFrameworkCore con base de datos SQL Server.

•   Identity.EntityFrameworkCore y Authentication.JwtBearer para la autenticación y autorización.

•   Swagger para la documentación y visualización de los endpoints expuestos.





Tema:

El proyecto está orientado a el tema de las aerolíneas. Se creó la tabla Airlines, sobre la cual se implementó un CRUD completo.



El controlador principal es Airlines, disponible en la URL: https://localhost:7052/Airlines



&nbsp;  Métodos públicos:

* GET (listar aerolíneas)
* GET /Airlines/{id} (consultar aerolínea por ID)

&nbsp;	

&nbsp;  Métodos restringidos (requieren autorización):

* POST (crear aerolínea)
* PUT (actualizar aerolínea)
* DELETE (eliminar aerolínea) → Este método requiere que el usuario tenga el rol admin.



Pruebas:

Se añadió un proyecto de pruebas unitarias utilizando xUnit para validar la funcionalidad de la API.



Configuración:

Para ejecutar el proyecto es necesario:



Verificar la conexión a la base de datos en el archivo appsettings.json o appsettings.Development.json, según corresponda.Configurar el nombre del servidor en el archivo de configuración.



En la clase ApplicationDbContext.cs se incluyeron datos iniciales de un usuario con rol admin, útiles para validaciones de acceso.

Endpoints

Ejecutar las migraciones con los comandos:

* Add-Migration First
* Update-Database



