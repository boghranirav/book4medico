using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Doctor_doc_passchange : System.Web.UI.Page
{

    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblcheck.Text = "";
        string did = Session["doctor_reg_id"].ToString();
        dt1 = con1.GetData("select * from Doctor_registration where doc_id='" + did + "'");
        foreach (DataRow dr1 in dt1.Rows)
        {
            doc_id.Text = dr1["doc_r_email_id"].ToString();
        }

    }
    
    protected void submit_Click(object sender, EventArgs e)
    {
        dt2 = con2.GetData("select * from Doctor_registration where doc_r_password='"+old_pass.Text+"' and doc_r_email_id='"+doc_id.Text+"'");
        if (dt2.Rows.Count <= 0)
        {
            lblcheck.Text = "Old Password Does Not Match.";
        }
        else
        {
            string aid = Session["doctor_reg_id"].ToString();
            bool b = con1.UpdateDeleteData("update Doctor_registration set doc_r_password='" + new_pass.Text + "' where doc_id='" + aid + "'");
            if (b == true)
            {
                Response.Redirect("index2.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Password Not Changed')");
                Response.Write("</script>");
            }
            
        }
       

          
    }
}