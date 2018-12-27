using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace POSSystem.Models
{
    public class UserModelBinder : IModelBinder
    {
       
        object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objcontext = controllerContext.HttpContext;
            string name = objcontext.Request.Form["txt_name"];
            string phone = objcontext.Request.Form["txt_phone"];
            string email = objcontext.Request.Form["txt_email"];
            string username = objcontext.Request.Form["txt_username"];
            string pwd = objcontext.Request.Form["txt_password"];

            UserRegistrationModel objuser = new UserRegistrationModel();
            objuser.name = name;
            objuser.email = email;
            objuser.phone = phone;
            objuser.userName = username;
            objuser.password = pwd;
            
            return objuser;
        }
    }
}