using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_clinic_info : System.Web.UI.Page
{
    connectionclass concoun1 = new connectionclass();
    connectionclass concoun2 = new connectionclass();
    connectionclass concoun3 = new connectionclass();
    connectionclass concoun4 = new connectionclass();
    connectionclass concoun5 = new connectionclass();
    connectionclass concoun6 = new connectionclass();



    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt6 = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        cancel_b.Visible = false;
        update_delete.Visible = false;

        dt1 = concoun1.GetData("select * from Doctor_clinic dc,Area_info ai,City_info ci where ai.area_id=dc.area_id and dc.city_id=ci.city_id and ai.city_id=ci.city_id and doc_id="+Convert.ToInt64( Session["doctor_reg_id"].ToString()));
        dt4 = concoun4.GetData("select * from Doctor_clinic");

        if (!IsPostBack)
        {
            dt2 = concoun2.GetData("select * from City_info");
            if (!IsPostBack)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    doc_city.Items.Add(new ListItem(dr["city_name"].ToString(), dr["city_id"].ToString()));
                }
            }
        }

        GridView1.DataSource = concoun5.GetData("select * from Doctor_clinic dc,Area_info ai,City_info ci where ai.area_id=dc.area_id and dc.city_id=ci.city_id and ai.city_id=ci.city_id and doc_id="+Convert.ToInt64( Session["doctor_reg_id"].ToString()));
        GridView1.DataBind();
      
    }
    protected void doc_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        doc_area.Items.Clear();
        string c_id = doc_city.SelectedValue.ToString();
        dt3 = concoun3.GetData("select * from Area_info  where city_id="+Convert.ToInt32(c_id));
        doc_area.Items.Add(new ListItem("SELECT","SELECT"));
        foreach (DataRow dr3 in dt3.Rows)
        {
            doc_area.Items.Add(new ListItem(dr3["area_name"].ToString(), dr3["area_id"].ToString()));
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bool cou = concoun4.SaveData("doc_id",Session["doctor_reg_id"].ToString(),"clinic_name",doc_clinic_name.Text,"city_id",doc_city.SelectedValue.ToString(),"area_id",doc_area.SelectedValue.ToString(),"address",doc_clinic_address.Text,"fees",doc_fees.Text,"pincode",doc_clinic_pincode.Text,"phone_no",doc_clinic_phone.Text,"email_id",doc_clinic_email.Text);
        if (cou == true)
        {
            Response.Redirect("doc_clinic_info.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Clinic Information Not Insert.')");
            Response.Write("<script>");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        ViewState["delete_id"] = id;

        dt6 = concoun6.GetData("select * from Doctor_clinic where dclinic_id="+id);

        foreach (DataRow dr6 in dt6.Rows)
        {
            doc_clinic_name.Text=dr6["clinic_name"].ToString();
            doc_clinic_address.Text = dr6["address"].ToString();
            doc_city.SelectedValue= dr6["city_id"].ToString();
            doc_clinic_phone.Text = dr6["phone_no"].ToString();
            doc_clinic_email.Text = dr6["email_id"].ToString();
            doc_clinic_pincode.Text = dr6["pincode"].ToString();
            doc_fees.Text=dr6["fees"].ToString();

            doc_area.Items.Clear();
            string c_id = doc_city.SelectedValue.ToString();
            dt3 = concoun3.GetData("select * from Area_info ai,City_info ci where ci.city_id=ai.city_id and ai.city_id=" + Convert.ToInt32(c_id));
            doc_area.Items.Add("Select Area");
            foreach (DataRow dr3 in dt3.Rows)
            {
                doc_area.Items.Add(new ListItem(dr3["area_name"].ToString(), dr3["area_id"].ToString()));
            }

            doc_area.SelectedValue=dr6["area_id"].ToString();

        }

       

        submit.Visible = false;
        update_delete.Text="Delete";
        update_delete.Visible = true;
        cancel_b.Visible = true;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Cells[7].Visible=false;
            GridView1.Rows[i].Cells[8].Visible = false;
        }
        GridView1.HeaderRow.Cells[7].Visible=false;
        GridView1.HeaderRow.Cells[8].Visible = false;

        int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
        ViewState["update_id"] = id;

        dt6 = concoun6.GetData("select * from Doctor_clinic where dclinic_id=" + id);

        foreach (DataRow dr6 in dt6.Rows)
        {
            doc_clinic_name.Text = dr6["clinic_name"].ToString();
            doc_clinic_address.Text = dr6["address"].ToString();
            doc_city.SelectedValue = dr6["city_id"].ToString();
            doc_clinic_phone.Text = dr6["phone_no"].ToString();
            doc_clinic_email.Text = dr6["email_id"].ToString();
            doc_clinic_pincode.Text = dr6["pincode"].ToString();
            doc_fees.Text = dr6["fees"].ToString();

            doc_area.Items.Clear();
            string c_id = doc_city.SelectedValue.ToString();
            dt3 = concoun3.GetData("select * from Area_info ai,City_info ci where ci.city_id=ai.city_id and ai.city_id=" + Convert.ToInt32(c_id));
            doc_area.Items.Add("Select Area");
            foreach (DataRow dr3 in dt3.Rows)
            {
                doc_area.Items.Add(new ListItem(dr3["area_name"].ToString(), dr3["area_id"].ToString()));
            }

            doc_area.SelectedValue = dr6["area_id"].ToString();

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
            bool delete = concoun6.UpdateDeleteData("update Doctor_clinic set clinic_name='"+doc_clinic_name.Text+"', city_id='"+doc_city.SelectedValue.ToString()+"', area_id='"+doc_area.SelectedValue.ToString()+"',address='"+doc_clinic_address.Text+"',fees='"+doc_fees.Text+"',pincode='"+doc_clinic_pincode.Text +"',phone_no='"+doc_clinic_phone.Text+"',email_id='"+doc_clinic_email.Text+"' where dclinic_id=" + ViewState["update_id"]);
            if (delete == true)
            {
                Response.Redirect("doc_clinic_info.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Deleted');");
                Response.Write("</script>");
            }
        }
        else
        if(update_delete.Text == "Delete")
        {
            bool delete = concoun6.UpdateDeleteData("delete from Doctor_clinic where dclinic_id=" + ViewState["delete_id"]);
            if (delete == true)
            {
                Response.Redirect("doc_clinic_info.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Deleted');");
                Response.Write("</script>");
            }
        }
    }
    protected void cancel_b_Click(object sender, EventArgs e)
    {
        Response.Redirect("doc_clinic_info.aspx");
    }
}