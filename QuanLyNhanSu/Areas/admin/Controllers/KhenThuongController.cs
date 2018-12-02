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
            khenthuong.AddKhenThuong(kt);
            return Redirect("/admin/KhenThuong");
        }
    }
}