using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach.Common
{
	[Serializable]
	public class UserLogin
	{
		public long UserId { set; get; }
		public string Email { set; get; }

		
	}
}