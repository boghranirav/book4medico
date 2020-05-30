using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_deletearea : System.Web.UI.Page
{
    connectionclass conc=new connectionclass();
    protected void Page_Load(object sender, EventArgs e)
    {

           string id = Request.QueryString["arid"];
        bool b = conc.UpdateDeleteData("delete from  Area_info  where area_id='" + id + "'");

        string msg;
        if (b == true)
        {
            msg = "success";
        

        }
        else
        {
            msg = "error";
        }
        Response.Redirect("admin_area.aspx?ermsg=" + msg);
        

    }

    
}