using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace POSSystem.Dal
{
    public class ProductDAL : CheckNull
    {
        public string Categoryname { get; set; }
        public string id { get; set; }
        public string productname { get; set; }
        public string price { get; set; }
        public string StockStatus { get; set; }
        public string image_path { get; set; }
        public string description{ get; set; }
        public string action { get; set; }
        public string quantity { get; set; }
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


        public int AddProduct(string cat_name,string sno,string productname,string price,string StockStatus,string image_path,string description,string action,string quantity)
        {
            string spName = "InsertUpdateproduct";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[9];
            arrproc[0] = new SqlParameter("@sno", SqlDbType.VarChar, 100);
            arrproc[0].Value = CheckNullString(sno);
            arrproc[1] = new SqlParameter("@category_name", SqlDbType.VarChar, 100);
            arrproc[1].Value = CheckNullString(cat_name);
            arrproc[2] = new SqlParameter("@product_name", SqlDbType.VarChar, 100);
            arrproc[2].Value = CheckNullString(productname);
            arrproc[3] = new SqlParameter("@price", SqlDbType.VarChar, 100);
            arrproc[3].Value = CheckNullString(price);
            arrproc[4] = new SqlParameter("@description", SqlDbType.VarChar, 5000);
            arrproc[4].Value = CheckNullString(description);
            arrproc[5] = new SqlParameter("@image", SqlDbType.VarChar, 1000);
            arrproc[5].Value = CheckNullString(image_path);
            arrproc[6] = new SqlParameter("@StockStatus", SqlDbType.VarChar, 100);
            arrproc[6].Value = CheckNullString(StockStatus);
            arrproc[7] = new SqlParameter("@Action", SqlDbType.VarChar, 100);
            arrproc[7].Value = CheckNullString(action);
            arrproc[8] = new SqlParameter("@Quantity", SqlDbType.VarChar, 100);
            arrproc[8].Value = CheckNullString(quantity);


            int result = 0;
            DataTable dt = new DataTable();
            dt = dUT.getDataTableproc(spName, arrproc);
            if (dt.Rows.Count > 0)
            {
              //  result = Convert.ToInt32(dt.Rows[0]["id"]);
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