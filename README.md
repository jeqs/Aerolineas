# Aerolíneas

Proyecto en Visual Studio 2019 Framework 4.8

# Librerías
- Aerolineas.DataStorage: Capa de Base de datos
- Aerolineas.Infrastructure: Capa de Infrastructura
- Aerolineas.Services: Capa de servicio o lógica de negocio
- Aerolineas.Transverse: Capa Transveral del Proyecto
- Aerolineas.Web: Proyecto Web en MVC
- Aerolineas.WebApi: Servicio Web REST API

# Lenguajes
C#, SQL, Javascript, HTML

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

# Donate/Support
If you like my work, feel free to support it. Donations to the project are always welcomed :)

Buy Me A Coffee
https://www.buymeacoffee.com/jeqs
