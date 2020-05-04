using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.DAO
{
	public class Account_Dao
	{
		WebSach_final db = null;
		public Account_Dao()
		{
			db = new WebSach_final();
		}
		public int Login(String email, String password)
		{
			var result = db.Accounts.SingleOrDefault(x => x.Email == email);
			if (result == null)
			{
				return 0;
			}
			else
			{
				if (result.Password == password)
					return 1;
				else
					return -2;
			}
		}
		public Account GetById(string email)
		{
			return db.Accounts.SingleOrDefault(x => x.Email == email);
		}
		public long findtype(long id)
		{
			var x = db.Workers.SingleOrDefault(t => t.Id_account == id);
			if (x != null)
				return Convert.ToInt64(x.Id_type);
			else
				return -1;
		}
		public long Insert(Account entity)
		{
			db.Accounts.Add(entity);
			db.SaveChanges();
			return entity.Id;
		}
	}

}
