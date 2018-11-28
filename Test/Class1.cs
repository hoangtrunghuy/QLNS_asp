using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class Class1
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        public IEnumerable GetUser()
        {
            return db.NhanViens.Where(x => x.MaNhanVien != "admin" && x.TrangThai == true).ToList();
        }

        public string Them(UserValidate nv)
        {
            Luong luong = new Luong();
            HopDong hd = new HopDong();
            NhanVien nvAdd = new NhanVien();
            nvAdd.MaNhanVien = nv.MaNhanVien;
            nvAdd.MatKhau = nv.MatKhau;
            nvAdd.HoTen = nv.HoTen;
            nvAdd.NgaySinh = nv.NgaySinh;
            nvAdd.QueQuan = nv.QueQuan;
            nvAdd.GioiTinh = nv.GioiTinh;
            nvAdd.DanToc = nv.DanToc;
            nvAdd.MaChucVuNV = nv.MaChucVuNV;
            nvAdd.MaPhongBan = nv.MaPhongBan;
            nvAdd.MaChuyenNganh = nv.MaChuyenNganh;
            nvAdd.MaTrinhDoHocVan = nv.MaTrinhDoHocVan;
            nvAdd.MaHopDong = nv.MaNhanVien;
            nvAdd.TrangThai = true;
            nvAdd.HinhAnh = "icon.jpg";

            //add hop dong
            hd.MaHopDong = nv.MaNhanVien;
            hd.NgayBatDau = DateTime.Now.Date;

            //tao bang luong
            luong.MaNhanVien = nv.MaNhanVien;
            luong.LuongToiThieu = 1150000;
            luong.BHXH = 8;
            luong.BHYT = 1.5;
            luong.BHTN = 1;
            var trinhdo = db.TrinhDoHocVans.Where(n => n.MaTrinhDoHocVan.Equals(nv.MaTrinhDoHocVan)).FirstOrDefault();
            var chucvu = db.ChucVuNhanViens.Where(n => n.MaChucVuNV.Equals(nv.MaChucVuNV)).SingleOrDefault();

            if (trinhdo.MaTrinhDoHocVan.Equals(nv.MaTrinhDoHocVan))
            {
                luong.HeSoLuong = (double)trinhdo.HeSoBac;
            }


            if (chucvu.MaChucVuNV.Equals(nv.MaChucVuNV))
            {
                if (chucvu.HSPC != null)
                {
                    luong.PhuCap = (double)chucvu.HSPC;
                }
                else
                { luong.PhuCap = 0; }
            }



            // tmp.Image = "~/Content/images/icon.jpg";
            db.NhanViens.Add(nvAdd);
            db.HopDongs.Add(hd);

            db.Luongs.Add(luong);
            // @ViewBag.add = "Đăng ký thành công";
            db.SaveChanges();

            return "<div class='alert alert-success'>Them thanh cong</div>";
        }
    }
}
