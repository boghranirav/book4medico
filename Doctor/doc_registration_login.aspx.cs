using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;

public partial class Doctor_doc_registration_login : System.Web.UI.Page
{

    connectionclass conc = new connectionclass();
   
    Random r1 = new Random();
    string code = "";
    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        email_id.Focus();
        code = (r1.Next(10000, 99999)).ToString();

       dt1 = conc.GetData("select * from Doctor_registration");
        
        //Response.Write(code);

    }
    protected void submit_Click(object sender, EventArgs e)
    {
            DateTime currdt = DateTime.Now.AddDays(0);
            code = currdt.ToString("ddMMyyyy") + code;
            bool cou = conc.SaveData("doc_id", code, "doc_r_email_id", email_id.Text, "doc_r_password", doc_password.Text, "doc_r_date_time", currdt.ToString(), "doc_r_mobile_no", doc_mobile.Text);
            if (cou == true)
            {
                try
                {
                    string fromAddress = "gmail_id@gmail.com";
                    string toAddress = email_id.Text;
                    const string pass = "password";
                    string sub = "login";

                    

                    string body = "http://localhost:55544/book4medico/Doctor/doc_verification.aspx?verify="+code;

                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(fromAddress, pass);
                        smtp.Timeout = 20000;
                    }
                    smtp.Send(fromAddress, toAddress, sub, body);

                    Response.Redirect("doc_login.aspx?result=success");
                }catch(Exception ex){
                    Response.Write(ex.ToString());
                }
            }
            else
            {
                Response.Write("Data Not Added");
            }
       
    }
    [System.Web.Services.WebMethod]
    public static string CheckEmail(string useroremail)
    {
        string retval = "";

        if (useroremail == "")
        {
            retval="1";
        }
        else
        {
            
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  doc_r_email_id from Doctor_registration where doc_r_email_id=@doc_r_email_id", con);
            cmd.Parameters.AddWithValue("@doc_r_email_id", useroremail);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                retval = "true";
            }
            else
            {
                retval = "false";
            }
        }
            return retval;
      
    }

    protected void cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("doc_login.aspx");
    }
   
}