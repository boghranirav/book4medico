using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Doctor_index : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    DataTable dt = new DataTable();

    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();

    connectionclass con2 = new connectionclass();
    DataTable dt2 = new DataTable();

    string doc_app_disp_up = "";

    DateTime currtdate2 = DateTime.Now;

    public void fill_appointment()
    {
        foreach (DataRow dr1 in dt1.Rows)
        {
            DateTime date1 = Convert.ToDateTime(dr1["book_date"].ToString());
            string bookdate = date1.ToString("dd MMM,yyyy");
            DateTime dt_p = Convert.ToDateTime(dr1["book_time"].ToString());
            string time_p = dt_p.ToShortTimeString();

            doc_app_disp_up += "<tr><td width='14%'>" + dr1["user_name"] + "</td>";
            doc_app_disp_up += "<td  width='10%'>" + dr1["clinic_name"] + "</td>";
            doc_app_disp_up += "<td  width='10%'>" + dr1["user_mobile"] + "</td>";
            doc_app_disp_up += "<td>" + bookdate + "</td>";
            doc_app_disp_up += "<td  width='10%'>" + time_p + "</td>";
            doc_app_disp_up += "<td>" + dr1["book_reason"] + "</td>";
            doc_app_disp_up += "<td width='5%' align='center'><a href='doc_patient_detail.aspx?aid=" + dr1["appoint_id"] + "'>Detail</a></td>";
            doc_app_disp_up += "<td width='5%' align='center'><a href='Javascript:cancelappfunction(" + dr1["appoint_id"] + ");'><i class='fa fa-2x fa-times'></i></a></td></tr>";
        }
        tbl_display_upcoming.InnerHtml = doc_app_disp_up;
    }

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Appointment Not Canceled.');");
                Response.Write("</script>");
            }

        }
        string str = "";
        string sql = "select doc_id from Doctor_registration where doc_r_email_id ='" + Session["doctor_id"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        if (cmd.ExecuteScalar() != null)
        {
            str = cmd.ExecuteScalar().ToString();
        }
        cnn.Close();

        Session["doctor_reg_id"] = str;

        if (!IsPostBack)
        {
            DateTime currtdate = DateTime.Today;
            string cudate = currtdate.ToString("MM/dd/yyyy");
            dt1.Clear();
            dt1 = con1.GetData("select * from Patient_appointment pa,User_registration ur,Doctor_clinic dc where dc.dclinic_id=pa.dclinic_id and pa.book_date>='" + cudate + "' and ur.user_id=pa.patient_id and pa.doc_id='" + Session["doctor_reg_id"].ToString() + "' order by pa.current_time_p desc");
            fill_appointment();
           
        }

       


       
    }


}