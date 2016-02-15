    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.Mvc;
    using BusinessLayerLibrary.Common;
    using BusinessLayerLibrary.DAL;
    using BusinessLayerLibrary.Domain.Model;
    using BusinessLayerLibrary.Facades;
    using WebAuthForm.Models;

    namespace WebAuthForm.Controllers
    {
        public class AccountController : Controller
        {
    
            public UserFacade UserService { get; set; }

            public AccountController(UserFacade userFac)
            {
                this.UserService = userFac;
            }
        
            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = UserService.Validate(model.Login, model.Password);
                    if (user != null)
                    {
                        Session["user"] = user;
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Offers", "Offers");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                    }
                }
                return View(model);
            }


            public ActionResult Register()
            {
                return View();
            }


        public virtual ActionResult Logoff()
        {
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
        }


        }
    }
