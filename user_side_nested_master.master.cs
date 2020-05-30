using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic; 


public partial class user_side_nested_master : System.Web.UI.MasterPage
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        //dt1 = con1.GetData("select * from City_info");

        //foreach(DataRow dr1 in dt1.Rows)
        //{
        //    filterby.Items.Add(new ListItem(dr1["city_name"].ToString(),dr1["city_id"].ToString()));
        //}
    }

    
    /*[System.Web.Script.Services.ScriptMethod()]
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
    }*/

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (searchQuery.Text != "")
        {
            string qry_string = searchQuery.Text;
            Response.Redirect("user_doctor_disp.aspx?srnm="+qry_string);
        }
    }
    protected void searchQuery_TextChanged(object sender, EventArgs e)
    {
        if (searchQuery.Text != "")
        {
            string qry_string = searchQuery.Text;
            Response.Redirect("user_doctor_disp.aspx?srnm=" + qry_string);
        }
    }
}
