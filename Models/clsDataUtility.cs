using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// This class is meant to provide a genralised set of 
/// data utilities that can be used by all the forms 
/// and classes.
/// 
/// </summary>
public class clsDataUtility
{
    private SqlConnection mConn;
    private SqlCommand mDataCom;
    private SqlDataAdapter mDataAdapter;
    private SqlConnection mConnReport;
    private SqlCommand mDataComReport;
    private SqlDataAdapter mDataAdapterReport;

    public clsDataUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Private Method openConnection
    /// Purpose:-
    ///		-Read the properties from web.config
    ///		-open connection
    ///		-initialize command object
    /// </summary>

    private void openConnection()
    {
        if (mConn == null)
        {
            //class code 
            string con = "";
            string Portocon = "";
            con = AppSettings.GetItem("ConnectionString");
            mConn = new SqlConnection(con);  //new SqlConnection(con);
            //
            //mConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            if (mConn.State == ConnectionState.Open)
            {
                mConn.Close();
                mConn.Open();
            }
            else if (mConn.State == ConnectionState.Closed)
                mConn.Open();
            mDataCom = new SqlCommand();
            mDataCom.CommandTimeout = 7200;
            mDataAdapter = new SqlDataAdapter();
            mDataCom.Connection = mConn;
            mDataCom.CommandTimeout = 7200;
        }
    }

    private void openConnectionString(string connectionString)
    {
        if (mConn == null)
        {
            //class code 
            string con = "";
            con = AppSettings.GetItem(connectionString); 
            mConn = new SqlConnection(con);
            //
            //mConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            if (mConn.State == ConnectionState.Open)
            {
                mConn.Close();
                mConn.Open();
            }
            else if (mConn.State == ConnectionState.Closed)
                mConn.Open();
            mDataCom = new SqlCommand();
            mDataCom.CommandTimeout = 7200;
            mDataAdapter = new SqlDataAdapter();
            mDataCom.Connection = mConn;
            mDataCom.CommandTimeout = 7200;
        }
    }

    private void openConnectionEcom()
    {
        if (mConn == null)
        {
            //class code 
            string con = "";
            string Portocon = "";
            con = AppSettings.GetItem("ECommConnectionString");
            mConn = new SqlConnection(con);  //new SqlConnection(con);
            //
            //mConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            if (mConn.State == ConnectionState.Open)
            {
                mConn.Close();
                mConn.Open();
            }
            else if (mConn.State == ConnectionState.Closed)
                mConn.Open();
            mDataCom = new SqlCommand();
            mDataCom.CommandTimeout = 7200;
            mDataAdapter = new SqlDataAdapter();
            mDataCom.Connection = mConn;
            mDataCom.CommandTimeout = 7200;
        }
    }
   
    private void openConnectionReport()
    {
        if (mConnReport == null)
        {
            //class code 
            string conReport = "";
            conReport = AppSettings.GetItem("ReportConnectionString");
            mConnReport = new SqlConnection(conReport);
            //
            //mConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            if (mConnReport.State == ConnectionState.Open)
            {
                mConnReport.Close();
                mConnReport.Open();
            }
            else if (mConnReport.State == ConnectionState.Closed)
                mConnReport.Open();
            mDataComReport = new SqlCommand();
            mDataComReport.CommandTimeout = 7200;
            mDataAdapterReport = new SqlDataAdapter();
            mDataComReport.Connection = mConnReport;
            mDataComReport.CommandTimeout = 7200;
        }
    }

    private void openConnectionRecord()
    {
        if (mConnReport == null)
        {
            //class code 
            string conReport = "";
            conReport = ConfigurationManager.ConnectionStrings["iHealthConnectionString"].ToString();

            mConnReport = new SqlConnection(conReport);
            //
            //mConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            if (mConnReport.State == ConnectionState.Open)
            {
                mConnReport.Close();
                mConnReport.Open();
            }
            else if (mConnReport.State == ConnectionState.Closed)
                mConnReport.Open();
            mDataComReport = new SqlCommand();
            mDataComReport.CommandTimeout = 7200;
            mDataAdapterReport = new SqlDataAdapter();
            mDataComReport.Connection = mConnReport;
            mDataComReport.CommandTimeout = 7200;
        }
    }
    /// <summary>
    /// Private Method closeConnection 
    /// Purpose:-
    ///			-Close the connection object
    /// </summary>
    private void closeConnection()
    {
        if (mConn.State == ConnectionState.Open)
            mConn.Close();
    }
    private void closeConnectionReport()
    {
        if (mConnReport.State == ConnectionState.Open)
            mConnReport.Close();
    }

