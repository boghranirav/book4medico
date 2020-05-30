using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class deletereview : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string id=Request.QueryString["fbid"];
        bool b=con1.UpdateDeleteData("delete from Doctor_feedback where fb_id='"+id+"'");
        string msg = "";
        if (b == true)
        {
            msg = "success";
        }
        else {
            msg = "error";
         }
        Response.Redirect("viewappointment.aspx?ermsg2="+msg);
    }
}