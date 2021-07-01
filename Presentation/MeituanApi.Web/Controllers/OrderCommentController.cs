using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MeituanApi.Data.External.Response;
using MeituanApi.Services.DataServices;
using MeituanApi.Services.MeiT;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeituanApi.Web.Controllers
{
    public class OrderCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMeiTConfigService _meiTConfigService;


        public OrderCommentController(IHttpClientFactory httpClientFactory,IMeiTConfigService meiTConfigService)
        {
            _httpClientFactory = httpClientFactory;
            _meiTConfigService = meiTConfigService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CommentInfo(string start,string end)
        {
            var shopUsers = MeiTShop.BindShopInfo(_httpClientFactory);
            var result = new List<RMeitCommentsModel>();
            if (shopUsers.data.Count > 0) 
            {
                var meiConifgs = _meiTConfigService.AllMetTShop();
                foreach (var shopUser in shopUsers.data)
                {
                    bool hasData = true;
                    int pageIndex = 0;
                    var nowData = new RMeitCommentsModel();
                    nowData.shopId = shopUser;
                    if (meiConifgs.FirstOrDefault(p => p.ShopId == shopUser) != null)
                    {
                        nowData.poiName = meiConifgs.FirstOrDefault(p => p.ShopId == shopUser).Name;
                        nowData.ZpName= meiConifgs.FirstOrDefault(p => p.ShopId == shopUser).Zp_ShopName;
                    }
                    else 
                    {
                        nowData.poiName = "";
                        nowData.ZpName = "";
                    }
                    while (hasData)
                    {
                        var comments = MeiTComment.QueryComment(_httpClientFactory, shopUser, start, end, pageIndex,20);
                        if (comments != null && comments.data.Count > 0) 
                        {
                            nowData.data.AddRange(comments.data);
                        }
                        if ((comments != null && comments.data.Count< 20) || comments == null)
                        {
                            hasData = false;
                        }
                        else
                        {
                            pageIndex = pageIndex + 20;
                        }
                    }
                    result.Add(nowData);
                }
            }
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}