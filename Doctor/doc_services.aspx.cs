using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Doctor_doc_services : System.Web.UI.Page
{
    connectionclass consv = new connectionclass();
    DataTable dts = new DataTable();
    connectionclass condsv = new connectionclass();
    DataTable dtdsv = new DataTable();
    connectionclass conalldsv = new connectionclass();
    DataTable dtall = new DataTable();

    connectionclass con4 =new  connectionclass();
    DataTable dt4 = new DataTable();

    connectionclass con5 = new connectionclass();

    connectionclass con6 = new connectionclass();
    DataTable dt6 = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        update_delete.Visible = false;
        cancel_b.Visible = false;

        string did = Session["doctor_reg_id"].ToString();

        if (!IsPostBack)
        {
            dts = consv.GetData("select * from Services");
            foreach (DataRow dr in dts.Rows)
            {
                doc_dd_service.Items.Add(new ListItem(dr["service_name"].ToString(), dr["service_id"].ToString()));

            }
        }
        dtall = conalldsv.GetData("select service_name,fees from Services s,Doctor_services ds where doc_id='"+ did+"' and s.service_id=ds.service_id   ");
        
        dtdsv = condsv.GetData("select * from Doctor_services");

        GridView1.DataSource = con5.GetData("select * from Services s,Doctor_services ds where doc_id='" + did + "' and s.service_id=ds.service_id");
        GridView1.DataBind();
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string serviceid = doc_dd_service.SelectedValue.ToString();
        string did1 = Session["doctor_reg_id"].ToString();

        if (Label1.Text == "")
        {
            bool b = condsv.SaveData("doc_id", did1, "service_id", serviceid, "fees", doc_txt_fees.Text);
            if (b == true)
            {
                Response.Redirect("doc_services.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Insertes');");
                Response.Write("</script>");

            }
        }
       
       
    }
   
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label1.Text = "";
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        ViewState["delete_id"] = id;

        dt6 = con6.GetData("select * from Doctor_services where doc_ser_id=" + id);
        foreach(DataRow dr6 in dt6.Rows)
        {
            doc_dd_service.SelectedValue = dr6["service_id"].ToString();
            doc_txt_fees.Text = dr6["fees"].ToString();
        }

        submit.Visible = false;
        update_delete.Text = "Delete";
        update_delete.Visible = true;
        cancel_b.Visible = true;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label1.Text = "";
         for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Cells[2].Visible = false;
            GridView1.Rows[i].Cells[3].Visible = false;
         }
         GridView1.HeaderRow.Cells[2].Visible = false;
         GridView1.HeaderRow.Cells[3].Visible = false;
         int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        ViewState["update_id"]=id;

        dt6 = con6.GetData("select * from Doctor_services where doc_ser_id=" + id);
        foreach(DataRow dr6 in dt6.Rows)
        {
            doc_dd_service.SelectedValue = dr6["service_id"].ToString();
            doc_txt_fees.Text = dr6["fees"].ToString();
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
            bool b = con6.UpdateDeleteData("update Doctor_services set service_id='"+doc_dd_service.SelectedValue.ToString()+"', fees='"+doc_txt_fees.Text+"' where doc_ser_id=" +Convert.ToInt32( ViewState["update_id"]));
            if (b == true)
            {
                Response.Redirect("doc_services.aspx");
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
                bool b = con6.UpdateDeleteData("delete from Doctor_services where doc_ser_id="+ViewState["delete_id"]);
                if (b == true)
                {
                    Response.Redirect("doc_services.aspx");
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