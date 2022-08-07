using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var baseUrl = $"{this.Request.Scheme}://{this.Request.Host.Value.ToString()}{this.Request.PathBase.Value.ToString()}";
            ViewData["baseUrl"] = baseUrl;

            return View();
        }
       

    }
}
