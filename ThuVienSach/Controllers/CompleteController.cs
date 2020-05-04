using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using ThuVienSach.Common;

namespace ThuVienSach.Controllers
{
    public class CompleteController : Controller
    {
        // GET: Complete
        public ActionResult Index()
        {
			CustomesDao customesDao = new CustomesDao();
			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			Order_Dao order_Dao = new Order_Dao();
			var x=order_Dao.FindList(customesDao.FindWithIDAccount(Convert.ToInt32(session.UserId)).Id);
			foreach(var item in x)
			{
				long n = item.Id;
			}
			return View(x);
        }
		public ActionResult Complete()
		{
			Book_Dao dao = new Book_Dao();
			OrderDetail_Dao orderDetail_Dao = new OrderDetail_Dao();
			CustomesDao customesDao = new CustomesDao();
			var session = (UserLogin)Session[Common.CommonConstaint.USER_SESSION];
			var cart = (List<Order_detail>)Session["Order_Detail"];
			Order_Dao order_Dao = new Order_Dao();
			Order order = new Order();
			order.Id_customer = customesDao.FindWithIDAccount(Convert.ToInt32(session.UserId)).Id;
			long total=0;
			foreach (var item in cart)
			{
				total = total + Convert.ToInt64(item.Money);

			}
			order.total = total + 15000 + (total * 10) / 100;
			long x=order_Dao.Add(order);
			Order z = order_Dao.Find(x);
			foreach (var item in cart)
			{
				Order_detail tam = new Order_detail();
				tam.Id_order = x;
				tam.Id_book = item.Id_book;
				tam.Money = item.Money;
				tam.Number = item.Number;
				
				orderDetail_Dao.Add(tam);
				z.Order_detail.Add(tam);


			}
			Session.Remove("Order_Detail");
			
			z.Customer = customesDao.FindWithIDAccount(Convert.ToInt32(session.UserId));

			return View(z);
		}
		public ActionResult Complete2(int Id,String diachi)
		{
			Order_Dao order_Dao = new Order_Dao();
			order_Dao.Edit(Convert.ToInt64(Id),diachi);
			
			return RedirectToAction("Index", "Complete");
		}
    }
}