using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Doctor_doc_personal_info : System.Web.UI.Page
{
    connectionclass conc = new connectionclass();
    connectionclass conc2 = new connectionclass();
    connectionclass conc3 = new connectionclass();
    connectionclass conc4 = new connectionclass();
    
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        dt4 = conc4.GetData("select * from Doctor_basic_info");

        if (!IsPostBack)
        {
            dt3 = conc3.GetData("select * from Country_info");

            foreach (DataRow d3 in dt3.Rows)
            {
                doc_country.Items.Add(new ListItem(d3["country_name"].ToString(), d3["country_id"].ToString()));
            }

            dt = conc.GetData("select * from Doctor_basic_info where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"]));
            if (dt.Rows != null)
            {
                foreach (DataRow d in dt.Rows)
                {
                    doc_first_name.Text = d["first_name"].ToString();
                    doc_last_name.Text = d["last_name"].ToString();
                    doc_experience.Text = d["experience"].ToString();
                    doc_country.SelectedIndex = Convert.ToInt32(d["country"].ToString());
                    display_pro_pic.ImageUrl = "~/Doctor/profile_pictures/" + d["profile_picture"].ToString();

                }

                if (doc_first_name.Text != "")
                {
                    submit.Text = "Update";
                }
            }



            string st1 = "select doc_r_mobile_no,doc_r_email_id from Doctor_registration where doc_id='" + Session["doctor_reg_id"].ToString() + "'";
            dt2 = conc2.GetData(st1);

            foreach (DataRow d1 in dt2.Rows)
            {
                doc_mobile.Text = d1["doc_r_mobile_no"].ToString();
                doc_email.Text = d1["doc_r_email_id"].ToString();
            }

        }


    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string doc_f_name = doc_first_name.Text;
        string gen = "";
        if (doc_gender1.Checked)
        {
            gen = "Male";
        }
        else
            if (doc_gender2.Checked)
            {
                gen = "Female";
            }

        if (submit.Text == "Submit")
        {
            string sess = Session["doctor_reg_id"].ToString();
     
            bool flag = conc4.SaveData("doc_id", sess, "first_name", doc_f_name, "last_name", doc_last_name.Text, "gender", gen, "country", doc_country.SelectedIndex.ToString(), "experience", doc_experience.Text);
            if (flag == true)
            {
                Response.Redirect("doc_personal_info.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Information Not Added');");
                Response.Write("</script>");
            }
        }
        else
            if(submit.Text=="Update")
        {

           bool update_info = conc4.UpdateDeleteData("update Doctor_basic_info set first_name='" + doc_f_name + "', last_name='" + doc_last_name.Text + "',gender='" + gen + "',country='" + doc_country.SelectedIndex.ToString() + "',experience='" + doc_experience.Text + "' where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"]));   
           if(update_info==true){
               Response.Redirect("doc_personal_info.aspx");
           }
           else
           {
               Response.Write("<script>");
               Response.Write("alert('Information Not Updated');");
               Response.Write("</script>");
           }
        }

    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        string st = Session["doctor_reg_id"].ToString();

        if (profile_picture.HasFile)
        {
            string fileName = Path.GetFileName(profile_picture.PostedFile.FileName);
            string ext = System.IO.Path.GetExtension(fileName);
            st = st + ext;
            
            if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif" || ext.ToLower() == ".jpeg")
            {
                profile_picture.PostedFile.SaveAs(Server.MapPath("~/Doctor/profile_pictures/") + st);
                
                bool update_info = conc.UpdateDeleteData("update Doctor_basic_info set profile_picture='"+st+"' where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"]));

                if (update_info == true)
                {
                    Response.Redirect("doc_personal_info.aspx");
                }
                else
                {
                    Response.Write("<script>");
                    Response.Write("alert('Profile Picture Not Updated.');");
                    Response.Write("</script>");
                }
                
                
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Only Images Are Allowed ');");
                Response.Write("</script>");
            }
        }
    }
}