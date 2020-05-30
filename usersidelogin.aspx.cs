using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;


public partial class usersidelogin : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();
  //  SqlCommand cmd = new SqlCommand();

    Random r1 = new Random();
    string code = "";

    protected void Page_Load(object sender, EventArgs e)
    {
     //   cmd.Connection = con;
       // con.Open();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        dt1 = con1.GetData("select * from User_registration where user_mobile='"+u_mobile.Text+"'");
        if (dt1.Rows.Count <= 0)
        {
            Label1.Text = "Mobile Number Not Found.";
        }
        else
        {
            code = (r1.Next(100000, 999999)).ToString();
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://71.18.59.95/sms/insertsms.php?user=uid&pass=pass&list=" + u_mobile.Text + "&msg=Your OTP : " + code + "");
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
                bool b = con1.UpdateDeleteData("update User_registration set user_password='" + code + "' where user_mobile='" + u_mobile.Text + "'");
                if (b == true)
                {
                    try
                    {
                        Session["usermobile"] = u_mobile.Text;
                        Response.Redirect("user_confirm.aspx");
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "*Please Try Again Later.";
                    }
                }
                else
                {
                    Label1.Text = "*Please Try Again Later.";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "*Please Try Again Later.";
            }
        }

        //cmd.CommandText = "sp_user_login";user_confirm.aspx
       // cmd.CommandType = System.Data.CommandType.StoredProcedure;
       // cmd.Parameters.Add("@us_mobile", SqlDbType.VarChar).Value = u_mobile.Text;
       // if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
       // {
       //     //Session["useremail"] = u_mobile.Text;
       //     Session["usermobile"] = u_mobile.Text;
       //     if (Session["booktime"] == null)
       //     {
       //         Response.Redirect("account.aspx");
       //     }
       //     else
       //     {
       //         string time = Session["booktime"].ToString();
       //         string clinic_id = Session["clinicid"].ToString();
       //         string bookdate = Session["book_date"].ToString();
       //         Response.Redirect("bookdetail.aspx?cid="+clinic_id+"&btime="+time+"&bdate="+bookdate);
       //     }
       // }
       // else
       // {
       //      Label1.Text="*Invalid id & Password";
        
       // }
    }
}