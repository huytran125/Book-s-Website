using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.DAO;

namespace ThuVienSach.Areas.Admin.Models
{
	public class BookModel
	{
		public IEnumerable<Book> books;
		public IEnumerable<Book> books1;
		public IEnumerable<Book> books2;
		public IEnumerable<Book> books3;


		public IEnumerable<Author> authors;
		public IEnumerable<NXB> nXBs;
		public IEnumerable<Category> categories;
		public IEnumerable<Category> categories2;
		public IEnumerable<Father_category> Father_Categories;
		public void setListBooks(int page,int pagesized)
		{
			Book_Dao dao = new Book_Dao();
			books = dao.ListAllPaging(page,pagesized);
		}
		public void setListBooks(int father, int son, int page, int pagesized)
		{
			Book_Dao dao = new Book_Dao();
			books1 = dao.ListAllPaging2(father, son, page, pagesized);
		}
		public void setListBooks2(int father, int son)
		{
			Book_Dao dao = new Book_Dao();
			books2 = dao.listbookCustom(father,son);
		}
		public void setListBooks3(String search)
		{
			Book_Dao dao = new Book_Dao();
			books3 = dao.Search(search);
		}
		public void setListAuthors()
		{
			Author_Dao dao = new Author_Dao();
			authors = dao.GetAuthors();
		}
		public void setListCategory()
		{
			CategoryDao dao = new CategoryDao();
			categories = dao.GetCategorys();
		}
		public void setListFatherCategorys()
		{
			FatherCategory_Dao dao = new FatherCategory_Dao();
			Father_Categories = dao.GetFatherCategorys();
		}
		public void setListNXBs()
		{
			NXB_Dao dao = new NXB_Dao();
			nXBs = dao.GetNXBs();
		}
		public void setListCategory2(int father)
		{
			CategoryDao dao = new CategoryDao();
			categories2 = dao.GetCategoryswith(father);
		}

	}
}