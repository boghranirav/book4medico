using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

public partial class Doctor_doc_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();
    SqlCommand cmd = new SqlCommand();

    string c_status="";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string check_s=Request.QueryString["result"];
        if (check_s=="success")
        {
            Response.Write("<script>");
            Response.Write("alert('Please Check Your Email ID You Registered With Us. We have send you verification Code. To Login You need to Verify Link.');");
            Response.Write("</script>");
        }
        else
            if (check_s == "verified")
            {
                Response.Write("<script>");
                Response.Write("alert('Successfully Verified. You Can Log In Now.');");
                Response.Write("</script>");
            }
            else
                if (check_s == "uverified")
                {
                    Response.Write("<script>");
                    Response.Write("alert('Error In Verification. Please Try Later.');");
                    Response.Write("</script>");
                }
                
        if (Session["doctor_id"] != null)
        {
            Response.Redirect("index2.aspx");
        }
        
        cmd.Connection = con;
        con.Open();
    }
    protected void user_password_TextChanged(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "sp_doctor_login";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add("@doc_email_id", SqlDbType.VarChar).Value = user_id.Text;
        cmd.Parameters.Add("@doc_password",SqlDbType.VarChar).Value=user_password.Text;
        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
        {
           
            dt1 = con1.GetData("select d_status from Doctor_registration where doc_r_email_id='"+user_id.Text+"'");
            foreach (DataRow dr1 in dt1.Rows)
            {
                c_status = dr1["d_status"].ToString();
            }

            if (c_status == "A")
            {
                Label1.Text = "*You Are Blocked By Admin.For more information contact admin.";
            }else
            if (c_status == "U")
            {
                Session["doctor_id"] = user_id.Text;
                Response.Redirect("index2.aspx");
            }
            else
            {
                Label1.Text = "*You have not Verify Your Accout. Please Varify to Proceed.";
            }
        }
        else {
            Label1.Text = "*Invalid Email Id Or Password..";
        }

    }
    protected void register_Click(object sender, EventArgs e)
    {

        Response.Redirect("doc_login_reg.aspx"); 
 
    }
}