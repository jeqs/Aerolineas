# Aerolineas


Proyecto en Visual Studio 2019 Framework 4.8

# Depedencias:
Para instalar las dependencias con Nuget, ejecutar el siguiente comando en consola de nuget
Update-Package -reinstall

# Base de datos
Ejecutar el script de creación de los objetos de la base de datos Microsoft Sql Server de la carpeta: 
ScriptsBD\CreacionObjetosBD.sql

# Archivos de Configuración
Las cadenas de conexión que se encuentran en los proyectos Aerolineas.WebApi\web.config
Cambiar en la sección AerolineasEntities en el grupo de cadenas de conexión "AerolineasEntities" por el servidor donde se encuentra la base de datos.

# Configuración sitio web
Para que el sitio web se conecte al servicio web Rest Api, cambiar en el archivo de  Aerolineas.Web\web.config
En la sección appSettings cambiar la siguiente llave por la ruta local donde se vaya a ejecutar el servicio web.

<add key="RutaUrlApi" value="http://localhost:2471/api"/>

