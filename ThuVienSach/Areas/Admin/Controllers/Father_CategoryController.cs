using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Areas.Admin.Models;
using Model.DAO;

namespace ThuVienSach.Areas.Admin.Controllers
{
    public class Father_CategoryController : Controller
    {
        // GET: Admin/Father_Category
        public ActionResult Index()
        {
			BookModel model = new BookModel();
			model.setListAuthors();
			
			model.setListFatherCategorys();

			return View(model);
			
        }
		public ActionResult Edit(int Id, String name)
		{
			FatherCategory_Dao dao = new FatherCategory_Dao();
			dao.Edit(Id.ToString(), name);
			return RedirectToAction("Index", "Category", new { Area = "Admin"});

		}
		public ActionResult Add(String name)
		{
			FatherCategory_Dao dao = new FatherCategory_Dao();
			dao.Add(name);
			return RedirectToAction("Index", "Category", new { Area = "Admin" });

		}
	}
}