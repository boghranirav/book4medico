using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_city : System.Web.UI.Page
{
    connectionclass concoun = new connectionclass();
    connectionclass constate = new connectionclass();
    connectionclass conc = new connectionclass();
    connectionclass disp = new connectionclass();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();

    string str_tab = "";

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

        dt3 = conc.GetData("select * from City_info");
        dt4 = disp.GetData("select c.city_name,c.city_id,s.state_name,co.country_name from City_info c,State_info s,Country_info co where c.state_id=s.state_id and s.country_id=co.country_id");
        int i=0;
        foreach (DataRow dr4 in dt4.Rows)
        {
            i++;
            string citynm=dr4["city_name"].ToString();
            string statenm=dr4["state_name"].ToString();
            string counnm=dr4["country_name"].ToString();
            str_tab += "<tr><td>" + i + "</td><td>" + citynm + "</td>";
            str_tab += "<td>" + statenm + "</td><td>" + counnm + "</td>";
            str_tab += "<td align='center' width='8%'><a href='admin_editcity.aspx?ctid=" + dr4["city_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
            str_tab += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr4["city_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
        }
        tbl_city.InnerHtml = str_tab;
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('City Not Deleted');");
                Response.Write("</script>");
            }

        }
    }
    protected void dd_country1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_state.Items.Clear();
        dd_state.Items.Add(new ListItem("SELECT", "0"));
        
        string coun_id = dd_country1.SelectedValue.ToString();

        dt2 = constate.GetData("select * from State_info where country_id="+coun_id);
            foreach (DataRow dr2 in dt2.Rows)
            {
                dd_state.Items.Add(new ListItem(dr2["state_name"].ToString(), dr2["state_id"].ToString()));
            }
       
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string state_id = dd_state.SelectedValue.ToString();
        bool cou = conc.SaveData("state_id", state_id ,"city_name",admin_city.Text);
        if (cou == true)
        {

            Response.Redirect("admin_city.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Added');");
            Response.Write("</script>");
        }
    }
}