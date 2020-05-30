using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class Doctor_doc_reg_info : System.Web.UI.Page
{
    connectionclass conreg = new connectionclass();
    DataTable dtreg = new DataTable();

    connectionclass con1 = new connectionclass();

    connectionclass con2 = new connectionclass();
    DataTable dt2 = new DataTable();

    connectionclass con3 = new connectionclass();
    DataTable dt3 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        update_delete.Visible = false;
        cancel_b.Visible = false;
      

        string did = Session["doctor_reg_id"].ToString();
        dtreg = conreg.GetData("select * from Registrations_board where doc_id='"+did+"'");

        GridView1.DataSource = con1.GetData("select * from Registrations_board where doc_id='" + did + "'");
        GridView1.DataBind();


    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (Label1.Text != "")
        {
            Response.Write("<script>");
            Response.Write("alert('Duplicate Registration Number Found.');");
            Response.Write("</script>");
        
        }
        else
        {
            string did = Session["doctor_reg_id"].ToString();

            bool b = conreg.SaveData("doc_id", did, "description", doc_board.Text, "registration_no", doc_reg_no.Text);
            if (b == true)
            {
                Response.Redirect("doc_reg_info.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Inserted');");
                Response.Write("</script>");
            }
        }       
    }
        
         protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {
             Label1.Text = "";
             int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
             ViewState["delete_id"]=id;

             dt2 = con2.GetData("select * from Registrations_board where reg_id="+id);
             foreach (DataRow dr2 in dt2.Rows)
             {
                 doc_reg_no.Text = dr2["registration_no"].ToString();
                 doc_board.Text=dr2["description"].ToString();
             }

             submit.Visible = false;
             update_delete.Text = "Delete";
             update_delete.Visible = true;
             cancel_b.Visible = true;
         }
         protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
         {
             doc_reg_no.Enabled = false;
             for (int i = 0; i < GridView1.Rows.Count; i++)
             {
                 GridView1.Rows[i].Cells[2].Visible = false;
                 GridView1.Rows[i].Cells[3].Visible = false;
             }
             GridView1.HeaderRow.Cells[2].Visible = false;
             GridView1.HeaderRow.Cells[3].Visible = false;

             int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
             ViewState["update_id"] = id;

             dt2 = con2.GetData("select * from Registrations_board where reg_id=" + id);
             foreach (DataRow dr2 in dt2.Rows)
             {
                 doc_reg_no.Text = dr2["registration_no"].ToString();
                 doc_board.Text = dr2["description"].ToString();
             }

             submit.Visible = false;
             update_delete.Text = "Update";
             update_delete.Visible = true;
             cancel_b.Visible = true;
         }
        
         protected void update_delete_Click(object sender, EventArgs e)
         {
             if (update_delete.Text == "Update")
             {
                 bool b = con3.UpdateDeleteData("update Registrations_board set description='"+doc_board.Text+"' where reg_id=" + ViewState["update_id"]);
                 if (b == true)
                 {
                     Response.Redirect("doc_reg_info.aspx");
                 }
                 else
                 {
                     Response.Write("<script>");
                     Response.Write("alert('Data Not Updated.');");
                     Response.Write("</script>");
                 }
             }else
                 if (update_delete.Text == "Delete")
                 {
                     bool b = con3.UpdateDeleteData("delete from Registrations_board where reg_id="+ViewState["delete_id"]);
                     if (b == true)
                     {
                         Response.Redirect("doc_reg_info.aspx");
                     }
                     else
                     {
                         Response.Write("<script>");
                         Response.Write("alert('Data Not Deleted');");
                         Response.Write("</script>");
                     }

                 }
         }
         protected void doc_reg_no_TextChanged(object sender, EventArgs e)
         {
             SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

             SqlCommand scmd = new SqlCommand();
             string qry = "select count(*) from Registrations_board where registration_no='" + doc_reg_no.Text + "'";
             scon.Open();
             scmd.Connection = scon;
             scmd.CommandText = qry;
             if (Convert.ToInt32(scmd.ExecuteScalar()) > 0)
             {
                 Label1.Text = "*Duplicate Registration Nubmer Found.";
             }
             else
             {
                 Label1.Text = "";
             }
             scon.Close();
         }
}