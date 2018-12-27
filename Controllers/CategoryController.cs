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
    public class CategoryController : Controller
    {
        // GET: Category
        DashboardDAL obj = new DashboardDAL();
        CategoryDal objcat = new CategoryDal();
        public ActionResult Category()
        {
            UserRegistrationVM objlistVM = new UserRegistrationVM();
            objlistVM.objmenulist = getmenu();
            objlistVM.objcategory = Bindcategorylist();
            return View(objlistVM);
        }

        public ActionResult Reload()
        {
           return RedirectToAction("Bindcategorylist", "Category");

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
                objcategory.Categoryname= row["cat_name"].ToString();
                objlistVM.Add(objcategory);

                //objmenulist.Add(objmenu);
            }

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
        public ActionResult AddCategory(CategoryDal obj)
        {
            CategoryDal objcat = new CategoryDal();
            CategoryDal objmenu = new CategoryDal();
            if (!string.IsNullOrEmpty(Session["userid"] as string))
            {
                objcat.updateCategorydata(obj.Categoryname,Session["userid"].ToString());
            }
            else
            {
               
                objcat.AddCategory(obj.Categoryname);
            }


           // return RedirectToAction("Category", "Category");
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowCategoryList()
        {
            CategoryDal objcat = new CategoryDal();
            DataTable dt =   objcat.ShowCategory();
            List<CategoryDal> objmenulist = new List<CategoryDal>();


            foreach (DataRow row in dt.Rows)
            {
                CategoryDal objmenu = new CategoryDal();
                objmenu.Categoryname = row["cat_name"].ToString();
         
                objmenulist.Add(objmenu);
            }


            return Json(objmenulist , JsonRequestBehavior.AllowGet);
        }

    
        [HttpGet]
        public JsonResult updateCategory(string id)
        {
            Session["userid"] = id;
            CategoryDal objcat = new CategoryDal();
            DataTable dt = objcat.UpdateCategory(id);
            List<CategoryDal> objmenulist = new List<CategoryDal>();
            CategoryDal objmenu = new CategoryDal();

            foreach (DataRow row in dt.Rows)
            {
               
                objmenu.Categoryname = row["cat_name"].ToString();

            
            }

            return Json(objmenu.Categoryname, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteCateogry(string id)
        {
            CategoryDal objcat = new CategoryDal();
            int result = objcat.DeleteCategory(id);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

    }
}