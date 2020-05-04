using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Areas.Admin.Models;
using Model.EF;
using Model.DAO;

namespace ThuVienSach.Areas.Admin.Controllers
{
    public class NXBController : Controller
    {
        // GET: Admin/NXB
        public ActionResult Index()
        {
			BookModel model = new BookModel();
			model.setListNXBs();
			model.setListCategory();
			model.setListFatherCategorys();
			return View(model);
		}
		public ActionResult Edit(int Id, String name, String description)
		{
			NXB_Dao dao = new NXB_Dao();
			dao.Edit(Id.ToString(), name, description);
			return RedirectToAction("Index", "NXB", new { Area = "Admin" });

		}
		public ActionResult Add(String name, String description)
		{
			NXB_Dao dao = new NXB_Dao();
			dao.Add(name, description);
			return RedirectToAction("Index", "NXB", new { Area = "Admin" });

		}
		public ActionResult Delete(int Id)
		{
			NXB_Dao dao = new NXB_Dao();
			dao.Delete(Id);
			return RedirectToAction("Index", "NXB", new { Area = "Admin" });
		}
	}
}