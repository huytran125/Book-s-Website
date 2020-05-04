using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using ThuVienSach.Common;

namespace ThuVienSach.Areas.Shipper.Controllers
{
    public class ShipController : BaseController
    {
        // GET: Shipper/Ship
        public ActionResult Index()
        {
			Order_Dao order_Dao = new Order_Dao();
			var x = order_Dao.FindListX();
            return View(x);
        }
		public ActionResult Change(long Id)
		{
			Worker_Dao worker_dao = new Worker_Dao();
			Order_Dao order_Dao = new Order_Dao();

			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			Worker worker = worker_dao.Find(session.UserId);
			order_Dao.Edit2(Id, worker.Id);
			return RedirectToAction("Receive", "Ship", new { area = "Shipper" });
			
		}
		public ActionResult Receive()
		{
			Worker_Dao worker_dao = new Worker_Dao();

			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			Worker worker = worker_dao.Find(session.UserId);

			Order_Dao order_Dao = new Order_Dao();
			var x = order_Dao.FindListXY(worker.Id);
			return View(x);
		}
		public ActionResult Change2(long Id)
		{
			Worker_Dao worker_dao = new Worker_Dao();
			Order_Dao order_Dao = new Order_Dao();

			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			Worker worker = worker_dao.Find(session.UserId);
			order_Dao.Edit3(Id);
			return RedirectToAction("Receive2", "Ship", new { area = "Shipper" });

		}
		public ActionResult Receive2()
		{
			Worker_Dao worker_dao = new Worker_Dao();

			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			Worker worker = worker_dao.Find(session.UserId);

			Order_Dao order_Dao = new Order_Dao();
			var x = order_Dao.FindListXYZ(worker.Id);
			return View(x);
		}
	}
}