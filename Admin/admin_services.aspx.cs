using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_services : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    DataTable dt1 = new DataTable();
    string str_service = "";
    int srno;
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = conc.GetData("select * from Services");
        srno = 1;
        foreach (DataRow d in dt1.Rows)
        {
            str_service += "<tr class='odd gradeX'> <td>" + srno + "</td>";
            str_service += "<td>" + d["service_name"] + "</td>";
            str_service += "<td align='center' width='8%'><a href='admin_editservices.aspx?serid=" + d["service_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
            str_service += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + d["service_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
            srno++;
        }
        tbl_service.InnerHtml = str_service;
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1=="error")
            {
                Response.Write("<script>");
                Response.Write("alert('Service Not Deleted');");
                Response.Write("</script>");
            }

        }

    }
   
    protected void submit_Click(object sender, EventArgs e)
    {
        bool b1 = conc.SaveData("service_name", admin_service.Text);
        if (b1 == true)
        {
            Response.Redirect("admin_services.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('not');");
            Response.Write("</script>");
        }
    }
}