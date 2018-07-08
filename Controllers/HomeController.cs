using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using RandomCode.Models;

namespace RandomCode.Controllers
{
    public class HomeController : Controller
    {
        public int counter = 1;

        public IActionResult Index()
        {
            ViewData["passcode"] = HttpContext.Session.GetString("passcode");
            return View();
        }

        [HttpPost("Generate")]
        public IActionResult Generate()
        {

            if (HttpContext.Session.GetInt32("Counter")==null)
            {
                HttpContext.Session.SetInt32("Counter", 0);
            }
            counter = (int)HttpContext.Session.GetInt32("Counter");
            counter++;
            HttpContext.Session.SetInt32("Counter", counter);
            int? IntVariable = HttpContext.Session.GetInt32("Counter");
            TempData["Counter"] = IntVariable;

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
                System.Console.WriteLine(stringChars[i]);
            }
            string passcode = new String(stringChars);
            HttpContext.Session.SetString("passcode", passcode);
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
