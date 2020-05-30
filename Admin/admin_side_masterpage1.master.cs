using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_side_masterpage1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] != null)
        {

            Label1.Text = Session["admin_id"].ToString();
            Label2.Text = Session["admin_id"].ToString();
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }

        String activepage = Request.RawUrl;
        if (activepage.Contains("index2.aspx"))
        {
            dashboard.Attributes["class"] = "active";
        }
        else
            if (activepage.Contains("admin_specialization.aspx") || activepage.Contains("admin_editspecialization.aspx"))
            {
                dr_specialization.Attributes["class"] = "active";
            }
            else
                if (activepage.Contains("admin_degree.aspx") || activepage.Contains("admin_editdegree.aspx"))
                {
                    dr_degree.Attributes["class"] = "active";
                }
                 else
                    if (activepage.Contains("admin_services.aspx") || activepage.Contains("admin_editservices.aspx"))
                {
                    dr_services.Attributes["class"] = "active";
                }
                    else
                        if (activepage.Contains("admin_passchange.aspx"))
                        {
                            pass_change.Attributes["class"] = "active";
                        }
                //else
                //    if (activepage.Contains("admin_city.aspx"))
                //    {
                //        dr_location.Attributes["class"] = "active";
                //    }
        
               

    }
}
