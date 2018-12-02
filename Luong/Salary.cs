using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Luong
{
    public class Salary
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public IEnumerable GetLuong()
        {
            return db.Luongs.ToList();
        }
        public string UpdateLuong(DAL.Luong luong, CapNhatLuong up)
        {
            var l = db.Luongs.Where(n => n.MaNhanVien == luong.MaNhanVien).FirstOrDefault();
            if (l != null)
            {
                //  l.MaNhanVien = luong.MaNhanVien;
                if (int.Parse(up.LuongSauCapNhat.ToString()) != 0)
                {
                    l.LuongToiThieu = up.LuongSauCapNhat;
                }

                l.BHXH = luong.BHXH == null ? 0 : luong.BHXH;
                l.BHYT = luong.BHYT == null ? 0 : luong.BHYT;
                l.BHTN = luong.BHTN == null ? 0 : luong.BHTN;
                //   l.PhuCap = luong.PhuCap;
                l.ThueThuNhap = luong.ThueThuNhap;
                l.HeSoLuong = luong.HeSoLuong;

                //tao table luu lai moi lan cap nhat luong
                CapNhatLuong capNhat = new CapNhatLuong();
                capNhat.NgayCapNhat = DateTime.Now.Date;
                capNhat.MaNhanVien = luong.MaNhanVien;
                capNhat.LuongHienTai = luong.LuongToiThieu;
                capNhat.LuongSauCapNhat = up.LuongSauCapNhat;
                capNhat.BHXH = luong.BHXH;
                capNhat.BHYT = luong.BHYT;
                capNhat.BHTN = luong.BHTN;
                //  capNhat.PhuCap = luong.PhuCap;
                capNhat.ThueThuNhap = luong.ThueThuNhap;
                capNhat.HeSoLuong = luong.HeSoLuong;

                db.CapNhatLuongs.Add(capNhat);
                db.SaveChanges();
                return "Sua thanh cong";
            }
            return "Sua khong thanh cong";
        }
        public void ThanhToanLuong()
        {
            var luong = db.Luongs.ToList();

            DateTime now = DateTime.Now;
            foreach (var item in luong)
            {
                ChiTietLuong ct = new ChiTietLuong();
                ct.MaChiTietBangLuong = "t" + now.Month.ToString();
                ct.MaNhanVien = item.MaNhanVien;
                var ctl = db.ChiTietLuongs.Where(n => n.MaNhanVien == ct.MaNhanVien).FirstOrDefault();
                //ct.MaChiTietBangLuong = t+dem.ToString();

                double tienthue = 0, phucap = 0;
                double tong = 0;
                item.HeSoLuong = item.HeSoLuong == null ? 0 : item.HeSoLuong;
                ct.LuongCoBan = item.LuongToiThieu * (double)item.HeSoLuong;

                item.BHXH = item.BHXH == null ? 0 : item.BHXH;
                ct.BHXH = item.BHXH * item.LuongToiThieu / 100;

                item.BHYT = item.BHYT == null ? 0 : item.BHYT;
                ct.BHYT = item.BHYT * item.LuongToiThieu / 100;

                item.BHTN = item.BHTN == null ? 0 : item.BHTN;
                ct.BHTN = item.BHTN * item.LuongToiThieu / 100;


                item.PhuCap = item.PhuCap == null ? 0 : item.PhuCap;
                phucap = item.LuongToiThieu * (double)item.PhuCap;
                ct.PhuCap = phucap;


                item.ThueThuNhap = item.ThueThuNhap == null ? 0 : item.ThueThuNhap;
                tienthue = item.LuongToiThieu * (int)item.ThueThuNhap / 100;
                ct.ThueThuNhap = tienthue;

                ct.NgayNhanLuong = DateTime.Now.Date;
                ct.TienThuong = 0;
                ct.TienPhat = 0;
                tong = tong + ct.LuongCoBan - (double)(ct.BHXH + ct.BHYT + ct.BHTN) - (double)ct.ThueThuNhap + (double)ct.PhuCap;
                ct.TongTienLuong = tong.ToString();
                if (ctl == null)
                {
                    db.ChiTietLuongs.Add(ct);
                }
                //ViewBag.ok = "thanh toán thành công";
                db.SaveChanges();
            }
        }
        public string ThanhToanMotNhanVien(string id)
        {
            var nv = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            if (nv != null)
            {
                //tim xem da co trong chi tiet lương chưa
                var ctl = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).FirstOrDefault();
                //tìm bảng lương tương ứng với nhân viên
                var luongthang = db.Luongs.Where(n => n.MaNhanVien == id).FirstOrDefault();
                ChiTietLuong ct = new ChiTietLuong();
                DateTime now = DateTime.Now;
                double tienthue = 0, tong = 0, phucap = 0;

                ct.MaChiTietBangLuong = "t" + now.Month.ToString();
                ct.MaNhanVien = luongthang.MaNhanVien;

                ct.LuongCoBan = luongthang.LuongToiThieu * (double)luongthang.HeSoLuong;

                luongthang.BHXH = luongthang.BHXH == null ? 0 : luongthang.BHXH;
                ct.BHXH = luongthang.BHXH * luongthang.LuongToiThieu / 100;

                luongthang.BHYT = luongthang.BHYT == null ? 0 : luongthang.BHYT;
                ct.BHYT = luongthang.BHYT * luongthang.LuongToiThieu / 100;

                luongthang.BHTN = luongthang.BHTN == null ? 0 : luongthang.BHTN;
                ct.BHTN = luongthang.BHTN * luongthang.LuongToiThieu / 100;

                luongthang.PhuCap = luongthang.PhuCap == null ? 0 : luongthang.PhuCap;
                phucap = luongthang.LuongToiThieu * (double)luongthang.PhuCap;
                ct.PhuCap = phucap;


                luongthang.ThueThuNhap = luongthang.ThueThuNhap == null ? 0 : luongthang.ThueThuNhap;
                tienthue = (double)luongthang.LuongToiThieu * (double)luongthang.ThueThuNhap / 100;
                ct.ThueThuNhap = (double)tienthue;
                ct.NgayNhanLuong = DateTime.Now.Date;
                ct.TienThuong = 0;
                ct.TienPhat = 0;
                tong = tong + ct.LuongCoBan - (double)(ct.BHXH + ct.BHYT + ct.BHTN) - (double)ct.ThueThuNhap + (double)ct.PhuCap;
                ct.TongTienLuong = tong.ToString();
                if (ctl == null)
                {
                    //ViewBag.ok = "thanh toán thành công";
                    db.ChiTietLuongs.Add(ct);
                }
                db.SaveChanges();
            }
            return "Thanh toan khong thanh cong";
        }
    }
}
