using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Doctor_doc_edit_practice_staff : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    connectionclass con3 = new connectionclass();
    connectionclass con4 = new connectionclass();


    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        int id =Convert.ToInt32( Request.QueryString["psid"]);

        if (!IsPostBack)
        {
            dt1 = con1.GetData("select * from Practice_staff ps,Doctor_clinic dc where ps.dclinic_id=dc.dclinic_id and ps.staff_id=" + id);
            dt2 = con2.GetData("select * from Doctor_clinic where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString()));
            dt3 = con3.GetData("select * from City_info");
            foreach (DataRow dr1 in dt1.Rows)
            {
                foreach (DataRow dr2 in dt2.Rows)
                {
                    doc_clinic_id.Items.Add(new ListItem(dr2["clinic_name"].ToString(), dr2["dclinic_id"].ToString()));
                }
                foreach (DataRow dr3 in dt3.Rows)
                {
                    staff_city.Items.Add(new ListItem(dr3["city_name"].ToString(), dr3["city_id"].ToString()));
                }
                doc_clinic_id.SelectedValue = dr1["dclinic_id"].ToString();
                doc_staff_name.Text = dr1["staff_name"].ToString();
                staff_mo_no.Text = dr1["s_mobile_no"].ToString();
                staff_email.Text = dr1["s_email"].ToString();
                staff_reg_no.Text = dr1["s_regstration_no"].ToString();
                staff_address.Text = dr1["s_address"].ToString();
                staff_city.SelectedValue = dr1["city_id"].ToString();
                note.Text = dr1["note"].ToString();
                staff_degree.Text = dr1["s_degree"].ToString();
                staff_reg_board.Text = dr1["s_registration_board"].ToString();


            }
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        int id =Convert.ToInt32( Request.QueryString["psid"]);
        bool b = con4.UpdateDeleteData("update Practice_staff set dclinic_id='"+doc_clinic_id.SelectedValue.ToString()+"', staff_name='"+doc_staff_name.Text+"',s_mobile_no='"+staff_mo_no.Text+"',s_email='"+staff_email.Text+"',s_regstration_no='"+staff_reg_no.Text+"',s_address='"+staff_address.Text+"',city_id='"+staff_city.SelectedValue.ToString()+"',note='"+note.Text+"',s_degree='"+staff_degree.Text+"',s_registration_board='"+ staff_reg_board.Text +"' where staff_id='" + id + "'");
        if (b == true)
        {
            Response.Redirect("doc_practice_staff.aspx");

        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Data Not Updated')");
            Response.Write("</script>");
        }
    }
   
}