using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VCardMVC.Models;
using static System.Net.Mime.MediaTypeNames;

namespace VCardMVC.Controllers
{
    public class CardController : Controller
    {
        private readonly vcardContext _context;

        public CardController(vcardContext context)
        {
            _context = context;
        }
        //vcardContext _context = new vcardContext();

        public IActionResult Index()
        {
            return View(_context.VCards.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VCards == null)
            {
                return NotFound();
            }

            var vCard = await _context.VCards
                .FirstOrDefaultAsync(m => m.Id == id);

            var response = await CreateQRCode(vCard);

            ViewData["svg"] = response;

            if (vCard == null)
            {
                return NotFound();
            }

            return View(vCard);
        }

        public async Task<string> CreateQRCode(VCard vCard)
        {
            string obj = $"BEGIN:VCARD\nFN:{vCard.First} {vCard.Last}\ntel:{vCard.Phone}\nemail:{vCard.Email}\nEND:VCARD";

            HttpClient httpClient = new();

            var item = new
            {
                frame_name = "no-frame",
                qr_code_text = obj,
                image_format = "SVG",
                qr_code_logo = "scan-me-square"
            };

            var ItemJson = new StringContent(
                JsonSerializer.Serialize(item),
                Encoding.UTF8,
                Application.Json);

             using var httpResponseMessage =
             await httpClient.PostAsync("https://api.qr-code-generator.com/v1/create?access-token=3Ur3VZVriKvoMiXWnHVZm-MRoLgvVZBBdSghW85r0nSptA9mgoVRRqH0XR9dEhSu", ItemJson);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadAsStringAsync();
            }
            return null;

    }

    }
}
    

