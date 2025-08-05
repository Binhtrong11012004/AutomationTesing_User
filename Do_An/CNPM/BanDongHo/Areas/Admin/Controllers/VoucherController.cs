using BanDongHo.Areas.Admin.Models;
using BanDongHo.Common;
using BanDongHo.Domain.DataContext;
using BanDongHo.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class VoucherController : Controller
    {
        VoucherService voucherService = new VoucherService();


        // GET: Admin/Voucher
        [HttpGet]
        public ActionResult Index()
        {
            var userSession = (UserLogin)Session[CommonConstands.ADMIN_SESSION];
            if (userSession == null)
            {
                return Redirect("~/Admin/Login/Login");
            }

            return View(voucherService.getAllVoucher());
        }

        // GET: Admin/Voucher/Create
        [HttpGet]
        public ActionResult Create()
        {
            VoucherViewModel voucherViewModel = new VoucherViewModel();
            voucherViewModel.MAVC = newMAVC(voucherService.getLastRecord());
            return View(voucherViewModel);
        }

        // POST: Admin/Voucher/Create
        [HttpPost]
        public ActionResult Create(VoucherViewModel vc)
        {
            ViewBag.message = "";
            if (ModelState.IsValid)
            {
                VOUCHER voucher = new VOUCHER();
                voucher.MAVC = vc.MAVC;
                voucher.TENVC = vc.TENVC;

                if (voucherService.addVoucher(voucher))
                {
                    ViewBag.message = "Thêm mới voucher thành công";
                    vc = new VoucherViewModel();
                    vc.MAVC = newMAVC(voucherService.getLastRecord());
                    return View(vc);
                }
                else
                {
                    ViewBag.message = "Thêm mới voucher thất bại";
                }
            }
            return View(vc);
        }

        [HttpGet]
        public ActionResult Update(string mavc)
        {
            VoucherViewModel voucherViewModel = new VoucherViewModel();
            var res = voucherService.getVoucherById(mavc);
            voucherViewModel.MAVC = res.MAVC;
            voucherViewModel.TENVC = res.TENVC;
            return View(voucherViewModel);
        }

        [HttpPost]
        public ActionResult Update(VoucherViewModel vc)
        {
            if (ModelState.IsValid)
            {
                VOUCHER voucher = new VOUCHER();
                voucher.MAVC = vc.MAVC;
                voucher.TENVC = vc.TENVC;

                if (voucherService.updateVoucher(voucher))
                {
                    return RedirectToAction("Index", "Voucher", voucherService.getAllVoucher());
                }

            }
            return View(vc);
        }

        // GET: Admin/Voucher/Delete/5
        public ActionResult Delete(string mavc)
        {
            return Json(new { result = voucherService.deleteVoucher(mavc) });
        }

        public string newMAVC(string lastVOUCHER)
        {
            string res = "VC00001";
            if (String.Compare(lastVOUCHER, "", false) != 0)
            {
                int tam = Int32.Parse(lastVOUCHER.Substring(2)) + 1;
                string rs = tam.ToString();
                while (rs.Length < 5)
                {
                    rs = "0" + rs;
                }

                res = "VC" + rs;

            }
            return res;
        }
    }
}
