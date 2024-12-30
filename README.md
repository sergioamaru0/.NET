# Task Manager API

Este proyecto es un backend desarrollado en **C#**, diseñado para gestionar tareas. Proporciona un conjunto de endpoints para realizar operaciones CRUD sobre las tareas y está configurado para ser dockerizado y desplegado en **Render**.

## Características

### Recursos principales

- **Tarea (Task):**
  - **ID**: Generado automáticamente.
  - **Título (title)**: Texto obligatorio.
  - **Descripción (description)**: Texto opcional.
  - **Estado (completed)**: Booleano, por defecto `false`.
  - **Fecha de creación (createdAt)**: Generada automáticamente.

### Endpoints

![image](https://github.com/user-attachments/assets/8e65504b-b32e-4837-bef6-ea4a4bad7d6a)

#### **POST** `/api/tasks`
- **Descripción**: Crea una nueva tarea.
- **Requisitos**:
  - Validación de que el campo `title` esté presente.
- **Códigos de respuesta**:
  - `201`: Tarea creada exitosamente.
  - `400`: Datos inválidos.
![image](https://github.com/user-attachments/assets/e761358e-97eb-4730-8b13-622c0a6403a2)

#### **GET** `/api/tasks`
- **Descripción**: Devuelve la lista de tareas.
- **Opciones**:
  - Filtrar por estado (`completed` o `pending`).
- **Códigos de respuesta**:
  - `200`: Lista de tareas obtenida exitosamente.
    
![image](https://github.com/user-attachments/assets/2782a509-0b4a-492f-84fc-658699337f05)

#### **GET** `/api/tasks/:id`
- **Descripción**: Devuelve los detalles de una tarea específica.
- **Códigos de respuesta**:
  - `200`: Tarea encontrada.
  - `404`: Tarea no encontrada.
  - 
![image](https://github.com/user-attachments/assets/eb23d5f8-eeee-4770-88e8-7f7cc525c190)

#### **PUT** `/api/tasks/:id`
- **Descripción**: Actualiza los campos de una tarea.
- **Códigos de respuesta**:
  - `200`: Tarea actualizada exitosamente.
  - `400`: Datos inválidos.
  - `404`: Tarea no encontrada.
  - 
![image](https://github.com/user-attachments/assets/8d82b7c8-38b0-4d22-9c58-8db73ac64de7)

#### **DELETE** `/api/tasks/:id`
- **Descripción**: Elimina una tarea.
- **Códigos de respuesta**:
  - `200`: Tarea eliminada exitosamente.
  - `404`: Tarea no encontrada.
![image](https://github.com/user-attachments/assets/6e364c98-1b42-47d7-9230-b0bddca93a74)

### Requerimientos técnicos

1. **Base de datos**:
   - **MongoDB**: Conectado usando **Mongoose**.

2. **Validaciones**:
   - Implementadas con `express-validator`.

3. **Documentación**:
   - Realizada con **Swagger**. Accede a la documentación en el endpoint `/swagger`.

4. **Manejo de errores**:
   - Respuestas estructuradas y claras con códigos de estado (`400`, `404`, `500`).

## Configuración y Uso

### Prerrequisitos

- Tener instalado [Docker](https://www.docker.com/).
- Tener una cuenta activa en [Render](https://render.com/).

### Descarga e instalación

1. Clona este repositorio:
  
   `git clone https://github.com/usuario/repo.git`
   `cd repo`
2. Construye la imagen Docker

  `docker build -t task-manager-api .`

3. **Ejecuta el contenedor**
  `docker run -p 5000:5000 task-manager-api`
4. Configuración del entorno
Asegúrate de configurar las siguientes variables de entorno:

`MONGO_URI: La cadena de conexión para tu base de datos MongoDB.`
`PORT: El puerto en el que se ejecutará el servidor (por defecto, 5000).`
5. Crea un archivo .env en la raíz del proyecto con las siguientes líneas:

`MONGO_URI=tu_cadena_de_conexion`
`PORT=5000`
6. Despliegue en Render
Inicia sesión en tu cuenta de Render.
Sube este repositorio como una nueva aplicación de servicio web.
Configura las variables de entorno necesarias en la sección de configuración de Render.
Uso
Accede a la API en http://localhost:5000 (o en el dominio proporcionado por Render después del despliegue).
Consulta la documentación Swagger en /swagger.
![image](https://github.com/user-attachments/assets/90311142-451d-49c9-a691-9424482f1563)

![image](https://github.com/user-attachments/assets/1638a78c-f8c4-4f69-be37-deb693d6e401)


