using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace POSSystem.Dal
{
    public class UserRegistrationDAL : CheckNull
    {
        

        SqlParameter[] arrproc;
        clsDataUtility dUT = new clsDataUtility();

        public int registerUser(string name, string phone, string email, string user_name, string pwd)
        {
            string spName = "sp_insert_tbl_users";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[5];
            arrproc[0] = new SqlParameter("@name", SqlDbType.VarChar, 600);
            arrproc[0].Value = CheckNullString(name);
            arrproc[1] = new SqlParameter("@phone", SqlDbType.VarChar, 600);
            arrproc[1].Value = CheckNullString(phone);
            arrproc[2] = new SqlParameter("@email", SqlDbType.VarChar, 600);
            arrproc[2].Value = CheckNullString(email);
            arrproc[3] = new SqlParameter("@user_name", SqlDbType.VarChar, 600);
            arrproc[3].Value = CheckNullString(user_name);
            arrproc[4] = new SqlParameter("@pwd", SqlDbType.VarChar, 600);
            arrproc[4].Value = CheckNullString(pwd);
           
            //int result = 0;
            //result = dUT.ExecuteStoredProc(spName, arrproc);
            //return result;
            int result = 0;
            DataTable dt = new DataTable();
            dt = dUT.getDataTableproc(spName, arrproc);
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToInt32(dt.Rows[0]["id"]);
            }
            return result;
        }


        public DataTable Checkuser(string password, string Name)
        {
            string spName = "sp_login";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[2];
            arrproc[0] = new SqlParameter("@user_name", SqlDbType.VarChar, 50);
            arrproc[0].Value = CheckNullString(Name);
            arrproc[1] = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
            arrproc[1].Value = CheckNullString(password);
            DataTable dt;
            dt = dUT.getDataTableproc(spName, arrproc);
            return dt;
        }

        public DataTable ShowRegisteredUsers()
        {
            string spName = "sp_select_tbl_users";
            clsDataUtility dUT = new clsDataUtility();
            DataTable dt;
            dt = dUT.getDataTable(spName);
            return dt;
        }

        public DataTable getUserbyid(string id)
        {
            string spName = "sp_selectbyid_tbl_users";
            clsDataUtility dUT = new clsDataUtility();
            arrproc = new SqlParameter[1];
            arrproc[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            arrproc[0].Value = CheckNullString(id);
          
            DataTable dt;
            dt = dUT.getDataTableproc(spName, arrproc);
            return dt;
        }
        

    }
}