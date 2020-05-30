using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doctor_side_masterpage2 : System.Web.UI.MasterPage
{
    connectionclass conc = new connectionclass();
   
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["doctor_id"] != null || Session["doctor_reg_id"] != null)
        {
            Label1.Text = Session["doctor_id"].ToString();
            Label2.Text = Session["doctor_id"].ToString();
        
        }
        else
        {
            Response.Redirect("doc_login.aspx");
        }
        String activepage = Request.RawUrl;
        //if (activepage.Contains("doc_personal_info.aspx"))
        //{
        //    doctor_info.Attributes["class"] = "active";
        //    person.Attributes["class"] = "active";
        //}
        //else
        if (activepage.Contains("doc_specialization.aspx"))
        {
            dr_specialization.Attributes["class"] = "active";
        }
        else
        if (activepage.Contains("doc_services.aspx"))
        {
            dr_services.Attributes["class"] = "active";
        }
        else
            if (activepage.Contains("doc_clinic_info.aspx"))
        {
            dr_clinic.Attributes["class"] = "active";
        }
            else
                if (activepage.Contains("doc_clinic_photos.aspx"))
                {
                    dr_clinic_photos.Attributes["class"] = "active";
                }
                else
                    if (activepage.Contains("doc_practice_staff.aspx"))
                    {
                        dr_practice_staff.Attributes["class"] = "active";
                    }
                    else
                        if (activepage.Contains("doc_clinic_timing.aspx"))
                        {
                            dr_timing.Attributes["class"] = "active";
                        }
        

        dt = conc.GetData("select * from Doctor_basic_info where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"]) + " ");
        if (dt.Rows != null)
        {
            foreach (DataRow d in dt.Rows)
            {
                Image2.ImageUrl = "~/Doctor/profile_pictures/" + d["profile_picture"].ToString();
                Image1.ImageUrl = "~/Doctor/profile_pictures/" + d["profile_picture"].ToString();
            }

           
        }
    }
}
