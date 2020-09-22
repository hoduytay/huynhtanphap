using QLSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSV.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            var listNhanVien = new DBContext().NhanViens.ToList();
            return View(listNhanVien);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int id)
        {
            var context = new DBContext();
            var deleting = context.NhanViens.Find(id);
            return View(deleting);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            var context = new DBContext();
            var chucvuselect = new SelectList(context.ChucVus, "Id", "Tên chức vụ");
            ViewBag.IdChucVu = chucvuselect;

            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBContext();
                context.NhanViens.Add(model);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new DBContext();
            var editing = context.NhanViens.Find(id);
            var chucvuselect = new SelectList(context.ChucVus, "Id", "Tên chức vụ",editing.IdChucVu);
            ViewBag.IdChucVu = chucvuselect;

            return View(editing);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBContext();
                var oldItem = context.NhanViens.Find(model.Id);
                oldItem.HoVaTen = model.HoVaTen;
                oldItem.GioiTinh = model.GioiTinh;
                oldItem.Email = model.Email;
                oldItem.IdChucVu = model.IdChucVu;
                oldItem.SoCanCuoc = model.SoCanCuoc;
                oldItem.SoDienThoai = model.SoDienThoai;
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {


            var context = new DBContext();
            var deleting = context.NhanViens.Find(id);

            return View(deleting);
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBContext();
                var deleting = context.NhanViens.Find(id);
                context.NhanViens.Remove(deleting);
                context.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
