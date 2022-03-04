1.- Para correr el proyecto  se habre el archivo de PruebaTecnica.sln
2.- Se compila y corre el servidor WEBAPI
3.- Todos los metodos creados para la prueba son de EndPoints de una API
Nota- las ordenes si las divide segun su status - la prueba la realice muy noche y por cansancio no la termine pero quedo la gran mayoria.
-------------------------------------------------------

El archivo endPointsPOSTMAN.json es el archivo de importacion para POSTMAN que tiene todos los endpoints y con algunos datos
para trabajar con los EndPoints de la API.


Muchas gracias.


Por lo tarde que realice la prueba y cansancio no alcance a terminar.

--------------
Descripcion de la organizacion que se utilizo
-----------
El proyecto esta hecho en .NET 5(Core).
-Se creo un proyecto MVC pero los controladores fueron realizados con el formato de API
-Se creo otro proyecto que se llama Service. donde basicamente se crearon modelos bases para realizar la prueba
-Dentro de Service vienen 2 clases de servicios que en teoria son funciones reutilizables y debido a la naturaleza del proyecto de Service
se puede exportar la DLL para otro proyecto o solucion.
-Se creo una clase AppCache que basicamente lo que hace es guardar Instancias Singleton del Stock, Products y Orders para el ciclo de vida del
programa que es basicamente un Cache Interno para guardar objetos de los tipos antes mencionados.

-La api consume principalmente los Metodos de Service y service le devuelve enteros segun sea la respuesta de exito
0 = Exitoso
1  = Fallo
(Salvo una ocasion que regreso un string para usarlo como mensaje).

-En la api se definen tambien modelos request para las peticiones que se realicen que despues se traducen a modelos para los metodos de service.
-Se crearon 2 controladores uno para productos y otro para ordenes.
-Se creo un solo controlador de angularJS para poder hacer la parte del Front que fue concluida. 
- y para el diseño de componentes se uso bootstrap 4.