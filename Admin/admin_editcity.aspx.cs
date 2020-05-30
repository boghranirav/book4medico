using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editcity : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    connectionclass concoun = new connectionclass();
    connectionclass consta = new connectionclass();
    connectionclass constate = new connectionclass();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dtst = new DataTable();
    DataTable dt2 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = concoun.GetData("select * from Country_info");
        if (!IsPostBack)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                dd_country1.Items.Add(new ListItem(dr["country_name"].ToString(), dr["country_id"].ToString()));
            }
        }

        if (!IsPostBack)
        {
            string id = Request.QueryString["ctid"];

            dt = conc.GetData("select ct.city_name,ct.city_id,st.state_name,st.state_id,c.country_name,c.country_id from City_info ct,State_info st,Country_info c where  ct.state_id=st.state_id and st.country_id=c.country_id and  city_id='" + id + "'");
            foreach (DataRow dr in dt.Rows)
            {
                dd_country1.SelectedValue = dr["country_id"].ToString();
                admin_city.Text = dr["city_name"].ToString();
                dtst = consta.GetData("select * from State_info where country_id=" + dd_country1.SelectedValue.ToString());

                foreach (DataRow dr1 in dtst.Rows)
                {
                    dd_state.Items.Add(new ListItem(dr1["state_name"].ToString(), dr1["state_id"].ToString()));
                    dd_state.SelectedValue = dr["state_id"].ToString();
                    
                }
            }

        }

    }
    protected void dd_country1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_state.Items.Clear();
        dd_state.Items.Add(new ListItem("SELECT", "0"));

        string coun_id = dd_country1.SelectedValue.ToString();

        dt2 = constate.GetData("select * from State_info where country_id=" + coun_id);
        foreach (DataRow dr2 in dt2.Rows)
        {
            dd_state.Items.Add(new ListItem(dr2["state_name"].ToString(), dr2["state_id"].ToString()));
        }

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["ctid"];
        bool b = conc.UpdateDeleteData("update City_info set city_name='" + admin_city.Text + "' where city_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_city.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    }
    
}