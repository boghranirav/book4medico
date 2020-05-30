using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Doctor_doc_practice_staffdetail : System.Web.UI.Page
{
    connectionclass conall = new connectionclass();
    DataTable dtall = new DataTable();
    string str_pstaff;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["psid"];
        dtall = conall.GetData("select * from Doctor_clinic dc,City_info c,Practice_staff p where dc.doc_id=p.doc_id and p.city_id=c.city_id and dc.dclinic_id=p.dclinic_id and staff_id='" + id + "'");
        foreach (DataRow dr1 in dtall.Rows)
        {
            str_pstaff += "<tr><td width='30%'><b>Clinic</b></td><td>" + dr1["clinic_name"] + "</td></tr>";
            str_pstaff += "<tr'><td><b>Staff Name</b></td><td>" + dr1["staff_name"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Mobile No.</b></td><td>" + dr1["s_mobile_no"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Email</b></td><td>" + dr1["s_email"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Registration No.</b></td><td>" + dr1["s_regstration_no"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Address</b></td><td>" + dr1["s_address"] + "</td></tr>";
            str_pstaff += "<tr><td><b>City</b></td><td>" + dr1["city_name"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Note</b></td><td>" + dr1["note"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Education</b></td><td>" + dr1["s_degree"] + "</td></tr>";
            str_pstaff += "<tr><td><b>Registration Board</b></td><td>" + dr1["s_registration_board"] + "</td></tr>";
            str_pstaff += "<tr><td colspan='2'><center><a href='doc_practice_staff.aspx'>Back</a></center></td></tr>";

        }


        tbl_pstaff.InnerHtml = str_pstaff;
    }
}