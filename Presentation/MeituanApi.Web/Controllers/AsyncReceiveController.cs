﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MeituanApi.Core;
using MeituanApi.Core.Helper;
using MeituanApi.Data.DataBase;
using MeituanApi.Data.External.Receive;
using MeituanApi.Services.DataServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeituanApi.Web.Controllers
{
    public class AsyncReceiveController : Controller
    {
        private readonly IMeiTOrderInfoService _meiTOrderInfoService;
        private readonly IMeiTOrderProductService _meiTOrderProductService;
        private readonly IMeiTOrderLogService _meiTOrderLogService;
        private readonly IOrderToZpService _orderToZpService;
        private readonly IMeiTOrderCancelService _orderCancelService;


        public AsyncReceiveController(IMeiTOrderInfoService meiTOrderInfoService
        ,IMeiTOrderProductService meiTOrderProductService
        ,IMeiTOrderLogService meiTOrderLogService
        ,IOrderToZpService orderToZpService
        ,IMeiTOrderCancelService orderCancelService)
        {
            _meiTOrderInfoService = meiTOrderInfoService;
            _meiTOrderProductService = meiTOrderProductService;
            _meiTOrderLogService = meiTOrderLogService;
            _orderToZpService = orderToZpService;
            _orderCancelService = orderCancelService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderNotify()
        {
            return Content("200");
        }

        [HttpPost]
        public IActionResult OrderNotify(OrderPayed model)
        {
            if (model == null || model.order_id == 0)
            {
                return Content("{\"data\":\"model not find\"}");
            }

            //model.detail = WebUtility.UrlDecode(model.detail);
            ////构建日志参数
            //var meiTOrderLog=new MeiTOrderLog
            //{
            //    OrderId = model.order_id,
            //    OrderContext = WebUtility.UrlDecode(JsonConvert.SerializeObject(model)),
            //    CreateTime = DateTime.Now
            //};
            //_meiTOrderLogService.Add(meiTOrderLog);
            //var orderInfoExist = _meiTOrderInfoService.GetMeiTOrderInfo(model.order_id);
            ////防止美团的重复推送
            //if (orderInfoExist == null)
            //{
            //    //将订单存储在数据库
            //    var orderInfo = new MeiTOrderInfo
            //    {
            //        ShopId = model.app_poi_code,
            //        ShopName = WebUtility.UrlDecode(model.wm_poi_name),
            //        OrderId = model.order_id,
            //        Consignee = WebUtility.UrlDecode(model.recipient_name),
            //        Phone = model.recipient_phone,
            //        Address = WebUtility.UrlDecode(model.recipient_address),
            //        DeliverFee = model.shipping_fee,
            //        Income = model.total,
            //        OriginalPrice = model.original_price,
            //        DaySeq = model.day_seq.ToString(),
            //        PackageBagMoney = model.package_bag_money,
            //        DinnersNumber = model.dinners_number,
            //        TotalPrice = model.original_price-model.shipping_fee
            //    };

            //    if (model.delivery_time != 0)
            //    {
            //        orderInfo.DeliverTime = CommonHelper.GenericTimeStamp(model.delivery_time);
            //    }
            //    orderInfo.Description = WebUtility.UrlDecode(model.caution);
            //    //orderInfo.Status = model.status;
            //    orderInfo.Status = 2;
            //    orderInfo.CreatedAt = CommonHelper.GenericTimeStamp(model.ctime);
            //    _meiTOrderInfoService.Add(orderInfo);

            //    var products = JsonConvert.DeserializeObject<List<OrderProduct>>(model.detail);

            //    if (products != null && products.Count > 0)
            //    {
            //        foreach (var orderProduct in products)
            //        {
            //            var mtProduct = new MeiTOrderProduct
            //            {
            //                OrderId = model.order_id,
            //                ProductId = orderProduct.app_food_code,
            //                Price = orderProduct.price,
            //                Quantity = orderProduct.quantity,
            //                Total = orderProduct.price * orderProduct.quantity,
            //                Attributes = orderProduct.unit,
            //                NewSpecs = orderProduct.spec,
            //                ProductName = orderProduct.food_name,
            //                //ShopPrice = orderProduct.price,
            //                BoxNum = orderProduct.box_num,
            //                BoxPrice = orderProduct.box_price,
            //                CartId = orderProduct.cart_id,
            //                FoodProperty = orderProduct.food_property
            //            };
            //            _meiTOrderProductService.Add(mtProduct);
            //        }
            //    }

            //}
            return Content("{\"data\":\"ok\"}");
        }

        [HttpGet]
        public IActionResult OrderConfirm()
        {
            return Content("200");
        }


        [HttpPost]
        public IActionResult OrderConfirm(OrderPayed model)
        {
            if (model == null || model.order_id == 0)
            {
                return Content("{\"data\":\"model not find\"}");
            }

            model.detail = WebUtility.UrlDecode(model.detail);
            model.poi_receive_detail = WebUtility.UrlDecode(model.poi_receive_detail);
            model.extras = WebUtility.UrlDecode(model.extras);
            //构建日志参数
            var meiTOrderLog = new MeiTOrderLog
            {
                OrderId = model.order_id,
                OrderContext = WebUtility.UrlDecode(JsonConvert.SerializeObject(model)),
                OrderPoiReceiveDetail = model.poi_receive_detail,
                OrderExtras = "",
                CreateTime = DateTime.Now
            };
            _meiTOrderLogService.Add(meiTOrderLog);
            var orderInfoExist = _meiTOrderInfoService.GetMeiTOrderInfo(model.order_id);
            //防止美团的重复推送
            if (orderInfoExist == null)
            {
                //将订单存储在数据库
                var orderInfo = new MeiTOrderInfo
                {
                    ShopId = model.app_poi_code,
                    ShopName = WebUtility.UrlDecode(model.wm_poi_name),
                    OrderId = model.order_id,
                    Consignee = WebUtility.UrlDecode(model.recipient_name),
                    Phone = model.recipient_phone,
                    Address = WebUtility.UrlDecode(model.recipient_address),
                    DeliverFee = model.shipping_fee,
                    Income = model.total,
                    OriginalPrice = model.original_price,
                    DaySeq = model.day_seq.ToString(),
                    PackageBagMoney = model.package_bag_money,
                    DinnersNumber = model.dinners_number,
                    TotalPrice = model.original_price - model.shipping_fee,
                    CreateTime = DateTime.Now
                };
                //获取商家实收
                var shopReceive = JsonConvert.DeserializeObject<PoiReceivedDetail>(model.poi_receive_detail);
                orderInfo.WmPoiReceive = Math.Round((decimal)shopReceive.wmPoiReceiveCent / 100, 2);
                if (orderInfo.DinnersNumber>10||orderInfo.DinnersNumber==0)
                {
                    orderInfo.DinnersNumber = 1;
                }

                if (model.delivery_time != 0)
                {
                    orderInfo.DeliverTime = CommonHelper.GenericTimeStamp(model.delivery_time);
                }
                orderInfo.Description = WebUtility.UrlDecode(model.caution);
                orderInfo.Status = 2;
                orderInfo.CreatedAt = CommonHelper.GenericTimeStamp(model.ctime);
                _meiTOrderInfoService.Add(orderInfo);

                var products = JsonConvert.DeserializeObject<List<OrderProduct>>(model.detail);

                if (products != null && products.Count > 0)
                {
                    foreach (var orderProduct in products)
                    {
                        var mtProduct = new MeiTOrderProduct
                        {
                            OrderId = model.order_id,
                            ProductId = orderProduct.app_food_code,
                            Price = orderProduct.price,
                            Quantity = orderProduct.quantity,
                            Total = orderProduct.price * orderProduct.quantity,
                            Attributes = orderProduct.unit,
                            NewSpecs = orderProduct.spec,
                            ProductName = orderProduct.food_name,
                            //ShopPrice = orderProduct.price,
                            BoxNum = orderProduct.box_num,
                            BoxPrice = orderProduct.box_price,
                            CartId = orderProduct.cart_id,
                            FoodProperty = orderProduct.food_property
                        };
                        _meiTOrderProductService.Add(mtProduct);
                    }
                }

            }
            return Content("{\"data\":\"ok\"}");
        }


        [HttpPost]
        public IActionResult OrderConfirmTest(OrderPayed model)
        {
            if (model == null || model.order_id == 0)
            {
                return Content("{\"data\":\"model not find\"}");
            }

            model.detail = WebUtility.UrlDecode(model.detail);
            //构建日志参数
            var meiTOrderLog = new MeiTOrderLog
            {
                OrderId = model.order_id,
                OrderContext = "confrim_" + WebUtility.UrlDecode(JsonConvert.SerializeObject(model)),
                OrderPoiReceiveDetail = model.poi_receive_detail,
                OrderExtras = model.extras,
                CreateTime = DateTime.Now
            };
            _meiTOrderLogService.Add(meiTOrderLog);
            var orderInfoExist = _meiTOrderInfoService.GetMeiTOrderInfo(model.order_id);
            //防止美团的重复推送
            if (orderInfoExist == null)
            {
                //将订单存储在数据库
                var orderInfo = new MeiTOrderInfo
                {
                    ShopId = model.app_poi_code,
                    ShopName = WebUtility.UrlDecode(model.wm_poi_name),
                    OrderId = model.order_id,
                    Consignee = WebUtility.UrlDecode(model.recipient_name),
                    Phone = model.recipient_phone,
                    Address = WebUtility.UrlDecode(model.recipient_address),
                    DeliverFee = model.shipping_fee,
                    Income = model.total,
                    OriginalPrice = model.original_price,
                    DaySeq = model.day_seq.ToString(),
                    PackageBagMoney = model.package_bag_money,
                    DinnersNumber = model.dinners_number,
                    TotalPrice = model.original_price - model.shipping_fee,
                    CreateTime = DateTime.Now
                };
                //获取商家实收
                var shopReceive = JsonConvert.DeserializeObject<PoiReceivedDetail>(model.poi_receive_detail);
                orderInfo.WmPoiReceive = Math.Round((decimal)shopReceive.wmPoiReceiveCent / 100, 2);
                if (orderInfo.DinnersNumber > 10 || orderInfo.DinnersNumber == 0)
                {
                    orderInfo.DinnersNumber = 1;
                }

                if (model.delivery_time != 0)
                {
                    orderInfo.DeliverTime = CommonHelper.GenericTimeStamp(model.delivery_time);
                }

                orderInfo.Description = WebUtility.UrlDecode(model.caution);
                orderInfo.Status = 2;
                orderInfo.CreatedAt = CommonHelper.GenericTimeStamp(model.ctime);
                _meiTOrderInfoService.Add(orderInfo);

                var products = JsonConvert.DeserializeObject<List<OrderProduct>>(model.detail);

                if (products != null && products.Count > 0)
                {
                    foreach (var orderProduct in products)
                    {
                        var mtProduct = new MeiTOrderProduct
                        {
                            OrderId = model.order_id,
                            ProductId = orderProduct.app_food_code,
                            Price = orderProduct.price,
                            Quantity = orderProduct.quantity,
                            Total = orderProduct.price * orderProduct.quantity,
                            Attributes = orderProduct.unit,
                            NewSpecs = orderProduct.spec,
                            ProductName = orderProduct.food_name,
                            //ShopPrice = orderProduct.price,
                            BoxNum = orderProduct.box_num,
                            BoxPrice = orderProduct.box_price,
                            CartId = orderProduct.cart_id,
                            FoodProperty = orderProduct.food_property
                        };
                        _meiTOrderProductService.Add(mtProduct);
                    }
                }

            }

            return Content("{\"data\":\"ok\"}");
        }

        [HttpGet]
        public IActionResult OrderCancelNotify(OrderCanceled model)
        {
            if (string.IsNullOrEmpty(model.reason))
            {
                return Content("200");
            }
            else
            {
                var cancelModel = new MeiTOrderCancel
                {
                    OrderId = model.order_id,
                    Reason = model.reason,
                    ReasonCode = model.notify_type,
                    CreateTime = DateTime.Now
                };
                _orderCancelService.AddCancelRecord(cancelModel);
                return Content("{\"data\":\"ok\"}");
            }
        }

        [HttpPost]
        public IActionResult OrderCancelNotify()
        {
            return Content("{\"data\":\"ok\"}");
        }

    }
}