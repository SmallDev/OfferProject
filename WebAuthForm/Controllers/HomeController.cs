using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLayerLibrary.Domain.Model;
using WebAuthForm.Models;

namespace WebAuthForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = "Ваш логин: " + User.Identity.Name;
            }
            ViewBag.Message = result;
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Scripts()
        {
            return PartialView("Partial/Scripts");
        }
    }    
}