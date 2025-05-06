# FutbolAdminDotnet

### Conectando a la base de datos

INSTRUCCIONES NO VÁLIDAS POR EL MOMENTO

1. Es necesario tener una base de datos Oracle database instalada de forma local y crear el usuario que va a acceder a la base de datos del proyecto.
2. Con ese usuario necesitas ejecutar el script de creación de tablas que se encuentra en la carpeta Scripts del proyecto. El script se llama `FutbolAdmin.sql`.
3. Necesitas ir al archivo App.config en la raíz del proyecto, ir hasta el final del archivo y cambiar la cadena de conexión por la de tu base de datos local.
La cadena de conexión tiene el siguiente formato:
```xml
connectionString="User Id=TU_USUARIO;Password=TU_CONTRASEÑA_DEL_USUARIO;Data Source=localhost:1521/ORCLPDB1;"
```