using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeituanApi.Data.External.Submit;
using MeituanApi.Data.MeiT;
using Microsoft.AspNetCore.Mvc;
using MeituanApi.Web.Models;

namespace MeituanApi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        //public IActionResult Index()
        //{
        //    return Ok();
        //}

        public IActionResult ShopBinding()
        {
            var shopSave = new SShopSave
            {
                app_poi_code = "469911",
                name = "麻辣盛艳(南京同曦万尚城店)",
                address = "南京市江宁区双龙大道1351号万尚城负1层",
                latitude = 31.942698,
                longitude = 118.821965,
                phone = "18115158980",
                shipping_fee = 5,
                shipping_time = "10:30-21:00",
                open_level = 1,
                is_online = 1,
                third_tag_name = "快餐简餐"
            };

            var result = MeiTProduct.ShopSave(_httpClientFactory, shopSave);
            return Content(result);

        }

        [Route("Home/Error/{statusCode}")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
