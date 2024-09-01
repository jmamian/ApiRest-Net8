var builder = WebApplication.CreateBuilder(args);   // Este método crea una instancia de WebApplicationBuilder, que es responsable de configurar y crear la aplicación ASP.NET Core. args es un parámetro que permite pasar argumentos de la línea de comandos a la aplicación, aunque no siempre es necesario usarlos.


// Add services to the container.
builder.Services.AddControllers(); //Este método agrega los servicios necesarios para que los controladores funcionen en la aplicación. Los controladores son clases que manejan las solicitudes HTTP entrantes, procesan la lógica del negocio y devuelven respuestas HTTP. En ASP.NET Core, al agregar este servicio, se habilitan las funcionalidades de un controlador MVC tradicional.

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();  // Este método agrega un servicio que ayuda a explorar y documentar los endpoints de la API. Aunque es opcional, es comúnmente utilizado junto con Swagger para generar documentación automática de API.
builder.Services.AddSwaggerGen();   //Este método agrega los servicios necesarios para generar la interfaz de usuario de Swagger y la documentación OpenAPI de tu API. Swagger es una herramienta popular para crear documentación interactiva para APIs RESTful. Permite a los desarrolladores ver y probar los endpoints de la API directamente en el navegador.

var app = builder.Build();  //Este método construye la aplicación web con todas las configuraciones y servicios que se han agregado al builder. Una vez que se llama a este método, se obtiene una instancia de WebApplication que representa la aplicación configurada y lista para ejecutarse.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   //Si la aplicación está en modo de desarrollo, este middleware habilita Swagger para generar el documento OpenAPI de la API en formato JSON. Esto es necesario para que Swagger UI pueda visualizar y probar los endpoints de la API.
    app.UseSwaggerUI(); //Este middleware activa la interfaz de usuario de Swagger (Swagger UI). Swagger UI es una interfaz basada en el navegador que permite a los desarrolladores explorar y probar los endpoints de la API documentados por Swagger.
}

app.UseHttpsRedirection();  //Este middleware redirige automáticamente las solicitudes HTTP a HTTPS, asegurando que todas las comunicaciones se realicen de manera segura utilizando el protocolo HTTPS.

//app.UseAuthorization();   //Este middleware habilitaría la autorización para la aplicación, asegurándose de que solo los usuarios autenticados y autorizados puedan acceder a ciertos recursos o endpoints. En el código proporcionado, esta línea está comentada, lo que significa que la autorización no está habilitada actualmente.

app.MapControllers(); // Este método mapea los endpoints definidos en los controladores a las rutas HTTP correspondientes. Esencialmente, le dice a la aplicación que utilice las rutas y los métodos HTTP definidos en las clases de controlador para manejar las solicitudes entrantes.

app.Run();
