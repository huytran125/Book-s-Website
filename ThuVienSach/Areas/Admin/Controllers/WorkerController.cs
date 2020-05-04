using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Common;

namespace ThuVienSach.Areas.Admin.Controllers
{
    public class WorkerController : Controller
    {
        // GET: Admin/Worker
        public ActionResult Index()
        {
			Worker_Dao dao = new Worker_Dao();
			var x = dao.GetList();
			foreach (var item in x)
			{

			}
			return View(x);
		}
		public ActionResult Edit(long Id, String name, String address, long type, string email)
		{
			Worker_Dao dao = new Worker_Dao();
			dao.Edit(Id, name, address, type, email);
			return RedirectToAction("Index", "Worker");
		}
		public ActionResult Add(String name, String address, string email, long type, string password)
		{
			Worker_Dao dao = new Worker_Dao();

			dao.Add(name, address, type, email, Encryptor.MD5Hash(password));
			return RedirectToAction("Index", "Worker");
		}


	}
}