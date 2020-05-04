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
    public class BookController : Controller
    {
        // GET: Admin/Book
        public ActionResult Index(int page = 1, int pageSize = 9)
        {
			BookModel model = new BookModel();
			model.setListBooks(page, pageSize);
			model.setListCategory();
			model.setListFatherCategorys();
			model.setListNXBs();
			model.setListAuthors();
		
            return View(model);
        }
		public ActionResult Edit(String Id,String name,long price,string son,long number,string author,string NXB,long page,string description)
		{

			Book_Dao dao = new Book_Dao();
			dao.Edit(Id, name, price, son, number, author, NXB, page, description);
			return RedirectToAction("Index", "Book", new { Area="Admin"});
		}
		public ActionResult Add(String name, long price, string son, long number, string author, string NXB, long page, string description)
		{
			Book_Dao dao = new Book_Dao();
			dao.Add(name, price, son, number, author, NXB, page, description);
			return RedirectToAction("Index", "Book", new { Area = "Admin" });
		}
		public ActionResult Detail(int Idfather, int Idson=0)
		{
			BookModel model = new BookModel();
			model.setListBooks2(Idfather, Idson);
			model.setListCategory();
			model.setListFatherCategorys();
			model.setListNXBs();
			model.setListAuthors();

			return View(model);
		}
		public ActionResult Search(String search)
		{
			BookModel model = new BookModel();
			model.setListBooks3(search);
			model.setListCategory();
			model.setListFatherCategorys();
			model.setListNXBs();
			model.setListAuthors();

			return View(model);
		}

	}
}