    /// <summary>
    /// Private Method disposeConnection
    /// purpose:- 
    ///		   -Check the connection for null
    ///		   -dispose the connection object
    /// </summary>
    private void disposeConnection()
    {
        if (mConn != null)
        {
            if (mConn.State == ConnectionState.Closed)
                mConn.Dispose();
            mConn = null;
        }
    }
    private void disposeConnectionReport()
    {
        if (mConnReport != null)
        {
            if (mConnReport.State == ConnectionState.Closed)
                mConnReport.Dispose();
            mConnReport = null;
        }
    }

    /// <summary>
    /// Public Method executeSql
    /// purpose:-
    ///			-get the sql string and execute nonQuery
    ///			-return the value returned by datasource
    /// </summary>
    /// <param name="strSql">SQL command</param>
    /// <returns>int(number of rows affected).</returns>
    public int executeSql(string strSql)
    {
        this.openConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        int intRows = mDataCom.ExecuteNonQuery();
        this.closeConnection();
        this.disposeConnection();
        return intRows;
    }

    public int executeSql(string strSql, string connectionString)
    {
        this.openConnectionString(connectionString);
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        int intRows = mDataCom.ExecuteNonQuery();
        this.closeConnection();
        this.disposeConnection();
        return intRows;
    }
    /// <summary>
    /// Public Method isExist
    /// purpose:- 
    ///			-to execute the sql statement 
    ///			-check for any rows existing
    ///	returns boolean
    /// </summary>
    /// <param name="strSql">SQL command</param>
    /// <returns>boolean (true if exists otherwise false)</returns>
    public bool isExist(string strSql)
    {
        openConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        int intRows = (int)mDataCom.ExecuteScalar();
        closeConnection();
        disposeConnection();
        if (intRows == 0)
            return false;
        else
            return true;
    }

    public bool isExist(string strSql, string connectionString)
    {
        this.openConnectionString(connectionString);
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        int intRows = (int)mDataCom.ExecuteScalar();
        closeConnection();
        disposeConnection();
        if (intRows == 0)
            return false;
        else
            return true;
    }

    public Int64 isReturnExist(string strSql)
    {
        openConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        long intRows = Convert.ToInt64(mDataCom.ExecuteScalar());
        closeConnection();
        disposeConnection();
        return intRows;
    }

    public int returnInt(string strSql)
    {
        openConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        int intRows = Convert.ToInt32(mDataCom.ExecuteScalar());
        closeConnection();
        disposeConnection();
        return intRows;
    }

    public string returnString(string strSql)
    {
        openConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        string intString = Convert.ToString(mDataCom.ExecuteScalar());
        closeConnection();
        disposeConnection();
        return intString;
    }

    public bool returnBool(string strSql)
    {
        openConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        bool boolValue = Convert.ToBoolean(mDataCom.ExecuteScalar());
        closeConnection();
        disposeConnection();
        return boolValue;
    }
    /// <summary>
    /// Public method getDataTable
    /// purpose:
    ///			-return datatable with executed Sql statement
    /// </summary>
    /// <param name="strSql">SQL command</param>
    /// <returns>DataTable </returns>
    public DataTable getDataTable(string strSql)
    {
        openConnection();        
        DataTable dt = new DataTable();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(dt);        
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }
    public DataTable getDataTableReport(string strSql)
    {
        openConnectionReport();
        DataTable dt = new DataTable();
        mDataComReport.CommandType = CommandType.Text;
        mDataComReport.CommandText = strSql;
        mDataComReport.Parameters.Clear();
        mDataAdapterReport.SelectCommand = mDataComReport;
        mDataAdapterReport.Fill(dt);
        this.closeConnectionReport();
        this.disposeConnectionReport();
        return dt;
    }

