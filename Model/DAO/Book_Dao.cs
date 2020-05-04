using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
	public class Book_Dao
	{
		WebSach_final db = null;
		public Book_Dao()
		{
			db = new WebSach_final();
		}
		public IEnumerable<Book> ListAllPaging(int page, int pageSized)
		{
			return db.Books.OrderByDescending(x => x.Id).ToPagedList(page, pageSized);
		}
		public IEnumerable<Book> ListAllPaging2(int father,int son,int page, int pageSized)
		{
			if(son!=0)
			return db.Books.Where(x => x.Id_category==son).OrderByDescending(x => x.Id).ToPagedList(page, pageSized);
			else
				return db.Books.Where(x => x.Category.Id_father == father).OrderByDescending(x => x.Id).ToPagedList(page, pageSized);


		}
		public Book FindBook(int Id)
		{
			return db.Books.Find(Id);
		}
		public void EditPDF(int Id,int pdf)
		{
			var book = db.Books.Find(Id);
			book.file_id_pdf = pdf;
			db.SaveChanges();
		}
		public void EditImage (int Id, int image)
		{
			var book = db.Books.Find(Id);
			book.file_id_image = image;
			db.SaveChanges();
		}
		public void Edit(String Id, String name, long price, string son, long number, string author, string NXB, long page, string description)
		{
			var book = db.Books.Find(Convert.ToInt64(Id));
			book.Name = name;
			book.Price = price;
			book.Id_category = Convert.ToInt64(son);
			book.Number_left = number;
			book.Id_author = Convert.ToInt64(author);
			book.Id_NXB = Convert.ToInt64(NXB);
			book.Page = page;
			book.Description = description;
			db.SaveChanges();
		}
		public bool Add( String name, long price, string son, long number, string author, string NXB, long page, string description)
		{
			try
			{
				Book book = new Book();
				book.Name = name;
				book.Price = price;
				book.Id_category = Convert.ToInt64(son);
				book.Number_left = number;
				book.Id_author = Convert.ToInt64(author);
				book.Id_NXB = Convert.ToInt64(NXB);
				book.Page = page;
				book.Description = description;
				db.Books.Add(book);
				db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
			

		}
		public IEnumerable<Book> listbookCustom(long father, long son)
		{
			IEnumerable<Book> x = null;

			if (son == 0)
			{
				x = db.Books.Where(model => model.Category.Id_father == father);

			}
			else
			{ x = db.Books.Where(model =>  model.Id_category == son); }
			return x;
		}
		public IEnumerable<Book> Search(String search)
		{
			if (!String.IsNullOrEmpty(search))
			{
				return db.Books.Where(s => s.Name.Contains(search));
			}
			else
				return null;
		}
	}
}
