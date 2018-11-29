using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Collections;

namespace User
{
    public class Employee
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public IEnumerable GetUser()
        {
            return db.NhanViens.Where(x => x.MaNhanVien != "admin" && x.TrangThai == true).ToList();
        }
        public string AddUser(UserValidate nv)
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
        public string DeleteUser(string id)
        {
            var a = db.NhanViens.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var hd = db.HopDongs.Where(x => x.MaHopDong == id).SingleOrDefault();
            var luong = db.Luongs.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var ctLuong = db.ChiTietLuongs.Where(x => x.MaNhanVien == id).ToList();
            foreach (var item in ctLuong)
            {
                db.ChiTietLuongs.Remove(item);
            }

            db.Luongs.Remove(luong);
            db.NhanViens.Remove(a);
            db.HopDongs.Remove(hd);

            db.SaveChanges();
            return "<div class='alert alert-success'>Xoa thanh cong</div>";
        }
        public UserValidate GetUser(string id)
        {
            var user = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            UserValidate userVal = new UserValidate();

            userVal.MaNhanVien = user.MaNhanVien;
            userVal.HoTen = user.HoTen;
            userVal.MatKhau = user.MatKhau;
            userVal.GioiTinh = user.GioiTinh;

            userVal.MaChucVuNV = user.MaChucVuNV;
            userVal.QueQuan = user.QueQuan;
            userVal.HinhAnh = user.HinhAnh;
            userVal.DanToc = user.DanToc;
            userVal.sdt_NhanVien = user.sdt_NhanVien;
            userVal.MaHopDong = user.MaHopDong;

            userVal.NgaySinh = user.NgaySinh;
            userVal.TrangThai = user.TrangThai;
            userVal.MaChuyenNganh = user.MaChuyenNganh;
            userVal.MaTrinhDoHocVan = user.MaTrinhDoHocVan;
            userVal.MaPhongBan = user.MaPhongBan;

            userVal.CMND = user.CMND;
            userVal.XacNhanMatKhau = user.MatKhau;

            return userVal;

        }

        public string UpdateUser(UserValidate upUser)
        {
            upUser.XacNhanMatKhau = upUser.MatKhau;
            var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();

            if (us != null)
            {
                CapNhatTrinhDoHocVan capNhat = new CapNhatTrinhDoHocVan();
                capNhat.MaNhanVien = upUser.MaNhanVien;
                capNhat.NgayCapNhat = DateTime.Now.Date;
                capNhat.MaTrinhDoTruoc = us.MaTrinhDoHocVan;
                capNhat.MaTrinhDoCapNhat = upUser.MaTrinhDoHocVan;

                us.MaNhanVien = upUser.MaNhanVien;
                us.HoTen = upUser.HoTen;
                us.MatKhau = upUser.MatKhau;
                us.GioiTinh = upUser.GioiTinh;

                us.MaChucVuNV = upUser.MaChucVuNV;
                us.QueQuan = upUser.QueQuan;
                us.HinhAnh = upUser.HinhAnh;
                us.DanToc = upUser.DanToc;
                us.sdt_NhanVien = upUser.sdt_NhanVien;
                us.MaHopDong = upUser.MaHopDong;

                us.NgaySinh = upUser.NgaySinh;
                us.TrangThai = upUser.TrangThai;
                us.MaChuyenNganh = upUser.MaChuyenNganh;
                us.MaTrinhDoHocVan = upUser.MaTrinhDoHocVan;
                us.MaPhongBan = upUser.MaPhongBan;
                us.CMND = upUser.CMND;

                var trinhdo = db.TrinhDoHocVans.Where(n => n.MaTrinhDoHocVan.Equals(us.MaTrinhDoHocVan)).FirstOrDefault();

                var luong = db.Luongs.Where(n => n.MaNhanVien.Equals(us.MaNhanVien)).FirstOrDefault();

                if (trinhdo.HeSoBac != null)
                {
                    luong.HeSoLuong = luong.HeSoLuong < (double)trinhdo.HeSoBac ? (double)trinhdo.HeSoBac : luong.HeSoLuong;
                }
                else
                { luong.HeSoLuong = 1; }



                db.CapNhatTrinhDoHocVans.Add(capNhat);

                db.SaveChanges();

                return "Sửa thành công";
            }
            
            return "Sửa thất bại";
        }
    }
}
