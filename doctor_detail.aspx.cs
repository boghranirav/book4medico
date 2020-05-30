using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class doctor_detail : System.Web.UI.Page
{
    connectionclass conbasic = new connectionclass();
    DataTable dtbasic = new DataTable();
    connectionclass condegree = new connectionclass();
    DataTable dtdegree = new DataTable();
    connectionclass conspecility = new connectionclass();
    DataTable dtspecility = new DataTable();
    connectionclass conclinic =new  connectionclass();
    DataTable dtclinic = new DataTable();
    connectionclass conservice = new connectionclass();
    DataTable dtservice = new DataTable();
    connectionclass conedu = new connectionclass();
    DataTable dtedu = new DataTable();
    connectionclass conexp = new connectionclass();
    DataTable dtexp = new DataTable();
    connectionclass conaward = new connectionclass();
    DataTable dtaward = new DataTable();
    connectionclass conreg = new connectionclass();
    DataTable dtreg = new DataTable();
    connectionclass conmem = new connectionclass();
    DataTable dtmem = new DataTable();
    connectionclass concpicture = new connectionclass();
    DataTable dtcpicture = new DataTable();
    connectionclass conctime = new connectionclass();
    DataTable dtctime = new DataTable();

    connectionclass con_timing1 = new connectionclass();

    DataTable dt_timing1 = new DataTable();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["did"];
        dtbasic = conbasic.GetData("select *from Doctor_basic_info where doc_id="+id);
        comment_div.InnerHtml = "<a href='readreview.aspx?did=" + id + "'>View Comments</a>";

        foreach (DataRow dr1 in dtbasic.Rows)
        {
            profile_picture.ImageUrl = "Doctor/profile_pictures/" + dr1["profile_picture"].ToString();
            lbldocname.Text = "Dr." + dr1["first_name"].ToString() + " " + dr1["last_name"].ToString();
            lblexperience1.Text = dr1["experience"].ToString()+" Year Expirence";
        }
        dtdegree = condegree.GetData("select de.degree_id,df.degree_id,degree_name from Doctor_education de,Degree_info df where de.degree_id=df.degree_id and doc_id=" + id);
        int degreecount=dtdegree.Rows.Count ;
        foreach (DataRow dr2 in dtdegree.Rows)
        {

            if (dtdegree.Rows.Count != degreecount)
            {
                lbldocdegree.Text = dr2["degree_name"].ToString() + ",";
            }
            else
            {
                lbldocdegree.Text = dr2["degree_name"].ToString() ;
            }
           
        }
        dtspecility = conspecility.GetData("select * from Doctor_specialization ds,Specializations_info sf where ds.sep_id= spe_id and doc_id=" + id);
        int specount = dtspecility.Rows.Count;
        //string div_specility="";
        string spe_edu_exp = "";
        foreach (DataRow dr3 in dtspecility.Rows)
        {
              if (dtspecility.Rows.Count != specount)
               {
                lblspeciality.Text = dr3["spe_name"].ToString() + ",";
                }
              else {
                 lblspeciality.Text = dr3["spe_name"].ToString();
               }
             spe_edu_exp += "<h3>Specializations</h3><br/><table><ul><tr><td><li>" + dr3["spe_name"] + "</li></td></tr></ul></table>";
          }
        
        dtclinic = conclinic.GetData("select * from Doctor_clinic dc,City_info cf,Area_info af where dc.city_id=cf.city_id   and dc.area_id=af.area_id and doc_id="+id);
        string div_add = "";
        
        div_add += "<div id='gallery' class='gallery'><div class='image gallery-group-1'><div class='image-inner'>";
        string did = "";
        int i = 0;
        foreach (DataRow dr4 in dtclinic.Rows)
        {
            did = dr4["dclinic_id"].ToString();
            dtcpicture.Rows.Clear();
            dtcpicture = concpicture.GetData("select * from Clinic_photos where dclinic_id=" + did);
            string picture = "";
            i++;
            foreach (DataRow drcp in dtcpicture.Rows)
            {
               
                picture+="<a href='Doctor/Clinic_Photos/" +drcp["src_name"].ToString() + "' data-lightbox='gallery-group-"+i+"'><img src='Doctor/Clinic_Photos/" + drcp["src_name"].ToString() + "' width='50' height='50' /> </a>";
           
               }
            DateTime today = DateTime.Today;
            DateTime tommoro = DateTime.Now.AddDays(1);
            DateTime d_3 = DateTime.Now.AddDays(2);
            DateTime d_4 = DateTime.Now.AddDays(3);
            DateTime d_5 = DateTime.Now.AddDays(4);
            DateTime d_6 = DateTime.Now.AddDays(5);
            DateTime d_7 = DateTime.Now.AddDays(6);

            DateTime month = DateTime.Now.AddMonths(1);
            //Response.Write(month.ToString("MMM"));
           
            
            dtcpicture.Rows.Clear();
            div_add += "<h3><a href='clinic_detail.aspx?cid="+did+"'>" + dr4["area_name"].ToString() + "-" + dr4["city_name"].ToString() + "</a></h3><br/>";
            div_add += picture + "<br/><table width='100%'><tr>";
            div_add += "<td width='50%'><font size='3'><b>Address</b></font></td>";
            div_add += "<td><font size='3'><b>Fees</b></font></td><td></td>";
            div_add += "<td rowspan='2' align='right'><a href="+"javascript:toggleDiv('div"+i+"')"+" Class='btn btn-primary font-additional hvr-wobble-bottom' >book</a></td></tr>";
            div_add += "<tr><td>" + dr4["clinic_name"] + "," + dr4["address"].ToString() + "-" + dr4["city_name"].ToString() + "<br/><b>Contact No. : </b>"+dr4["phone_no"]+"</td>";
            div_add += "<td>" + dr4["fees"].ToString() + "</td><td></td></tr></table><br/>";
            dtctime.Rows.Clear();
            dtctime = conctime.GetData("select * from Doctor_schedule where doc_id='"+dr4["doc_id"].ToString()+"' and dclinic_id='"+dr4["dclinic_id"].ToString()+"'");
            
            int cnt = 0;
            div_add += "<div class='slidediv' id='div" + i + "'>";
            div_add += "<div class='col-lg-12' style='background:#F8F8F8;border:solid #dcdcdc;'><br>";
            if (dtctime.Rows.Count == 0)
            {
                div_add += "Doctor has not set clinic timing.<br><br>";
            }
            else
            {
                foreach (DataRow drct in dtctime.Rows)
                {
                    //i++;
                    //cnt++;
                    //lb[i].ID = "lbl" + i;
                    //lb[i].Text = drct["s_day_name"].ToString();
                    if (drct["s_day_name"].ToString() == today.ToString("dddd"))
                    {

                        div_add += "<div class='col-lg-2'>";
                        div_add += drct["s_day_name"].ToString() + "<br/>" + today.ToString("dd") + " " + today.ToString("MMM") + "<br>";
                        int count_i = Convert.ToInt32(drct["s_avg_time"].ToString());
                        DateTime dt_start = Convert.ToDateTime(drct["s_first_from"].ToString());
                        DateTime current_time = DateTime.Now;
                        string cth = current_time.ToString("%h");
                        string ctm = current_time.ToString("%m");
                        string am_pm = current_time.ToString("tt");
                        if (am_pm == "PM")
                        {
                            cth = cth + 12;
                        }

                        DateTime dt_end = Convert.ToDateTime(drct["s_first_to"].ToString());
                        DateTime dt_second_start = Convert.ToDateTime(drct["s_second_from"].ToString());
                        DateTime dt_second_end = Convert.ToDateTime(drct["s_second_to"].ToString());

                        div_add += "<div style='float:left;width:50%;height:auto;'>";
                        div_add += "Morning";
                        string app_date = today.ToShortDateString();



                        while (Convert.ToInt32(dt_start.ToString("%h")) < Convert.ToInt32(dt_end.ToString("%h")))
                        {


                            if (Convert.ToInt32(cth) < Convert.ToInt32(dt_start.ToString("%h")))
                            {
                                dt_timing1.Clear();
                                dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + app_date + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                                if (dt_timing1.Rows.Count > 0)
                                {
                                    div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                                }
                                else
                                {
                                    div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + app_date + "'>" + dt_start.ToString("H:mm") + "</a>";
                                }

                            }
                            else
                                if ((Convert.ToInt32(cth) == Convert.ToInt32(dt_start.ToString("%h"))) && (Convert.ToInt32(ctm) <= Convert.ToInt32(dt_start.ToString("%m"))))
                                {
                                    dt_timing1.Clear();
                                    dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + app_date + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                                    if (dt_timing1.Rows.Count > 0)
                                    {
                                        div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                                    }
                                    else
                                    {
                                        div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + app_date + "'>" + dt_start.ToString("H:mm") + "</a>";
                                    }
                                }
                                else
                                {
                                    div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                                }
                            dt_start = dt_start.AddMinutes(count_i);
                        }
                        div_add += "</div>";

                        div_add += "<div  style='float:left;width:50%;height:auto;'>";
                        div_add += "Afternoon";

                        while (Convert.ToInt32(dt_second_start.ToString("%h")) < Convert.ToInt32(dt_second_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_second_start.ToString("H:mm") + "' and book_date='" + app_date + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br>&nbsp;&nbsp;<strike>" + dt_second_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br>&nbsp;&nbsp;<a href='bookdetail.aspx?btime=" + dt_second_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + app_date + "'>" + dt_second_start.ToString("H:mm") + "</a>";
                            }
                            dt_second_start = dt_second_start.AddMinutes(count_i);
                        }

                        div_add += "</div>";


                        div_add += "</div>";
                    }
                    else if (drct["s_day_name"].ToString() == tommoro.ToString("dddd"))
                    {
                        div_add += "<div class='col-lg-2'>";
                        div_add += drct["s_day_name"].ToString() + "<br/>" + tommoro.ToString("dd") + " " + tommoro.ToString("MMM") + "<br>";
                        int count_i = Convert.ToInt32(drct["s_avg_time"].ToString());
                        DateTime dt_start = Convert.ToDateTime(drct["s_first_from"].ToString());
                        DateTime dt_end = Convert.ToDateTime(drct["s_first_to"].ToString());
                        DateTime dt_second_start = Convert.ToDateTime(drct["s_second_from"].ToString());
                        DateTime dt_second_end = Convert.ToDateTime(drct["s_second_to"].ToString());

                        div_add += "<div style='float:left;width:50%;height:auto;'>";
                        div_add += "Morning";
                        while (Convert.ToInt32(dt_start.ToString("%h")) < Convert.ToInt32(dt_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + tommoro.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + tommoro.ToShortDateString() + "'>" + dt_start.ToString("H:mm") + "</a>";
                            }
                            dt_start = dt_start.AddMinutes(count_i);
                        }
                        div_add += "</div>";

                        div_add += "<div  style='float:left;width:50%;height:auto;'>";
                        div_add += "Afternoon";

                        while (Convert.ToInt32(dt_second_start.ToString("%h")) < Convert.ToInt32(dt_second_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_second_start.ToString("H:mm") + "' and book_date='" + tommoro.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br>&nbsp;&nbsp;<strike>" + dt_second_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br>&nbsp;&nbsp;<a href='bookdetail.aspx?btime=" + dt_second_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + tommoro.ToShortDateString() + "'>" + dt_second_start.ToString("H:mm") + "</a>";
                            }
                            dt_second_start = dt_second_start.AddMinutes(count_i);
                        }

                        div_add += "</div>";
                        div_add += "</div>";
                    }
                    else if (drct["s_day_name"].ToString() == d_3.ToString("dddd"))
                    {
                        div_add += "<div class='col-lg-2'>";
                        div_add += drct["s_day_name"].ToString() + "<br/>" + d_3.ToString("dd") + " " + d_3.ToString("MMM") + "<br>";
                        int count_i = Convert.ToInt32(drct["s_avg_time"].ToString());
                        DateTime dt_start = Convert.ToDateTime(drct["s_first_from"].ToString());
                        DateTime dt_end = Convert.ToDateTime(drct["s_first_to"].ToString());
                        DateTime dt_second_start = Convert.ToDateTime(drct["s_second_from"].ToString());
                        DateTime dt_second_end = Convert.ToDateTime(drct["s_second_to"].ToString());

                        div_add += "<div style='float:left;width:50%;height:auto;'>";
                        div_add += "Morning";
                        while (Convert.ToInt32(dt_start.ToString("%h")) < Convert.ToInt32(dt_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + d_3.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_3.ToShortDateString() + "'>" + dt_start.ToString("H:mm") + "</a>";
                            }
                            dt_start = dt_start.AddMinutes(count_i);
                        }
                        div_add += "</div>";

                        div_add += "<div  style='float:left;width:50%;height:auto;'>";
                        div_add += "Afternoon";

                        while (Convert.ToInt32(dt_second_start.ToString("%h")) < Convert.ToInt32(dt_second_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_second_start.ToString("H:mm") + "' and book_date='" + d_3.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br>&nbsp;&nbsp;<strike>" + dt_second_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br>&nbsp;&nbsp;<a href='bookdetail.aspx?btime=" + dt_second_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_3.ToShortDateString() + "'>" + dt_second_start.ToString("H:mm") + "</a>";
                            }
                            dt_second_start = dt_second_start.AddMinutes(count_i);
                        }

                        div_add += "</div>";
                        div_add += "</div>";
                    }
                    else if (drct["s_day_name"].ToString() == d_4.ToString("dddd"))
                    {
                        div_add += "<div class='col-lg-2'>";
                        div_add += drct["s_day_name"].ToString() + "<br/>" + d_4.ToString("dd") + " " + d_4.ToString("MMM") + "<br>";
                        int count_i = Convert.ToInt32(drct["s_avg_time"].ToString());
                        DateTime dt_start = Convert.ToDateTime(drct["s_first_from"].ToString());
                        DateTime dt_end = Convert.ToDateTime(drct["s_first_to"].ToString());
                        DateTime dt_second_start = Convert.ToDateTime(drct["s_second_from"].ToString());
                        DateTime dt_second_end = Convert.ToDateTime(drct["s_second_to"].ToString());

                        div_add += "<div style='float:left;width:50%;height:auto;'>";
                        div_add += "Morning";
                        while (Convert.ToInt32(dt_start.ToString("%h")) < Convert.ToInt32(dt_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + d_4.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_4.ToShortDateString() + "'>" + dt_start.ToString("H:mm") + "</a>";
                            }
                            dt_start = dt_start.AddMinutes(count_i);
                        }
                        div_add += "</div>";

                        div_add += "<div  style='float:left;width:50%;height:auto;'>";
                        div_add += "Afternoon";

                        while (Convert.ToInt32(dt_second_start.ToString("%h")) < Convert.ToInt32(dt_second_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_second_start.ToString("H:mm") + "' and book_date='" + d_4.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br>&nbsp;&nbsp;<strike>" + dt_second_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br>&nbsp;&nbsp;<a href='bookdetail.aspx?btime=" + dt_second_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_4.ToShortDateString() + "'>" + dt_second_start.ToString("H:mm") + "</a>";
                            }
                            dt_second_start = dt_second_start.AddMinutes(count_i);
                        }

                        div_add += "</div>";
                        div_add += "</div>";
                    }
                    else if (drct["s_day_name"].ToString() == d_5.ToString("dddd"))
                    {
                        div_add += "<div class='col-lg-2'>";
                        div_add += drct["s_day_name"].ToString() + "<br/>" + d_5.ToString("dd") + " " + d_5.ToString("MMM") + "<br>";
                        int count_i = Convert.ToInt32(drct["s_avg_time"].ToString());
                        DateTime dt_start = Convert.ToDateTime(drct["s_first_from"].ToString());
                        DateTime dt_end = Convert.ToDateTime(drct["s_first_to"].ToString());
                        DateTime dt_second_start = Convert.ToDateTime(drct["s_second_from"].ToString());
                        DateTime dt_second_end = Convert.ToDateTime(drct["s_second_to"].ToString());

                        div_add += "<div style='float:left;width:50%;height:auto;'>";
                        div_add += "Morning";
                        while (Convert.ToInt32(dt_start.ToString("%h")) < Convert.ToInt32(dt_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + d_5.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_5.ToShortDateString() + "'>" + dt_start.ToString("H:mm") + "</a>";
                            }
                            dt_start = dt_start.AddMinutes(count_i);
                        }
                        div_add += "</div>";

                        div_add += "<div  style='float:left;width:50%;height:auto;'>";
                        div_add += "Afternoon";

                        while (Convert.ToInt32(dt_second_start.ToString("%h")) < Convert.ToInt32(dt_second_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_second_start.ToString("H:mm") + "' and book_date='" + d_5.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br>&nbsp;&nbsp;<strike>" + dt_second_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br>&nbsp;&nbsp;<a href='bookdetail.aspx?btime=" + dt_second_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_5.ToShortDateString() + "'>" + dt_second_start.ToString("H:mm") + "</a>";
                            }
                            dt_second_start = dt_second_start.AddMinutes(count_i);
                        }

                        div_add += "</div>";
                        div_add += "</div>";
                    }
                    else if (drct["s_day_name"].ToString() == d_6.ToString("dddd"))
                    {
                        div_add += "<div class='col-lg-2'>";
                        div_add += drct["s_day_name"].ToString() + "<br/>" + d_6.ToString("dd") + " " + d_6.ToString("MMM") + "<br>";
                        int count_i = Convert.ToInt32(drct["s_avg_time"].ToString());
                        DateTime dt_start = Convert.ToDateTime(drct["s_first_from"].ToString());
                        DateTime dt_end = Convert.ToDateTime(drct["s_first_to"].ToString());
                        DateTime dt_second_start = Convert.ToDateTime(drct["s_second_from"].ToString());
                        DateTime dt_second_end = Convert.ToDateTime(drct["s_second_to"].ToString());

                        div_add += "<div style='float:left;width:50%;height:auto;'>";
                        div_add += "Morning";
                        while (Convert.ToInt32(dt_start.ToString("%h")) < Convert.ToInt32(dt_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_start.ToString("H:mm") + "' and book_date='" + d_6.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br><strike>" + dt_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br><a href='bookdetail.aspx?btime=" + dt_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_6.ToShortDateString() + "'>" + dt_start.ToString("H:mm") + "</a>";
                            }
                            dt_start = dt_start.AddMinutes(count_i);
                        }
                        div_add += "</div>";

                        div_add += "<div  style='float:left;width:50%;height:auto;'>";
                        div_add += "Afternoon";

                        while (Convert.ToInt32(dt_second_start.ToString("%h")) < Convert.ToInt32(dt_second_end.ToString("%h")))
                        {
                            dt_timing1.Clear();
                            dt_timing1 = con_timing1.GetData("select * from Patient_appointment where book_time='" + dt_second_start.ToString("H:mm") + "' and book_date='" + d_6.ToShortDateString() + "' and dclinic_id='" + dr4["dclinic_id"] + "'");

                            if (dt_timing1.Rows.Count > 0)
                            {
                                div_add += "<br>&nbsp;&nbsp;<strike>" + dt_second_start.ToString("H:mm") + "</strike>";
                            }
                            else
                            {
                                div_add += "<br>&nbsp;&nbsp;<a href='bookdetail.aspx?btime=" + dt_second_start.ToString("H:mm") + "&cid=" + dr4["dclinic_id"] + "&bdate=" + d_6.ToShortDateString() + "'>" + dt_second_start.ToString("H:mm") + "</a>";
                            }
                            dt_second_start = dt_second_start.AddMinutes(count_i);
                        }

                        div_add += "<br><br></div>";
                        div_add += "</div>";
                    }

                }
            }
            div_add += "</div><br><br></div>";
     
        }
         div_add += "</div></div></div>";

        
       
       
        
        divaddress.InnerHtml = div_add;

        dtservice = conservice.GetData("select *from Doctor_services ds,Services s where ds.service_id=s.service_id and doc_id="+id);
        string div_services = "";
        int scnt = 0;
        if (dtservice.Rows.Count <= 0)
        {
            div_services += "";
        }
        else
        {
            div_services += "<hr/><h3>Services</h3><br/><table width=100%><ul><tr>";
            foreach (DataRow dr5 in dtservice.Rows)
            {
                if (scnt == 2)
                {
                    div_services += "<td><li>" + dr5["service_name"] + "</li></td></tr><tr>";
                    scnt = 0;
                }
                else
                {
                    div_services += "<td><li>" + dr5["service_name"] + "</li></td>";
                    scnt++;
                }


            }

            div_services += "</ul></table><hr/>";
        }
        divservices.InnerHtml = div_services;

        dtedu = conedu.GetData("select *from Doctor_education de,Degree_info df  where de.degree_id=df.degree_id and doc_id="+id);
        dtexp = conexp.GetData("select * from Doctor_experience where doc_id=" + id);
        if (dtedu.Rows.Count <= 0)
        {
            spe_edu_exp += "";
        }
        else
        {
            spe_edu_exp += "<br/><h3>Education</h3><br/><table><ul>";
            foreach (DataRow dr6 in dtedu.Rows)
            {
                spe_edu_exp += "<tr><td><li>" + dr6["degree_name"] + "-" + dr6["institute_name"] + " in year " + dr6["description"] + "</li></td></tr>";
            }
            spe_edu_exp += "</ul></table>";

        }
        if (dtexp.Rows.Count <= 0)
        {
            spe_edu_exp += "";
        }
        else
        {

            spe_edu_exp += "<br/><h3>Experiences</h3><br/><table> <ul>";
            foreach (DataRow dr7 in dtexp.Rows)
            {
                string from_mth = dr7["from_month"].ToString();
                DateTime from_dt = new DateTime(2015, int.Parse(from_mth), 1);
                string from_monthname = from_dt.ToString("MMM");
                string to_mth = dr7["to_month"].ToString();
                DateTime to_dt = new DateTime(2015, int.Parse(to_mth), 1);
                string to_monthname = to_dt.ToString("MMM");

                spe_edu_exp += "<tr><td><li>" + from_monthname + "-" + dr7["from_year"] + "  to  " + to_monthname + "-" + dr7["to_year"] + "<br/> &nbsp;&nbsp; Description:- " + dr7["description"] + "</li></td></tr>";
            }
            spe_edu_exp += "</ul></table>";
        }
        divspe_edu_exp.InnerHtml = spe_edu_exp;


        dtaward = conaward.GetData("select * from Award_recognitions where doc_id=" + id);
        string award_mem_reg = "";
        if (dtaward.Rows.Count <= 0)
        {
            award_mem_reg += "";
        }
        else
        {
            award_mem_reg += "<h3>Awards and Recognitions</h3><br/><table><ul>";
            foreach (DataRow dr8 in dtaward.Rows)
            {
                award_mem_reg += "<tr><td><li>" + dr8["award_year"] + "-" + dr8["description"] + "</li></td></tr>";
            }
            award_mem_reg += "<ul></table>";
        }

        dtmem = conmem.GetData("select *from Doctor_memberships where doc_id=" + id);
        if (dtmem.Rows.Count <= 0)
        {
            award_mem_reg += "";
        }
        else
        {
            award_mem_reg += "<br/><h3>Membership</h3><br/><table><ul>";
            foreach (DataRow dr9 in dtmem.Rows)
            {
                award_mem_reg += "<tr><td><li>" + dr9["description"] + "</li></td></tr>";
            }
            award_mem_reg += "</ul></table>";
        }
                dtreg = conreg.GetData("select * from Registrations_board where doc_id=" + id);
        if (dtreg.Rows.Count <= 0)
           {
             award_mem_reg += "";
            }
            else
                {
                    award_mem_reg += "<br/><h3>Registrations</h3><br/><table><ul>";
                    foreach (DataRow dr10 in dtreg.Rows)
                    {
                        award_mem_reg += "<tr><td><li>" + dr10["registration_no"] + "-" + dr10["description"] + "</li></td></tr>";
                    }
                    award_mem_reg += "</ul></table>";
                }
        div_award_mem_reg.InnerHtml = award_mem_reg;
        
    }
}