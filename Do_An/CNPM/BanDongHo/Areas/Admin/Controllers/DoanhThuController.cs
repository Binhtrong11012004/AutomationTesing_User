using BanDongHo.Areas.Admin.Models;
using BanDongHo.Domain.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class DoanhThuController : Controller
    {
        // GET: Admin/DoanhThu
        private readonly DoanhThuService _doanhThuService;

        public DoanhThuController()
        {
            var context = new BANDONGHOEntities(); // Tạo context hoặc lấy từ DI Container
            _doanhThuService = new DoanhThuService(context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDoanhThu(DateTime startDate, DateTime endDate)
        {
            var doanhThu = _doanhThuService.GetDoanhThu(startDate, endDate);
            var viewModel = new DoanhThuViewModel
            {
                DoanhThu = doanhThu
            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}