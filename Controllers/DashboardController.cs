using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POSSystem.Dal;
using System.Web.Mvc;
using System.Data;
using POSSystem.Models;

namespace POSSystem.Controllers
{
    public class DashboardController : Controller
    {
        DashboardDAL obj = new DashboardDAL();
        // GET: Dashboard
        public ActionResult Dashboard()
        {
         
          
            UserRegistrationVM objlistVM = new UserRegistrationVM();

            objlistVM.objmenulist = getmenu();

            // ViewData.Model = dt.AsEnumerable();
            return View(objlistVM);
        }


        public List<DashboardDAL> getmenu()
        {
            DataTable dt = obj.BindMenu();
            List<DashboardDAL> objlistVM = new List<DashboardDAL>();
            foreach (DataRow row in dt.Rows)
            {
                DashboardDAL objmenu = new DashboardDAL();
                objmenu.MenuName = row["menu_name"].ToString();
                objmenu.menu_path = row["menu_path"].ToString();
                objlistVM.Add(objmenu);

                //objmenulist.Add(objmenu);
            }

            return objlistVM;

        }

        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}