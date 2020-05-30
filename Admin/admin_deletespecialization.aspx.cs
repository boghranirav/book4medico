using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_deletespecialization : System.Web.UI.Page
{
    connectionclass conspe = new connectionclass();
   
    
    protected void Page_Load(object sender, EventArgs e)
    {

        string id = Request.QueryString["speid"];
        bool b = conspe.UpdateDeleteData("delete from Specializations_info where spe_id='" + id + "'");
        
            Response.Redirect("admin_specialization.aspx");
        
        string msg;
        if (b == true)
        {
            msg = "success";
            Response.Redirect("admin_specialization.aspx?ermsg=" + msg);

        }
        else
        {
            msg = "error";
            Response.Redirect("admin_specialization.aspx?ermsg=" + msg);
        }
    }
    
       
    
}