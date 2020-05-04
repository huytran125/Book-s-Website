using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Common;
using Model.EF;
using Model.DAO;

namespace ThuVienSach.Controllers
{
    public class OrderController : BaseController
    {
		// GET: Order
		
		public ActionResult Index()
		{
			if ((List<Order_detail>)Session["Order_Detail"] == null)
			{
				
			}
			else
			{
				
			}
			return View((List<Order_detail>)Session["Order_Detail"]);
		}
		[HttpPost]
		public ActionResult Index2(int IdBook, int number)
		{
			if ((List<Order_detail>)Session["Order_Detail"] == null)
			{
				Book_Dao dao = new Book_Dao();
				List<Order_detail> order_DetailList = new List<Order_detail>();
				Order_detail order_Detail = new Order_detail();
				order_Detail.Id_book = IdBook;
				order_Detail.Number = number;
				order_Detail.Book = dao.FindBook(IdBook);
				order_Detail.Money = order_Detail.Book.Price * order_Detail.Number;
				order_DetailList.Add(order_Detail);

				Session.Add("Order_Detail", order_DetailList);
			}
			else
			{
				Book_Dao dao = new Book_Dao();
				Order_detail order_Detail = new Order_detail();
				order_Detail.Id_book = IdBook;
				order_Detail.Number = number;
				order_Detail.Book = dao.FindBook(IdBook);
				order_Detail.Money = order_Detail.Book.Price * order_Detail.Number;
				var cart = (List<Order_detail>)Session["Order_Detail"];
				cart.Add(order_Detail);
			}
			return View("Index",(List<Order_detail>)Session["Order_Detail"]);
		}
		public ActionResult Delete(int IdBook)
		{
			
			var cart = (List<Order_detail>)Session["Order_Detail"];
			var temp=cart.Where(x => x.Id_book == IdBook);
			cart.Remove(temp.First());
			
			return View("Index", (List<Order_detail>)Session["Order_Detail"]);
		}
		

	}
}