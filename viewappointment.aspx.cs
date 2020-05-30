using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class viewappointment : System.Web.UI.Page
{
    connectionclass conup = new connectionclass();
    DataTable dtup = new DataTable();
    connectionclass conp = new connectionclass();
    DataTable dtp = new DataTable();
    connectionclass conpast = new connectionclass();
    DataTable dtpast = new DataTable();
    connectionclass confeed = new connectionclass();
    DataTable dtfeed = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dtp = conp.GetData("select user_id from User_registration where user_mobile='" + Session["usermobile"] + "' ");
        foreach (DataRow drpt in dtp.Rows)
        {
            ViewState["pid"] = drpt["user_id"].ToString();
        }
        string ptid = ViewState["pid"].ToString();
        DateTime currtdate = DateTime.Today;
        string cudate = currtdate.ToString("MM/dd/yyyy");
        dtup = conup.GetData("select *from Patient_appointment pa,Doctor_clinic dc,Doctor_basic_info df where pa.doc_id=df.doc_id and pa.dclinic_id=dc.dclinic_id  and book_date>='"+cudate+"' and  patient_id='" + ptid + "'");
        string upcoming = "";
        if (dtup.Rows.Count <= 0)
        {
            upcoming += "No upcoming appoitment.";
        }
        else
        {
            upcoming += "<tr><th>Doctor</th><th>Clinic Name</th><th>Address</th><th>Date</th><th>Time</th><th>Reason For visit</th><th>Cancel</th></tr>";
            foreach (DataRow drup in dtup.Rows)
            {


                DateTime date1 = Convert.ToDateTime(drup["book_date"].ToString());
                string bookdate = date1.ToShortDateString();
                DateTime dt_p = Convert.ToDateTime(drup["book_time"].ToString());
                string time_p = dt_p.ToShortTimeString();

                upcoming += "<tr>";
                upcoming += "<td>" + "Dr." + drup["first_name"].ToString() + " " + drup["last_name"].ToString() + "</td>";
                upcoming += "<td>" + drup["clinic_name"].ToString() + "</td><td>" + drup["address"].ToString() + "</td>";
                upcoming += "<td>" + bookdate + "</td><td>" + time_p + "</td>";
                upcoming += "<td>" + drup["book_reason"].ToString() + "</td>";
                upcoming += "<td align='center'><a href='Javascript:cancelappfunction(" + drup["appoint_id"] + ");'><i class='fa fa-2x fa-times'></i></a></td>";
                upcoming += "</tr>";

            }
        }
           booktableid.InnerHtml = upcoming;
        
         if (Request.QueryString["ermsg"] != "")
          {
            string msg1 = Request.QueryString["ermsg"];
            if (msg1 == "error")
            {
                Response.Write("<script>");
                Response.Write("alert('Appointment not deleted.');");
                Response.Write("</script>");
            }

        }
         if (Request.QueryString["ermsg2"] != "")
         {
             string msg2 = Request.QueryString["ermsg2"];
             if (msg2 == "error")
             {
                 Response.Write("<script>");
                 Response.Write("alert('Comment not deleted.');");
                 Response.Write("</script>");
             }

         }
    }
    protected void rdbpast_CheckedChanged(object sender, EventArgs e)
    {
    
        string ptid = ViewState["pid"].ToString();
        DateTime currtdate = DateTime.Today;
        string cudate = currtdate.ToString("MM/dd/yyyy");
        dtpast.Clear();
        dtpast = conpast.GetData("select *from Patient_appointment pa,Doctor_clinic dc,Doctor_basic_info df where pa.doc_id=df.doc_id and pa.dclinic_id=dc.dclinic_id  and book_date<'" + cudate + "' and  patient_id='" + ptid + "'");
        string past = "";

        //string date1="";
        if (dtpast.Rows.Count <= 0)
        {
            past += "No past appointment.";
        }
        else
        {
         past+="<tr><th>Doctor</th><th>Clinic Name</th><th>Address</th><th>Date</th><th>Time</th><th>Reason For visit</th><th>Delete</th><th>Write Comment</th></tr>";
        
             foreach (DataRow drpast in dtpast.Rows)
             {
                 
                 DateTime date1 = Convert.ToDateTime(drpast["book_date"].ToString());
                 string bookdate = date1.ToShortDateString();
                 DateTime dt_p = Convert.ToDateTime(drpast["book_time"].ToString());
                 string time_p = dt_p.ToShortTimeString();

                 past += "<tr>";
                 past += "<td>" + "Dr." + drpast["first_name"].ToString() + " " + drpast["last_name"].ToString() + "</td>";
                 past += "<td>" + drpast["clinic_name"].ToString() + "</td><td>" + drpast["address"].ToString() + "</td>";
                 past += "<td>" + bookdate + "</td><td>" + time_p + "</td>";
                 past += "<td>" + drpast["book_reason"].ToString() + "</td>";
                 past += "<td align='center'><a href='Javascript:deleteappfunction(" + drpast["appoint_id"] + ");'><i class='fa fa-2x fa-trash-o'></i></a></td>";
                 past += "<td><a href='review.aspx?did=" + drpast["doc_id"].ToString() + "'>Write Comment</a></td>";
                 past += "</tr>";
                 }
            }
        booktableid.InnerHtml = past;
        
        dtfeed.Clear();
        dtfeed=confeed.GetData("select *from Doctor_feedback df,Doctor_basic_info dbf where df.doc_id=dbf.doc_id and patient_id='"+ptid+"'");
       string str_review = "";
       if (dtfeed.Rows.Count <= 0)
       {
           str_review = "";
       }
       else
       {
           str_review += "<tr><td  colspan='4' align='center'><font size='3'>Comment</font></td></tr>";
           str_review += "<tr><th>Srno.</th><th>Doctor</th><th>Comment</th><th>Delete</th></tr>";
           int srcount = 0;
           foreach (DataRow drfeed in dtfeed.Rows)
           {
               srcount++;
               str_review += "<tr>";
               str_review += "<td>" + srcount + "</td>";
               str_review += "<td>" + "Dr." + drfeed["first_name"].ToString() + " " + drfeed["last_name"].ToString() + "</td>";
               str_review += "<td>" + drfeed["feedback"].ToString() + "</td>";
               str_review += "<td center='align'><a href='Javascript:deletereviewfunction(" + drfeed["fb_id"] + ");'><i class='fa fa-2x fa-trash-o'></i></a></td>";
               str_review += "</tr>";
           }
       }
        reviewid.InnerHtml = str_review;
        
         

    }
    protected void rdbup_CheckedChanged(object sender, EventArgs e)
    {
        string ptid = ViewState["pid"].ToString();
        DateTime currtdate = DateTime.Today;
        string cudate = currtdate.ToString("MM/dd/yyyy");
        dtup.Clear();
        dtup = conup.GetData("select *from Patient_appointment pa,Doctor_clinic dc,Doctor_basic_info df where pa.doc_id=df.doc_id and pa.dclinic_id=dc.dclinic_id  and book_date>='" + cudate + "' and  patient_id='" + ptid + "'");
        string upcoming = "";

        //string date1="";
        if (dtup.Rows.Count <= 0)
        {
            upcoming += "No upcoming appointment.";
        }
        else
        {
        upcoming += "<tr><th>Doctor</th><th>Clinic Name</th><th>Address</th><th>Date</th><th>Time</th><th>Reason For visit</th><th>Cancel</th></tr>";
       
            foreach (DataRow drup in dtup.Rows)
            {
                
                    DateTime date1 = Convert.ToDateTime(drup["book_date"].ToString());
                    string bookdate = date1.ToShortDateString();
                    DateTime dt_p = Convert.ToDateTime(drup["book_time"].ToString());
                    string time_p = dt_p.ToShortTimeString();
                    upcoming += "<tr>";
                    upcoming += "<td>" + "Dr." + drup["first_name"].ToString() + " " + drup["last_name"].ToString() + "</td>";
                    upcoming += "<td>" + drup["clinic_name"].ToString() + "</td><td>" + drup["address"].ToString() + "</td>";
                    upcoming += "<td>" + bookdate + "</td><td>" + time_p + "</td>";
                    upcoming += "<td>" + drup["book_reason"].ToString() + "</td>";
                    upcoming += "<td align='center'><a href='Javascript:cancelappfunction(" + drup["appoint_id"] + ");'><i class='fa fa-2x fa-times'></i></a></td>";
                    upcoming += "</tr>";
                }
            }
                   booktableid.InnerHtml = upcoming;

                   reviewid.InnerHtml = "";
    }
}