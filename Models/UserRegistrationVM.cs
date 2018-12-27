using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POSSystem.Dal;

namespace POSSystem.Models
{
    public class UserRegistrationVM
    {

     

        public UserRegistrationModel objregistration { get; set; }
        public List<UserRegistrationModel> objregistration2 { get; set; }
        public List<DashboardDAL> objmenulist { get; set; }
        public List<CategoryDal> objcategory { get; set; }
      



    }
}