    public DataTable getDataTable(string strSql, string connectionString)
    {
        openConnectionString(connectionString);
        DataTable dt = new DataTable();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }
    public DataTable getDataTable(string strSql, SqlParameter[] arProcParams)
    {
        openConnection();
        SqlDataAdapter da = new SqlDataAdapter(strSql, mConn);
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(dt);          
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }

    public DataTable getDataTable(string strSql, SqlParameter[] arProcParams, string connectionString)
    {
        openConnectionString(connectionString);
        SqlDataAdapter da = new SqlDataAdapter(strSql, mConn);
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }


    public DataTable getDataTableproc(string strSPName)
    {
        openConnection();
        DataTable dt = new DataTable();        
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;        
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }

    public DataTable getDataTableproc(string strSPName, string connectionString)
    {
        openConnectionString(connectionString);
        DataTable dt = new DataTable();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }
    public DataTable getDataTableRecordproc(string strSPName, SqlParameter[] arProcParams)
    {
        openConnectionRecord();
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataComReport.CommandType = CommandType.StoredProcedure;
        mDataComReport.CommandText = strSPName;
        mDataComReport.Parameters.Clear();
        mDataAdapterReport.SelectCommand = mDataComReport;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataComReport.Parameters.Add(param);
        }
        mDataAdapterReport.Fill(dt);
        this.closeConnectionReport();
        this.disposeConnectionReport();
        return dt;
    }
    public DataTable getDataTableprocPreCopy3(string strSPName, SqlParameter[] arProcParams)
    {

        openConnectionEcom();
        openConnectionString("ConnectionString1");
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }
    public DataTable getDataTableproc(string strSPName, SqlParameter[] arProcParams)
    {
       
        openConnection();
        //openConnectionString("ConnectionString1");
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }
    //Created For Reporting Database
    public DataTable getDataTableReportproc(string strSPName, SqlParameter[] arProcParams)
    {
        openConnectionReport();
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataComReport.CommandType = CommandType.StoredProcedure;
        mDataComReport.CommandText = strSPName;
        mDataComReport.Parameters.Clear();
        mDataAdapterReport.SelectCommand = mDataComReport;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataComReport.Parameters.Add(param);
        }
        mDataAdapterReport.Fill(dt);
        this.closeConnectionReport();
        this.disposeConnectionReport();
        return dt;
    }

 
    //public DataTable getDataTableproc(string strSPName, SqlParameter[] arProcParams)
    //{
    //    openConnection();       
    //    DataTable dt = new DataTable();
    //    SqlParameter param = new SqlParameter();
    //    mDataCom.CommandType = CommandType.StoredProcedure; 
    //    mDataCom.CommandText = strSPName;        
    //    mDataCom.Parameters.Clear();
    //    mDataAdapter.SelectCommand = mDataCom;
    //    foreach (SqlParameter LoopVar_param in arProcParams)
    //    {
    //        param = LoopVar_param;
    //        mDataCom.Parameters.Add(param);
    //    }
    //    mDataAdapter.Fill(dt);
    //    this.closeConnection();
    //    this.disposeConnection();
    //    return dt;
    //}
    public DataTable getDataTableproc(string strSPName, SqlParameter[] arProcParams, string connectionString)
    {
        openConnectionString(connectionString);
        DataTable dt = new DataTable();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(dt);
        this.closeConnection();
        this.disposeConnection();
        return dt;
    }
    /// <summary>
    /// Public Method GetDataSet
    /// purpose:- fetch the data from the datasource and return
    /// the data filled dataset
    /// </summary>
    /// <param name="strSql">Sql command</param>
    /// <returns>DataSet</returns>
    public DataSet GetDataSet(string strSql)
    {
        openConnection();        
        DataSet ds = new DataSet();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(ds);            
        closeConnection();
        disposeConnection();
        return ds;
    }
    public DataSet GetDataSet(string strSql, string connectionString)
    {
        openConnectionString(connectionString);
        DataSet ds = new DataSet();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(ds);
        closeConnection();
        disposeConnection();
        return ds;
    }
    /// <summary>
    /// Public Method GetDataSet
    /// purpose:- fetch the data from the datasource and return
    /// the data filled dataset with name tablename
    /// </summary>
    /// <param name="strSql">Sql Command</param>
    /// <param name="tblname">Table name</param>
    /// <returns>DataSet</returns>
    public DataSet GetDataSet(string strSql, string tblname, string connectionString)
    {
        openConnectionString(connectionString);
        SqlDataAdapter da = new SqlDataAdapter(strSql, mConn);
        DataSet ds = new DataSet();
        da.Fill(ds, tblname);
        closeConnection();
        disposeConnection();
        return ds;
    }

    public DataSet GetDataSetParam(string strSql, SqlParameter[] arProcParams)
    {
        openConnection();       
        DataSet ds = new DataSet();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(ds);      
        closeConnection();
        disposeConnection();
        return ds;
    }
    public DataSet GetDataSetProc(string strSPName, SqlParameter[] arProcParams)
    {
        openConnection();
        DataSet ds = new DataSet();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure; mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }        
        mDataAdapter.Fill(ds);       
        closeConnection();
        disposeConnection();
        return ds;
    }

    public DataSet GetDataSetProc(string strSPName, SqlParameter[] arProcParams, string connectionString)
    {
        openConnectionString(connectionString);
        DataSet ds = new DataSet();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure; mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataAdapter.Fill(ds);
        closeConnection();
        disposeConnection();
        return ds;
    }
    ///<summary>
    /// Created for Modified 
    /// </summary>

    public DataSet GetDataSetProcReport(string strSPName, SqlParameter[] arProcParams)
    {
        openConnectionReport();
        DataSet ds = new DataSet();
        SqlParameter param = new SqlParameter();
        mDataComReport.CommandType = CommandType.StoredProcedure; mDataComReport.CommandText = strSPName;
        mDataComReport.Parameters.Clear();
        mDataAdapterReport.SelectCommand = mDataComReport;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataComReport.Parameters.Add(param);
        }
        mDataAdapterReport.Fill(ds);
       closeConnectionReport();
       disposeConnectionReport();
        return ds;
    }
     
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="strSPName"></param>
    /// <param name="tblname"></param>
    /// <returns></returns>
    public DataSet GetDataSetProc(string strSPName, string tblname, SqlParameter[] arProcParams)
    {
        openConnection();
        DataSet ds = new DataSet();
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        if (tblname == null)
        {
            mDataAdapter.Fill(ds);
        }
        else
        {
            mDataAdapter.Fill(ds, tblname);
        }
        closeConnection();
        disposeConnection();
        return ds;
    }

    public DataSet GetDataSetProc(string strSPName)
    {
        openConnection();
        DataSet ds = new DataSet();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(ds);
        closeConnection();
        disposeConnection();
        return ds;
    }
    public DataSet GetDataSetProc(string strSPName, string connectionString)
    {
        openConnectionString(connectionString);
        DataSet ds = new DataSet();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSPName;
        mDataCom.Parameters.Clear();
        mDataAdapter.SelectCommand = mDataCom;
        mDataAdapter.Fill(ds);
        closeConnection();
        disposeConnection();
        return ds;
    }
    /// <summary>
    /// This method is to populate a DataReader to bind control at Connected mode
    /// </summary>
    /// <param name="strSql">SQL Command</param>
    /// <returns>DataReader</returns>
    public SqlDataReader getDataReader(string strSql)
    {
        openConnection();
        SqlDataReader dReader;
        dReader = mDataCom.ExecuteReader(CommandBehavior.CloseConnection);
        return dReader;
    }

    public SqlDataReader getDataReader(string strSql, SqlParameter[] arProcParams)
    {
        openConnection();
        SqlDataReader dReader;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        dReader = mDataCom.ExecuteReader(CommandBehavior.CloseConnection);
        return dReader;      
    }
    /// <summary>
    /// This method executes stored procedure and fill output in datareader
    /// </summary>
    
    /// <Name>getDataReaderProc</Name>
    /// <param name="strSql">Stored Procedure Name</param>
    /// <param name="arProcParams">Stored Procedure input parameters and corrosponding values</param>
    /// <returns>DataReader</returns>
    public SqlDataReader getDataReaderProc(string strSql, SqlParameter[] arProcParams)
    {
        openConnection();
        SqlDataReader dReader;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strSql;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        dReader = mDataCom.ExecuteReader(CommandBehavior.CloseConnection);
        return dReader;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="strProcName"></param>
    /// <param name="arProcParams"></param>
    /// <returns></returns>
    public int ExecuteStoredProc(string strProcName, SqlParameter[] arProcParams, string connectionString)
    {
        openConnectionString(connectionString);
        int returnValue;
        SqlParameter param = new SqlParameter();        
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strProcName;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }        
        returnValue = mDataCom.ExecuteNonQuery();
        closeConnection();
        disposeConnection();
        return returnValue;
    }
    public int ExecuteStoredProc(string strProcName, SqlParameter[] arProcParams)
    {
        openConnection();
        int returnValue;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strProcName;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        returnValue = mDataCom.ExecuteNonQuery();
        closeConnection();
        disposeConnection();
        return returnValue;
    }
    public int ExecuteStoredProcPreCopy3(string strProcName, SqlParameter[] arProcParams)
    {
        openConnectionEcom();
        int returnValue;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strProcName;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        returnValue = mDataCom.ExecuteNonQuery();
        closeConnection();
        disposeConnection();
        return returnValue;
    }
    public string ReturnStringStoredProc(string strProcName, SqlParameter[] arProcParams)
    {
        openConnection();
        int returnValue;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strProcName;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataCom.ExecuteNonQuery();
        string strRows = Convert.ToString(mDataCom.Parameters["@RETVAL"].Value);
        closeConnection();
        disposeConnection();
        return strRows;
    }

    public long ReturnPrimaryStoredProc(string strProcName, SqlParameter[] arProcParams)
    {
        openConnection();
        int returnValue;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strProcName;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataCom.ExecuteNonQuery();
        long intRows = (long)mDataCom.Parameters["@Identity"].Value;
        closeConnection();
        disposeConnection();
        return intRows;
    }

    public int ReturnIntPrimaryStoredProc(string strProcName, SqlParameter[] arProcParams)
    {
        openConnection();
        int returnValue;
        SqlParameter param = new SqlParameter();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = strProcName;
        mDataCom.Parameters.Clear();
        foreach (SqlParameter LoopVar_param in arProcParams)
        {
            param = LoopVar_param;
            mDataCom.Parameters.Add(param);
        }
        mDataCom.ExecuteNonQuery();
        int intRows = Convert.ToInt32(mDataCom.Parameters["@Identity"].Value);
        closeConnection();
        disposeConnection();
        return intRows;
    }
    /// <summary>
    /// public method bindDDL 
    /// purpose:-
    ///		fetch the data in the datatable and bind the dropdownlist
    /// </summary>
    /// <param name="strSql">Sql statement</param>
    /// <param name="ddl">dropdownlist to bind with</param>
    /// <param name="fName">first name of the table</param>
    /// <returns>binded dropdownlist</returns>
    public DropDownList bindDDL(string strSql, DropDownList ddl, string fName)
    {
        DataTable dt = getDataTable(strSql);
        ddl.DataSource = dt;
        ddl.DataTextField = fName + "Name";
        ddl.DataValueField = fName + "ID";
        ddl.DataBind();
        return ddl;
    }


    public DropDownList bindDDL(DropDownList ddl, string textField, string valueField, string strProcName, params SqlParameter[] arrProcParam)
    {
        ddl.Items.Clear();
        DataTable myDataTable = new DataTable();
        myDataTable = getDataTable(strProcName, arrProcParam);
        ddl.DataSource = myDataTable;
        ddl.DataTextField = textField;
        ddl.DataValueField = valueField;
        ddl.DataBind();
        return ddl;
    }
}




		
	
