﻿using System.Web.Mvc;

namespace ThuVienSach.Areas.Shipper
{
    public class ShipperAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Shipper";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Shipper_default",
                "Shipper/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional },
								 new[] { "ThuVienSach.Areas.Shipper.Controllers" }
			);
        }
    }
}