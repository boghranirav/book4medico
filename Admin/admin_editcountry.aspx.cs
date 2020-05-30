using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editcountry : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["cntid"];

            dt = conc.GetData("select country_name,country_id from Country_info where   country_id='" + id + "'");
            foreach (DataRow dr in dt.Rows)
            {
                admin_country.Text = dr["country_name"].ToString();
                

            }

        }

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["cntid"];
        bool b = conc.UpdateDeleteData("update Country_info set country_name='" + admin_country.Text + "' where country_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_country.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    }
   
}