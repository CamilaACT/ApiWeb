
# API Web en .NET 8

## Descripción

Esta API está desarrollada en .NET 8 y expone varios servicios relacionados con la autenticación de usuarios, gestión de menús, roles y usuarios. Cada controlador maneja una serie de operaciones CRUD, asegurando la interacción con la base de datos SQL server a través de procedimientos almacenados.

### Controladores expuestos:

#### **LoginController**

1. **POST `/api/Login/registrarse`**  
   Registra un nuevo usuario en la plataforma encriptando la contraseña utilizando SHA256.
   - **Parámetros**: 
     - `Usuario`: Información del usuario a registrar.
   - **Respuesta**: 
     - Objeto `Respuesta` que indica el éxito o fallo del registro.

2. **POST `/api/Login/inicioSesion`**  
   Inicia sesión para un usuario existente, valida las credenciales y devuelve un token JWT en caso de éxito.
   - **Parámetros**: 
     - `Login`: Objeto con las credenciales de acceso (usuario y contraseña).
   - **Respuesta**: 
     - Objeto `Respuesta` que incluye un token JWT para el usuario.

3. **GET `/api/Login/validarToken`**  
   Valida si el token JWT proporcionado es válido.
   - **Parámetros**: 
     - `token`: El token JWT que se quiere validar.
   - **Respuesta**: 
     - Objeto `Respuesta` que indica si el token es válido o no.

#### **MenuController**

1. **POST `/api/Menu/listarMenu`**  
   Retorna la lista de menús disponibles para un usuario específico según su rol.
   - **Parámetros**: 
     - `us_id`: ID del usuario.
   - **Respuesta**: 
     - Lista de menús disponibles para el usuario.

#### **RolesController**

1. **GET `/api/Roles/listarRoles`**  
   Retorna una lista de todos los roles disponibles en el sistema.
   - **Parámetros**: 
     - Ninguno.
   - **Respuesta**: 
     - Lista de roles.

#### **UsuarioController**

1. **POST `/api/Usuario/listaUsuarios`**  
   Devuelve una lista de usuarios filtrados por un ID de usuario.
   - **Parámetros**: 
     - `Usuario_id`: ID del usuario a buscar.
   - **Respuesta**: 
     - Lista de usuarios asociados con el ID proporcionado.

2. **POST `/api/Usuario/registrar`**  
   Registra un nuevo usuario con la contraseña encriptada utilizando SHA256.
   - **Parámetros**: 
     - `Usuario`: Información del usuario a registrar.
   - **Respuesta**: 
     - Objeto `Respuesta` que indica el éxito o fallo del registro.

3. **PUT `/api/Usuario/editar`**  
   Edita la información de un usuario existente.
   - **Parámetros**: 
     - `Usuario`: Información actualizada del usuario.
   - **Respuesta**: 
     - Objeto `Respuesta` que indica el éxito o fallo de la edición.

4. **POST `/api/Usuario/buscar`**  
   Busca un usuario por su nombre.
   - **Parámetros**: 
     - `Usuario_nombre`: Nombre del usuario a buscar.
   - **Respuesta**: 
     - Objeto `Respuesta` con la información del usuario encontrado.

5. **DELETE `/api/Usuario/eliminar/{us_id}`**  
   Elimina un usuario del sistema por su ID.
   - **Parámetros**: 
     - `us_id`: ID del usuario a eliminar.
   - **Respuesta**: 
     - Objeto `Respuesta` que indica el éxito o fallo de la operación.
### Objeto Respuesta

El objeto `Respuesta` es utilizado para estandarizar las respuestas de las operaciones en la API. Está compuesto por los siguientes campos:

- **`CodigoError`**: Un valor entero que indica si la operación fue exitosa o si ocurrió un error.
  - `-1`: Indica que la operación fue exitosa.
  - `1`: Indica que ocurrió un error en la operación.

- **`Message`**: Una cadena de texto que contiene un mensaje adicional sobre el resultado de la operación. Este mensaje puede describir el éxito o los detalles del error.

- **`Result`**: Un objeto que contiene el resultado de la operación realizada. Este campo es dinámico y puede variar dependiendo del tipo de operación:
  - Puede ser un objeto de usuario, una lista de elementos, o cualquier otro tipo de dato esperado como resultado de la operación.
  - Si la operación es de tipo "inicio de sesión", este campo puede incluir un token JWT.



### Estructura del Proyecto

El proyecto está dividido en varias capas lógicas:

- **Controllers**: Controladores para manejar las peticiones HTTP.
- **Custom**: Contiene utilidades específicas como la encriptación y validación de tokens JWT.
- **Data**: Encargada de la conexión a la base de datos y procedimientos relacionados.
- **Model**: Define los modelos de datos para los usuarios, roles, menús, y peticiones/respuestas de la API.
- **Util**: Clases de apoyo para la conexión y manejo de utilidades en el sistema.


## Tabla de Contenidos

1. [Requisitos previos](#requisitos-previos)
2. [Instalación](#instalación)
3. [Configuración](#configuración)
4. [Uso](#uso)
5. [Tests](#tests)
6. [Despliegue](#despliegue)
7. [Contribuciones](#contribuciones)
8. [Licencia](#licencia)

## Requisitos previos

- .NET SDK 8.0 o superior.
- SQL Server u otra base de datos compatible.
- IIS o algún servicio de hosting compatible.

## Instalación

Clona el repositorio en tu máquina local:

```bash
git clone https://github.com/CamilaACT/ApiWeb.git
