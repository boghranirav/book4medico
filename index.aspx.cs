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

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("index2.aspx");
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCompletionList(string prefixText)
    {
        List<string> CompliteList = new List<string>();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Doctor_clinic where clinic_name like @Name+'%'", con);
        cmd.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CompliteList.Add(dt.Rows[i][2].ToString());
        }
        con.Close();

        con.Open();
        SqlCommand cmd2 = new SqlCommand("select distinct first_name from Doctor_basic_info where first_name like @Name+'%'", con);
        cmd2.Parameters.AddWithValue("@Name", "%" + prefixText + "%");
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);

        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            CompliteList.Add(dt2.Rows[i][0].ToString());
        }
        con.Close();
        con.Open();
        SqlCommand cmd3 = new SqlCommand("select * from Specializations_info where spe_name like @Name+'%'", con);
        cmd3.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        da3.Fill(dt3);

        for (int i = 0; i < dt3.Rows.Count; i++)
        {
            CompliteList.Add(dt3.Rows[i][1].ToString());
        }
        con.Close();

        return CompliteList;
    }
}