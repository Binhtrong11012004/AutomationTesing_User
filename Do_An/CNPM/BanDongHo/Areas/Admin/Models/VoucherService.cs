using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BanDongHo.Domain.DataContext;

namespace BanDongHo.Areas.Admin.Models
{
    public class VoucherService
    {
        BANDONGHOEntities db;

        public VoucherService()
        {
            db = new BANDONGHOEntities();
        }

        public IEnumerable<VOUCHER> getAllVoucher()
        {        
            return db.VOUCHERs;
        }

        public bool addVoucher(VOUCHER vc)
        {
            try
            {
                db.VOUCHERs.Add(vc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateVoucher(VOUCHER vc)
        {
            try
            {
                var result = db.VOUCHERs.Find(vc.MAVC);
                if(result != null)
                {
                    result.TENVC = vc.TENVC;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteVoucher(string mavc)
        {          
                try
                {              
                    string query = "DELETE FROM VOUCHER WHERE MAVC = '" + mavc + "'";
                    db.Database.ExecuteSqlCommand(query);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }          

        }

        public string getLastRecord()
        {
            string res = "";//Lấy bản ghi cuối cùng từ bảng LOAISANPHAM sắp xếp theo MALOAISP giảm dần
            var lastrecord = db.VOUCHERs.OrderByDescending(p => p.MAVC).FirstOrDefault();
            if (lastrecord != null)
            {
                res = lastrecord.MAVC;
            }

            return res ;
        }

        public VOUCHER getVoucherById(string mavc)
        {
            return db.VOUCHERs.Find(mavc);
        }
    }
}