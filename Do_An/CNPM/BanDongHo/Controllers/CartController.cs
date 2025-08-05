using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models.Models;
using BanDongHo.Domain.DataContext;
using System.Globalization;
using BanDongHo.Models.Service;
using BanDongHo.Common;
using PayPal.Api;



namespace BanDongHo.Controllers
{
    public class CartController : Controller
    {
      
        
        // GET: Cart
        public ActionResult Index()
        {
            var userSession = (UserLogin)Session[CommonConstands.USER_SESSION];
            if (userSession == null)
            {
                return Redirect("dang-nhap");
            }
            else
            {
                /* Tạo mới một giỏ hàng nếu nó bằng null
                   Giỏ hàng được tạo khi người dùng nhấp vào giỏ hàng hoặc 
                   người dùng mua một sản phẩm  */
                // Giỏ hàng được quản lý bằng một biến Session
                Cart cart = Session["Cart"] as Cart;
                // Nếu chưa có giỏ hàng thì tạo mới một giỏ hàng
                if (cart == null)
                {
                    cart = new Cart();
                }
                // gán giỏ hàng cho biến session[cart]
                Session["Cart"] = cart;
                // Trả giỏ hàng ra giao diện 
                return View(Session["Cart"] as Cart);
            }
        }

        public ActionResult AddProduct(int id,int sl=1)
        {
            /*
             * Thêm một sản phẩm vào giỏ hàng
             * được gọi khi người dùng chọn một 
             * sản phẩm từ trang chi tiết
             */
             // Lấy biến giỏ hàng từ session
            Cart cart = Session["Cart"] as Cart;
            // Nếu chưa có thì tạo mới giỏ hàng
            if (cart == null)
            {
                cart = new Cart();
            }
            // Thêm sản phẩm vào giỏ hàng
            cart.AddProduct(id, sl);
            // Gán lại giỏ hàng cho session
            Session["Cart"] = cart;
            // Trở về giao diện index
            return RedirectToAction("Index");
        }

        public string DeleteProduct(int id)
        {
            /*
             * Xóa một sản phẩm khi người dùng chọn button delete
             * trong màn hình giỏ hàng. Khi xóa sản phẩm bị loại 
             * ra khỏi giỏ hàng.
             */

            // lấy giỏ hàng từ session
            Cart cart = Session["Cart"] as Cart;
            // Nếu chưa có thì trả về total = 0;
            if(cart==null)
            {
                return "Total:";
            }
            // Xóa sản phẩm đi
            cart.RemoveProduct(id);
            // gán lại giỏ hàng cho session
            Session["Cart"] = cart;
            // Trả về chuỗi total đã định dạng tiền mặt việt nam
            return "Total: " + cart.TotalMoney().ToString("0,0");
        }

        public string UpdateProduct(int id,int sl)
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                return "Total:";
            }
            cart.UpdateProduct(id,sl);
            Session["Cart"] = cart;
            string res="Total: "+ cart.TotalMoney().ToString("0,0");
            return res;
        }
       
       
        public ActionResult Checkout()
        {
            /*
             * Kiểm tra số lượng của mỗi sản phẩm trên giỏ có đủ với số lượng 
             * trong kho hàng hay không?
             */
            Cart cart = (Cart)Session["Cart"];
            bool isFalse = false;
            foreach (var item in cart.GetList())
            {
                if (!CartService.CheckNumberProduct(item.Product.MASP, item.Quantity))
                {
                    isFalse = true;
                }
            }
            if (!isFalse)
            {
                return RedirectToAction("Index", "CusInfo");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

/// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       /// 

        public ActionResult FailureView()
        {
            return View();
        }
        public ActionResult SuccessView()
        {
            return View();
        }
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/shoppingcart/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }
            //on successful payment, show success page to user.  
            return View("SuccessView");

        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listSanPham = Session["Cart"] as Cart;

            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            foreach (var item in listSanPham.GetList())
            {
                itemList.items.Add(new Item()
                {
                    name = item.Product.TENSP, // Tên sản phẩm
                    currency = "USD",
                    price = item.Product.DONGIA.Value.ToString("F2"), // Giá sản phẩm, cần định dạng thành chuỗi
                    quantity = item.Quantity.ToString(), // Số lượng sản phẩm
                    sku = item.Product.MASP.ToString() // Mã sản phẩm
                }) ; 
            }
            
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = listSanPham.TotalMoney().ToString()
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = listSanPham.TotalMoney().ToString(),
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            var paypalOrderId = DateTime.Now.Ticks;
            transactionList.Add(new Transaction()
            {
                description = $"Invoice #{paypalOrderId}",
                invoice_number = paypalOrderId.ToString(), //Generate an Invoice No    
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetTotalNumber()
        {
            int totalNumber = 0;

            // Gọi phương thức để lấy giỏ hàng
            List<CartItem> cart = (Session["Cart"] as Cart)?.GetList();

            if (cart != null)
            {
                // Tính tổng số lượng của tất cả các mục trong giỏ hàng
                totalNumber = cart.Sum(sp => sp.Quantity);
            }

            return totalNumber;
        }
        [ChildActionOnly]
        public ActionResult CartMenu()
        {
            ViewBag.TotalNumber = GetTotalNumber();
            return PartialView();
        }
    }
}

