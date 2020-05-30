using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_memberships : System.Web.UI.Page
{

    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    connectionclass con3 = new connectionclass();
    connectionclass con4 = new connectionclass();


    DataTable dt1 = new DataTable();
    DataTable dt3 = new DataTable();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        update_delete.Visible = false;
        cancel_b.Visible = false;
        dt1 = con1.GetData("select * from Doctor_memberships where doc_id="+Convert.ToInt64(Session["doctor_reg_id"].ToString()));

        GridView1.DataSource = con2.GetData("select * from Doctor_memberships where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString()));
        GridView1.DataBind();
      
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bool b = con1.SaveData("doc_id",Session["doctor_reg_id"].ToString(),"description",doc_membership.Text);
        if (b == true)
        {
            Response.Redirect("doc_memberships.aspx");
        }
        else
        {
            Response.Redirect("<script>");
            Response.Redirect("alert('Data Not Inserted.');");
            Response.Redirect("</script>");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        ViewState["delete_id"] = id;

        dt3 = con3.GetData("select * from Doctor_memberships where membership_id="+id);
        foreach(DataRow dr3 in dt3.Rows)
        {
        doc_membership.Text= dr3["description"].ToString();
        }

        submit.Visible = false;
        update_delete.Text = "Delete";
        update_delete.Visible = true;
        cancel_b.Visible = true;

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Cells[1].Visible = false;
            GridView1.Rows[i].Cells[2].Visible = false;
        }
        GridView1.HeaderRow.Cells[1].Visible = false;
        GridView1.HeaderRow.Cells[2].Visible = false;

        int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        ViewState["update_id"] = id;

        dt3 = con3.GetData("select * from Doctor_memberships where membership_id=" + id);
        foreach (DataRow dr3 in dt3.Rows)
        {
            doc_membership.Text = dr3["description"].ToString();
        }
        submit.Visible = false;
        update_delete.Text = "Update";
        update_delete.Visible = true;
        cancel_b.Visible = true;
    }
    
    protected void update_delete_Click(object sender, EventArgs e)
    {
        if(update_delete.Text=="Update"){
            bool update = con4.UpdateDeleteData("update Doctor_memberships set description='"+doc_membership.Text+"' where membership_id=" + ViewState["update_id"]);
            if (update == true)
            {
                Response.Redirect("doc_memberships.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Deleted');");
                Response.Write("</script>");
            }
        }
        else
            if (update_delete.Text == "Delete")
            {
                bool delete = con4.UpdateDeleteData("delete from Doctor_memberships where membership_id=" + ViewState["delete_id"]);
                if (delete == true)
                {
                    Response.Redirect("doc_memberships.aspx");
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