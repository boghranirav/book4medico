using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editspecialization : System.Web.UI.Page
{
    connectionclass conspe = new connectionclass();
    DataTable dtspe = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["speid"];

            dtspe = conspe.GetData("select * from Specializations_info where spe_id='" + id + "'");
            foreach (DataRow dr in dtspe.Rows)
            {
                admin_spe.Text = dr["spe_name"].ToString();
            }
        }

    }
    protected void update_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["speid"];
        bool b = conspe.UpdateDeleteData("update Specializations_info set spe_name='" + admin_spe.Text + "' where spe_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_specialization.aspx");
           
         }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    
    }
    
}