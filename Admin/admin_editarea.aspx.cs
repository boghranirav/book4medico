using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_editarea : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    DataTable dt = new DataTable();
  
    connectionclass constate = new connectionclass();
    connectionclass concoun = new connectionclass();
    connectionclass conarea = new connectionclass();
    connectionclass consta = new connectionclass();
    connectionclass conct = new connectionclass();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dtst = new DataTable();
    DataTable dtct = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = concoun.GetData("select * from Country_info");
        if (!IsPostBack)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                dd_country2.Items.Add(new ListItem(dr["country_name"].ToString(), dr["country_id"].ToString()));
            }
        }

        if (!IsPostBack)
        {
            string id = Request.QueryString["arid"];

            dt = conc.GetData("select a.area_name,ct.city_name,ct.city_id,st.state_name,st.state_id,c.country_name,c.country_id from Area_info a,City_info ct,State_info st,Country_info c where a.city_id=ct.city_id and ct.state_id=st.state_id and st.country_id=c.country_id and  area_id='" + id + "'");
            foreach (DataRow dr in dt.Rows)
            {
                dd_country2.SelectedValue = dr["country_id"].ToString();
                admin_area.Text = dr["area_name"].ToString();
                dtst = consta.GetData("select * from State_info where country_id=" + dd_country2.SelectedValue.ToString());
               
                foreach (DataRow dr1 in dtst.Rows)
                {
                    dd_state1.Items.Add(new ListItem(dr1["state_name"].ToString(), dr1["state_id"].ToString()));
                    dd_state1.SelectedValue = dr["state_id"].ToString();
                    dtct.Clear();
                    dtct = conct.GetData("select * from City_info where state_id=" + dd_state1.SelectedValue.ToString());
                    dd_city.Items.Clear();
                    foreach (DataRow dr2 in dtct.Rows)
                    {
                        dd_city.Items.Add(new ListItem(dr2["city_name"].ToString(), dr2["city_id"].ToString()));
                        dd_city.SelectedValue = dr["city_id"].ToString();
                    }
                }
            }
            
        }
    }
    protected void dd_state1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_city.Items.Clear();
        dd_city.Items.Add(new ListItem("SELECT", "0"));

        string state_id = dd_state1.SelectedValue.ToString();

        dt3 = conarea.GetData("select city_name,city_id from City_info where state_id=" + state_id);

        foreach (DataRow dr3 in dt3.Rows)
        {
            dd_city.Items.Add(new ListItem(dr3["city_name"].ToString(), dr3["city_id"].ToString()));
        }
        dd_city.Items.RemoveAt(1);
        admin_area.Text = "";
    }
    protected void dd_country2_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_state1.Items.Clear();
        dd_state1.Items.Add(new ListItem("SELECT", "0"));

        string coun_id = dd_country2.SelectedValue.ToString();

        dt2 = constate.GetData("select * from State_info where country_id=" + coun_id);
        foreach (DataRow dr2 in dt2.Rows)
        {
            dd_state1.Items.Add(new ListItem(dr2["state_name"].ToString(), dr2["state_id"].ToString()));
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["arid"];
        bool b = conc.UpdateDeleteData("update Area_info set Area_name='" + admin_area.Text + "' where area_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("admin_area.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    }
   
}