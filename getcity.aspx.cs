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

public partial class getcity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<string> GetEmployeeName(string empName)
    {
        List<string> empResult = new List<string>();
        using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from City_info where city_name like @Name+'%'";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@Name", empName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empResult.Add(dr["city_name"].ToString());
                }
                con.Close();
                return empResult;
            }
        }
    }  
}