using BanDongHo.Domain.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.Areas.Admin.Models
{
    public class SalesService
    {
        private readonly BANDONGHOEntities _context;

        public SalesService(BANDONGHOEntities context)
        {
            _context = context;
        }

        // Tổng doanh thu
        public double GetTotalRevenue()
        {
            var totalRevenue = _context.DONHANGs
                .Where(dh => dh.NGAYGIAO.HasValue)
                .Sum(dh => dh.TONGTIEN) ?? 0;

            return totalRevenue;
        }

        // Doanh thu theo tháng
        public Dictionary<int, double> GetMonthlyRevenue(int year)
        {
            var monthlyRevenue = _context.DONHANGs
                .Where(dh => dh.NGAYGIAO.HasValue && dh.NGAYGIAO.Value.Year == year)
                .GroupBy(dh => dh.NGAYGIAO.Value.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Revenue = g.Sum(dh => dh.TONGTIEN) ?? 0
                })
                .OrderBy(mr => mr.Month)
                .ToDictionary(mr => mr.Month, mr => mr.Revenue);

            return monthlyRevenue;
        }
    }
}