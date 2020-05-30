using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editstate : System.Web.UI.Page
{
    connectionclass concoun = new connectionclass();
    connectionclass conc = new connectionclass();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = concoun.GetData("select * from Country_info");
        if (!IsPostBack)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                admin_country.Items.Add(new ListItem(dr["country_name"].ToString(), dr["country_id"].ToString()));
            }
        }
        if (!IsPostBack)
        {
            string id = Request.QueryString["stid"];

            dt = conc.GetData("select st.state_name,st.state_id,c.country_name,c.country_id from State_info st,Country_info c where   st.country_id=c.country_id and  state_id='" + id + "'");
            foreach (DataRow dr in dt.Rows)
            {
                admin_country.SelectedValue = dr["country_id"].ToString();
                admin_state.Text = dr["state_name"].ToString();
                
            }

        }

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["stid"];
        bool b = conc.UpdateDeleteData("update State_info set state_name='" + admin_state.Text + "' where state_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_state.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }

    }
    
}