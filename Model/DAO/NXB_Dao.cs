using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
	public class NXB_Dao
	{
		WebSach_final db = null;
		public NXB_Dao()
		{
			db = new WebSach_final();
		}
		public IEnumerable<NXB> GetNXBs()
		{
			return db.NXBs.AsEnumerable();
		}
		public void Edit(String Id, String name, string description)
		{
			var book = db.NXBs.Find(Convert.ToInt64(Id));
			book.Name = name;

			book.Information = description;
			db.SaveChanges();
		}
		public void Add(String name, string description)
		{
			NXB book = new NXB();
			book.Name = name;

			book.Information = description;
			db.NXBs.Add(book);
			db.SaveChanges();
		}
		public void Delete(int Id)
		{
			var book = db.NXBs.Find(Convert.ToInt64(Id));
			var product = db.Books.Where(x => x.Id_NXB == Id);
			foreach (var item in product)
			{
				item.Id_NXB = 2;
			}
			db.NXBs.Remove(book);
			db.SaveChanges();
		}
	}
}
