using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
public	class OrderDetail_Dao
	{
		WebSach_final db = null;
		public OrderDetail_Dao()
		{
			db = new WebSach_final();
		}
		public Order_detail Add(Order_detail order_Details)
		{
			
				db.Order_detail.Add(order_Details);
			
			db.SaveChanges();
			return order_Details;
		}
		public IEnumerable<Order_detail> ListOrder(long Id)
		{
			return db.Order_detail.Where(x => x.Id_order == Id).AsEnumerable();
		}
	}



}
