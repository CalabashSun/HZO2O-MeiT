using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeituanApi.Services.MeiT;
using Microsoft.AspNetCore.Mvc;

namespace MeituanApi.Web.Controllers
{
    public class OrderCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public OrderCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CommentInfo()

        {
            var result = MeiTComment.QueryComment(_httpClientFactory);
            return Content(result);
        }
    }
}