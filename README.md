# Sistema de Tutorías - README

¡Bienvenido al proyecto de Sistema de Tutorías de Cesar Gonzalez Lopez! Este repositorio contiene la documentación y el código fuente de un sistema desarrollado como parte de la materia de Tecnologías para la Construcción de Software en la carrera de Ingeniería de Software de la Universidad Veracruzana.

## Descripción del proyecto

El Sistema de Tutorías es una aplicación diseñada para automatizar el proceso de desarrollo de tutorías, abordando tres aspectos principales: académicos, jefes de carrera y coordinador de tutorías. El objetivo es proporcionar una plataforma en línea que facilite la gestión eficiente de las tutorías, permitiendo a los diferentes roles involucrados realizar tareas específicas.

### Funcionalidades

El sistema ofrece las siguientes funcionalidades:

- **Académicos**:
  - Registrar la asistencia de los tutorados.
  - Registrar las problemáticas que presenten los tutorados durante las tutorías.
  - Realizar comentarios generales sobre las sesiones de tutoría.

- **Jefes de carrera**:
  - Visualizar las problemáticas identificadas en las tutorías.
  - Crear soluciones para las problemáticas identificadas.

- **Coordinador de tutorías**:
  - Registrar tutores y alumnos en el sistema.
  - Asignar alumnos a tutores.

## Detalles del proyecto

- Nombre: Sistema de Tutorías
- Desarrollador: Cesar Gonzalez Lopez
- Carrera: Ingeniería de Software
- Universidad: Universidad Veracruzana

## Estructura del repositorio

El repositorio está organizado de la siguiente manera:

- **[\`/TecnologiasProyect\`](/TecnologiasProyect)**: Contiene el servicio WCF (Windows Communication Foundation) que sirve como backend del sistema.
- **[\`/SQLServer-BD\`](/SQLServer-BD)**: Contiene la base de datos, dividida en estructura y datos, para el sistema.
- **[\`/FrontTecnologiasProyect\`](/FrontTecnologiasProyect)**: Contiene la aplicación WPF (Windows Presentation Foundation) que sirve como frontend del sistema.

Haz clic en los enlaces para acceder a cada carpeta en la estructura del repositorio.

## Requisitos del sistema

Antes de comenzar a utilizar el Sistema de Tutorías, asegúrate de tener los siguientes requisitos en tu entorno de desarrollo:

- Microsoft .NET Framework 4.5 o superior
- Microsoft Visual Studio (para compilar y ejecutar el servicio WCF y la aplicación WPF)
- SQL Server (para la base de datos)

## Guía de instalación

Sigue estos pasos para instalar y configurar el Sistema de Tutorías en tu entorno local:

1. Clona este repositorio en tu máquina local: \`git clone https://github.com/DracoGilga/Solution-TecnologiasProyect.git\`
2. Abre el proyecto del servicio WCF en Microsoft Visual Studio y compílalo.
3. Configura la conexión a la base de datos en el servicio WCF.
4. Ejecuta el servicio WCF.
5. Abre el proyecto de la aplicación WPF en Microsoft Visual Studio y compílalo.
6. Configura la conexión al servicio WCF en la aplicación WPF.
7. Ejecuta la aplicación WPF.

Una vez completados estos pasos, podrás utilizar el Sistema de Tutorías a través de la aplicación.
