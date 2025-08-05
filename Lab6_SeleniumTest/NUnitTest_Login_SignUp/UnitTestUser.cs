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
            oNhapDiaChi.SendKeys("9 Le Trong Tan");
            System.Threading.Thread.Sleep(2000);
            oNhapEmail.SendKeys("hoaheo1101@gmail.com");
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
        public void SanPham()
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

            Assert.IsTrue(isUrlValid && isHomePageElementPresent, "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            // Nhấn vào liên kết "Sản phẩm"
            IWebElement linkSanPham = driver.FindElement(By.CssSelector("a[href='/san-pham/tat-ca']"));
            linkSanPham.Click();
            System.Threading.Thread.Sleep(3000);

            // Kiểm tra URL sau khi nhấn vào "Sản phẩm"
            string expectedProductPageUrl = "http://localhost:8838/san-pham/tat-ca";
            Assert.AreEqual(expectedProductPageUrl, driver.Url, "Không chuyển hướng đến trang tất cả sản phẩm.");
        }

        [Test]
        public void SanPham_ChiTietSanPham()
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

            Assert.IsTrue(isUrlValid && isHomePageElementPresent, "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            // Nhấn vào liên kết "Sản phẩm"
            IWebElement linkSanPham = driver.FindElement(By.CssSelector("a[href='/san-pham/tat-ca']"));
            linkSanPham.Click();
            System.Threading.Thread.Sleep(3000);

            // Kiểm tra URL sau khi nhấn vào "Sản phẩm"
            string expectedProductPageUrl = "http://localhost:8838/san-pham/tat-ca";
            Assert.AreEqual(expectedProductPageUrl, driver.Url, "Không chuyển hướng đến trang tất cả sản phẩm.");

            // Nhấn vào sản phẩm "HARRY POTTER 03"
            IWebElement harryPotterProduct = driver.FindElement(By.CssSelector("img.img-responsive.zoom-img[src='/images/HINHANH/20240711032543481.jpg']"));
            harryPotterProduct.Click();
            System.Threading.Thread.Sleep(3000);
        }

        [Test]
        public void SanPham_ThemVaoGioHang()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(1000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(1000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(driver.Url.Contains("dashboard") || !driver.Url.Contains("dang-nhap"), "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            IWebElement linkSanPham = driver.FindElement(By.CssSelector("a[href='/san-pham/tat-ca']"));
            linkSanPham.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual("http://localhost:8838/san-pham/tat-ca", driver.Url, "Không chuyển hướng đến trang tất cả sản phẩm.");

            IWebElement harryPotterProduct = driver.FindElement(By.CssSelector("img.img-responsive.zoom-img[src='/images/HINHANH/20240711032543481.jpg']"));
            harryPotterProduct.Click();
            System.Threading.Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement addToCartButton = wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Thêm vào giỏ hàng')]")));
                addToCartButton.Click();
                System.Threading.Thread.Sleep(2000);

                // Kiểm tra nếu có liên kết hoặc icon giỏ hàng
                IWebElement viewCartLink = wait.Until(d => d.FindElement(By.CssSelector("a[href='/Cart'], a.cart-icon")));
                viewCartLink.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thêm vào giỏ hàng' hoặc 'Xem giỏ hàng'. Kiểm tra lại HTML.");
            }

            try
            {
                wait.Until(d => d.Url.Contains("/Cart"));
                Assert.AreEqual("http://localhost:8838/Cart", driver.Url, "Không chuyển hướng đến trang giỏ hàng.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không chuyển đến trang giỏ hàng sau khi thêm sản phẩm.");
            }

            bool isProductInCart = driver.FindElements(By.CssSelector("img[src='/images/HINHANH/20240711032543481.jpg']")).Count > 0;
            Assert.IsTrue(isProductInCart, "Sản phẩm không xuất hiện trong giỏ hàng.");
        }

        [Test]
        public void SanPham_ThanhToanThatBaiDoThieuSDT()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(1000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(1000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(driver.Url.Contains("dashboard") || !driver.Url.Contains("dang-nhap"), "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            IWebElement linkSanPham = driver.FindElement(By.CssSelector("a[href='/san-pham/tat-ca']"));
            linkSanPham.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual("http://localhost:8838/san-pham/tat-ca", driver.Url, "Không chuyển hướng đến trang tất cả sản phẩm.");

            IWebElement harryPotterProduct = driver.FindElement(By.CssSelector("img.img-responsive.zoom-img[src='/images/HINHANH/20240711032543481.jpg']"));
            harryPotterProduct.Click();
            System.Threading.Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement addToCartButton = wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Thêm vào giỏ hàng')]")));
                addToCartButton.Click();
                System.Threading.Thread.Sleep(2000);

                IWebElement viewCartLink = wait.Until(d => d.FindElement(By.CssSelector("a[href='/Cart'], a.cart-icon")));
                viewCartLink.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thêm vào giỏ hàng' hoặc 'Xem giỏ hàng'. Kiểm tra lại HTML.");
            }

            try
            {
                wait.Until(d => d.Url.Contains("/Cart"));
                Assert.AreEqual("http://localhost:8838/Cart", driver.Url, "Không chuyển hướng đến trang giỏ hàng.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không chuyển đến trang giỏ hàng sau khi thêm sản phẩm.");
            }

            bool isProductInCart = driver.FindElements(By.CssSelector("img[src='/images/HINHANH/20240711032543481.jpg']")).Count > 0;
            Assert.IsTrue(isProductInCart, "Sản phẩm không xuất hiện trong giỏ hàng.");

            try
            {
                IWebElement checkoutButton = wait.Until(d => d.FindElement(By.CssSelector("a.btn.btn-primary[href='Cart/Checkout/']")));
                checkoutButton.Click();
                System.Threading.Thread.Sleep(2000);

                wait.Until(d => d.Url.Contains("/CusInfo"));
                Assert.AreEqual("http://localhost:8838/CusInfo", driver.Url, "Không chuyển hướng đến trang chi tiết hóa đơn.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thanh toán' hoặc không chuyển đến trang chi tiết hóa đơn.");
            }

            // Thêm thông tin địa chỉ giao hàng và kiểm tra validation
            try
            {
                // Điền địa chỉ giao hàng
                IWebElement diaChiGiaoInput = wait.Until(d => d.FindElement(By.CssSelector("input.text-box#DiaChiGiao")));
                diaChiGiaoInput.SendKeys("9 Le Trong Tan");
                System.Threading.Thread.Sleep(1000);

                // Nhấn nút Đặt hàng
                IWebElement datHangButton = wait.Until(d => d.FindElement(By.CssSelector("input.btn.btn-success[type='submit'][value='Đặt hàng']")));
                datHangButton.Click();
                System.Threading.Thread.Sleep(2000);

                // Kiểm tra thông báo validation của HTML5
                IWebElement requiredField = driver.FindElement(By.CssSelector("input:invalid"));
                Assert.IsTrue(requiredField != null, "Không xuất hiện thông báo yêu cầu điền các trường bắt buộc.");

                // Kiểm tra xem trang chưa chuyển hướng vì form chưa hợp lệ
                Assert.AreEqual("http://localhost:8838/CusInfo", driver.Url, "Trang không nên chuyển hướng khi form chưa điền đầy đủ.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy textbox địa chỉ hoặc nút Đặt hàng.");
            }
        }

        [Test]
        public void SanPham_ThanhToanThatBaiDoThieuDiaChi()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(1000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(1000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(driver.Url.Contains("dashboard") || !driver.Url.Contains("dang-nhap"), "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            IWebElement linkSanPham = driver.FindElement(By.CssSelector("a[href='/san-pham/tat-ca']"));
            linkSanPham.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual("http://localhost:8838/san-pham/tat-ca", driver.Url, "Không chuyển hướng đến trang tất cả sản phẩm.");

            IWebElement harryPotterProduct = driver.FindElement(By.CssSelector("img.img-responsive.zoom-img[src='/images/HINHANH/20240711032543481.jpg']"));
            harryPotterProduct.Click();
            System.Threading.Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement addToCartButton = wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Thêm vào giỏ hàng')]")));
                addToCartButton.Click();
                System.Threading.Thread.Sleep(2000);

                // Kiểm tra nếu có liên kết hoặc icon giỏ hàng
                IWebElement viewCartLink = wait.Until(d => d.FindElement(By.CssSelector("a[href='/Cart'], a.cart-icon")));
                viewCartLink.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thêm vào giỏ hàng' hoặc 'Xem giỏ hàng'. Kiểm tra lại HTML.");
            }

            try
            {
                wait.Until(d => d.Url.Contains("/Cart"));
                Assert.AreEqual("http://localhost:8838/Cart", driver.Url, "Không chuyển hướng đến trang giỏ hàng.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không chuyển đến trang giỏ hàng sau khi thêm sản phẩm.");
            }

            bool isProductInCart = driver.FindElements(By.CssSelector("img[src='/images/HINHANH/20240711032543481.jpg']")).Count > 0;
            Assert.IsTrue(isProductInCart, "Sản phẩm không xuất hiện trong giỏ hàng.");

            // Thêm bước nhấn nút Thanh toán
            try
            {
                IWebElement checkoutButton = wait.Until(d => d.FindElement(By.CssSelector("a.btn.btn-primary[href='Cart/Checkout/']")));
                checkoutButton.Click();
                System.Threading.Thread.Sleep(2000);

                // Kiểm tra chuyển hướng đến trang chi tiết hóa đơn
                wait.Until(d => d.Url.Contains("/CusInfo"));
                Assert.AreEqual("http://localhost:8838/CusInfo", driver.Url, "Không chuyển hướng đến trang chi tiết hóa đơn.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thanh toán' hoặc không chuyển đến trang chi tiết hóa đơn.");
            }

            // Thêm số điện thoại và kiểm tra validation
            try
            {
                // Điền số điện thoại
                IWebElement phoneInput = wait.Until(d => d.FindElement(By.Id("Sdt")));
                phoneInput.SendKeys("0794857510");
                System.Threading.Thread.Sleep(1000);

                // Nhấn nút Đặt hàng
                IWebElement orderButton = wait.Until(d => d.FindElement(By.CssSelector("input.btn.btn-success[type='submit'][value='Đặt hàng']")));
                orderButton.Click();
                System.Threading.Thread.Sleep(2000);

                // Kiểm tra thông báo validation
                // Giả sử thông báo "please fill out this fields" xuất hiện trong HTML5 validation
                IWebElement invalidElement = wait.Until(d => d.FindElement(By.XPath("//input[@required and not(@id='Sdt') and string-length(@value)=0]")));
                bool isValidationTriggered = (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                    "return arguments[0].validity.valueMissing", invalidElement);

                Assert.IsTrue(isValidationTriggered, "Không hiển thị thông báo 'please fill out this fields' khi các trường bắt buộc khác bị bỏ trống.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy textbox số điện thoại, nút đặt hàng hoặc thông báo validation không hoạt động.");
            }
        }

        [Test]
        public void SanPham_ThanhToanThanhCong()
        {
            driver.Navigate().GoToUrl(LoginURL);

            IWebElement oNhapTenDangNhap = driver.FindElement(By.Name("UserName"));
            IWebElement oNhapMatKhau = driver.FindElement(By.Name("PassWord"));
            IWebElement nutDangNhap = driver.FindElement(By.CssSelector("input[type='submit'][value='Đăng nhập']"));

            oNhapTenDangNhap.SendKeys(tenDangNhapHopLe);
            System.Threading.Thread.Sleep(1000);
            oNhapMatKhau.SendKeys(matKhauHopLe);
            System.Threading.Thread.Sleep(1000);
            nutDangNhap.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(driver.Url.Contains("dashboard") || !driver.Url.Contains("dang-nhap"), "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            IWebElement linkSanPham = driver.FindElement(By.CssSelector("a[href='/san-pham/tat-ca']"));
            linkSanPham.Click();
            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual("http://localhost:8838/san-pham/tat-ca", driver.Url, "Không chuyển hướng đến trang tất cả sản phẩm.");

            IWebElement harryPotterProduct = driver.FindElement(By.CssSelector("img.img-responsive.zoom-img[src='/images/HINHANH/20240711032543481.jpg']"));
            harryPotterProduct.Click();
            System.Threading.Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement addToCartButton = wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Thêm vào giỏ hàng')]")));
                addToCartButton.Click();
                System.Threading.Thread.Sleep(2000);

                IWebElement viewCartLink = wait.Until(d => d.FindElement(By.CssSelector("a[href='/Cart'], a.cart-icon")));
                viewCartLink.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thêm vào giỏ hàng' hoặc 'Xem giỏ hàng'. Kiểm tra lại HTML.");
            }

            try
            {
                wait.Until(d => d.Url.Contains("/Cart"));
                Assert.AreEqual("http://localhost:8838/Cart", driver.Url, "Không chuyển hướng đến trang giỏ hàng.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không chuyển đến trang giỏ hàng sau khi thêm sản phẩm.");
            }

            bool isProductInCart = driver.FindElements(By.CssSelector("img[src='/images/HINHANH/20240711032543481.jpg']")).Count > 0;
            Assert.IsTrue(isProductInCart, "Sản phẩm không xuất hiện trong giỏ hàng.");

            try
            {
                IWebElement checkoutButton = wait.Until(d => d.FindElement(By.CssSelector("a.btn.btn-primary[href='Cart/Checkout/']")));
                checkoutButton.Click();
                System.Threading.Thread.Sleep(2000);

                wait.Until(d => d.Url.Contains("/CusInfo"));
                Assert.AreEqual("http://localhost:8838/CusInfo", driver.Url, "Không chuyển hướng đến trang chi tiết hóa đơn.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không tìm thấy nút 'Thanh toán' hoặc không chuyển đến trang chi tiết hóa đơn.");
            }

            // Thêm thông tin giao hàng và đặt hàng
            try
            {
                // Nhập địa chỉ giao hàng
                IWebElement deliveryAddress = wait.Until(d => d.FindElement(By.Id("DiaChiGiao")));
                deliveryAddress.SendKeys("9 Le Trong Tan");
                System.Threading.Thread.Sleep(1000);

                // Nhập số điện thoại
                IWebElement phoneNumber = wait.Until(d => d.FindElement(By.Id("Sdt")));
                phoneNumber.SendKeys("0794857510");
                System.Threading.Thread.Sleep(1000);

                // Nhập mô tả
                IWebElement description = wait.Until(d => d.FindElement(By.Id("MoTa")));
                description.SendKeys("Giao cho nguoi trong nha");
                System.Threading.Thread.Sleep(1000);

                // Nhấn nút Đặt hàng
                IWebElement orderButton = wait.Until(d => d.FindElement(By.CssSelector("input.btn.btn-success[type='submit'][value='Đặt hàng']")));
                orderButton.Click();
                System.Threading.Thread.Sleep(2000);

                // Kiểm tra chuyển hướng đến trang thành công
                wait.Until(d => d.Url.Contains("/CusInfo/Success"));
                Assert.AreEqual("http://localhost:8838/CusInfo/Success", driver.Url, "Không chuyển hướng đến trang đặt hàng thành công.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Không thể điền thông tin giao hàng hoặc đặt hàng không thành công.");
            }
        }

       
        [Test]
        public void LienHe()
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

            // Kiểm tra URL chứa "dashboard" hoặc không chứa "dang-nhap"
            bool isUrlValid = driver.Url.Contains("dashboard") || !driver.Url.Contains("dang-nhap");

            // Kiểm tra sự tồn tại của phần tử trang chủ bằng XPath
            bool isHomePageElementPresent = driver.FindElements(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/ul/li[2]/a")).Count > 0;

            Assert.IsTrue(isUrlValid && isHomePageElementPresent, "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            // Nhấn vào liên kết "Liên hệ"
            IWebElement linkLienHe = driver.FindElement(By.CssSelector("a[href='/Home/Contact']"));
            linkLienHe.Click();
            System.Threading.Thread.Sleep(3000);

            // Kiểm tra URL sau khi nhấn vào "Liên hệ"
            string expectedContactPageUrl = "http://localhost:8838/Home/Contact";
            Assert.AreEqual(expectedContactPageUrl, driver.Url, "Không chuyển hướng đến trang liên hệ.");
        }

        [Test]
        public void LienHe_ThemThanhCong()
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

            driver.FindElement(By.Name("Name")).SendKeys("Nguyen Binh Trong");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Phone")).SendKeys("0794857510");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("hoaheo1101@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Content")).SendKeys("Cuu tui mon bao dam voi");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void LienHe_ChiThemTen()
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
            driver.FindElement(By.Name("Name")).SendKeys("Nguyen Binh Trong");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Phone\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void LienHe_ChiThemSDT()
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
            driver.FindElement(By.Name("Phone")).SendKeys("0794857510");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Name\"]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void LienHe_ChiThemEmail()
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
        public void LienHe_ThemTenVaSDT()
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
            driver.FindElement(By.Name("Name")).SendKeys("Nguyen Binh Trong");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Phone")).SendKeys("0794857510");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Email\"]')?.validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void LienHe_ThemTenVaEmail()
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
            driver.FindElement(By.Name("Name")).SendKeys("Nguyen Binh Trong");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("hoaheo1101@gmai.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);

            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Phone\"]')?.validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }

        [Test]
        public void LienHe_ThemSDTvaEmail()
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
            driver.FindElement(By.Name("Phone")).SendKeys("0794857510");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("hoaheo1101@com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("btn-lienhe")).Click();
            Thread.Sleep(2000);
            var errorMessage = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[name=\"Name\" ]').validationMessage;");
            Console.WriteLine(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Please fill out this field."));
        }


        [Test]
        public void LichSuDonHang()
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

            Assert.IsTrue(isUrlValid && isHomePageElementPresent, "Đăng nhập không thành công hoặc không chuyển hướng đến trang chủ.");

            // Nhấn vào liên kết "Lịch sử đơn hàng"
            IWebElement linkLichSuDonHang = driver.FindElement(By.CssSelector("a[href='/OrderHistory/OrderHistory']"));
            linkLichSuDonHang.Click();
            System.Threading.Thread.Sleep(3000);

            // Kiểm tra URL sau khi nhấn vào "Lịch sử đơn hàng"
            string expectedOrderHistoryUrl = "http://localhost:8838/OrderHistory/OrderHistory";
            Assert.AreEqual(expectedOrderHistoryUrl, driver.Url, "Không chuyển hướng đến trang lịch sử đơn hàng.");
        }


        [TearDown]
        public void KetThuc()
        {
            driver.Quit();
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