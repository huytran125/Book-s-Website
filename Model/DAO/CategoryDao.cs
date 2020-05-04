using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
public	class CategoryDao
	{
		WebSach_final db = null;
		public CategoryDao()
		{
			db = new WebSach_final();
		}
		public IEnumerable<Category> GetCategorys()
		{
			return db.Categories.AsEnumerable();
		}
		public IEnumerable<Category> GetCategoryswith(int father)
		{
			var product = db.Categories.Where(x => x.Id_father == father);
			return product;
		}
		public void Edit(String Id, String name)
		{
			var book = db.Categories.Find(Convert.ToInt64(Id));
			book.Name = name;

			
			db.SaveChanges();
		}
		public void Add(String name,int father)
		{
			Category book = new Category();
			book.Name = name;
			book.Id_father = father;
			
			db.Categories.Add(book);
			db.SaveChanges();
		}
	}
}
