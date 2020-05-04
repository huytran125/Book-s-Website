using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThuVienSach.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
			Session.Remove(Common.CommonConstaint.USER_SESSION);
			return RedirectToAction("Index", "Shop");
        }

    }
}