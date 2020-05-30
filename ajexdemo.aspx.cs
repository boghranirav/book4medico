using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class ajexdemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCountries(string prefixText)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from City_info where city_name like @Name+'%'", con);
        cmd.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        List<string> CountryNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CountryNames.Add(dt.Rows[i][2].ToString());
        }
        return CountryNames;
    }
}