using BanDongHo.Domain.DataContext;
using BanDongHo.Models.Models;
using BanDongHo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanDongHo.Models.Service
{
    public class OrderHistoryService
    {
        public List<OrderHistoryViewModel> GetOrderHistoryByCustomerId(int customerId)
        {
            using (BANDONGHOEntities db = new BANDONGHOEntities())
            {
                var orders = db.DONHANGs
                    .Where(dh => dh.MAKH == customerId)
                    .OrderByDescending(dh => dh.NGAYDAT)
                    .Select(dh => new OrderHistoryViewModel
                    {
                        MADH = dh.MADH,
                        MAKH = dh.MAKH,
                        DIACHIGIAO = dh.DIACHIGIAO,
                        NGAYDAT = dh.NGAYDAT,
                        NGAYGIAO = dh.NGAYGIAO,
                        TONGTIEN = dh.TONGTIEN,
                        TRANGTHAI = dh.TRANGTHAI
                    }).ToList();

                return orders;
            }
        }
        
    }
}