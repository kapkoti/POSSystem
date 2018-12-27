using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSSystem.Models;
using POSSystem.Dal;
using System.Data;

namespace POSSystem.Controllers
{
    public class UserRegistrationController : Controller
    {
        UserModelBinder objbinder = new UserModelBinder();
        UserRegistrationDAL objregistration = new UserRegistrationDAL();
        DashboardDAL obj = new DashboardDAL();
        UserRegistrationVM objlistVM = new UserRegistrationVM();

        // GET: UserRegistration
        public ActionResult UserRegistration()
        {
            UserRegistrationVM objlistVM = new UserRegistrationVM();
            objlistVM.objmenulist = getmenu();

            objlistVM.objregistration2 =  Binduserdata();
            return View(objlistVM);

         
           
        }

        public ActionResult Submit([ModelBinder(typeof(UserModelBinder))]UserRegistrationModel objuserregistration)
        {
            objregistration.registerUser(objuserregistration.name, objuserregistration.phone, objuserregistration.email, objuserregistration.userName, objuserregistration.password);
           
            return RedirectToAction("Binduserdata");
        }

        public List<UserRegistrationModel> Binduserdata()
        {
            
            DataTable dt = objregistration.ShowRegisteredUsers();
            List<UserRegistrationModel> objuserlist = new List<UserRegistrationModel>();
          

            foreach (DataRow row in dt.Rows)
            {
                UserRegistrationModel objuser = new UserRegistrationModel();
                objuser.email = row["email"].ToString();
                objuser.name = row["Name"].ToString();
                objuser.password = row["pwd"].ToString();
                objuser.phone = row["phone"].ToString();
                objuser.userName = row["user_name"].ToString();
                objuser.id = row["id"].ToString();
                objuserlist.Add(objuser);
                //objuserlist.Add(objuser);
            }

            // ViewData.Model = dt.AsEnumerable();
            return objuserlist;


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

        public JsonResult GetbyIDcon(string ID)
        {
            DataTable  UserDetail = objregistration.getUserbyid(ID);
            UserRegistrationModel objreg = new UserRegistrationModel();
            foreach (DataRow row in UserDetail.Rows)
            {
              
                objreg.name = row["Name"].ToString();
                objreg.phone = row["phone"].ToString();
                objreg.userName = row["user_name"].ToString();
                objreg.email = row["email"].ToString();
       
                //objmenulist.Add(objmenu);
            }
                     
            return Json(objreg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult update()
        {
            var id = Request.Url.Segments[3];
            return RedirectToAction("UserRegistration");
        }
    }
}