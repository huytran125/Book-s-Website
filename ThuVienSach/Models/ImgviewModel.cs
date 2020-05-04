using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model.EF;

namespace ThuVienSach.Models
{
	public class ImgviewModel
	{
		#region Properties  

		/// <summary>  
		/// Gets or sets Image file.  
		/// </summary>  
		[Required]
		[Display(Name = "Upload File")]
		public HttpPostedFileBase FileAttach { get; set; }

		/// <summary>  
		/// Gets or sets Image file list.  
		/// </summary>  
		public List<File> ImgLst { get; set; }

		#endregion
	}
}