using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class bookdetail : System.Web.UI.Page
{
    connectionclass conuser = new connectionclass();
    DataTable dtuser= new DataTable();
    connectionclass conbook = new connectionclass();
    DataTable dtbook = new DataTable();
    connectionclass condoc = new connectionclass();
    DataTable dtdoc = new DataTable();

    connectionclass con_spe = new connectionclass();
    DataTable dt_spe = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        string clinic_id=Request.QueryString["cid"];
        string time = Request.QueryString["btime"];
        string bookdate = Request.QueryString["bdate"];
        
            
        if ( Session["usermobile"] == null)
        {
            Session["booktime"] = time;
            Session["clinicid"] = clinic_id;
            Session["book_date"] = bookdate;
            Response.Redirect("usersidelogin.aspx");
        }
        else
        {
            lbldate.Text = Request.QueryString["bdate"];
            DateTime dt_p = Convert.ToDateTime(Request.QueryString["btime"]);
            string time_p = dt_p.ToShortTimeString();
            lbltime.Text = time_p;
            //lbltime.Text = Session["booktime"].ToString();
            dtuser = conuser.GetData("select *from User_registration where user_mobile='" + Session["usermobile"].ToString() + "'");
            
            foreach (DataRow dr1 in dtuser.Rows)
            {
                ViewState["pid"] = dr1["user_id"].ToString();
                pt_name.Text = dr1["user_name"].ToString();
                u_email.Text = dr1["user_email"].ToString();
                u_mobile.Text = dr1["user_mobile"].ToString();
            }
            dtbook = conbook.GetData("select *from Patient_appointment");
        }
        dtdoc = condoc.GetData("select * from Doctor_clinic dc,Doctor_basic_info dbi,Area_info ai,City_info ci where ci.city_id=dc.city_id and ai.area_id=dc.area_id and dbi.doc_id=dc.doc_id and dc.dclinic_id='" + clinic_id + "'");
        foreach (DataRow drdoc in dtdoc.Rows)
        {
            
            ViewState["docid"] = drdoc["doc_id"].ToString();
            doc_profile_picture.ImageUrl = "Doctor/profile_pictures/"+ drdoc["profile_picture"].ToString();
            doc_profile_picture.AlternateText = drdoc["first_name"].ToString() + " " + drdoc["last_name"];
            lblname.Text=drdoc["first_name"].ToString()+" "+drdoc["last_name"];
            lbladdress.Text = "<br>" + drdoc["address"].ToString() + ",<br>" + drdoc["area_name"].ToString() + ",<br>" + drdoc["city_name"].ToString() + ".";
            lblfees.Text = drdoc["fees"].ToString();
            dt_spe = con_spe.GetData("select * from Specializations_info si,Doctor_specialization ds where si.spe_id=ds.sep_id and ds.doc_id='" + drdoc["doc_id"].ToString() + "'");
            foreach (DataRow dr_spe in dt_spe.Rows)
            {
                lblspeciality.Text = dr_spe["spe_name"].ToString();
            }
        }
    }
    protected void done_Click(object sender, EventArgs e)
    {
        string docid=ViewState["docid"].ToString();
        string patientid=ViewState["pid"].ToString();

        string clinic_id = Request.QueryString["cid"];
        string time = Request.QueryString["btime"];
        string bookdate = Request.QueryString["bdate"];
        DateTime dt=DateTime.Now;
        bool b= conbook.SaveData("doc_id",docid, "dclinic_id",clinic_id, "patient_id",patientid,"book_date",bookdate, "book_time",time, "book_reason",rsn_fr_visit.Text,"current_time_p",dt.ToString());

        if (b == true)
        {
            Response.Redirect("viewappointment.aspx");
        }
        else {
            Response.Write("<script>");
            Response.Write("alert('no');");
            Response.Write("</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("doctor_detail.aspx?did="+ViewState["docid"].ToString());
    }
}