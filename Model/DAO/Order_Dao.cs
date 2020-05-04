using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
	public class Order_Dao
	{
		WebSach_final db = null;
		public Order_Dao()
		{
			db = new WebSach_final();
		}
		public long Add(Order order)
		{
			db.Orders.Add(order);
			db.SaveChanges();
			return order.Id;
		}
		public Order Find(long Id)
		{
			return db.Orders.Find(Id);
		}
		public void Edit(long Id,string diachi)
		{
			var z= db.Orders.Find(Id);
			z.Address = diachi;
			z.status = false;
			db.SaveChanges();
		}
		public void Edit2(long Id, long worker)
		{
			
			var z = db.Orders.Find(Id);
			z.Id_Shipper = worker;
			
			
			db.SaveChanges();
		}
		public void Edit3(long Id)
		{

			var z = db.Orders.Find(Id);
			
			z.status = true;

			db.SaveChanges();
		}
		public IEnumerable<Order> FindList(long IdCus)
		{
			try
			{
				var h= db.Orders.Where(x => x.Id_customer==IdCus).AsEnumerable();
				return h;
			}
			catch (Exception e)
			{
				return null;
			}
			
		}
		public IEnumerable<Order> FindListX()
		{
			try
			{
				var h = db.Orders.Where(x => x.Id_Shipper==null).AsEnumerable();
				return h;
			}
			catch (Exception e)
			{
				return null;
			}

		}
		public IEnumerable<Order> FindListXY(long IdShip)
		{
			try
			{
				var h = db.Orders.Where(x => x.Id_Shipper == IdShip && x.status == false).AsEnumerable();
				return h;
			}
			catch (Exception e)
			{
				return null;
			}

		}
		public IEnumerable<Order> FindListXYZ(long IdShip)
		{
			try
			{
				var h = db.Orders.Where(x => x.Id_Shipper == IdShip&& x.status==true).AsEnumerable();
				return h;
			}
			catch (Exception e)
			{
				return null;
			}

		}
	}
}
