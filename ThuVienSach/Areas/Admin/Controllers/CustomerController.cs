using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Common;

namespace ThuVienSach.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
			CustomesDao dao = new CustomesDao();
			var x = dao.GetList();
			foreach(var item in x)
			{
				
			}
            return View(x);
        }
		public ActionResult Edit(long Id,String name,String address,string phone,string email)
		{
			CustomesDao dao = new CustomesDao();
			dao.Edit(Id, name, address,  phone,  email);
			return RedirectToAction("Index", "Customer");
		}
		public ActionResult Add( String name, String address, string phone, string email,string password)
		{
			CustomesDao dao = new CustomesDao();
			dao.Add(name, address, phone, email,Encryptor.MD5Hash(password));
			return RedirectToAction("Index", "Customer");
		}
	}
}