using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AppSettings
/// </summary>
public class AppSettings
{
    public static string GetItem(string key)
    {
        string item = "";

        if (ConfigurationSettings.AppSettings[key] != null)
        {
            item = ConfigurationSettings.AppSettings[key];
        }

        return item;
    }
}
