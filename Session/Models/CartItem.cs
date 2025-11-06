using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session.Models
{
    public class CartItem
    {
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        DuLieu data = new DuLieu();

        // Hàm tạo cho giỏ hàng
        public CartItem(int MaSach)
        {
            var sach = data.tblSanPhams.Single(n => n.MaSanPham == MaSach.ToString());

            if (sach != null)
            {
                iMaSach = MaSach;
                sTenSach = sach.TenSP;
                sAnhBia = sach.HinhAnh;
                dDonGia = double.Parse(sach.DonGia.ToString());
                iSoLuong = 1;
            }
        }
    }
    public class GioHang
    {
        public List<CartItem> lst;

        // Hàm tạo cho giỏ hàng
        public GioHang()
        {
            lst = new List<CartItem>();
        }

        public GioHang(List<CartItem> lstGH)
        {
            lst = lstGH;
        }

        // Tính số mặt hàng
        public int SoMatHang()
        {
            return lst.Count;
        }

        // Tính tổng số lượng mặt hàng
        public int TongSLHang()
        {
            return lst.Sum(n => n.iSoLuong);
        }

        // Tính tổng thành tiền
        public double TongThanhTien()
        {
            return lst.Sum(n => n.ThanhTien);
        }

        // Thêm sản phẩm
        public int Them(int iMaSach)
        {
            // Kiểm tra sản phẩm có trong ds chưa??
            CartItem sanpham = lst.Find(n => n.iMaSach == iMaSach);

            if (sanpham == null) // chưa có
            {
                CartItem sach = new CartItem(iMaSach); // tạo mới
                if (sach == null)
                    return -1;

                lst.Add(sach);
                return 1;
            }
            else // có rồi
            {
                sanpham.iSoLuong++; // tăng số lượng lên 1
                return 1;
            }
        }

        // Xóa sản phẩm
        public void Xoa(int iMaSach)
        {
            CartItem sanpham = lst.Find(n => n.iMaSach == iMaSach);
            if (sanpham != null)
            {
                lst.Remove(sanpham);
            }
        }

        // Sửa số lượng
        public void Sua(int iMaSach, int soLuong)
        {
            CartItem sanpham = lst.Find(n => n.iMaSach == iMaSach);
            if (sanpham != null)
            {
                sanpham.iSoLuong = soLuong;
            }
        }
    }
}