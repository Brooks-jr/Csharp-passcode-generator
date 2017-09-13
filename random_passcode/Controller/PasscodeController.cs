
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandomPasscode.Controllers
{
    public class PasscodeController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();
            int? countVar = HttpContext.Session.GetInt32("countVar");
            if (countVar == null)
            {
                countVar = 0;
            }
            countVar += 1;
// --------------------------------------------------------------------------------
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];

            }
// ----------------------------------------------------------------------------------
            var finalString = new String(stringChars);
            ViewBag.finalString = finalString;
            ViewBag.count = countVar;
            HttpContext.Session.SetInt32("countVar", (int)countVar);
            return View();


        }

    }
}