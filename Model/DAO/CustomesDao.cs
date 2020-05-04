using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
public	class CustomesDao
	{
		WebSach_final db = null;
		public CustomesDao()
		{
			db = new WebSach_final();
		}
		public Customer FindWithIDAccount(int IdAccount)
		{
			try
			{
				return db.Customers.Where(x => x.Id_account == IdAccount).SingleOrDefault();

			}catch (Exception e)
			{
				return null;
			}
		}
		public IEnumerable<Customer> GetList()
		{
			return db.Customers.AsEnumerable();
		}
		public void Edit(long Id, String name, String address, string phone, string email)
		{
			var x = db.Customers.Find(Id);
			x.Name = name;
			x.Address = address;
			x.Phone = phone;
			Account_Dao account_Dao = new Account_Dao();
			var y = db.Accounts.Where(h => h.Id == x.Id_account).SingleOrDefault();
			y.Email = email;
			db.SaveChanges();
		}
		public void Add(String name, String address, string phone, string email, string password)
		{
			Account_Dao account_Dao = new Account_Dao();
			Account account = new Account();
			account.Email = email;
			account.Password = password;
			var x=account_Dao.Insert(account);
			Customer customer = new Customer();
			customer.Name = name;
			customer.Address = address;
			customer.Phone = phone;
			customer.Id_account = x;
			db.SaveChanges();
		}
	}
}
