using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Doctor_doc_experience : System.Web.UI.Page
{
    connectionclass conex = new connectionclass();
    DataTable dtex = new DataTable();
    int srno;
    string str_exp;

    protected void Page_Load(object sender, EventArgs e)
    {

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

        if (!IsPostBack)
        {
            int yr = Convert.ToInt32(DateTime.Now.Year);
            for (int i = 1950; i <= yr; i++)
            {
                doc_exp_year_from.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 12; i++)
            {
                string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
                doc_exp_month_from.Items.Add(new ListItem(monthName, i.ToString().PadLeft(2, '0')));
                doc_exp_month_to.Items.Add(new ListItem(monthName, i.ToString().PadLeft(2, '0')));
            }

        }

         string did = Session["doctor_reg_id"].ToString();
        dtex = conex.GetData("Select * from Doctor_experience where doc_id='"+did+"'");
        srno = 1;
        foreach (DataRow dr1 in dtex.Rows)
        {
            string from_mth = dr1["from_month"].ToString();
            DateTime from_dt = new DateTime(2015, int.Parse(from_mth), 1);
            string from_monthname = from_dt.ToString("MMM");
            string to_mth = dr1["to_month"].ToString();
            DateTime to_dt = new DateTime(2015, int.Parse(to_mth), 1);
            string to_monthname = to_dt.ToString("MMM");
            str_exp += "<tr class='odd gradeX'> <td>" + srno + "</td>";
            str_exp += "<td>" + from_monthname + "-" + dr1["from_year"] + "</td>";
            str_exp += "<td>" + to_monthname + "-" + dr1["to_year"] + "</td>";
            str_exp += "<td>" + dr1["description"] + "</td>";
            str_exp += "<td  align='center'><a href='doc_edit_experience.aspx?expid=" + dr1["exp_id"] + "'><img src='../assets/img/edit.png'></a></td>";
            str_exp += "<td align='center'><a href='Javascript:deletefunction(" + dr1["exp_id"] + ");'><img src='../assets/img/delete.png'></a></td></tr>";
            srno++;

        }

   
        tbl_exp.InnerHtml=str_exp;
       
       
     

    
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string fmth = doc_exp_month_from.SelectedValue.ToString();
        string fyer = doc_exp_year_from.SelectedValue.ToString();
        string tmth = doc_exp_month_to.SelectedValue.ToString();
        string tyer = doc_exp_year_to.SelectedValue.ToString();
        string disc_str = doc_disc.Text;
        if (disc_str == "")
            disc_str = "-";
        string did = Session["doctor_reg_id"].ToString();
        bool b = conex.SaveData("doc_id",did, "from_month",fmth, "from_year",fyer, "to_month",tmth, "to_year",tyer, "description",disc_str);
        if (b == true)
         {
             Response.Redirect("doc_experience.aspx");
            }
        else {
            Response.Write("<script>");
            Response.Write("alert('Data Not Inserted');");
            Response.Write("</script>");
        
        }
    }
    protected void doc_exp_year_from_SelectedIndexChanged(object sender, EventArgs e)
    {
        int yr = Convert.ToInt32(DateTime.Now.Year);
        for (int i = Convert.ToInt32(doc_exp_year_from.SelectedValue.ToString()); i <= yr; i++)
        {
            doc_exp_year_to.Items.Add(i.ToString());
        }   
    }
}