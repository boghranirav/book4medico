using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class user_confirm : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (Session["usermobile"] != null)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "sp_user_login";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@us_mobile", SqlDbType.VarChar).Value = Session["usermobile"].ToString();
            cmd.Parameters.Add("@us_pass", SqlDbType.VarChar).Value = u_otp.Text;
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                //Session["useremail"] = u_mobile.Text;
               if (Session["booktime"] == null)
                {
                    Response.Redirect("account.aspx");
                }
                else
                {
                    string time = Session["booktime"].ToString();
                    string clinic_id = Session["clinicid"].ToString();
                    string bookdate = Session["book_date"].ToString();
                    Response.Redirect("bookdetail.aspx?cid=" + clinic_id + "&btime=" + time + "&bdate=" + bookdate);
                }
            }
            else
            {
                Label1.Text = "*Invalid OTP.";

            }
        }
        else
        {
            Response.Redirect("index2.aspx");
        }
    }
}