using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_admin_degree : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    DataTable dt1 = new DataTable();
    string str_degree="";
    int srno;
    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = conc.GetData("select * from Degree_info");
        srno=1;
        foreach (DataRow d in dt1.Rows)
        {
            str_degree += "<tr class='odd gradeX'> <td>" + srno + "</td> ";
            str_degree += " <td>" + d["degree_name"] + "</td> ";
            str_degree += "<td align='center' width='8%'><a href='admin_editdegree.aspx?degid=" + d["degree_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
            str_degree += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + d["degree_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
            srno++;
        }
        tbl_degree.InnerHtml = str_degree;
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Degree Not Deleted');");
                Response.Write("</script>");
            }

        }

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bool b1 = conc.SaveData("degree_name", admin_degree.Text);
        if (b1 == true)
        {

            Response.Redirect("admin_degree.aspx");
        }
        else {
            Response.Write("<script>");
            Response.Write("alert('not');");
            Response.Write("</script>");
        }
    }
    protected void update_Click(object sender, EventArgs e)
    {

    }
}