using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.Models.ViewModel
{
    public class OrderHistoryViewModel
    {
        public int MADH { get; set; }
        public int? MAKH { get; set; }
        public string DIACHIGIAO { get; set; }
        public DateTime? NGAYDAT { get; set; }
        public DateTime? NGAYGIAO { get; set; }
        public double? TONGTIEN { get; set; }
        public string TRANGTHAI { get; set; }
    }
}