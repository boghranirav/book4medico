using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_deletestate : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["stid"];
        bool b = conc.UpdateDeleteData("delete from  State_info  where state_id='" + id + "'");

        string msg;
        if (b == true)
        {
            msg = "success";


        }
        else
        {
            msg = "error";
        }
        Response.Redirect("admin_state.aspx?ermsg=" + msg);
        

    }
}