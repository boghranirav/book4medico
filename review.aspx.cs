using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class user_feedback : System.Web.UI.Page
{
    connectionclass conbasic = new connectionclass();
    DataTable dtbasic = new DataTable();
    connectionclass condegree = new connectionclass();
    DataTable dtdegree = new DataTable();
    connectionclass conspecility = new connectionclass();
    DataTable dtspecility = new DataTable();
    connectionclass conreview = new connectionclass();
    DataTable dtreview = new DataTable();
    connectionclass conuser = new connectionclass();
    DataTable dtuser = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["did"];
        dtbasic = conbasic.GetData("select *from Doctor_basic_info  where doc_id=" + id);
        foreach (DataRow dr4 in dtbasic.Rows)
        {
            doc_profile_picture.ImageUrl = "Doctor/profile_pictures/" + dr4["profile_picture"].ToString();
            docname.InnerHtml = "<a href='doctor_detail.aspx?doctor=" + dr4["doc_id"] + "'><label>Dr." + dr4["first_name"].ToString() + " " + dr4["last_name"].ToString() + "</label></a>";
            lblexp.Text = dr4["experience"].ToString() + " Year Expirence";
        }

        dtdegree = condegree.GetData("select de.degree_id,df.degree_id,degree_name from Doctor_education de,Degree_info df where de.degree_id=df.degree_id  and doc_id=" + id);
        int degreecount = dtdegree.Rows.Count;
        foreach (DataRow dr5 in dtdegree.Rows)
        {

            if (dtdegree.Rows.Count != degreecount)
            {
                lbldegree.Text = dr5["degree_name"].ToString() + ",";
            }
            else
            {
                lbldegree.Text = dr5["degree_name"].ToString();
            }

        }

        dtspecility = conspecility.GetData("select * from Doctor_specialization ds,Specializations_info sf where ds.sep_id=sf.spe_id  and doc_id=" + id);
        int specount = dtspecility.Rows.Count;
        //string div_specility="";

        foreach (DataRow dr6 in dtspecility.Rows)
        {
            if (dtspecility.Rows.Count != specount)
            {
                lblspeciality.Text = dr6["spe_name"].ToString() + ",";
            }
            else
            {
                lblspeciality.Text = dr6["spe_name"].ToString();
            }

        }

        dtreview = conreview.GetData("select *from Doctor_feedback");

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string docid = Request.QueryString["did"];
        DateTime cdate = DateTime.Today;
        dtuser = conuser.GetData("select user_id from User_registration where user_mobile='" + Session["usermobile"].ToString() + "'");
        string pid = "";
        foreach (DataRow dr1 in dtuser.Rows)
        {
            pid = dr1["user_id"].ToString();
        }
        bool b = conreview.SaveData("doc_id",docid,"feedback",txtfeedback.Text,"patient_id",pid,"f_datetime",cdate.ToString());
        if (b == true)
        {
            Response.Redirect("viewappointment.aspx");
        }
        
    }
}