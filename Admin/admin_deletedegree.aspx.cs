using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_deletedegree : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["degid"];
        bool b = conc.UpdateDeleteData("delete from  Degree_info  where degree_id='" + id + "'");

        string msg;
        if (b == true)
        {
            msg = "success";
        

        }
        else
        {
            msg = "error";
        }
        Response.Redirect("admin_degree.aspx?ermsg=" + msg);
        

    }
}