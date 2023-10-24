// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Infraestructura.Conexiones;
using Servicios.ContactosServices;

PersonaService personaService = new PersonaService("Server=localhost;" +"Port=5432; User Id=postgres; Password=root; Database=Apiper;");
personaService.insertarPersona(new Infraestructura.Modelos.PersonaModel
{
     nombre_persona = "Lucas",
     apellido_persona = "Espinola",
     direccion = "..",
     email= "...",
     celular = "...",
     edad = 20,
     fk_ciudad = 1

});
Console.WriteLine(personaService);

//var ciudad = ciudadService.obtenerCiudadPorId(4);
//Console.WriteLine($"Ciudad: {ciudad.nombre_ciudad}");
//ciudadService.eliminarCiudad(ciudad);
Console.WriteLine("...");
