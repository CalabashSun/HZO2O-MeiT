using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeituanApi.Web.Controllers
{
    public class OrderInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}