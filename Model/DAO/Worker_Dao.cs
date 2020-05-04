using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
public	class Worker_Dao
	{
		WebSach_final db = null;
		public Worker_Dao()
		{
			db = new WebSach_final();
		}
		public Worker Find(long IdAccount)
		{
			return db.Workers.Where(x => x.Id_account == IdAccount).SingleOrDefault();
		}
		public Worker FindX(long Id)
		{

			return db.Workers.Where(x => x.Id == Id).SingleOrDefault();
		}
		public IEnumerable<Worker> GetList()
		{
			return db.Workers.AsEnumerable();
		}



		public void Edit(long Id, String name, String address,long type, string email)
		{
			var x = db.Workers.Find(Id);
			x.Name = name;
			x.Address = address;
			x.Id_type = type;
			Account_Dao account_Dao = new Account_Dao();
			var y = db.Accounts.Where(h => h.Id == x.Id_account).SingleOrDefault();
			y.Email = email;
			db.SaveChanges();
		}
		public void Add(String name, String address, long type, string email, string password)
		{
			Account_Dao account_Dao = new Account_Dao();
			Account account = new Account();
			account.Email = email;
			account.Password = password;
			var x = account_Dao.Insert(account);
			Worker customer = new Worker();
			customer.Name = name;
			customer.Address = address;
			customer.Id_type = type;
			customer.Id_account = x;
			db.SaveChanges();
		}
	}
}
