using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_patient_detail : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    string docid = "";
    string pid = "",tbl_data="";

    protected void Page_Load(object sender, EventArgs e)
    {
        string aid=Request.QueryString["aid"];
        dt1 = con1.GetData("select pa.appoint_id,pa.patient_id,pa.doc_id,ur.user_id,ur.user_email,ur.user_name,ur.user_mobile,ur.user_gender,ur.user_dob,pa.current_time_p from User_registration ur,Patient_appointment pa where pa.patient_id=ur.user_id and pa.appoint_id='" + aid + "' order by pa.current_time_p");
        DateTime datet = DateTime.Now;
        
        foreach(DataRow dr1 in dt1.Rows)
        {
            docid=dr1["doc_id"].ToString();
            pid=dr1["patient_id"].ToString();
            p_first_name.Text = dr1["user_name"].ToString();
            p_email.Text = dr1["user_email"].ToString();
            p_mobile.Text = dr1["user_mobile"].ToString();
            p_gender.Text = dr1["user_gender"].ToString();
            if (dr1["user_dob"].ToString() != "")
            {
                p_birthdate.Text = Convert.ToDateTime(dr1["user_dob"].ToString()).ToShortDateString();
                datet = Convert.ToDateTime(datet.ToShortDateString());
                p_age.Text = (datet.Year - Convert.ToDateTime(p_birthdate.Text).Year).ToString();
            }
        }

        dt2 = con2.GetData("select * from Patient_appointment pa,Doctor_clinic dc where dc.dclinic_id=pa.dclinic_id and pa.doc_id='"+docid+"' and pa.patient_id='"+pid+"'");
        foreach(DataRow dr2 in dt2.Rows)
        {
            tbl_data += "<tr>";
            tbl_data += "<td>" + dr2["clinic_name"] + "</td>";
            tbl_data += "<td>" +Convert.ToDateTime( dr2["book_date"]).ToShortDateString() + "</td>";
            tbl_data += "<td>" +Convert.ToDateTime( dr2["book_time"]).ToShortTimeString() + "</td>";
            tbl_data += "<td>" + dr2["book_reason"] + "</td>";
            tbl_data += "</tr>";
        }
        tbl_appontment_h.InnerHtml = tbl_data;

    }
}