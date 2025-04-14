using Microsoft.AspNetCore.Mvc;
using System.Text;
using API.Models;
using Newtonsoft.Json;

namespace Ticket.Web.Controllers
{
    public class OrganizersController : Controller

    {

        private readonly string apiUrl = "http://localhost:5280/api/Organizer";

        public async Task<IActionResult> Index()

        {

            using (var httpClient = new HttpClient())

            {

                // Llamada a la API

                var response = await httpClient.GetAsync("http://localhost:5280/api/Organizer");

                if (response.IsSuccessStatusCode)

                {

                    // Obtener el contenido JSON de la respuesta

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserializar el JSON en una lista de Organizer

                    var organizers = JsonConvert.DeserializeObject<List<Organizer>>(jsonResponse);

                    // Validar que el modelo nunca sea nulo

                    if (organizers == null)

                    {

                        organizers = new List<Organizer>();

                    }

                    return View(organizers); // Enviar datos a la vista

                }

                else

                {

                    // Manejo de error si la API no responde correctamente

                    return View(new List<Organizer>()); // Lista vacía en caso de error

                }

            }

        }

        public IActionResult Crear()

        {

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Crear(Organizer organizer)

        {

            using (var httpClient = new HttpClient())

            {

                var content = new StringContent(JsonConvert.SerializeObject(organizer), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)

                {

                    return RedirectToAction("Index");

                }

                return View(organizer); // Retorna a la vista si algo falla

            }

        }

        public async Task<IActionResult> Editar(int id)

        {

            using (var httpClient = new HttpClient())

            {

                var response = await httpClient.GetAsync($"{apiUrl}/{id}");

                if (response.IsSuccessStatusCode)

                {

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var organizer = JsonConvert.DeserializeObject<Organizer>(jsonResponse);

                    return View(organizer);

                }

                return RedirectToAction("Index"); // Redirige si algo falla

            }

        }

        [HttpPost]

        public async Task<IActionResult> Editar(Organizer organizer)

        {

            using (var httpClient = new HttpClient())

            {

                var content = new StringContent(JsonConvert.SerializeObject(organizer), Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"{apiUrl}/{organizer.IdOrganizer}", content);

                if (response.IsSuccessStatusCode)

                {

                    return RedirectToAction("Index");

                }

                return View(organizer); // Retorna a la vista si algo falla

            }

        }

        public async Task<IActionResult> Eliminar(int id)

        {

            using (var httpClient = new HttpClient())

            {

                var response = await httpClient.DeleteAsync($"{apiUrl}/{id}");

                if (response.IsSuccessStatusCode)

                {

                    return RedirectToAction("Index");

                }

                return RedirectToAction("Index"); // Redirige si algo falla

            }

        }



    }

}
