using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach.Models;

namespace ThuVienSach.Controllers
{
    public class FileController : Controller
    {
		// GET: File
		public File_Dao dao = new File_Dao();
		public Book_Dao dao1 = new Book_Dao();
		#region Private Properties  

		/// <summary>  
		/// Gets or sets database manager property.  
		/// </summary>  


		#endregion

		#region Index view method.  

		#region Get: /Img/Index method.  

		/// <summary>  
		/// Get: /Img/Index method.  
		/// </summary>          
		/// <returns>Return index view</returns>  
		public ActionResult Index()
		{
			// Initialization.  
			ImgviewModel model = new ImgviewModel { FileAttach = null, ImgLst = new List<File>() };

			try
			{
				// Settings.  
				model.ImgLst = dao.GetAllFile().ToList();
			}
			catch (Exception ex)
			{
				// Info  
				Console.Write(ex);
			}

			// Info.  
			return this.View(model);
		}

		#endregion

		#region POST: /Img/Index  

		/// <summary>  
		/// POST: /Img/Index  
		/// </summary>  
		/// <param name="model">Model parameter</param>  
		/// <returns>Return - Response information</returns>  
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Index(ImgviewModel model,String book,string check)
		{
			if (check == null && book == null)
			// Initialization.  
			{
				string fileContent = string.Empty;
				string fileContentType = string.Empty;

				try
				{
					// Verification  
					if (ModelState.IsValid)
					{
						// Converting to bytes.  
						byte[] uploadedFile = new byte[model.FileAttach.InputStream.Length];
						model.FileAttach.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

						// Initialization.  
						fileContent = Convert.ToBase64String(uploadedFile);
						fileContentType = model.FileAttach.ContentType;

						// Saving info.  
						dao.InsertFile(model.FileAttach.FileName, fileContentType, fileContent);
					}

					// Settings.  
					model.ImgLst = dao.GetAllFile().ToList();
				}
				catch (Exception ex)
				{
					// Info  
					Console.Write(ex);
				}

				// Info  
				return this.View(model);
			}
			else
			{

				string fileContent = string.Empty;
				string fileContentType = string.Empty;

				try
				{
					// Verification  
					if (ModelState.IsValid)
					{
						// Converting to bytes.  
						byte[] uploadedFile = new byte[model.FileAttach.InputStream.Length];
						model.FileAttach.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

						// Initialization.  
						fileContent = Convert.ToBase64String(uploadedFile);
						fileContentType = model.FileAttach.ContentType;

						// Saving info.  
						File x=dao.InsertFile(model.FileAttach.FileName, fileContentType, fileContent);
						if (check=="1")
						dao1.EditPDF(Convert.ToInt32(book), Convert.ToInt32(x.file_id));
						else
							dao1.EditImage(Convert.ToInt32(book), Convert.ToInt32(x.file_id));


					}

					// Settings.  
					model.ImgLst = dao.GetAllFile().ToList();
				}
				catch (Exception ex)
				{
					// Info  
					Console.Write(ex);
				}
				return RedirectToAction("Index", "Book", new { area = "Admin" });
			}
		}

		#endregion

		#endregion

		#region Download file methods  

		#region GET: /Img/DownloadFile  

		/// <summary>  
		/// GET: /Img/DownloadFile  
		/// </summary>  
		/// <param name="fileId">File Id parameter</param>  
		/// <returns>Return download file</returns>  
		public ActionResult DownloadFile(int fileId)
		{
			// Model binding.  
			ImgviewModel model = new ImgviewModel { FileAttach = null, ImgLst = new List<File>() };

			try
			{
				// Loading dile info.  
				var fileInfo = dao.GetFile(fileId);

				// Info.  
				return this.GetFile(fileInfo.file_base6, fileInfo.file_ext);
			}
			catch (Exception ex)
			{
				// Info  
				Console.Write(ex);
			}

			// Info.  
			return this.View(model);
		}

		#endregion

		#endregion

		#region Helpers  

		#region Get file method.  

		/// <summary>  
		/// Get file method.  
		/// </summary>  
		/// <param name="fileContent">File content parameter.</param>  
		/// <param name="fileContentType">File content type parameter</param>  
		/// <returns>Returns - File.</returns>  
		private FileResult GetFile(string fileContent, string fileContentType)
		{
			// Initialization.  
			FileResult file = null;

			try
			{
				// Get file.  
				byte[] byteContent = Convert.FromBase64String(fileContent);
				file = this.File(byteContent, fileContentType);
			}
			catch (Exception ex)
			{
				// Info.  
				throw ex;
			}

			// info.  
			return file;
		}

		#endregion

		#endregion
	}
}