using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Common;
using BanDongHo.Areas.Admin.Models;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel )
        {
            ViewBag.ErrorMessage = "";
            if (ModelState.IsValid)// kiểm tra giá trị hợp lệ hay không
            {
                LoginService loginService = new LoginService();
                var result = loginService.Login(loginViewModel.UserName, Encryptor.MD5Hash(loginViewModel.Password));
                if(result == 1)
                {
                    var user = loginService.GetUserByName(loginViewModel.UserName);//lấy thông tin
                    var userSession = new UserLogin();//tạo để lưu 
                    userSession.UserID = user.MATK;
                    userSession.UserName = user.TENDN;                   
                    Session.Add(CommonConstands.ADMIN_SESSION, userSession);//lưu
                    return Redirect("~/Admin/Product/Index");
                }else if(result == 0)
                {
                    ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                }else if(result == -1)
                {
                    ViewBag.ErrorMessage = "Tài khoản này không đủ quyền truy cập trang Admin";
                }else
                {
                    ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
               
            }
            return View(loginViewModel);
        }
    }
}