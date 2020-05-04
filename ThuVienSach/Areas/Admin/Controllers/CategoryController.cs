using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Areas.Admin.Models;
using Model.DAO;
using Model.EF;

namespace ThuVienSach.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int father)
        {
			BookModel model = new BookModel();
			model.setListAuthors();
			model.setListCategory2(father);
			model.setListFatherCategorys();

			return View(model);
        }
		public ActionResult Edit(int Id, String name, String description,int father)
		{
			CategoryDao dao = new CategoryDao();
			dao.Edit(Id.ToString(), name);
			return RedirectToAction("Index", "Category", new { Area = "Admin",father=father });

		}
		public ActionResult Add(String name, String description, int father)
		{
			CategoryDao dao = new CategoryDao();
			dao.Add(name,father);
			return RedirectToAction("Index", "Category", new { Area = "Admin",father=father});

		}
		
	}
}