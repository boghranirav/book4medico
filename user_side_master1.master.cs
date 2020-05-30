using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class user_side_master1 : System.Web.UI.MasterPage
{
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();

    string disp="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usermobile"] != null)
        {
            login_dis.Visible = false;
            disp+="<li class='dropdown my-account'>";
			disp+="<a data-toggle='dropdown' class='dropdown-toggle' href='#'>My Account <i class='fa fa-angle-down'></i></a>";
			disp+="<ul role='menu' class='dropdown-menu' >";
			disp+="<li><a href='account.aspx'>Profile</a></li>";
			disp+="<li><a href='viewappointment.aspx'>Appointment</a></li>";
			disp+="<li><a href='logout.aspx'>LogOut</a></li>";
			disp+="</ul>";
			disp+="</li>";
        }

        master_profile.InnerHtml = disp;
    }
}
