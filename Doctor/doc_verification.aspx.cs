using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_verification : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        string code=Request.QueryString["verify"];

        bool c = con1.UpdateDeleteData("update Doctor_registration set d_status='U' where doc_id='"+code+"'");
        if (c == true)
        {
            Response.Redirect("doc_login.aspx?result=verified");
        }
        else
        {
            Response.Write("doc_login.aspx?result=nverified");
        }
    }
}