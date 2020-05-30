using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_specialization : System.Web.UI.Page
{

    connectionclass conc = new connectionclass();
    DataTable dt = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = conc.GetData("select * from Specializations_info");
        string str = "";
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            i++;
            string spe=dr["spe_name"].ToString();
            str += "<tr><td>" + i + "</td><td>" + spe + "</td>";
            str += "<td align='center' width='8%'><a href='admin_editspecialization.aspx?speid=" + dr["spe_id"] + "'><i class='fa fa-1x fa-pencil'></i></a></td>";
            str += "<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["spe_id"] + ");'><i class='fa fa-1x fa-trash-o'></i></a></td></tr>";
        }
        doc_spe.InnerHtml = str;
        if (Request.QueryString["ermsg"] != "")
        {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Specialization Not Deleted');");
                Response.Write("</script>");
            }

        }

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bool cou = conc.SaveData("spe_name", admin_spe.Text);
        if (cou == true)
        {
            Response.Write("<script>");
            Response.Write("alert('Added');");
            Response.Write("</script>");
            Response.Redirect("admin_specialization.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Not Added');");
            Response.Write("</script>");
        }
    }
}