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
            // API'ye gönderilecek veri (örnek: bir model veya parametre)
            var requestData = new { ExampleProperty = "value" }; // Buraya uygun veri modelini yazýn.

            // JSON formatýnda veri içeriði oluþturuluyor
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            try
            {
                // API'ye POST isteði gönderme
                var response = await _httpClient.PostAsync("http://localhost:5193/api/Users/GetAll", content);

                // API'den dönen yanýt baþarýlýysa iþlemi devam ettir
                response.EnsureSuccessStatusCode();

                // API'den gelen yanýtý string olarak al
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Yanýtý konsola yazdýrarak kontrol edelim
                Console.WriteLine(jsonResponse); // Yanýtýn ne þekilde olduðunu görmek için

                // Yanýtý deserialize et
                var responseObject = JsonConvert.DeserializeObject<AppUser>(jsonResponse);

                // Veriyi ViewData ile gönder
                ViewData["Products"] = responseObject; // Eðer null ise boþ bir dizi gönder

                return View();
            }
            catch (JsonSerializationException ex)
            {
                // Deserialize sýrasýnda hata oluþursa, hatayý logla ve kullanýcýya bildirim gönder
                _logger.LogError(ex, "JSON deserialize hatasý oluþtu.");

                // Hata durumunda boþ bir ürün listesi gönderelim
                ViewData["Products"] = new string[0];

                return View();
            }
            catch (Exception ex)
            {
                // Diðer hatalarý yakala
                _logger.LogError(ex, "Bir hata oluþtu.");

                // Hata durumunda boþ bir ürün listesi gönderelim
                ViewData["Products"] = new string[0];

                return View();
            }
        }
    }

   

}