using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


public partial class Doctor_cancel_p_appointment : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["appid"]);

        dt1 = con1.GetData("select * from Patient_appointment pa,User_registration ur,Doctor_basic_info dbi where dbi.doc_id=pa.doc_id and ur.user_id=pa.patient_id and pa.appoint_id='"+id+"'");
        foreach(DataRow dr1 in dt1.Rows)
        {
                try
                {
                    string toAddress = dr1["user_mobile"].ToString();
                    string body = "Doctor " + dr1["first_name"].ToString() + " " + dr1["last_name"].ToString() + " had cancelled your appointment as on "+Convert.ToDateTime( dr1["book_date"]).ToShortDateString()+" "+Convert.ToDateTime( dr1["book_time"]).ToShortTimeString()+".";
                    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://71.18.59.95/sms/insertsms.php?user=uid&pass=pass&list=" + toAddress + "&msg= " + body + "");
                    HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                    string responseString = respStreamReader.ReadToEnd();
                    respStreamReader.Close();
                    myResp.Close();
                }
                catch (Exception ex)
                {
                    Response.Redirect("index2.aspx");
                }
        }

        bool b = con1.UpdateDeleteData("delete from patient_appointment where appoint_id='" + id + "'");
        if (b == true)
        {

            Response.Redirect("index2.aspx?ermsg=success");
        }
        else
        {
            Response.Redirect("index2.aspx?ermsg=error");
        }


       
    }
}