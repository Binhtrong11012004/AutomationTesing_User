using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models.ViewModel;
using BanDongHo.Models.Models;
using BanDongHo.Models.Service;
using BanDongHo.Common;
using BanDongHo.Domain.DataContext;

namespace BanDongHo.Controllers
{
    
    public class CusInfoController : Controller
    {
        BANDONGHOEntities pay=new BANDONGHOEntities();  
  
        // GET: CusInfo
        [HttpGet]
        public ActionResult Index()
        {
            var userSession = (UserLogin)Session[CommonConstands.USER_SESSION];
            if (userSession == null)
            {
                return Redirect("dang-nhap");
            }
            else
            {
                CusInfoViewModel cus = new CusInfoViewModel();
                if (Session["Cart"] == null)
                {
                    Session["Cart"] = new Cart();
                }
                cus.cart = Session["Cart"] as Cart;
                return View(cus);
            }
            
        }
        [HttpPost]
        public ActionResult Index(CusInfoViewModel model)
        {
            // kiểm tra danh sách sản phẩm về số lượng
            bool isCheck = true;
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            model.cart = Session["Cart"] as Cart;
            foreach (var item in model.cart.GetList())
            {
                if(!CusInfoService.CheckNumberProduct(item.Product.MASP,item.Quantity))
                {
                    isCheck = false;
                    break;
                }
            }
            if(!isCheck)
            {
                return RedirectToAction("Index","Cart");
            }
            //lấy Id Khách hàng
            int Id = 1;// mã khách hàng là khách
            if(Session[CommonConstands.USER_SESSION]!=null)
            {
                long MaTK = (Session[CommonConstands.USER_SESSION] as UserLogin).UserID;
                Id = CusInfoService.GetIdCustomer(MaTK);
            }
            // Thêm đơn hàng
            CusInfoService.AddBill(model,Id);
            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            Session["Cart"] = null;
            return View();
        }

    }
}