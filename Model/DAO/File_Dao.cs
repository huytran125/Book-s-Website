using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
	public class File_Dao
	{
		public WebSach_final db = new WebSach_final();
		public File_Dao()
		{
			db = new WebSach_final();
		}
		public IEnumerable<File> GetAllFile()
		{
			return db.Files.AsEnumerable();
		}
		public File InsertFile(string FileName, string fileContentType, string fileContent)
		{
			try
			{
				File file = new File();
				file.file_name = FileName;
				file.file_ext = fileContentType;
				file.file_base6 = fileContent;
				db.Files.Add(file);
			
				db.SaveChanges();
				File x = db.Files.Where(b => b.file_name == file.file_name).FirstOrDefault();
				return x ;
			}
			catch (Exception e)
			{
				return null;
			}

		}
		public File GetFile(int Id)
		{
			return db.Files.Find(Id);
		}
		
	}
}
