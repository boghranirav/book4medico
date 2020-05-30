using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class Doctor_doc_specilazation : System.Web.UI.Page
{
    connectionclass concoun = new connectionclass();
    connectionclass concoun2 = new connectionclass();
    connectionclass concoun3 = new connectionclass();
    
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();

    
    protected void Page_Load(object sender, EventArgs e)
    {

        update_delete.Visible = false;
        btncancle.Visible = false;
        dt1 = concoun.GetData("select * from Doctor_specialization");

        dt2 = concoun2.GetData("select * from Specializations_info");

        if (!IsPostBack)
        {
            foreach (DataRow dr1 in dt2.Rows)
            {
                doc_specialization.Items.Add(new ListItem(dr1["spe_name"].ToString(), dr1["spe_id"].ToString()));

            }
        }

        string doc_id = Session["doctor_reg_id"].ToString();

        GridView1.DataSource= concoun3.GetData("select * from Doctor_specialization ds,Specializations_info ads where ds.sep_id=ads.spe_id and doc_id='"+doc_id+"'");
        GridView1.DataBind();

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string doc_s=doc_specialization.SelectedValue.ToString();
        string doc_id=Session["doctor_reg_id"].ToString();

        if (Label1.Text == "")
        {
            bool cou = concoun.SaveData("doc_id", doc_id, "sep_id", doc_s);
            if (cou == true)
            {
                Response.Redirect("doc_specialization.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Not Added');");
                Response.Write("</script>");
            }
        }
    }
    protected void doc_specialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        submit.Visible = true;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

        SqlCommand scmd = new SqlCommand();
        string qry = "select count(*) from Doctor_specialization where sep_id='" + doc_specialization.SelectedValue.ToString() + "' and  doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString());
        scon.Open();
        scmd.Connection = scon;
        scmd.CommandText = qry;
        if (Convert.ToInt32(scmd.ExecuteScalar()) > 0)
        {
            Label1.Text = "*Specialization Already Added By You.";
        }
        else
        {
            Label1.Text = "";
        }
        scon.Close();
    }
    protected void update_delete_Click(object sender, EventArgs e)
    {
            if (update_delete.Text == "Delete")
            {
                bool delete = concoun3.UpdateDeleteData("delete from Doctor_specialization where doc_sep_id=" + ViewState["delete_id"]);
                if (delete == true)
                {
                    Response.Redirect("doc_specialization.aspx");
                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("alert('Data Not Deleted');");
                    Response.Write("</script>");
                }
            }
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("doc_specialization.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label1.Text = "";
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        dt3 = concoun3.GetData("select * from Doctor_specialization where doc_sep_id=" + id);
        ViewState["delete_id"] = id;
        foreach (DataRow dr3 in dt3.Rows)
        {
            doc_specialization.SelectedValue = dr3["sep_id"].ToString();
        }

        update_delete.Text = "Delete";
        update_delete.Visible = true;
        btncancle.Visible = true;
        submit.Visible = false;
      
    }
   
}