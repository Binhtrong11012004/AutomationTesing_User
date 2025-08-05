using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BanDongHo.Areas.Admin.Models
{
    public class VoucherViewModel
    {
        [Required]
        public string MAVC { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên voucher")]
        public string TENVC { get; set; }

        public float GIATRI { get; set; }

        public DateTime NGAYTAO { get; set; }

        public DateTime NGAYHETHAN { get; set; }
    }
}