using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_doctor_deatils : System.Web.UI.Page
{
    connectionclass con1 =new connectionclass();
    connectionclass con2 = new connectionclass();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();

    string str_doc = "";
    string status_d = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["dcid"];
        dt1 = con1.GetData("select * from Doctor_basic_info dbi, Doctor_registration dr,Country_info ci where dr.doc_id=dbi.doc_id and ci.country_id=dbi.country and dbi.doc_id="+id);
       
        foreach (DataRow dr1 in dt1.Rows)
        {
            status_d=dr1["d_status"].ToString();

            if (status_d=="A")
            {
                block.Checked = true;
            }
            else
                if (status_d=="B")
                {
                    block.Checked = true;
                }
                else
            
            if (status_d == "U")
                {
                    unblock.Checked = true;
                }
            string img_src = "../Doctor/profile_pictures/" + dr1["profile_picture"];
            str_doc += "<tr class='odd gradeX'><td colspan='2'><center><img src='" + img_src + "' width='100' height='100' title='Profile Picture of Dr. " + dr1["first_name"] + " " + dr1["last_name"] + "'></center></td></tr><tr class='odd gradeX'><td  width='40%'><b>Doctor Id</b></td><td>" + dr1["doc_id"] + "</td></tr><tr class='odd gradeX'><td><b>Name</b></td><td>" + dr1["first_name"] + " " + dr1["last_name"] + "</td></tr><tr class='odd gradeX'><td><b>Email Id</b></td><td>" + dr1["doc_r_email_id"] + "</td></tr><tr class='odd gradeX'><td><b>Mobile No.</b></td><td>" + dr1["doc_r_mobile_no"] + "</td></tr><tr class='odd gradeX'><td><b>Gender</b></td><td>" + dr1["gender"] + "</td></tr><tr class='odd gradeX'><td><b>Country</b></td><td>" + dr1["country_name"] + "</td></tr><tr class='odd gradeX'><td><b>Experience</b></td><td>" + dr1["experience"] + "</td></tr><tr class='odd gradeX'><td><b>Registered On(Date/Time) :</b></td><td>" + dr1["doc_r_date_time"] + "</td></tr><tr class='odd gradeX'><td colspan='2'><center><a href='index2.aspx' class='btn btn-primary'>Back</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='admin_view_clinic.aspx?did="+id+"' class='btn btn-primary'>View Clinics</a></center></td></tr>";
        }


        tbl_disp.InnerHtml = str_doc;

    }
    protected void block_CheckedChanged(object sender, EventArgs e)
    {
        string id = Request.QueryString["dcid"];
        bool check=con2.UpdateDeleteData("update Doctor_registration set d_status='A' where doc_id="+id);

        if (check == true)
        {
            Response.Write("<script>");
            Response.Write("alert('Status Updated.')");
            Response.Write("</script>");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Status Not Updated.')");
            Response.Write("</script>");
        }
    }
    protected void unblock_CheckedChanged(object sender, EventArgs e)
    {
        string id = Request.QueryString["dcid"];
        bool check = con2.UpdateDeleteData("update Doctor_registration set d_status='U' where doc_id=" + id);

        if (check == true)
        {
            Response.Write("<script>");
            Response.Write("alert('Status Updated.')");
            Response.Write("</script>");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Status Not Updated.')");
            Response.Write("</script>");
        }
    }
}