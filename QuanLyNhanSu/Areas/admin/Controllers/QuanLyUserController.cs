using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;
//using cExcel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using User;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyUserController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        Employee user = new Employee();

        // GET: /admin/QuanLyUser/
        public ActionResult Index()
        {
            //var user = db.NhanViens.Where(x => x.MaNhanVien != "admin" && x.TrangThai == true).ToList();
            //return View(user);

            return View(user.GetUser());
        }


        public ActionResult XoaUser(String id)
        {

            //var a = db.NhanViens.Where(x => x.MaNhanVien == id).SingleOrDefault();
            //var hd = db.HopDongs.Where(x => x.MaHopDong == id).SingleOrDefault();
            //var luong = db.Luongs.Where(x => x.MaNhanVien == id).SingleOrDefault();
            //var ctLuong = db.ChiTietLuongs.Where(x => x.MaNhanVien == id).ToList();
            //foreach (var item in ctLuong)
            //{
            //    db.ChiTietLuongs.Remove(item);
            //}

            //db.Luongs.Remove(luong);
            //db.NhanViens.Remove(a);
            //db.HopDongs.Remove(hd);

            //db.SaveChanges();
            user.DeleteUser(id);

            return Redirect("~/admin/QuanLyUser");
        }
        [HttpGet]
        public ActionResult UpdateUser(String id)
        {
            //var user = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            //UserValidate userVal = new UserValidate();

            //userVal.MaNhanVien = user.MaNhanVien;
            //userVal.HoTen = user.HoTen;
            //userVal.MatKhau = user.MatKhau;
            //userVal.GioiTinh = user.GioiTinh;

            //userVal.MaChucVuNV = user.MaChucVuNV;
            //userVal.QueQuan = user.QueQuan;
            //userVal.HinhAnh = user.HinhAnh;
            //userVal.DanToc = user.DanToc;
            //userVal.sdt_NhanVien = user.sdt_NhanVien;
            //userVal.MaHopDong = user.MaHopDong;

            //userVal.NgaySinh = user.NgaySinh;
            //userVal.TrangThai = user.TrangThai;
            //userVal.MaChuyenNganh = user.MaChuyenNganh;
            //userVal.MaTrinhDoHocVan = user.MaTrinhDoHocVan;
            //userVal.MaPhongBan = user.MaPhongBan;

            //userVal.CMND = user.CMND;
            //userVal.XacNhanMatKhau = user.MatKhau;

            return View(user.GetUser(id));
            //  return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserValidate upUser)
        {
            //upUser.XacNhanMatKhau = upUser.MatKhau;
            //var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();

            if (ModelState.IsValid)
            {
                //var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();


                //CapNhatTrinhDoHocVan capNhat = new CapNhatTrinhDoHocVan();
                //capNhat.MaNhanVien = upUser.MaNhanVien;
                //capNhat.NgayCapNhat = DateTime.Now.Date;
                //capNhat.MaTrinhDoTruoc = us.MaTrinhDoHocVan;
                //capNhat.MaTrinhDoCapNhat = upUser.MaTrinhDoHocVan;

                //us.MaNhanVien = upUser.MaNhanVien;
                //us.HoTen = upUser.HoTen;
                //us.MatKhau = upUser.MatKhau;
                //us.GioiTinh = upUser.GioiTinh;

                //us.MaChucVuNV = upUser.MaChucVuNV;
                //us.QueQuan = upUser.QueQuan;
                //us.HinhAnh = upUser.HinhAnh;
                //us.DanToc = upUser.DanToc;
                //us.sdt_NhanVien = upUser.sdt_NhanVien;
                //us.MaHopDong = upUser.MaHopDong;

                //us.NgaySinh = upUser.NgaySinh;
                //us.TrangThai = upUser.TrangThai;
                //us.MaChuyenNganh = upUser.MaChuyenNganh;
                //us.MaTrinhDoHocVan = upUser.MaTrinhDoHocVan;
                //us.MaPhongBan = upUser.MaPhongBan;
                //us.CMND = upUser.CMND;

                //var trinhdo = db.TrinhDoHocVans.Where(n => n.MaTrinhDoHocVan.Equals(us.MaTrinhDoHocVan)).FirstOrDefault();

                //var luong = db.Luongs.Where(n => n.MaNhanVien.Equals(us.MaNhanVien)).FirstOrDefault();

                //if (trinhdo.HeSoBac != null)
                //{
                //    luong.HeSoLuong = luong.HeSoLuong < (double)trinhdo.HeSoBac ? (double)trinhdo.HeSoBac : luong.HeSoLuong;
                //}
                //else
                //{ luong.HeSoLuong = 1; }



                //db.CapNhatTrinhDoHocVans.Add(capNhat);

                //db.SaveChanges();

                
                ViewBag.thongbao = user.UpdateUser(upUser);
                return Redirect("/admin/QuanLyUser");


            }
            return View(upUser);

        }//end update

        [HttpGet]

        public ActionResult ThemUser()
        {
            //var chucvu = db.ChucVuNhanViens.ToList();
            //var phongban = db.PhongBans.ToList();
            //var hopdong = db.HopDongs.ToList();
            //var chuyennganh = db.ChuyenNganhs.ToList();
            //var trinhdo = db.TrinhDoHocVans.ToList();
            //List<ChucVuNhanVien> list = chucvu;

            return View(new UserValidate());
        }


        [HttpPost]
        public ActionResult ThemUser(UserValidate nv)
        {
            nv.XacNhanMatKhau = nv.MatKhau;
            if (ModelState.IsValid)
            {
                ViewBag.err = String.Empty;
                var checkMaNhanVien = db.NhanViens.Any(x => x.MaNhanVien == nv.MaNhanVien);

                if (checkMaNhanVien)
                {
                    ViewBag.err = "tài khoản đã tồn tại";
                    //ModelState.AddModelError("MaNhanVien", "Mã tài khoản đã tồn tại");
                    return View(nv);
                }
                else
                {
                    ViewBag.error = user.AddUser(nv);
                    //xác thực tài khoản trong ứng dụng
                    //FormsAuthentication.SetAuthCookie(nvAdd.MaNhanVien, false);
                    //trả về trang quản lý

                    return Redirect("/admin/QuanLyUser");
                }
            }
            else
            {

                return View(nv);
            }
        }//end add nhan vien

        public ActionResult QuaTrinhCongTac(String id)
        {
            var ds = db.LuanChuyenNhanViens.Where(n => n.MaNhanVien == id).ToList();
            return View(ds);
        }

        public ActionResult XuatFileExel()
        {

            var ds = db.NhanViens.Where(n => n.MaNhanVien != "admin" && n.MaHopDong != null).ToList();
            var phong = db.PhongBans.ToList();
            var gv = new GridView();
            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Họ tên", typeof(String));

            dt.Columns.Add("Phòng ban", typeof(String));
            dt.Columns.Add("Chức vụ", typeof(String));
            dt.Columns.Add("Học vấn", typeof(String));
            dt.Columns.Add("Chuyên ngành", typeof(String));

            //Add in the datarow


            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["Họ tên"] = item.HoTen;
                newRow["Phòng ban"] = item.PhongBan.TenPhongBan;
                newRow["Chức vụ"] = item.ChucVuNhanVien.TenChucVu;
                newRow["Học vấn"] = item.TrinhDoHocVan.TenTrinhDo;
                newRow["Chuyên ngành"] = item.ChuyenNganh.TenChuyenNganh;

                dt.Rows.Add(newRow);
            }

            //====================================================
            gv.DataSource = dt;
            // gv.DataSource = ds;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/admin/QuanLyUser");
        }

        public ActionResult QuaTrinhHoc(String id)
        {
            var ht = db.CapNhatTrinhDoHocVans.Where(n => n.MaNhanVien == id).ToList();
            return View(ht);
        }

    }   //end lass
}