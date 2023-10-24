using System.Net;
using System.Text.Json;

namespace ApiSwa.Middlewares
{
    public class MisErrores
    {
        private readonly RequestDelegate _next;
        public MisErrores(RequestDelegate next) {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try {
                await _next(context);
            }catch (Exception ex)
            {
                //Objeto Modelo error
                var errorResponse = new
                {
                    message = ex.Message,
                    details = ex.StackTrace
                };

                //Convertir el objeto modelo a Json

                var json = JsonSerializer.Serialize(errorResponse);

                //Establecer el tipo de contenido de la respuesta como JSON
                context.Response.ContentType = "application/json";

                //Establecer el codigo de estado http como 400(bad request)
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //Escribir el Json en la respuesta
                await context.Response.WriteAsync(json);

            }
        }
    }
}
