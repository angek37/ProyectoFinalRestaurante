# Proyecto Final App Restaurante

## Integrantes
- Mayra Monserrat Gaspar Venegas
- Karla Del Rocío Reyes Ramírez
- Miguel Ángel Rodríguez González

En esta practica realizaremos una aplicación que realice un cuestionario de retroalimentación de un curso determinado de su elección, una vez que el usuario conteste el cuestionario presionara el botón de enviar y la aplicación registrará la respuesta en un servicio web montado sobre Heroku. Queremos que sea creativo acerca de cómo lograr esto. Depende de usted de qué se tratarán las preguntas de la prueba y cómo desea presentarlas a su usuario. (Según la rúbrica, requerimos un mínimo de 8 preguntas y un máximo de 15 preguntas de prueba para la presentación correcta de la aplicación).

## Desarrollo
Para completar este proyecto, deberá diseñar un diseño de cuestionario e implementarlo en una aplicación. El cuestionario puede ser sobre cualquier tema de su elección, y se le anima a crear uno sobre un tema que le parezca personalmente interesante. Querrá construir este proyecto en pasos.

1.  Primero, construye el diseño. Esto implica crear las preguntas del cuestionario, decidir qué tipo de prueba serán y formatearlas en el archivo de diseño xml para su actividad.
2.  En segundo lugar, querrá escribir un código que vincule el diseño a la actividad. Para el paso 3, querrá variables que se refieran a cada una de las respuestas al cuestionario.
3.  Finalmente, escribe el código para el botón que envie tus respuestas. Este código debe ejecutarse a través de cada pregunta en la aplicación, registrar la respuesta del usuario en el API Rest y luego mostrar los resultados del cuestionario en una app web que consulte el API. Su proyecto será evaluado utilizando la rúbrica del proyecto.

### API Endpoints
| Endpoint | Method |
|--|--|
| https://restaurante-apps-moviles.herokuapp.com/api/pregunta | GET |
| https://restaurante-apps-moviles.herokuapp.com/api/pregunta | POST |
| https://restaurante-apps-moviles.herokuapp.com/api/pregunta | PUT |
| https://restaurante-apps-moviles.herokuapp.com/api/pregunta | DELETE |
| https://restaurante-apps-moviles.herokuapp.com/api/respuesta | GET |


![Heroku](https://res.cloudinary.com/hy4kyit2a/image/upload/heroku-products.png)

## Resultados
#### Vista principal

![Vista Principal](https://image.ibb.co/khSDDV/bienvenido.jpg)

#### Menu Principal

![Menu](https://image.ibb.co/gZKofA/menu.jpg)

#### Funcionalidad Extra

![Funcionalidad Extra](https://image.ibb.co/cyLWiV/funcionalidadextra1.jpg)
![Funcionalidad Extra](https://image.ibb.co/cgSYxq/funcionalidadextra.jpg)

#### Cuestionario de la Aplicación
 
![Formulario](https://image.ibb.co/cVmAcq/formulario.jpg)

![Formlario Relleno](https://image.ibb.co/eUzwHq/formulatio1.jpg)

#### Cuestionario posición horizontal

![Formulario Horizontal](https://preview.ibb.co/mwBMiV/horizontal1.jpg)
## Aplicación Web Cliente
Las respuestas a las preguntas se envían a la API Rest por un endpoint POST las cuales pueden ser consultadas desde una aplicación web cliente que se preparo con el framework Angular, la cual está alojada en Firebase, en la siguiente dirección:
[Aplicación Web Cliente](https://restaurante-686b0.firebaseapp.com/#/respuestas)

![APP Web Client](https://i.ibb.co/kMjcKhn/Untitled.png)

## Software Libre
- ASP.NET Core
- PostgreSQL
- Angular
![enter image description here](https://malcoded.com/v1/api/asset/angular-asp-core.jpg)![enter image description here](http://www.postgresqltutorial.com/wp-content/uploads/2012/08/What-is-PostgreSQL.png)
