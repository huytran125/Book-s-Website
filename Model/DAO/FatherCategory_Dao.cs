using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
	public class FatherCategory_Dao
	{
		WebSach_final db = null;
		public FatherCategory_Dao()
		{
			db = new WebSach_final();
		}
		public IEnumerable<Father_category> GetFatherCategorys()
		{
			return db.Father_category.AsEnumerable();
		}
		public void Edit(String Id, String name)
		{
			var book = db.Father_category.Find(Convert.ToInt64(Id));
			book.Name = name;

			
			db.SaveChanges();
		}
		public void Add(String name)
		{
			Father_category book = new Father_category();
			book.Name = name;

			db.Father_category.Add(book);
			db.SaveChanges();
		}
	}
}
