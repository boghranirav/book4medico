using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_state : System.Web.UI.Page
{

    connectionclass concoun = new connectionclass();
    connectionclass constate = new connectionclass();
    connectionclass conc = new connectionclass();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();


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

        dt2 = constate.GetData("select * from State_info");

        dt3 = conc.GetData("select s.state_name,s.state_id,c.country_name,s.country_id from State_info s,Country_info c where c.country_id=s.country_id");
        string str = "";
        int i = 0;
        foreach (DataRow dr3 in dt3.Rows)
        {
            i++;
            string st = dr3["state_name"].ToString();
            string coun = dr3["country_name"].ToString();
            str += "<tr><td>" + i + "</td><td>" + st + "</td>";
            str += "<td>" + coun + "</td><td align='center' width='8%'><a href='admin_editstate.aspx?stid=" + dr3["state_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
            str += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr3["state_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
        }
        tbl_state.InnerHtml = str;
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('State Not Deleted');");
                Response.Write("</script>");
            }

        }

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string coun_id = admin_country.SelectedValue.ToString();
        bool cou = constate.SaveData("country_id",coun_id ,"state_name",admin_state.Text);
        if (cou == true)
        {
            Response.Redirect("admin_state.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data not added');");
            Response.Write("</script>");
        }
    }
}