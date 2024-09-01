var builder = WebApplication.CreateBuilder(args);   // Este m�todo crea una instancia de WebApplicationBuilder, que es responsable de configurar y crear la aplicaci�n ASP.NET Core. args es un par�metro que permite pasar argumentos de la l�nea de comandos a la aplicaci�n, aunque no siempre es necesario usarlos.


// Add services to the container.
builder.Services.AddControllers(); //Este m�todo agrega los servicios necesarios para que los controladores funcionen en la aplicaci�n. Los controladores son clases que manejan las solicitudes HTTP entrantes, procesan la l�gica del negocio y devuelven respuestas HTTP. En ASP.NET Core, al agregar este servicio, se habilitan las funcionalidades de un controlador MVC tradicional.

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();  // Este m�todo agrega un servicio que ayuda a explorar y documentar los endpoints de la API. Aunque es opcional, es com�nmente utilizado junto con Swagger para generar documentaci�n autom�tica de API.
builder.Services.AddSwaggerGen();   //Este m�todo agrega los servicios necesarios para generar la interfaz de usuario de Swagger y la documentaci�n OpenAPI de tu API. Swagger es una herramienta popular para crear documentaci�n interactiva para APIs RESTful. Permite a los desarrolladores ver y probar los endpoints de la API directamente en el navegador.

var app = builder.Build();  //Este m�todo construye la aplicaci�n web con todas las configuraciones y servicios que se han agregado al builder. Una vez que se llama a este m�todo, se obtiene una instancia de WebApplication que representa la aplicaci�n configurada y lista para ejecutarse.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   //Si la aplicaci�n est� en modo de desarrollo, este middleware habilita Swagger para generar el documento OpenAPI de la API en formato JSON. Esto es necesario para que Swagger UI pueda visualizar y probar los endpoints de la API.
    app.UseSwaggerUI(); //Este middleware activa la interfaz de usuario de Swagger (Swagger UI). Swagger UI es una interfaz basada en el navegador que permite a los desarrolladores explorar y probar los endpoints de la API documentados por Swagger.
}

app.UseHttpsRedirection();  //Este middleware redirige autom�ticamente las solicitudes HTTP a HTTPS, asegurando que todas las comunicaciones se realicen de manera segura utilizando el protocolo HTTPS.

//app.UseAuthorization();   //Este middleware habilitar�a la autorizaci�n para la aplicaci�n, asegur�ndose de que solo los usuarios autenticados y autorizados puedan acceder a ciertos recursos o endpoints. En el c�digo proporcionado, esta l�nea est� comentada, lo que significa que la autorizaci�n no est� habilitada actualmente.

app.MapControllers(); // Este m�todo mapea los endpoints definidos en los controladores a las rutas HTTP correspondientes. Esencialmente, le dice a la aplicaci�n que utilice las rutas y los m�todos HTTP definidos en las clases de controlador para manejar las solicitudes entrantes.

app.Run();
