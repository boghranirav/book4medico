using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_past_appointment : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();

    string doc_app_disp_pa = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime currtdate = DateTime.Today;
        string cudate = currtdate.ToString("MM/dd/yyyy");
        dt1.Clear();
        dt1 = con1.GetData("select * from Patient_appointment pa,User_registration ur,Doctor_clinic dc where dc.dclinic_id=pa.dclinic_id and pa.book_date<'" + cudate + "' and ur.user_id=pa.patient_id and pa.doc_id='" + Session["doctor_reg_id"].ToString() + "'");

        foreach (DataRow dr1 in dt1.Rows)
        {
            DateTime date1 = Convert.ToDateTime(dr1["book_date"].ToString());
            string bookdate = date1.ToString("dd MMM,yyyy");
            DateTime dt_p = Convert.ToDateTime(dr1["book_time"].ToString());
            string time_p = dt_p.ToShortTimeString();

            doc_app_disp_pa += "<tr><td>" + dr1["user_name"] + "</td>";
            doc_app_disp_pa += "<td>" + dr1["clinic_name"] + "</td>";
            doc_app_disp_pa += "<td>" + dr1["user_mobile"] + "</td>";
            doc_app_disp_pa += "<td>" + dr1["user_email"] + "</td>";
            doc_app_disp_pa += "<td>" + bookdate + "</td>";
            doc_app_disp_pa += "<td>" + time_p + "</td>";
            doc_app_disp_pa += "<td>" + dr1["book_reason"] + "</td>";
            doc_app_disp_pa += "<td align='center'><a href='Javascript:deleteappfunction(" + dr1["appoint_id"] + ");'><img src='../assets/img/delete.png' /></a></td></tr>";
        }
        tbl_display_upcoming.InnerHtml = doc_app_disp_pa;

        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Appointment Record Not Deleted');");
                Response.Write("</script>");
            }

        }
    }
}