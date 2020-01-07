using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CP.UI.VueWeb.Controllers
{
    public class SampleController : Controller
    {
        private static string[] Characters = new[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J","k"
        };

        public IActionResult Index()
        {
            return Json(Characters);
        }
    }
}