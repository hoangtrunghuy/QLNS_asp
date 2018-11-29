using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using KhenThuong;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class KhenThuongController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        Bonus khenthuong = new Bonus();
        //
        // GET: /admin/KhenThuong/
        public ActionResult Index()
        {

            return View(khenthuong.GetKhenThuong());
        }
        [HttpGet]
        public ActionResult khen()
        {
            //var nv = db.NhanViens.ToList();

            return View(new DAL.KhenThuong());
        }
        [HttpPost]
        public ActionResult khen(DAL.KhenThuong kt)
        {
            //var ct = db.ChiTietLuongs.Where(n => n.MaNhanVien == kt.MaNhanVien).FirstOrDefault();

            //KhenThuong ad = new KhenThuong();
            //ad.MaNhanVien = kt.MaNhanVien;
            //ad.ThangThuong = kt.ThangThuong;
            //ad.TienThuong = kt.TienThuong;
            //ad.LyDo = kt.LyDo;

            //db.KhenThuongs.Add(ad);
            //db.SaveChanges();
            khenthuong.AddKhenThuong(kt);
            return Redirect("/admin/KhenThuong");
        }
    }
}