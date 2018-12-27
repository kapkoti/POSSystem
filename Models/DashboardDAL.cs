using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


    namespace POSSystem.Dal
{
    public class DashboardDAL : CheckNull
    {
        

        SqlParameter[] arrproc;
        clsDataUtility dUT = new clsDataUtility();

        public string MenuName { get; set; }
        public string menu_path { get; set; }
     
        public DataTable BindMenu()
        {
            string spName = "sp_tblmenu";
            clsDataUtility dUT = new clsDataUtility();
            DataTable dt;
            dt = dUT.getDataTable(spName);
            return dt;
        }


    }
}