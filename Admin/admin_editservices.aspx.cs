using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editservices : System.Web.UI.Page
{
    connectionclass conser = new connectionclass();
    DataTable dtser = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["serid"];

            dtser = conser.GetData("select * from Services where service_id='" + id + "'");
            foreach (DataRow dr in dtser.Rows)
            {
                admin_service.Text = dr["service_name"].ToString();
            }
        }

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["serid"];
        bool b = conser.UpdateDeleteData("update Services set service_name='" + admin_service.Text + "' where service_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_services.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
   

    }
    
}