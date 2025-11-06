using Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class DatHangController : Controller
    {
        DuLieu data = new DuLieu();
        // GET: DatHang
        public ActionResult ThemMatHang(int msp)
        {
            var kh = Session["kh"] as tblKhachHang;
            if (kh == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
                gh = new GioHang();

            int kq = gh.Them(msp);
            Session["gh"] = gh;

            return RedirectToAction("DsSanPham", "Home");
        }

        public ActionResult XemGioHang()
        {
            GioHang gh = (GioHang)Session["gh"];
            return View(gh);
        }

        public ActionResult ChiTietDonHang(string mahd)
        {
            var hoaDon = data.tblHoaDons
                .Include("tblChiTiets.tblSanPham")
                .FirstOrDefault(h => h.MaHoaDon == mahd);

            if (hoaDon == null)
            {
                return HttpNotFound();
            }

            return View(hoaDon);
        }

        public ActionResult TaoDonDatHang()
        {
            GioHang gh = (GioHang)Session["gh"];
            tblKhachHang kh = (tblKhachHang)Session["kh"];

            if (kh == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (gh == null || gh.SoMatHang() == 0)
            {
                return RedirectToAction("XemGioHang");
            }

            ViewBag.GioHang = gh;
            ViewBag.KhachHang = kh;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoDonDatHang(FormCollection col)
        {
            GioHang gh = (GioHang)Session["gh"];
            tblKhachHang kh = (tblKhachHang)Session["kh"];

            if (kh == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }

            if (gh == null || gh.SoMatHang() == 0)
            {
                return RedirectToAction("XemGioHang");
            }

            // Tạo hóa đơn mới
            tblHoaDon hd = new tblHoaDon();
            //Xử lý id
            var lastHD = data.tblHoaDons.OrderByDescending(h => h.MaHoaDon.Trim()).Select(h => h.MaHoaDon.Trim()).FirstOrDefault();

            int nextId = 1;

            if (!string.IsNullOrEmpty(lastHD))
            {
                if (int.TryParse(lastHD, out int lastId))
                {
                    nextId = lastId + 1;
                }
            }

            hd.MaHoaDon = nextId.ToString();

            hd.NgayHoaDon = string.IsNullOrEmpty(col["txtDate"]) ? DateTime.Now : DateTime.Parse(col["txtDate"]);
            hd.MaKH = kh.MaKhachHang;

            data.tblHoaDons.Add(hd);
            data.SaveChanges();

            // Lưu chi tiết đơn hàng
            foreach (var item in gh.lst)
            {
                tblChiTiet ct = new tblChiTiet();
                ct.MaHD = hd.MaHoaDon;
                ct.MaSP = item.iMaSach.ToString();
                ct.SoLuong = item.iSoLuong;

                data.tblChiTiets.Add(ct);

                // Cập nhật số lượng tồn
                var sanpham = data.tblSanPhams.Find(item.iMaSach.ToString());
                if (sanpham != null)
                {
                    sanpham.SoLuongTon -= item.iSoLuong;
                }
            }

            data.SaveChanges();

            // Xóa giỏ hàng sau khi đặt hàng thành công
            Session["gh"] = null;

            ViewBag.ThongBao = "Đơn hàng của quý khách đã được chúng tôi ghi nhận. Chúng tôi sẽ liên hệ quý khách trong thời gian sớm nhất và giao hàng đúng hẹn.";

            return View("XemGioHang");
        }

        public ActionResult Xoa(int msp)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh != null)
            {
                gh.Xoa(msp);
                Session["gh"] = gh;
            }
            return RedirectToAction("XemGioHang");
        }

        public ActionResult Sua(int msp, int sl)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh != null)
            {
                gh.Sua(msp, sl);
                Session["gh"] = gh;
            }
            return RedirectToAction("XemGioHang");
        }
    }
}