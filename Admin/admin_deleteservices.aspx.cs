using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_deleteservices : System.Web.UI.Page
{
    connectionclass conser = new connectionclass();
     
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string id = Request.QueryString["serid"];
        bool b = conser.UpdateDeleteData("delete from  Services  where service_id='" + id + "'");

        string msg;
        if (b == true)
        {
           msg = "success";
            Response.Redirect("admin_services.aspx?ermsg="+msg);

        }
        else
        {
            msg = "error";
            Response.Redirect("admin_services.aspx?ermsg=" + msg);
        }
      
    }
    
}