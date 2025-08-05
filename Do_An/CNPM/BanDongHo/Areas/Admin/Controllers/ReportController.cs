using BanDongHo.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        // GET: Admin/Report
        private readonly SalesService _salesService;

        public ReportController(SalesService salesService)
        {
            _salesService = salesService;
        }

        // Action để hiển thị báo cáo doanh thu theo tháng
        public ActionResult RevenueByMonth(int year)
        {
            var monthlyRevenue = _salesService.GetMonthlyRevenue(year);
            ViewBag.MonthlyRevenue = monthlyRevenue;

            return View();
        }
    }
}