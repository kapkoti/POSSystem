using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for CheckNull
/// </summary>
public class CheckNull
{
	public CheckNull()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public object CheckNullString(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = DBNull.Value;
        }
        else
        {
            obj = values;
        }
        return obj;
    }
    public object CheckNullMoney(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = new SqlMoney((Convert.ToDouble("0")));
        }
        else
        {            
            obj = new SqlMoney((Convert.ToDouble(values)));
        }
        return obj;
    }
    public object CheckNullDateTime(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = DBNull.Value;
        }
        else
        {
            obj = System.Convert.ToDateTime(values);
        }
        return obj;
    }
    public object CheckNullInt32(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = DBNull.Value;
        }
        else
        {
            obj = System.Convert.ToInt32(values);
        }
        return obj;
    }
    public object CheckNullInt16(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = DBNull.Value;
        }
        else
        {
            obj = System.Convert.ToInt16(values);
        }
        return obj;
    }
    public object CheckNullTinyInt(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = DBNull.Value;
        }
        else
        {
            obj = System.Convert.ToInt16(values);
        }
        return obj;
    }
    public object CheckNullFloat(string values)
    {
        object obj;
        if (values == null || values.Trim().Length == 0 || values == "NULL")
        {
            obj = DBNull.Value;
        }
        else
        {
            obj = System.Convert.ToDouble(values);
        }
        return obj;
    }
}
