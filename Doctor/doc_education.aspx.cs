using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Doctor_doc_education : System.Web.UI.Page
{
    connectionclass cone = new connectionclass();
    connectionclass cond = new connectionclass();
    connectionclass conall = new connectionclass();
    connectionclass conall1 = new connectionclass();
    connectionclass conall5 = new connectionclass();


    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt5 = new DataTable();

    
    protected void Page_Load(object sender, EventArgs e)
    {
        update_delete.Visible = false;
        cancel_b.Visible = false;

        dt1 = cone.GetData("select * from Doctor_education");

        string doc_id2 = Session["doctor_reg_id"].ToString();
        dt3 = conall.GetData("select d.degree_name,e.institute_name,e.description from Degree_info d,Doctor_education e where d.degree_id=e.degree_id and  e.doc_id="+doc_id2);

        if (!IsPostBack)
        {
            dt2 = cond.GetData("select * from  Degree_info");
            foreach (DataRow dr in dt2.Rows)
            {
                doc_degree.Items.Add(new ListItem(dr["degree_name"].ToString(), dr["degree_id"].ToString()));

            }
        }

        GridView1.DataSource = conall1.GetData("select * from Degree_info d,Doctor_education e where d.degree_id=e.degree_id and  e.doc_id=" + doc_id2);
        GridView1.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string degreeid = doc_degree.SelectedValue.ToString();
        string did = Session["doctor_reg_id"].ToString();
        string disc_str = doc_disc.Text;
        if (disc_str == "")
            disc_str = "-";

        if (Label1.Text == "")
        {
            bool b = cone.SaveData("degree_id", degreeid, "doc_id", did, "institute_name", doc_inst_name.Text, "description", disc_str);
            if (b == true)
            {
                Response.Redirect("doc_education.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Not Insert')");
                Response.Write("<script>");

            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label1.Text = "";
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        ViewState["delete_id"]=id;

        dt5 = conall5.GetData("select * from Doctor_education where edu_id="+id);
        foreach(DataRow dr5 in dt5.Rows){
        doc_degree.SelectedValue=dr5["degree_id"].ToString();
        doc_inst_name.Text = dr5["institute_name"].ToString();
        doc_disc.Text = dr5["description"].ToString();
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
            GridView1.Rows[i].Cells[3].Visible = false;
            GridView1.Rows[i].Cells[4].Visible = false;
        }
        GridView1.HeaderRow.Cells[3].Visible = false;
        GridView1.HeaderRow.Cells[4].Visible = false;

        int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        ViewState["update_id"] = id;

        dt5 = conall5.GetData("select * from Doctor_education where edu_id=" + id);
        foreach (DataRow dr5 in dt5.Rows)
        {
            doc_degree.SelectedValue = dr5["degree_id"].ToString();
            doc_inst_name.Text = dr5["institute_name"].ToString();
            doc_disc.Text = dr5["description"].ToString();
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
            bool update = conall5.UpdateDeleteData("update Doctor_education set degree_id='"+doc_degree.SelectedValue.ToString()+"', institute_name='"+doc_inst_name.Text+"', description='"+doc_disc.Text+"' where edu_id=" + ViewState["update_id"]);
            if (update == true)
            {
                Response.Redirect("doc_education.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Updated');");
                Response.Write("</script>");
            }
        }
        else
            if(update_delete.Text=="Delete"){
                bool delete = conall5.UpdateDeleteData("delete from Doctor_education where edu_id=" + ViewState["delete_id"]);
                if (delete == true)
                {
                    Response.Redirect("doc_education.aspx");
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