using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_view_clinic : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();

    string str_clinic = "";
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id=Request.QueryString["did"];
        dt1 = con1.GetData("select * from Doctor_clinic dc, City_info ci,Area_info ai where ai.area_id=dc.area_id and ci.city_id=dc.city_id and dc.doc_id="+id);

        foreach (DataRow dr1 in dt1.Rows)
        {
            i++;
            str_clinic += "<table class='table table-striped table-bordered'><thead></thead><tbody><tr><td colspan='2'><center>Clinic " + i + " </center></td></tr><tr class='odd gradeX'><td><b>Clinic Name </b></td><td>" + dr1["clinic_name"] + "</td></tr><tr class='odd gradeX'><td><b>Phone No.</b></td><td>" + dr1["phone_no"] + "</td></tr><tr class='odd gradeX'><td><b>Email Id</b></td><td>" + dr1["email_id"] + "</td></tr><tr class='odd gradeX'><td><b>City Name</b></td><td>" + dr1["city_name"] + "</td></tr><tr class='odd gradeX'><td><b>Area Name</b></td><td>" + dr1["area_name"] + "</td></tr><tr class='odd gradeX'><td><b>Address</b></td><td>" + dr1["address"] + "</td></tr><tr class='odd gradeX'><td><b>Pin Code</b></td><td>" + dr1["pincode"] + "</td></tr><tr class='odd gradeX'><td><b>Fees</b></td><td>" + dr1["fees"] + "</td></tr><tr><td colspan='2'  align='right'><a href='admin_view_clinic_photos.aspx?dclid="+dr1["dclinic_id"]+"'>View Photos</a></td></tr></tbody></table>";
        }

        tbl_disp.InnerHtml = str_clinic;
    }
}