using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace POSSystem.Dal
{
    public class CategoryDal : CheckNull
    {
        public string Categoryname { get; set; }
        public string id { get; set; }

        SqlParameter[] arrproc;
        clsDataUtility dUT = new clsDataUtility();

        public int updateCategorydata(string cat_name,string id)
        {
            string spName = "sp_update_tbl_web_menu";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[2];
            arrproc[0] = new SqlParameter("@id", SqlDbType.VarChar, 100);
            arrproc[0].Value = CheckNullString(id);
            arrproc[1] = new SqlParameter("@cat_name", SqlDbType.VarChar, 100);
            arrproc[1].Value = CheckNullString(cat_name);


            int result = 0;
            DataTable dt = new DataTable();
            dt = dUT.getDataTableproc(spName, arrproc);
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            return result;
        }


        public int AddCategory(string cat_name)
        {
            string spName = "sp_insert_tbl_web_menu";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[1];
            arrproc[0] = new SqlParameter("@cat_name", SqlDbType.VarChar, 100);
            arrproc[0].Value = CheckNullString(cat_name);
                      
          
            int result = 0;
            DataTable dt = new DataTable();
            dt = dUT.getDataTableproc(spName, arrproc);
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            return result;
        }


        public DataTable ShowCategory()
        {
            string spName = "sp_category";
            clsDataUtility dUT = new clsDataUtility();
            DataTable dt;
            dt = dUT.getDataTable(spName);
            return dt;
        }

        public DataTable UpdateCategory(string id)
        {
            string spName = "sp_update_select_category";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[1];
            arrproc[0] = new SqlParameter("@id", SqlDbType.VarChar, 100);
            arrproc[0].Value = CheckNullString(id);
            DataTable dt;
            dt = dUT.getDataTableproc(spName,arrproc);
            return dt;
        }


        public int DeleteCategory(string id)
        {
            string spName = "sp_delete_tbl_web_menu";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[1];
            arrproc[0] = new SqlParameter("@id", SqlDbType.VarChar, 100);
            arrproc[0].Value = CheckNullString(id);
            int result;
            result = dUT.ExecuteStoredProc(spName, arrproc);
            return result;
        }

    }
}