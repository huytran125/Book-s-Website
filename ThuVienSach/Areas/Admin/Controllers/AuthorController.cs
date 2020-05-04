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
    public class AuthorController : Controller
    {
        // GET: Admin/Author
        public ActionResult Index()
        {
			BookModel model = new BookModel();
			model.setListAuthors();
			model.setListCategory();
			model.setListFatherCategorys();

			return View(model);
        }
		public ActionResult Edit(int Id,String name,String description)
		{
			Author_Dao dao = new Author_Dao();
			dao.Edit(Id.ToString(),name, description);
			return RedirectToAction("Index", "Author", new { Area = "Admin" });

		}
		public ActionResult Add(String name, String description)
		{
			Author_Dao dao = new Author_Dao();
			dao.Add( name, description);
			return RedirectToAction("Index", "Author", new { Area = "Admin" });

		}
		public ActionResult Delete(int Id)
		{
			Author_Dao dao = new Author_Dao();
			dao.Delete(Id);
			return RedirectToAction("Index", "Author", new { Area = "Admin" });
		}

	}
}