using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ThuVienSach.Common;

namespace ThuVienSach.Controllers
{
    public class BaseController : Controller
    {
		// GET: Base
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			if (session == null)
			{

				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
			}

			base.OnActionExecuting(filterContext);
		}
	}
}