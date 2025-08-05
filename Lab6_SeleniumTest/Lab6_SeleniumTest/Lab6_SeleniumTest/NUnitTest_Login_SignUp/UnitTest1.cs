using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace NUnitTest_Login_SignUp
{
    public class Tests
    {
        private IWebDriver driver;
        private string LoginURL = "http://localhost:8838/dang-nhap";
        private string AdminLoginURL = "http://localhost:8838/Admin/Login/Login";
        private string SignUpURL = "http://localhost:8838/dang-ky";
        private readonly string tenDangNhapHopLe = "binhtrong1101";
        private readonly string matKhauHopLe = "11012004";

        [SetUp]
        public void KhoiTao()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void KiemTraDangKyKhiChiDienHo()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement hoField = wait.Until(drv => drv.FindElement(By.Name("FirstName")));
                hoField.SendKeys("Nguyen");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền họ phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field họ: {ex.Message}");
            }
        }

        [Test]
        public void KiemTraDangKyKhiChiDienTen()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement tenField = wait.Until(drv => drv.FindElement(By.Name("LastName")));
                tenField.SendKeys("Binh Trong");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền tên phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field tên: {ex.Message}");
            }
        }

        [Test]
        public void KiemTraDangKyKhiChiDienDiaChi()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement diaChiField = wait.Until(drv => drv.FindElement(By.Name("Address")));
                diaChiField.SendKeys("9 Le Trong Tan");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền địa chỉ phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field địa chỉ: {ex.Message}");
            }
        }

        [Test]
        public void KiemTraDangKyKhiChiDienEmail()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement emailField = wait.Until(drv => drv.FindElement(By.Name("Email")));
                emailField.SendKeys("hoaheo1101@gmail.com");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền email phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field email: {ex.Message}");
            }
        }

        [Test]
        public void KiemTraDangKyKhiChiDienSoDienThoai()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement sdtField = wait.Until(drv => drv.FindElement(By.Name("Phone")));
                sdtField.SendKeys("0794857510");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền số điện thoại phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field số điện thoại: {ex.Message}");
            }
        }


        [Test]
        public void KiemTraDangKyKhiChiChonGioiTinh()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement gioiTinhNam = wait.Until(drv => drv.FindElement(By.CssSelector("input[name='Sex'][value='Nam']")));
                gioiTinhNam.Click();

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ chọn giới tính phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field giới tính: {ex.Message}");
            }
        }

        [Test]
        public void KiemTraDangKyKhiChiDienTenTaiKhoan()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement usernameField = wait.Until(drv => drv.FindElement(By.Name("Account")));
                usernameField.SendKeys("binhtrong1101");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền tên tài khoản phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field tên tài khoản: {ex.Message}");
            }
        }

        [Test]
        public void KiemTraDangKyKhiChiDienMatKhau()
        {
            driver.Navigate().GoToUrl(SignUpURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement passwordField = wait.Until(drv => drv.FindElement(By.Id("inPassWord")));
                passwordField.SendKeys("11012004");

                IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));
                nutDangKy.Click();
                System.Threading.Thread.Sleep(3000);

                Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                             driver.Url.Contains("dang-ky"), "Đăng ký chỉ điền mật khẩu phải hiển thị lỗi");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Không thể tìm thấy field mật khẩu: {ex.Message}");
            }
        }
        [Test]
        public void KiemTraDangKyMatKhauKhongKhop()
        {
            driver.Navigate().GoToUrl(SignUpURL);

            IWebElement oNhapHo = driver.FindElement(By.Name("FirstName"));
            IWebElement oNhapTen = driver.FindElement(By.Name("LastName"));
            IWebElement oNhapDiaChi = driver.FindElement(By.Name("Address"));
            IWebElement oNhapEmail = driver.FindElement(By.Name("Email"));
            IWebElement oNhapSoDienThoai = driver.FindElement(By.Name("Phone"));
            IWebElement oNhapTaiKhoan = driver.FindElement(By.Name("Account"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement oNhapLaiMatKhau = driver.FindElement(By.Name("ResetPassword"));
            IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));

            oNhapHo.SendKeys("Nguyen");
            System.Threading.Thread.Sleep(2000);
            oNhapTen.SendKeys("Binh Trong");
            System.Threading.Thread.Sleep(2000);
            oNhapDiaChi.SendKeys("9 le Trong Tan");
            System.Threading.Thread.Sleep(2000);
            oNhapEmail.SendKeys("hoaheo1101@mgail.com");
            System.Threading.Thread.Sleep(2000);
            oNhapSoDienThoai.SendKeys("0794857510");
            System.Threading.Thread.Sleep(2000);
            oNhapTaiKhoan.SendKeys("binhtrong1101");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("11012004");
            System.Threading.Thread.Sleep(2000);
            oNhapLaiMatKhau.SendKeys("123456789");
            System.Threading.Thread.Sleep(2000);

            nutDangKy.Click();
            System.Threading.Thread.Sleep(3000);

            Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                         driver.Url.Contains("dang-ky"));
        }

        [Test]
        public void KiemTraDangKyHopLe()
        {
            driver.Navigate().GoToUrl(SignUpURL);

            IWebElement oNhapHo = driver.FindElement(By.Name("FirstName"));
            IWebElement oNhapTen = driver.FindElement(By.Name("LastName"));
            IWebElement oNhapDiaChi = driver.FindElement(By.Name("Address"));
            IWebElement oNhapEmail = driver.FindElement(By.Name("Email"));
            IWebElement oNhapSoDienThoai = driver.FindElement(By.Name("Phone"));
            IWebElement luaChonGioiTinhNam = driver.FindElement(By.XPath("//input[@name='Sex' and @value='Nam']"));
            IWebElement oNhapTaiKhoan = driver.FindElement(By.Name("Account"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement oNhapLaiMatKhau = driver.FindElement(By.Name("ResetPassword"));
            IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));

            oNhapHo.SendKeys("Nguyen");
            System.Threading.Thread.Sleep(2000);
            oNhapTen.SendKeys("Binh Trong");
            System.Threading.Thread.Sleep(2000);
            oNhapDiaChi.SendKeys("9 Le Trong Tan");
            System.Threading.Thread.Sleep(2000);
            oNhapEmail.SendKeys("hoaheo1101@gmail.com");
            System.Threading.Thread.Sleep(2000);
            oNhapSoDienThoai.SendKeys("0794857510");
            System.Threading.Thread.Sleep(2000);
            if (!luaChonGioiTinhNam.Selected) luaChonGioiTinhNam.Click();
            System.Threading.Thread.Sleep(2000);
            oNhapTaiKhoan.SendKeys("binhtrong1101");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("11012004");
            System.Threading.Thread.Sleep(2000);
            oNhapLaiMatKhau.SendKeys("11012004");
            System.Threading.Thread.Sleep(2000);

            nutDangKy.Click();
            System.Threading.Thread.Sleep(3000);

            Assert.IsTrue(driver.Url.Contains("dang-nhap") ||
                         driver.Url.Contains("dashboard") ||
                         !driver.Url.Contains("dang-ky"));
        }


        [Test]
        public void KiemTraDangNhapKhiTrongUsername()
        {
            driver.Navigate().GoToUrl(LoginURL);

            // Chỉ điền password
            IWebElement passwordField = driver.FindElement(By.CssSelector("input[type='password']"));
            passwordField.SendKeys("testpassword123");

            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Kiểm tra thông báo lỗi hoặc URL vẫn ở trang đăng nhập
            bool ketQua = driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                         driver.Url.Contains("dang-nhap");
            Assert.IsTrue(ketQua, "Đăng nhập với username trống phải hiển thị lỗi");
        }

        [Test]
        public void KiemTraDangNhapKhiTrongPassword()
        {
            driver.Navigate().GoToUrl(LoginURL);

            // Chỉ điền username
            IWebElement usernameField = driver.FindElement(By.CssSelector("input[type='text']"));
            usernameField.SendKeys("testuser");

            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Kiểm tra thông báo lỗi hoặc URL vẫn ở trang đăng nhập
            bool ketQua = driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                         driver.Url.Contains("dang-nhap");
            Assert.IsTrue(ketQua, "Đăng nhập với password trống phải hiển thị lỗi");
        }

        [Test]
        public void KiemTraDangNhapSaiThongTin()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys("wronguser");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("wrongpass");
            System.Threading.Thread.Sleep(2000);

            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            Assert.IsTrue(driver.FindElements(By.ClassName("error-message")).Count > 0 ||
                         driver.Url.Contains("dang-nhap"));
        }

            [Test]
            public void KiemTraDangNhapHopLe()
            {
                driver.Navigate().GoToUrl(LoginURL);

                IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
                IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
                IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

                oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
                System.Threading.Thread.Sleep(2000);
                oNhapMatKhau.SendKeys(matKhauHopLe);
                System.Threading.Thread.Sleep(2000);

                nutDangNhap.Click();
                System.Threading.Thread.Sleep(3000);

                // Kiểm tra URL chứa "dashboard" hoặc không chứa "dang-nhap"
                bool isUrlValid = driver.Url.Contains("dashboard") || !driver.Url.Contains("dang-nhap");

                // Kiểm tra sự tồn tại của phần tử trang chủ bằng XPath
                bool isHomePageElementPresent = driver.FindElements(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/ul/li[2]/a")).Count > 0;

                // Kết hợp cả hai điều kiện trong Assert
                Assert.IsTrue(isUrlValid && isHomePageElementPresent, "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");
            }

        
            [Test]
            public void ThemLienHeLopLe()
            {
                driver.Navigate().GoToUrl(LoginURL);

                IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
                IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
                IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

                oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
                System.Threading.Thread.Sleep(2000);
                oNhapMatKhau.SendKeys(matKhauHopLe);
                System.Threading.Thread.Sleep(2000);
                nutDangNhap.Click();
                System.Threading.Thread.Sleep(2000);

                    driver.FindElement(By.LinkText("Liên hệ")).Click();

                    driver.FindElement(By.Name("Name")).SendKeys("Dang Anh Phat Mup");
                    Thread.Sleep(2000);
                    driver.FindElement(By.Name("Phone")).SendKeys("0123456789");
                    Thread.Sleep(2000);
                    driver.FindElement(By.Name("Email")).SendKeys("admin@gmail.com");
                    Thread.Sleep(2000);
                    driver.FindElement(By.Name("Content")).SendKeys("Cuu tui mon bao dam voi");
                    Thread.Sleep(2000);

                    driver.FindElement(By.Name("btn-lienhe")).Click();
                    Thread.Sleep(1000);
            }
        
        [Test]
        public void ThemLienHeThieuTruongBC()
        {
            driver.Navigate().GoToUrl(LoginURL);
            
            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.LinkText("Liên hệ")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Name")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Phone\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void ThemLienHeThieuTruongAC()
        {
            driver.Navigate().GoToUrl(LoginURL);
            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Liên hệ")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Phone")).SendKeys("0123456789");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Name\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void ThemLienHeThieuTruongAB()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.LinkText("Liên hệ")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("admin@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Name\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void ThemLienHeThieuTruongC()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Liên hệ")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Name")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Phone")).SendKeys("0123456789");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Email\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void ThemLienHeThieuTruongB()
        {
            driver.Navigate().GoToUrl(LoginURL);
            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Liên hệ")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Name")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("admin@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Phone\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void ThemLienHeThieuTruongA()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Liên hệ")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Phone")).SendKeys("0123456789");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("admin@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Name\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

    //THEM SAN PHAM
        [Test]
        public void Themsanphamhople()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            // Chuyển sang cửa sổ mới
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(mainWindowHandle);

            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");
            driver.Navigate().Refresh();
            IWebElement productList = wait.Until(drv => drv.FindElement(By.Id("table-list")));
            Assert.IsTrue(productList.Text.Contains("Dang Anh Phat Mup"), "Sản phẩm không xuất hiện trong danh sách!");
            Console.WriteLine("Thêm sản phẩm thành công!");
        }

        [Test]
        public void Themsanphamcogiaduoi100000()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("BenTen10");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("50000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);
            //driver.SwitchTo().Window(mainWindowHandle);

            wait.Until(drv => drv.FindElement(By.XPath("//input[@id='DONGIA']")));

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#DONGIA').validationMessage;");
            Console.WriteLine("Thông báo lỗi: " + errorMessage);
            Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 100000"), "Không hiển thị cảnh báo khi nhập giá dưới 100.000!");
        }

        [Test]
        public void Themsanpham_khcotruongTENSP()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("50000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#TENSP').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."), "Thông báo lỗi không hiển thị đúng");
        }

        [Test]
        public void Themsanpham_khcotruongSOLUONG()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#SOLUONG').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 1.") || errorMessage.Contains("Thông báo nhập thiếu số lượng"),
                          "Thông báo lỗi không hiển thị đúng");
        }

        //[Test]
        //public void Themsanpham_SOLUONGlasonguyenlonnhat()
        //{
        //    driver.Navigate().GoToUrl(AdminLoginURL);

        //    IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
        //    IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
        //    IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

        //    oNhapTenDangNhap.SendKeys("thien");
        //    System.Threading.Thread.Sleep(2000);
        //    oNhapMatKhau.SendKeys("123456");
        //    System.Threading.Thread.Sleep(2000);
        //    nutDangNhap.Click();
        //    System.Threading.Thread.Sleep(3000);

        //    // Chuyển đến trang danh sách sản phẩm
        //    driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
        //    btnThem.Click();

        //    string mainWindowHandle = driver.CurrentWindowHandle;

        //    foreach (string windowHandle in driver.WindowHandles)
        //    {
        //        if (windowHandle != mainWindowHandle)
        //        {
        //            driver.SwitchTo().Window(windowHandle);
        //            break;
        //        }
        //    }

        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("BenTen10");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
        //    driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("9999999");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
        //    Thread.Sleep(2000);
        //    //driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
        //    driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
        //    Thread.Sleep(2000);

        //    driver.SwitchTo().Alert().Accept();

        //    wait.Until(drv => drv.FindElement(By.XPath("//input[@id='SOLUONG']")));

        //    var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#SOLUONG').validationMessage;");
        //    Console.WriteLine("Thông báo lỗi: " + errorMessage);
        //    Assert.IsTrue(errorMessage.Contains("The value '999999999999999' is not valid for SOLUONG. #SOLUONG"), "Không hiển thị cảnh báo khi nhập giá dưới 100.000!");
        //}

        [Test]
        public void Themsanpham_soluongam()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("-100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript(
            "return document.querySelector('#SOLUONG').validationMessage;");

            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 1.") || errorMessage.Contains("Giá trị không hợp lệ"),
                          "Thông báo lỗi không hiển thị đúng");

        }

        [Test]
        public void Themsanpham_soluonglasothuc()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("9.64");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript(
            "return document.querySelector('#SOLUONG').validationMessage;");

            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("{Please enter a valid value. The two nearest valid value are 9 and 10.") || errorMessage.Contains("Số lượng không hợp lệ"),
                          "Thông báo lỗi không hiển thị đúng");

        }

        [Test]
        public void Themsanpham_khnhapmota()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("9.64");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#MOTA').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."), "Thông báo lỗi không hiển thị đúng");
        }

        [Test]
        public void Themsanpham_khcohinhanh()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#HINHANH').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please select a file."), "Thông báo lỗi không hiển thị đúng");
        }

        [Test]
        public void Themsanpham_dongiaduoi0()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            // Chuyển sang cửa sổ mới
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("-1000000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#DONGIA').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 100000."), "Thông báo lỗi không hiển thị đúng");
        }

        //[Test]
        //public void Themsanpham_dongiaqualon()
        //{
        //    driver.Navigate().GoToUrl(AdminLoginURL);

        //    IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
        //    IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
        //    IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

        //    oNhapTenDangNhap.SendKeys("thien");
        //    System.Threading.Thread.Sleep(2000);
        //    oNhapMatKhau.SendKeys("123456");
        //    System.Threading.Thread.Sleep(2000);
        //    nutDangNhap.Click();
        //    System.Threading.Thread.Sleep(3000);

        //    // Chuyển đến trang danh sách sản phẩm
        //    driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
        //    btnThem.Click();

        //    string mainWindowHandle = driver.CurrentWindowHandle;

        //    // Chuyển sang cửa sổ mới
        //    foreach (string windowHandle in driver.WindowHandles)
        //    {
        //        if (windowHandle != mainWindowHandle)
        //        {
        //            driver.SwitchTo().Window(windowHandle);
        //            break;
        //        }
        //    }

        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
        //    driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
        //    driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("200000000000000");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
        //    Thread.Sleep(2000);

        //    var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#DONGIA').validationMessage;");
        //    Console.WriteLine(errorMessage);
        //    Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 100000."), "Thông báo lỗi không hiển thị đúng");
        //}

        [Test]
        public void Themsanpham_khnhapdongia()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            // Chuyển sang cửa sổ mới
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='DANHGIA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#DONGIA').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 100000."), "Thông báo lỗi không hiển thị đúng");
        }

        [Test]
        public void Themsanpham_khnhapodanhgia()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement btnThem = wait.Until(drv => drv.FindElement(By.Id("btn-themsanpham")));
            btnThem.Click();

            string mainWindowHandle = driver.CurrentWindowHandle;

            // Chuyển sang cửa sổ mới
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='TENSP']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).Clear();
            driver.FindElement(By.XPath("//input[@id='SOLUONG']")).SendKeys("100");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//textarea[@id='MOTA']")).SendKeys("Dang Anh Phat Mup");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MATH']")).SendKeys("ZenBooks");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//select[@id='MALOAISP']")).SendKeys("Truyện");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).Clear();
            driver.FindElement(By.XPath("//input[@id='DONGIA']")).SendKeys("100000");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='HINHANH']")).SendKeys("D:\\conchodap.jpg");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='btn-ok-create']")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('#DANHGIA').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Value must be greater than or equal to 100000."), "Thông báo lỗi không hiển thị đúng");
        }

        //XOA SAN PHAM
        [Test]
        public void Xoasanphamadmin()
        {
            driver.Navigate().GoToUrl(AdminLoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Login']"));

            oNhapTenDangNhap.SendKeys("thien");
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys("123456");
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);

            // Chuyển đến trang danh sách sản phẩm
            driver.Navigate().GoToUrl("http://localhost:8838/Admin/Product/Index");

            var deleteButtons = driver.FindElements(By.XPath("//button[contains(@class,'btn btn-danger')]"));
            int initialDeleteCount = deleteButtons.Count;
            Assert.IsNotNull(deleteButtons, "Sản phẩm cần xóa không tồn tại");

            deleteButtons[0].Click();
            System.Threading.Thread.Sleep(2000);

            var confirmDeleteButton = driver.FindElement(By.XPath("//button[contains(text(),'Ok')]"));
            confirmDeleteButton.Click();
            System.Threading.Thread.Sleep(3000);

            IAlert alert = driver.SwitchTo().Alert();
            Assert.AreEqual("remove successful", alert.Text, "Thông báo không đúng!"); // Kiểm tra nội dung
            alert.Accept(); // Nhấn "OK"
            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void KetThuc()
        {
            driver.Quit();
            driver.Dispose();
        }

        private void ThucHienDangNhap(string tenDangNhap, string matKhau)
        {
            driver.Navigate().GoToUrl(LoginURL);
            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhap);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhau);
            System.Threading.Thread.Sleep(2000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(3000);
        }

        private void ThucHienDangKy(string ho, string ten, string diaChi, string email, string soDienThoai, string gioiTinh, string taiKhoan, string matKhau, string nhapLaiMatKhau)
        {
            driver.Navigate().GoToUrl(SignUpURL);
            IWebElement oNhapHo = driver.FindElement(By.Name("FirstName"));
            IWebElement oNhapTen = driver.FindElement(By.Name("LastName"));
            IWebElement oNhapDiaChi = driver.FindElement(By.Name("Address"));
            IWebElement oNhapEmail = driver.FindElement(By.Name("Email"));
            IWebElement oNhapSoDienThoai = driver.FindElement(By.Name("Phone"));
            IWebElement luaChonGioiTinh = driver.FindElement(By.XPath($"//input[@name='Sex' and @value='{gioiTinh}']"));
            IWebElement oNhapTaiKhoan = driver.FindElement(By.Name("Account"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("Password"));
            IWebElement oNhapLaiMatKhau = driver.FindElement(By.Name("ResetPassword"));
            IWebElement nutDangKy = driver.FindElement(By.Id("btnSubmit"));

            oNhapHo.SendKeys(ho);
            System.Threading.Thread.Sleep(2000);
            oNhapTen.SendKeys(ten);
            System.Threading.Thread.Sleep(2000);
            oNhapDiaChi.SendKeys(diaChi);
            System.Threading.Thread.Sleep(2000);
            oNhapEmail.SendKeys(email);
            System.Threading.Thread.Sleep(2000);
            oNhapSoDienThoai.SendKeys(soDienThoai);
            System.Threading.Thread.Sleep(2000);
            if (!luaChonGioiTinh.Selected) luaChonGioiTinh.Click();
            System.Threading.Thread.Sleep(2000);
            oNhapTaiKhoan.SendKeys(taiKhoan);
            System.Threading.Thread.Sleep(2000);
            oNhapMatKhau.SendKeys(matKhau);
            System.Threading.Thread.Sleep(2000);
            oNhapLaiMatKhau.SendKeys(nhapLaiMatKhau);
            System.Threading.Thread.Sleep(2000);
            nutDangKy.Click();
            System.Threading.Thread.Sleep(3000);
        }
    }
}