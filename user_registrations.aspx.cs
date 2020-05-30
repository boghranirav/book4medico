using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Net;
using System.Net.Mail;
public partial class user_registrations : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();
    Random r1 = new Random();
    string code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = con1.GetData("select *from User_registration");
    }

    [System.Web.Services.WebMethod]
    public static string CheckEmail(string useroremail)
    {
        string retval = ""; 

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  user_mobile from User_registration where user_mobile=@u_mobile_id", con);
            cmd.Parameters.AddWithValue("@u_mobile_id", useroremail);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                retval = "true";
            }
            else
            {
                retval = "false";
            }
       
        return retval;

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (lblStatus.Text == "")
        {
            code = (r1.Next(100000, 999999)).ToString();
            bool b = con1.SaveData("user_email", u_email.Text, "user_name", pt_name.Text, "user_mobile", u_mobile.Text, "user_password", code);
            if (b == true)
            {
                try
                {
                    Response.Redirect("usersidelogin.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
            else
            {
                Label1.Text = "*You are not register";

            }
        }
    }
}