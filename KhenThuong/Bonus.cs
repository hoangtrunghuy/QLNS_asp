using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Collections;
namespace KhenThuong
{
    public class Bonus
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public IEnumerable GetKhenThuong()
        {
            return db.KhenThuongs.ToList();
        }
        public string AddKhenThuong(DAL.KhenThuong kt)
        {
            DAL.KhenThuong ad = new DAL.KhenThuong();
            ad.MaNhanVien = kt.MaNhanVien;
            ad.ThangThuong = kt.ThangThuong;
            ad.TienThuong = kt.TienThuong;
            ad.LyDo = kt.LyDo;

            db.KhenThuongs.Add(ad);
            db.SaveChanges();
            return "Them thanh cong";
        }
    }
}
