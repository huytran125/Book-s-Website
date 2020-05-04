
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
	public class Author_Dao
	{
		WebSach_final db = null;
		public Author_Dao()
		{
			db = new WebSach_final();
		}
		public IEnumerable<Author> GetAuthors()
		{
			return db.Authors.AsEnumerable();
		}
		public void Edit(String Id, String name, string description)
		{
			var book = db.Authors.Find(Convert.ToInt64(Id));
			book.Name = name;

			book.Information = description;
			db.SaveChanges();
		}
		public void Add(String name, string description)
		{
			Author book = new Author();
			book.Name = name;

			book.Information = description;
			db.Authors.Add(book);
			db.SaveChanges();
		}
		public void Delete(int Id)
		{
			var book = db.Authors.Find(Convert.ToInt64(Id));
			var product = db.Books.Where(x => x.Id_author == Id);
			foreach(var item in product)
			{
				item.Id_author = 3;
			}
			db.Authors.Remove(book);
			db.SaveChanges();
		}
	}
}
