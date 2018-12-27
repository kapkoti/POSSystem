using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSSystem.Dal;
using System.Data;
using POSSystem.Models;
using System.IO;

namespace POSSystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

       DashboardDAL obj = new DashboardDAL();
        CategoryDal objcat = new CategoryDal();
        public ActionResult Product()
        {
            UserRegistrationVM objlistVM = new UserRegistrationVM();
            objlistVM.objmenulist = getmenu();
            objlistVM.objcategory = Bindcategorylist();
            return View(objlistVM);
        }

        // Category list code
        public List<CategoryDal> Bindcategorylist()
        {
            DataTable dt = objcat.ShowCategory();
            List<CategoryDal> objlistVM = new List<CategoryDal>();
            foreach (DataRow row in dt.Rows)
            {
                CategoryDal objcategory = new CategoryDal();
                objcategory.id = row["id"].ToString();
                objcategory.Categoryname = row["cat_name"].ToString();
                objlistVM.Add(objcategory);

                //objmenulist.Add(objmenu);
            }
            ViewBag.Category = objlistVM;
            return objlistVM;

        }

        // Menu bind code
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


        [HttpPost]
        public ActionResult AddProduct(string P_productname, string P_price, string P_Categoryname, string P_description, string P_Stockstatus, string P_image_path,string P_Action , string P_quantity)
        {

          
            ProductDAL objproduct = new ProductDAL();
            objproduct.AddProduct(P_Categoryname, "", P_productname, P_price, P_Stockstatus, P_image_path, P_description, P_Action,P_quantity);
          
             return Json(obj, JsonRequestBehavior.AllowGet);
                 
          
        }




    }
}