using Microsoft.AspNetCore.Mvc;
using System.Text;
using API.Models;
using Newtonsoft.Json;

namespace Ticket.Web.Controllers
{
	public class UsersController : Controller

	{

		private readonly string apiUrl = "http://localhost:5280/api/Users";

		public async Task<IActionResult> Index()

		{

			using (var httpClient = new HttpClient())

			{

				// Llamada a la API

				var response = await httpClient.GetAsync("http://localhost:5280/api/Users");

				if (response.IsSuccessStatusCode)

				{

					// Obtener el contenido JSON de la respuesta

					var jsonResponse = await response.Content.ReadAsStringAsync();

					// Deserializar el JSON en una lista de User

					var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

					// Validar que el modelo nunca sea nulo

					if (users == null)

					{

						users = new List<User>();

					}

					return View(users); // Enviar datos a la vista

				}

				else

				{

					// Manejo de error si la API no responde correctamente

					return View(new List<User>()); // Lista vacía en caso de error

				}

			}

		}

		public IActionResult Crear()

		{

			return View();

		}

		[HttpPost]

		public async Task<IActionResult> Crear(User user)

		{

			using (var httpClient = new HttpClient())

			{

				var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

				var response = await httpClient.PostAsync(apiUrl, content);

				if (response.IsSuccessStatusCode)

				{

					return RedirectToAction("Index");

				}

				return View(user); // Retorna a la vista si algo falla

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

					var user = JsonConvert.DeserializeObject<User>(jsonResponse);

					return View(user);

				}

				return RedirectToAction("Index"); // Redirige si algo falla

			}

		}

		[HttpPost]

		public async Task<IActionResult> Editar(User user)

		{

			using (var httpClient = new HttpClient())

			{

				var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

				var response = await httpClient.PutAsync($"{apiUrl}/{user.IdUser}", content);

				if (response.IsSuccessStatusCode)

				{

					return RedirectToAction("Index");

				}

				return View(user); // Retorna a la vista si algo falla

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
