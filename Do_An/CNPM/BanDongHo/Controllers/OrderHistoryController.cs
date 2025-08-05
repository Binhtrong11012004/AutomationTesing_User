using BanDongHo.Models.Service;
using BanDongHo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly OrderHistoryService _orderHistoryService;

        public OrderHistoryController()
        {
            _orderHistoryService = new OrderHistoryService();
        }

        // Action để hiển thị lịch sử đơn hàng
        public ActionResult OrderHistory()
        {
            int? customerId = Session["MAKH"] as int?;
            if (customerId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Customer ID is required");
            }

            List<OrderHistoryViewModel> orderHistory = _orderHistoryService.GetOrderHistoryByCustomerId(customerId.Value);
            return View(orderHistory);
        }
    }
}