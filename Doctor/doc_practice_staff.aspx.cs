using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class Doctor_doc_practice_staff : System.Web.UI.Page
{
    connectionclass conclinic = new connectionclass();
    DataTable dtclinic = new DataTable();
    connectionclass conpstaff = new connectionclass();
    DataTable dtpstaff = new DataTable();
    connectionclass conall = new connectionclass();
    DataTable dtall = new DataTable();
    connectionclass concity = new connectionclass();
    DataTable dtcity = new DataTable();
    int srno;
    string str_pstaff;
    protected void Page_Load(object sender, EventArgs e)
    {
            string did = Session["doctor_reg_id"].ToString();
        dtclinic = conclinic.GetData("select * from Doctor_clinic where doc_id='"+did+"'");
        
            foreach (DataRow dr in dtclinic.Rows)
            {
                doc_clinic_id.Items.Add(new ListItem(dr["clinic_name"].ToString(), dr["dclinic_id"].ToString()));
            }
            
        dtcity = concity.GetData("select * from City_info");
        foreach (DataRow dr in dtcity.Rows)
            {
                staff_city.Items.Add(new ListItem(dr["city_name"].ToString(), dr["city_id"].ToString()));
            }

        dtall = conall.GetData("select * from Doctor_clinic dc,City_info c,Practice_staff p where dc.doc_id=p.doc_id and p.city_id=c.city_id and dc.dclinic_id=p.dclinic_id and dc.doc_id='" + did + "'");
            srno = 1;
            foreach (DataRow dr1 in dtall.Rows)
            {
                str_pstaff += "<tr class='odd gradeX'> <td>" + srno + "</td>";
                str_pstaff += "<td>" + dr1["clinic_name"] + "</td>";
                str_pstaff += "<td>" + dr1["staff_name"] + "</td>";
                str_pstaff += "<td>" + dr1["s_mobile_no"] + "</td>";
                str_pstaff += "<td>" + dr1["s_email"] + "</td>";
                str_pstaff += "<td><a href='doc_practice_staffdetail.aspx?psid=" + dr1["staff_id"] + "'>Detail</a></td>";
                str_pstaff += "<td align='center'><a href='doc_edit_practice_staff.aspx?psid=" + dr1["staff_id"] + "'><img src='../assets/img/edit.png'></a></td>";
                str_pstaff += "<td align='center'><a href='Javascript:deletefunction(" + dr1["staff_id"] + ");'><img src='../assets/img/delete.png'></a></td></tr>";
                srno++;

            }


            tbl_pstaff.InnerHtml = str_pstaff;
            dtpstaff = conpstaff.GetData("select * from Practice_staff");
        

    }
    [System.Web.Services.WebMethod]
    public static string Checkregno(string regno)
    {
        string retval = "";
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select  p.s_regstration_no,r.registration_no from Practice_staff p,Registrations_board r where p.s_regstration_no=@registration_no or r.registration_no=@registration_no", con);
        cmd.Parameters.AddWithValue("@registration_no", regno);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            retval = "true";
        }
        else
        {
            retval = "false";
        }

        return retval;
        /*
        if (useroremail == "shailesh@gm.com")
        {
            retval = "true";
        }
        else
        {
            retval = "false";
        }
        return retval;*/

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string nt = note.Text;
        string rb = staff_reg_board.Text;
        string rbno = staff_reg_no.Text;
        if (nt == "")
            nt = "-";
         if(rb=="")
            rb="-";
         if (rbno == "")
             rbno = "-";
         if (lblcheck.Text != "")
         {
             Response.Write("<script>");
             Response.Write("alert('Duplicate Registration Number Found.');");
             Response.Write("</script>");

         }
         else
         {
             bool b = conpstaff.SaveData("doc_id", Session["doctor_reg_id"].ToString(), "dclinic_id", doc_clinic_id.SelectedValue.ToString(), "staff_name", doc_staff_name.Text, "s_mobile_no", staff_mo_no.Text, "s_email", staff_email.Text, "s_regstration_no", rbno, "s_address", staff_address.Text, "city_id", staff_city.SelectedValue.ToString(), "note", nt, "s_degree", staff_degree.Text, "s_registration_board", rb);
             if (b == true)
             {
                 Response.Redirect("doc_practice_staff.aspx");

             }
             else
             {
                 Response.Write("<script>");
                 Response.Write("alert('Data Not Inserted')");
                 Response.Write("</script>");
             }
         }
    }
    protected void staff_reg_no_TextChanged(object sender, EventArgs e)
    {
         SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

             SqlCommand scmd = new SqlCommand();
             string qry = "select count(*) from Registrations_board rb, Practice_staff ps where rb.registration_no='" + staff_reg_no.Text + "' or ps.s_regstration_no='"+staff_reg_no.Text+"'";
             scon.Open();
             scmd.Connection = scon;
             scmd.CommandText = qry;
             if (Convert.ToInt32(scmd.ExecuteScalar()) > 0)
             {
                 lblcheck.Text = "*Duplicate Registration Nubmer Found.";
             }
             else
             {
                 lblcheck.Text = "";
             }
             scon.Close();
    }
}