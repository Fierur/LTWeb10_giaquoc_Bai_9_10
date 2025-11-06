using Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        DuLieu data = new DuLieu();
        public ActionResult Index()
        {
            tblKhachHang kh = Session["kh"] as tblKhachHang;
            if(kh!=null)
            {
                ViewBag.khachhang = kh;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection col)
        {
            //tblKhachHang kh = data.tblKhachHangs.FirstOrDefault(k => k.TenKH == col["txtName"] && k.MatKhau == col["txtPass"]);
            //if(kh != null)
            //{
            //    Session["kh"] = kh;
            //    return RedirectToAction("Index", "Home");
            //}

            // Gán ra biến trước
            string ten = col["txtName"];
            string mk = col["txtPass"];

            // EF hiểu được vì đây là biến C#
            tblKhachHang kh = data.tblKhachHangs
                .FirstOrDefault(k => k.TenKH == ten && k.MatKhau == mk);

            if (kh != null)
            {
                Session["kh"] = kh;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult DsSanPham()
        {
            var dssp =  data.tblSanPhams.ToList();
            return View(dssp);
        }
        public ActionResult DangXuat()
        {
            Session["kh"] = null;
            Session["gh"] = null;
            return RedirectToAction("Index", "Home");
        }

        


    }
}