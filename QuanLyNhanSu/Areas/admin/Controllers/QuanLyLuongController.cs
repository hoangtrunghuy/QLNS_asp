using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Data;
using DAL;
using Luong;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyLuongController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        Salary luongnhanvien = new Salary();
        
        // GET: /admin/QuanLyLuong/
        public ActionResult Index()
        {
            return View(luongnhanvien.GetLuong());
        }
        [HttpGet]
        public ActionResult SuaBangLuong(String id)
        {
            var luong = db.Luongs.Where(n => n.MaNhanVien == id).SingleOrDefault();
            return View(luong);
        }
        [HttpPost]
        public ActionResult SuaBangLuong(DAL.Luong luong, CapNhatLuong up)
        {
            luongnhanvien.UpdateLuong(luong, up);

            return Redirect("/admin/QuanLyLuong");
        }
        //end update lương

        public ActionResult ThanhToanLuong()
        {

            luongnhanvien.ThanhToanLuong();
            return Redirect("/admin/QuanLyLuong");
        }


        public ActionResult ThanhToanMotNhanVien(String id)
        {
            luongnhanvien.ThanhToanMotNhanVien(id);
            return Redirect("/admin/QuanLyLuong");
        }

        public ActionResult DanhSachNhanLuong()
        {
            var list = db.ChiTietLuongs.ToList();
            return View(list);
        }
        public ActionResult XuatFileLuong(String id)
        {
            //var l = db.ChiTietLuongs.Where(n => n.MaChiTietBangLuong == id).ToList();
            var ds = db.ChiTietLuongs.ToList();
            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Mã nhân viên", typeof(String));
            dt.Columns.Add("Lương cơ bản", typeof(String));
            dt.Columns.Add("BHXH", typeof(String));
            dt.Columns.Add("Phụ cấp", typeof(String));
            dt.Columns.Add("Thuế thu nhập", typeof(String));
            dt.Columns.Add("Ngày nhận lương", typeof(String));
            dt.Columns.Add("Thực lãnh", typeof(String));

            //Add in the datarow


            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["Mã nhân viên"] = item.MaNhanVien;
                newRow["Lương cơ bản"] = item.LuongCoBan;
                newRow["BHXH"] = item.BHXH;
                newRow["Phụ cấp"] = item.PhuCap;
                newRow["Thuế thu nhập"] = item.ThueThuNhap;
                newRow["Ngày nhận lương"] = item.NgayNhanLuong;
                newRow["Thực lãnh"] = item.TongTienLuong;


                dt.Rows.Add(newRow);
            }

            //====================================================
            var gv = new GridView();
            //gv.DataSource = ds;
            gv.DataSource = dt;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach-luong.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/admin/QuanLyLuong");
        }


        public ActionResult QuaTrinhTangLuong(String id)
        {
            var tangluong = db.CapNhatLuongs.Where(n => n.MaNhanVien == id).ToList();
            
            if (tangluong != null)
            {
                return View(tangluong);
            }
            return Redirect("/admin/QuanLyLuong");
        }// EndEv
    }   //end class
}
