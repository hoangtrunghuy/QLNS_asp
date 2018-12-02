using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Collections;

namespace PhongBan
{
    public class Department
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public IEnumerable GetPhongBan()
        {
            return db.PhongBans.ToList();
        }
        public string ChuyenNhanVien(NhanVien nv, LuanChuyenNhanVien fl)
        {
            var nvChuyen = db.NhanViens.Where(n => n.MaNhanVien == nv.MaNhanVien).FirstOrDefault();

            nvChuyen.MaNhanVien = nv.MaNhanVien;
            nvChuyen.HoTen = nv.HoTen;
            nvChuyen.MaChucVuNV = nv.MaChucVuNV;
            nvChuyen.MaPhongBan = fl.PhongBanDen;

            nvChuyen.MatKhau = nv.MatKhau;
            nvChuyen.GioiTinh = nv.GioiTinh;
            nvChuyen.QueQuan = nv.QueQuan;
            nvChuyen.HinhAnh = nv.HinhAnh;
            nvChuyen.DanToc = nv.DanToc;
            nvChuyen.sdt_NhanVien = nv.sdt_NhanVien;
            nvChuyen.MaHopDong = nv.MaHopDong;
            nvChuyen.NgaySinh = nv.NgaySinh;
            nvChuyen.TrangThai = nv.TrangThai;
            nvChuyen.MaChuyenNganh = nv.MaChuyenNganh;
            nvChuyen.MaTrinhDoHocVan = nv.MaTrinhDoHocVan;
            nvChuyen.CMND = nv.CMND;

            //add vao bang luan chuyen nhan vien
            LuanChuyenNhanVien tableChuyen = new LuanChuyenNhanVien();
            tableChuyen.MaNhanVien = nv.MaNhanVien;
            tableChuyen.NgayChuyen = DateTime.Now.Date;
            tableChuyen.PhongBanChuyen = nv.MaPhongBan; //

            tableChuyen.PhongBanDen = fl.PhongBanDen;
            tableChuyen.LyDoChuyen = fl.LyDoChuyen;
            //cap nhat lại phụ cấp chức vụ
            var luong = db.Luongs.Where(n => n.MaNhanVien.Equals(nv.MaNhanVien)).SingleOrDefault();
            var chucvu = db.ChucVuNhanViens.Where(n => n.MaChucVuNV.Equals(nv.MaChucVuNV)).SingleOrDefault();

            if (chucvu.HSPC != null)
            {
                luong.PhuCap = chucvu.HSPC;

            }
            else
            {
                luong.PhuCap = 0;
            }


            //add vao csdl quá trình công tác
            db.LuanChuyenNhanViens.Add(tableChuyen);
            db.SaveChanges();
            return "Chuyen thanh cong";
        }
        public string DeletePhongBan(string id)
        {
            var pb = db.PhongBans.Where(n => n.MaPhongBan == id).FirstOrDefault();

            // những nhân viên phòngban
            var nv = db.NhanViens.Where(n => n.MaPhongBan == id).ToList();

            //danh sách hợp đồng
            var hd = db.HopDongs.ToList();

            /*
             * mã phòng ban
             * mã hợp đồng = mã nhân viên
             */

            foreach (var item in hd)
            {
                foreach (var i in nv)
                {
                    if (item.MaHopDong == i.MaHopDong)
                    {
                        db.NhanViens.Remove(i);
                        db.SaveChanges();
                    }

                }
                db.HopDongs.Remove(item);
                db.SaveChanges();
            }
            if (pb != null)
            {
                db.PhongBans.Remove(pb);
                db.SaveChanges();
            }
            return "Xoa thanh cong";
        }
        public IEnumerable GetPhuCap()
        {
            return db.ChucVuNhanViens.ToList();
        }
        
    }
}
