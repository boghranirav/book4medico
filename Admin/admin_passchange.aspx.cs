using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class Admin_admin_passchange : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();

    string old_p = "";
    string s_null = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        old_pass.Attributes.Add("value",s_null);
        lblcheck.Text = "";
        string aid = Session["admin_id"].ToString();
        dt1 = con1.GetData("select * from Admin_login where admin_id='"+aid+"'");
        foreach (DataRow dr1 in dt1.Rows)
        {
            admin_id.Text = dr1["admin_id"].ToString();            
        }

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        dt2.Clear();
            dt2 = con2.GetData("select * from Admin_login where admin_id='"+Session["admin_id"].ToString()+"' and admin_password='"+old_pass.Text+"'");
            if (dt2.Rows.Count <= 0)
            {
                lblcheck.Text = "*Old Password Does Not Match.";
            }
        else
        if (lblcheck.Text == "")
        {
            string aid = Session["admin_id"].ToString();
            bool b = con1.UpdateDeleteData("update Admin_login set admin_password='" + new_pass.Text + "' where admin_id='" + aid + "'");
            if (b == true)
            {
                Response.Redirect("admin_login.aspx");
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