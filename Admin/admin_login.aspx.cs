using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Admin_admin_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        cmd.Connection = con;

        if (Session["admin_id"] != null)
        {
            Response.Redirect("index2.aspx");
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "sp_admin_login";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

       
        cmd.Parameters.Add("@adminid", SqlDbType.VarChar).Value=admin_id.Text;   
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value=admin_password.Text; 

        if (Convert.ToInt32(cmd.ExecuteScalar()) >0)  
        {
            Session["admin_id"] = admin_id.Text;
            Response.Redirect("index2.aspx");  
        }
        else
        {
            con.Close();
            Label1.Text="*Invalid User Name or Password.";
        }
    }
}