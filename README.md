# Taxi Unico Server
Servidor para proyecto Taxi Unico en formato de Web API programado en c# mediante .Net Core Framework.
Actualmente hosteado en digital ocean.

## Instrucciones
Realizar peticiones http (GET, POST, PUT) a la dirección http://206.189.164.14:80/api/{RUTA}
Donde RUTA puede ser
Para clientes:
  [GET]
    clientes => GetAllClientes
    clientes/{id} => GetClienteById
    clientes/email/{email} => GetClienteByEmail
  [POST]
    clientes => CreateCliente
  [PUT]
    clientes/{id} => UpdateCliente

Para taxistas:
  [GET]
    taxistas => GetAll
    taxistas/{id} => GetById
    taxistas/email/{email} => GetByEmail
  [POST]
    taxistas => Create
  [PUT]
    taxistas/{id} => Update
    
Para administradores:
  [GET]
    admins => GetAll
    admins/{id} => GetById
    admins/email/{email} => GetByEmail
  [POST]
    admins => Create
  [PUT]
    admins/{id} => Update

Para viajes:
  [GET]
    viajes => GetAll
    viajes/{id} => GetById
    viajes/vehiculo/{vehiculoId} => GetByVehiculo
    viajes/taxista/{taxistaId} => GetByTaxista
    viajes/cliente/{clienteId} => GetByCliente
  [POST]
    viajes => Create
  [PUT]
    viajes/{id} => Update
    
## Instalación
Si desea instalar el servidor en su propia red debe instalar el SDK .Net Core en su equipo, puede descargarlo desde: 
  https://www.microsoft.com/net/download 
Tambien debe clonar el repositorio con: 
  git clone https://github.com/CarlosIvanCardenas/TaxiUnicoServer.git
Entrar al directorio:
  cd TaxiUnicoServer
Iniciar .Net:
  dotnet run
