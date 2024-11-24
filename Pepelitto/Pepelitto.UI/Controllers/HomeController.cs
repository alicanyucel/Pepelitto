using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pepelitto.Domain.Entities;
using Pepelitto.UI.Models;
using System.Diagnostics;
using System.Text;

namespace Pepelitto.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // API'ye g�nderilecek veri (�rnek: bir model veya parametre)
            var requestData = new { ExampleProperty = "value" }; // Buraya uygun veri modelini yaz�n.

            // JSON format�nda veri i�eri�i olu�turuluyor
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            try
            {
                // API'ye POST iste�i g�nderme
                var response = await _httpClient.PostAsync("http://localhost:5193/api/Users/GetAll", content);

                // API'den d�nen yan�t ba�ar�l�ysa i�lemi devam ettir
                response.EnsureSuccessStatusCode();

                // API'den gelen yan�t� string olarak al
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Yan�t� konsola yazd�rarak kontrol edelim
                Console.WriteLine(jsonResponse); // Yan�t�n ne �ekilde oldu�unu g�rmek i�in

                // Yan�t� deserialize et
                var responseObject = JsonConvert.DeserializeObject<AppUser>(jsonResponse);

                // Veriyi ViewData ile g�nder
                ViewData["Products"] = responseObject; // E�er null ise bo� bir dizi g�nder

                return View();
            }
            catch (JsonSerializationException ex)
            {
                // Deserialize s�ras�nda hata olu�ursa, hatay� logla ve kullan�c�ya bildirim g�nder
                _logger.LogError(ex, "JSON deserialize hatas� olu�tu.");

                // Hata durumunda bo� bir �r�n listesi g�nderelim
                ViewData["Products"] = new string[0];

                return View();
            }
            catch (Exception ex)
            {
                // Di�er hatalar� yakala
                _logger.LogError(ex, "Bir hata olu�tu.");

                // Hata durumunda bo� bir �r�n listesi g�nderelim
                ViewData["Products"] = new string[0];

                return View();
            }
        }
    }

   

}