using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class readreview : System.Web.UI.Page
{
    connectionclass conbasic = new connectionclass();
    DataTable dtbasic = new DataTable();
    connectionclass condegree = new connectionclass();
    DataTable dtdegree = new DataTable();
    connectionclass conspecility = new connectionclass();
    DataTable dtspecility = new DataTable();

    connectionclass conreview = new connectionclass();
    DataTable dtreview = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["did"];
        dtbasic = conbasic.GetData("select *from Doctor_basic_info where doc_id=" + id);
        foreach (DataRow dr1 in dtbasic.Rows)
        {
            profile_picture.ImageUrl = "Doctor/profile_pictures/" + dr1["profile_picture"].ToString();
            lbldocname.Text = "Dr." + dr1["first_name"].ToString() + " " + dr1["last_name"].ToString();
            lblexperience1.Text = dr1["experience"].ToString() + " Year Expirence";
        }
        dtdegree = condegree.GetData("select de.degree_id,df.degree_id,degree_name from Doctor_education de,Degree_info df where de.degree_id=df.degree_id and doc_id=" + id);
        int degreecount = dtdegree.Rows.Count;
        foreach (DataRow dr2 in dtdegree.Rows)
        {

            if (dtdegree.Rows.Count != degreecount)
            {
                lbldocdegree.Text = dr2["degree_name"].ToString() + ",";
            }
            else
            {
                lbldocdegree.Text = dr2["degree_name"].ToString();
            }

        }
        dtspecility = conspecility.GetData("select * from Doctor_specialization ds,Specializations_info sf where ds.sep_id= spe_id and doc_id=" + id);
        int specount = dtspecility.Rows.Count;
        //string div_specility="";
        
        foreach (DataRow dr3 in dtspecility.Rows)
        {
            if (dtspecility.Rows.Count != specount)
            {
                lblspeciality.Text = dr3["spe_name"].ToString() + ",";
            }
            else
            {
                lblspeciality.Text = dr3["spe_name"].ToString();
            }
          
        }

        dtreview = conreview.GetData("select *from Doctor_feedback df,User_registration ur where df.patient_id=ur.user_id and df.doc_id='"+id+"' order by df.f_datetime desc");
        string str_review = "";
        str_review+="<div class='table-responsive'>";
        str_review += "<table width='100%'>";
        if (dtreview.Rows.Count <= 0)
        {
            str_review += "<tr ><td style='padding:5px 0 3px 0;'><b>No Comment Found.</b></td></tr>";
        }
        else
        {
            foreach (DataRow drre in dtreview.Rows)
            {
                DateTime date1 = Convert.ToDateTime(drre["f_datetime"].ToString());

                str_review += "<tr ><td style='padding:5px 0 3px 0;'>" + date1.ToString("dd MMM,yyyy") + "<td></tr>";
                str_review += "<tr><td style='padding:5px 0 3px 0;'>" + drre["feedback"].ToString() + "</td></tr>";
                str_review += "<tr><td style='padding:5px 0 3px 0;font-family:calibri;color:#FD6F1A;' align='right'>" + "By " + drre["user_name"].ToString() + "</td></tr><tr><td><hr/></td></tr>";

            }
        }
        str_review += "</table>";
        str_review += "</div>";
       
        divreview.InnerHtml = str_review;
    }
}