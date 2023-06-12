<h1 align="center">
  <p>MusiColab</p>
</h1>

![Portada](https://github.com/FRodrigoRuiz/proyecto-albumes/assets/93401989/258eadf7-30c5-49a8-a2a9-e470cd7254e7)

<p align="left">
  <img src="https://img.shields.io/badge/STATUS-EN%20DESAROLLO-green">
</p>

<h2>Descripción</h2>

<p>
  MusicColab es una aplicación de gestión de álbumes musicales y autores que te permite explorar, crear y descubrir la música de tus       artistas favoritos de manera sencilla. Además, también podrás controlar el stock de los álbumes asociados a los artistas, manteniendo     un seguimiento preciso de la disponibilidad de cada título en tu colección.
  Nuestra plataforma ofrece una experiencia intuitiva, donde podrás agregar nuevos álbumes con toda su información relevante, como el       título, el año de lanzamiento, el género y más. Además, podrás asociar los álbumes con sus respectivos autores, lo que   te permitirá     explorar más sobre los artistas que te gustan, al tiempo que controlas la cantidad de copias disponibles de cada álbum.
</p>

## :hammer:Funciones

- `Gestion de albumes`: 
  - Creación de un nuevo álbum con información como título, año de lanzamiento, género, etc.
  - Asociar el álbum con su respectivo autor.
  - Mostrar una lista de todos los álbumes existentes en la base de datos.
  - Permitir la visualización de los detalles de un álbum específico.
  - Modificar la información de un álbum existente, como su título, año de lanzamiento, género, etc.
  - Eliminar un álbum de la base de datos, eliminando también su asociación con el autor correspondiente.
- `Gestion de autores`:
  - Agregar un nuevo autor con detalles como nombre, año de nacimiento y género musical.
  - Mostrar una lista de todos los autores registrados.
  - Permitir la visualización de los detalles de un autor específico.
  - Actualizar la información de un autor existente.
  - Eliminar un autor de la base de datos, asegurando que se manejen adecuadamente las asociaciones con los álbumes relacionados.
- `Control de stock`:
  - Registrar la cantidad de copias disponibles para cada álbum.
  - Actualizar el stock cuando se vendan o agreguen nuevas copias.

## 📊 Estado del proyecto
Actualmente, el proyecto MusiColab desarrollado en ASP.NET Core MVC se encuentra en funcionamiento y ofrece las funcionalidades básicas de crear, leer, actualizar y eliminar álbumes y autores. También se ha implementado el control de stock de los álbumes.
Próximas mejoras y nuevas funciones:
- ## Carga de imágenes de artistas y álbumes:
  Se planea agregar la funcionalidad de permitir a los usuarios cargar y asociar imágenes a los artistas y álbumes. Esto puede mejorar la   presentación visual y la experiencia del usuario al mostrar imágenes relacionadas con los álbumes y los artistas en las vistas.
- ## Mejora del diseño de las vistas:
  Se espera realizar mejoras en el diseño de las vistas para lograr una interfaz más atractiva y fácil de usar. Esto puede implicar el     uso de frameworks de diseño como Bootstrap y la optimización de la disposición y el aspecto visual de los elementos en las vistas.

## 🛠️ Abre y ejecuta el proyecto
- Para poder ejecutar el proyecto siga los siguientes pasos:
  - Descargue e instale git para su sistema operativo desde el siguiente enlace: https://git-scm.com/
  - Descargue e instale Visual Studio Code: https://code.visualstudio.com/
  - En GitHub.com, navega a la página principal del repositorio. Encima de la lista de archivos, haga clic en Code.
  - ![1](https://github.com/FRodrigoRuiz/proyecto-albumes/assets/93401989/79a83f41-4e3d-4c73-b9b5-58b12074e1fc)
  - Copia la dirección URL del repositorio. 
  - ![2](https://github.com/FRodrigoRuiz/proyecto-albumes/assets/93401989/a53ccc4d-9d13-437d-8831-6264b156d388)
  - Abra Git Bash. Cambia el directorio de trabajo actual a la ubicación en donde quieres clonar el directorio. Escriba git clone y           pegue la dirección URL que ha copiado antes.![3](https://github.com/FRodrigoRuiz/proyecto-albumes/assets/93401989/4b7f02e9-e487-4684-b379-00388897842c)
  - Presione "Enter" para crear el clon local.
  - ![4](https://github.com/FRodrigoRuiz/proyecto-albumes/assets/93401989/3f4a97ce-f23d-420d-b343-28f320fbbf06)
  - Abra la carpeta del proyecto con Visual Studio Code
  - Abra la terminal presionando "Ctrl" + "ñ"
  - Ejecute el comando "dotnet run" para iniciar la aplicación

## ✔️ Tecnologías utilizadas
- ASP.NET Core MVC
- C#
- Entity Framework Core
- Razor
- Bootstrap
- JavaScript
- SQLite

