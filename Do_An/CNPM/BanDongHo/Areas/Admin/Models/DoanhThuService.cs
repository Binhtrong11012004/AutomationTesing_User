using BanDongHo.Domain.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.Areas.Admin.Models
{
    public class DoanhThuService
    {
        private readonly BANDONGHOEntities _context;

        public DoanhThuService(BANDONGHOEntities context)
        {
            _context = context;
        }

        public double GetDoanhThu(DateTime startDate, DateTime endDate)
        {
            return _context.DONHANGs
                .Where(dh => dh.NGAYDAT >= startDate && dh.NGAYDAT <= endDate)
                .Sum(dh => dh.TONGTIEN ?? 0);
        }
    }
}