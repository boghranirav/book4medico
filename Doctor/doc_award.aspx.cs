using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Doctor_doc_award : System.Web.UI.Page
{

    connectionclass conawd = new connectionclass();
    connectionclass conawd2 = new connectionclass();
    connectionclass conawd3 = new connectionclass();
    

    DataTable dtawd = new DataTable();
    DataTable dtawd3 = new DataTable();

    int srno;
    string str_awd;
    protected void Page_Load(object sender, EventArgs e)
    {
        update_delete.Visible = false;
        Button1.Visible = false;
        int yr=Convert.ToInt32(DateTime.Now.Year);
        for (int i = 1950; i <= yr; i++)
        {
            doc_award_year.Items.Add(i.ToString());
            
        }
        string did = Session["doctor_reg_id"].ToString();
        dtawd = conawd.GetData("select * from Award_recognitions  where doc_id='" + did + "'");
       

        GridView1.DataSource = conawd2.GetData("select *  from Award_recognitions where doc_id='" + did + "'");
        GridView1.DataBind();

      
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bool b = conawd.SaveData("doc_id",Session["doctor_reg_id"].ToString(), "award_year",doc_award_year.Text, "description",doc_award_des.Text);
        if (b == true)
        {

            Response.Redirect("doc_award.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Inserted');");
            Response.Write("</script>");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        dtawd3 = conawd3.GetData("select * from Award_recognitions where ar_id="+id);
        ViewState["delete_id"]=id;
        foreach (DataRow dr3 in dtawd3.Rows)
        {
            doc_award_year.SelectedValue = dr3["award_year"].ToString();
            doc_award_des.Text = dr3["description"].ToString();
        }

        update_delete.Text = "Delete";
        update_delete.Visible = true;
        Button1.Visible = true;
        submit.Visible = false;
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Cells[2].Visible=false;
            GridView1.Rows[i].Cells[3].Visible = false;
           
        }
        GridView1.HeaderRow.Cells[2].Visible = false;
        GridView1.HeaderRow.Cells[3].Visible = false;

        int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        dtawd3 = conawd3.GetData("select * from Award_recognitions where ar_id=" + id);
        ViewState["update_id"]=id;

        foreach (DataRow dr3 in dtawd3.Rows)
        {
            doc_award_year.SelectedValue = dr3["award_year"].ToString();
            doc_award_des.Text = dr3["description"].ToString();
        }

        update_delete.Text = "Update";
        update_delete.Visible = true;
        Button1.Visible = true;
        submit.Visible = false;
    }
    protected void update_delete_Click(object sender, EventArgs e)
    {
        if (update_delete.Text == "Update")
        {
            bool delete = conawd3.UpdateDeleteData("update Award_recognitions set award_year='"+doc_award_year.SelectedValue.ToString()+"', description='"+ doc_award_des.Text+"' where ar_id=" + ViewState["update_id"]);
            if (delete == true)
            {
                Response.Redirect("doc_award.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Updated');");
                Response.Write("</script>");
            }
        }
        else
            if (update_delete.Text == "Delete")
            {
                bool delete = conawd3.UpdateDeleteData("delete from Award_recognitions where ar_id=" + ViewState["delete_id"]);
                if (delete == true)
                {
                    Response.Redirect("doc_award.aspx");
                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("alert('Data Not Deleted');");
                    Response.Write("</script>");
                }
            }
    }
   
}