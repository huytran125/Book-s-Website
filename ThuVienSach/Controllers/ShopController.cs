using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Areas.Admin.Models;
using Model.EF;
using Model.DAO;

namespace ThuVienSach.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(int page = 1, int pageSize = 9)
        {
			BookModel model = new BookModel();
			model.setListBooks(page, pageSize);
			model.setListCategory();
			model.setListFatherCategorys();
			return View(model);
        }
		public ActionResult Detail(int Idfather, int Idson = 0)
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