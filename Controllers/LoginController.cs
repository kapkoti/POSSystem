using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSSystem.Dal;
using System.Data;
using POSSystem.Models;

namespace POSSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DashboardDAL obj = new DashboardDAL();
        UserRegistrationDAL objdal = new UserRegistrationDAL();
        public ActionResult Login()
       {
           
            return View();
        }

        [HttpPost]
        public ActionResult submitlogin(string username, string pwd)
        {
            objdal.Checkuser(pwd, username);
            

            return RedirectToAction("Dashboard", "Dashboard");          

        }

  
    }
}