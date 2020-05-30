using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class Admin_admin_area : System.Web.UI.Page
{
    connectionclass concoun = new connectionclass();
    connectionclass constate = new connectionclass();
    connectionclass concity = new connectionclass();
    connectionclass conarea = new connectionclass();
    connectionclass condisplay = new connectionclass();
    connectionclass conarea2 = new connectionclass();


    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dtarea = new DataTable();


    string disp_str="";
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = concoun.GetData("select * from Country_info");
        dtarea = conarea2.GetData("select * from Area_info");

        if (!IsPostBack)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                dd_country2.Items.Add(new ListItem(dr["country_name"].ToString(), dr["country_id"].ToString()));
            }


            dt4 = conarea.GetData("select * from Area_info");

        }
            dt5 = condisplay.GetData("select a.area_id,a.area_name,c.city_name,s.state_name from Area_info a,City_info c,State_info s where a.city_id=c.city_id and c.state_id=s.state_id");
            int i = 0;
            foreach (DataRow dr5 in dt5.Rows)
            {
                i++;
                string area_nm = dr5["area_name"].ToString();
                string city_nm = dr5["city_name"].ToString();
                string state_nm = dr5["state_name"].ToString();
                disp_str += "<tr><td>" + i + "</td><td>" + area_nm + "</td>";
                disp_str += "<td>" + city_nm + "</td><td>" + state_nm + "</td>";
                disp_str += "<td align='center' width='8%'><a href='admin_editarea.aspx?arid=" + dr5["area_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
                disp_str += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr5["area_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
            }
            tbl_area.InnerHtml = disp_str;

        
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Area Not Deleted');");
                Response.Write("</script>");
            }

        }
    }
    protected void dd_state1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_city.Items.Clear();
        dd_city.Items.Add(new ListItem("SELECT","0"));

        string state_id = dd_state1.SelectedValue.ToString();
       
        dt3 = conarea.GetData("select city_name,city_id from City_info where state_id="+state_id);
        
        foreach (DataRow dr3 in dt3.Rows)
        {
            dd_city.Items.Add(new ListItem(dr3["city_name"].ToString(), dr3["city_id"].ToString()));
        }
        //dd_city.Items.RemoveAt(1);
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
    protected void submit_Click(object sender, EventArgs e)
    {
        string city_id = dd_city.SelectedValue.ToString();
        bool cou = conarea2.SaveData("city_id", city_id, "area_name", admin_area.Text);
        if (cou == true)
        {
            Response.Redirect("admin_area.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Not Added.');");
            Response.Write("</script>");
        }
    }

}