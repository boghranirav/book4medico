using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Admin_doc_edit_experience : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        int yr = Convert.ToInt32(DateTime.Now.Year);
        int id = Convert.ToInt32(Request.QueryString["expid"]);
        if (!IsPostBack)
        {   
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


           
            dt1 = con1.GetData("select * from Doctor_experience where exp_id=" + id);
            foreach (DataRow dr1 in dt1.Rows)
            {
                doc_exp_month_from.SelectedIndex = Convert.ToInt32(dr1["from_month"].ToString());
                doc_exp_year_from.SelectedValue = dr1["from_year"].ToString();
                doc_exp_month_to.SelectedIndex = Convert.ToInt32(dr1["to_month"].ToString());

                for (int i = Convert.ToInt32(doc_exp_year_from.SelectedValue.ToString()); i <= yr; i++)
                {
                    doc_exp_year_to.Items.Add(i.ToString());
                }
                doc_exp_year_to.SelectedValue = dr1["to_year"].ToString();
                doc_disc.Text = dr1["description"].ToString();
            }
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
    protected void cancel_b_Click(object sender, EventArgs e)
    {
        Response.Redirect("doc_experience.aspx");
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["expid"];
        bool b = con1.UpdateDeleteData("update Doctor_experience set from_month='" + doc_exp_month_from.SelectedValue.ToString() + "', from_year='"+ doc_exp_year_from.SelectedValue.ToString() +"',to_month='"+ doc_exp_month_to.SelectedValue.ToString() +"',to_year='"+ doc_exp_year_to.SelectedValue.ToString() +"',description='"+ doc_disc.Text +"' where exp_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("doc_experience.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    }
}