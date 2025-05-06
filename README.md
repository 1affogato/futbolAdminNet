## ERROR EN LA CLASE "RepositoryBase": NO se encuentra el namespace
### Solucion:
Desinstalar los paquetes de oracle:
1. click derecho en la solucion -> Manage NuGet Packages for solution.
2. buscar los paquetes de oracle y desinstalar ManageDataAcess y ManageDataAccess.EntityFramework
3. Abrir tools -> NuGet Package Manager -> Package Manager Console
4. Ejecutar Install-Package Oracle.ManagedDataAccess
5. Ejecutar Install-Package Oracle.ManagedDataAccess.EntityFramework
