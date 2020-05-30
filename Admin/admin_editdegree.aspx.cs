using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editdegree : System.Web.UI.Page
{
    connectionclass condeg = new connectionclass();
    DataTable dtdeg = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string id = Request.QueryString["degid"];

            dtdeg = condeg.GetData("select * from Degree_info where degree_id='" + id + "'");
            foreach (DataRow dr in dtdeg.Rows)
            {
                admin_degree.Text = dr["degree_name"].ToString();
            }
        }

    }
    protected void update_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["degid"];
        bool b = condeg.UpdateDeleteData("update Degree_info set Degree_name='" + admin_degree.Text + "' where degree_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_degree.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    }
  
}