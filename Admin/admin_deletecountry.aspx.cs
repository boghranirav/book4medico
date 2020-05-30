using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_admin_deletecountry : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["cntid"];
        bool b = conc.UpdateDeleteData("delete from  Country_info  where country_id='" + id + "'");

        string msg;
        if (b == true)
        {
            msg = "success";


        }
        else
        {
            msg = "error";
        }
        Response.Redirect("admin_country.aspx?ermsg=" + msg);
        

    }
}