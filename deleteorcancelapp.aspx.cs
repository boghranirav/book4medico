using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class deleteorcancelapp : System.Web.UI.Page
{
    connectionclass con1 =new  connectionclass();
    DataTable dt1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string app_id = Request.QueryString["appid"];
        bool b = con1.UpdateDeleteData("delete from Patient_appointment where appoint_id='" + app_id + "'");
        string msg = "";
        if (b == true)
        {
            msg = "success";
        }
        else {
            msg = "error";
        }
        Response.Redirect("viewappointment.aspx?ermsg="+msg);
    }
}