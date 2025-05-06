## Construir BD
Para que funcione el programa se debe contar ya con la base de datos creada, para esto existe un archivo que contiene el codigo SQL para construir la BD. Se encuentra en futbolAdmin -> sqls -> FUTBOLADMIN.sql
El codigo SQL se utiliza en el Oracle SQL develooper para crear la base de datos, se sigue el mismo procedimiento visto en la clase de BD

## ERROR EN LA CLASE "RepositoryBase": NO se encuentra el namespace
### Solucion:
Desinstalar los paquetes de oracle:
1. click derecho en la solucion -> Manage NuGet Packages for solution.
2. buscar los paquetes de oracle y desinstalar ManageDataAcess y ManageDataAccess.EntityFramework
3. Abrir tools -> NuGet Package Manager -> Package Manager Console
4. Ejecutar Install-Package Oracle.ManagedDataAccess
5. Ejecutar Install-Package Oracle.ManagedDataAccess.EntityFramework
