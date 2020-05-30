using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_country : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = conc.GetData("select * from Country_info");
        string str = "";
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i++;
            string coun = dr["country_name"].ToString();
            str += "<tr><td>" + i + "</td><td>" + coun + "</td>";
            str += "<td align='center' width='8%'><a href='admin_editcountry.aspx?cntid=" + dr["country_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
            str += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["country_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
        }
        a_country.InnerHtml = str;
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Country Not Deleted');");
                Response.Write("</script>");
            }

        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bool cou = conc.SaveData("country_name", admin_country.Text);
        if (cou == true)
        {
            Response.Write("<script>");
            Response.Write("alert('Added');");
            Response.Write("</script>");
            Response.Redirect("admin_country.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Not Added');");
            Response.Write("</script>");
        }
    }
}