using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_delete_practice_staff : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["psid"];
        bool b = con1.UpdateDeleteData("delete from Practice_staff  where staff_id='" + id + "'");

        string msg;
        if (b == true)
        {
            msg = "success";
        }
        else
        {
            msg = "error";
        }
        Response.Redirect("doc_practice_staff.aspx?ermsg=" + msg);
    }
}