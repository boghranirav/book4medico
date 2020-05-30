using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class clinic_detail : System.Web.UI.Page
{
    connectionclass conclinic = new connectionclass();
    DataTable dtclinic = new DataTable();
    connectionclass conclinicphotos = new connectionclass();
    DataTable dtclinicphotos = new DataTable();
    connectionclass conservice = new connectionclass();
    DataTable dtservice = new DataTable();

    connectionclass conbasic = new connectionclass();
    DataTable dtbasic = new DataTable();
    connectionclass condegree=new connectionclass();
    DataTable dtdegree=new DataTable();
    connectionclass conspecility = new connectionclass();
    DataTable dtspecility =new DataTable();
    connectionclass conreg = new connectionclass();
    DataTable dtreg = new DataTable();

    connectionclass con_timing1 = new connectionclass();
    connectionclass con_timing2 = new connectionclass();
    connectionclass con_timing3 = new connectionclass();
    connectionclass con_timing4 = new connectionclass();
    connectionclass con_timing5 = new connectionclass();
    connectionclass con_timing6 = new connectionclass();
    connectionclass con_timing7 = new connectionclass();

    DataTable dt_timing1 = new DataTable();
    DataTable dt_timing2 = new DataTable();
    DataTable dt_timing3 = new DataTable();
    DataTable dt_timing4 = new DataTable();
    DataTable dt_timing5 = new DataTable();
    DataTable dt_timing6 = new DataTable();
    DataTable dt_timing7 = new DataTable();

    string mon1 = "", mon2 = "", mon3 = "", mon4 = "";
    string tue1 = "", tue2 = "", tue3 = "", tue4 = "";
    string wed1 = "", wed2 = "", wed3 = "", wed4 = "";
    string thu1 = "", thu2 = "", thu3 = "", thu4 = "";
    string fri1 = "", fri2 = "", fri3 = "", fri4 = "";
    string sat1 = "", sat2 = "", sat3 = "", sat4 = "";
    string sun1 = "", sun2 = "", sun3 = "", sun4 = "";
    string day_1 = "", day_2 = "", day_3 = "", day_4 = "", day_5 = "", day_6 = "", day_7 = "";
    string set_m = "";
    string clinic_day = "";
    string avail_day = "";

    public void get_meridian(string s1)
    {
        if (Convert.ToInt32(s1) >= 12)
        {
            set_m = "PM";
        }
        else
        {
            set_m = "AM";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["cid"];
        dtclinic = conclinic.GetData("select * from Doctor_clinic dc,City_info cf,Area_info af where dc.city_id=cf.city_id and dc.area_id=af.area_id and dclinic_id=" + id);
     
        foreach (DataRow dr1 in dtclinic.Rows)
        {

            lblclinicname.Text=dr1["clinic_name"].ToString();
            lbladdress.Text="<b>Address : </b>"+dr1["address"].ToString() + "-"+dr1["area_name"].ToString()+"," + dr1["city_name"].ToString();
            lblphone.Text = "<b>Phone Number : </b>" + dr1["phone_no"].ToString();
            lblfees.Text = "INR " + dr1["fees"].ToString();
        }
        dtclinicphotos = conclinicphotos.GetData("select * from Clinic_photos where dclinic_id="+id);
        int i = 0;
        string photos = "";
        photos += "<div id='gallery' class='gallery'><div class='image gallery-group-1'><div class='image-inner'>";
        foreach (DataRow dr2 in dtclinicphotos.Rows)
        {
            if (i == 0)
            {
                profile_picture.ImageUrl = "Doctor/Clinic_Photos/" + dr2["src_name"].ToString();
            }
            photos += "<a href='Doctor/Clinic_Photos/" + dr2["src_name"].ToString() + "' data-lightbox='gallery-group-1'><img src='Doctor/Clinic_Photos/" + dr2["src_name"].ToString() + "' width='50' height='50' /> </a> ";
                
            i++;
        }
        photos+="</div></div></div>";
        divclinicphoto.InnerHtml = photos;
       
        dtservice = conservice.GetData("select *from Doctor_services ds,Services s,Doctor_clinic dc where ds.service_id=s.service_id and ds.doc_id=dc.doc_id and  dclinic_id=" + id);
        string div_services = "";
        int scnt = 0;
        div_services += "<hr/><h3>Services</h3><br/><table width=100%><ul><tr>";
        foreach (DataRow dr3 in dtservice.Rows)
        {
            if (scnt == 2)
            {
                div_services += "<td><li>" + dr3["service_name"] + "</li></td></tr><tr>";
                scnt = 0;
            }
            else
            {
                div_services += "<td><li>" + dr3["service_name"] + "</li></td>";
                scnt++;
            }


        }
        div_services += "</ul></table><hr/>";
        divservices.InnerHtml = div_services;
      
        dtbasic = conbasic.GetData("select *from Doctor_basic_info dbi,Doctor_clinic dc where dc.doc_id=dbi.doc_id and dclinic_id=" + id);
        foreach (DataRow dr4 in dtbasic.Rows)
        {
            doc_profile_picture.ImageUrl = "Doctor/profile_pictures/" + dr4["profile_picture"].ToString();
            docname.InnerHtml = "<a href='doctor_detail.aspx?did="+dr4["doc_id"]+"'><label>Dr." + dr4["first_name"].ToString() + " " + dr4["last_name"].ToString()+"</label></a>";
            lblexp.Text = dr4["experience"].ToString() + " Year Expirence";
        }

        dtdegree = condegree.GetData("select de.degree_id,df.degree_id,degree_name from Doctor_education de,Degree_info df,Doctor_clinic dlc where de.degree_id=df.degree_id and de.doc_id=dlc.doc_id and dclinic_id=" + id);
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

        dtspecility = conspecility.GetData("select * from Doctor_specialization ds,Specializations_info sf,Doctor_clinic dc where ds.sep_id=sf.spe_id and ds.doc_id=dc.doc_id and dclinic_id=" + id);
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

        dtreg= conreg.GetData("select *from Doctor_registration dr,Doctor_clinic dc where dr.doc_id=dc.doc_id and dclinic_id=" + id);
        foreach (DataRow dr7 in dtreg.Rows)
        {
            lbldocmobileno.Text = "Mobile No. " + dr7["doc_r_mobile_no"].ToString();
        }


        dt_timing1 = con_timing1.GetData("select * from Doctor_schedule where s_day_name='Monday' and dclinic_id='" + id + "'");
        dt_timing2 = con_timing2.GetData("select * from Doctor_schedule where s_day_name='Tuesday' and dclinic_id='" + id + "'");
        dt_timing3 = con_timing3.GetData("select * from Doctor_schedule where s_day_name='Wednesday' and dclinic_id='" + id + "'");
        dt_timing4 = con_timing4.GetData("select * from Doctor_schedule where s_day_name='Thursday' and dclinic_id='" + id + "'");
        dt_timing5 = con_timing5.GetData("select * from Doctor_schedule where s_day_name='Friday' and dclinic_id='" + id + "'");
        dt_timing6 = con_timing6.GetData("select * from Doctor_schedule where s_day_name='Saturday' and dclinic_id='" + id + "'");
        dt_timing7 = con_timing7.GetData("select * from Doctor_schedule where s_day_name='Sunday' and dclinic_id='" + id + "'");

        foreach (DataRow dr_timing1 in dt_timing1.Rows)
        {
            mon1 = dr_timing1["s_first_from"].ToString();
            mon2 = dr_timing1["s_first_to"].ToString();
            mon3 = dr_timing1["s_second_from"].ToString();
            mon4 = dr_timing1["s_second_to"].ToString();

            if (mon1 != "00:00:00")
            {
                string[] dayss1 = mon1.Split(':');
                day_1 += dayss1[0] + ":";
                day_1 += dayss1[1] + "AM-";

                string[] dayss2 = mon2.Split(':');
                get_meridian(dayss2[0]);
                day_1 += dayss2[0] + " :";
                day_1 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (mon3 != "00:00:00")
            {

                string[] dayss3 = mon3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_1 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = mon4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_1 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }

            if (mon1 == "00:00:00" && mon3 == "00:00:00")
            {
                day_1 += "Holiday";
            }

        }

        foreach (DataRow dr_timing2 in dt_timing2.Rows)
        {
            tue1 = dr_timing2["s_first_from"].ToString();
            tue2 = dr_timing2["s_first_to"].ToString();
            tue3 = dr_timing2["s_second_from"].ToString();
            tue4 = dr_timing2["s_second_to"].ToString();

            if (tue1 != "00:00:00")
            {
                string[] dayss1 = tue1.Split(':');
                day_2 += dayss1[0] + ":";
                day_2 += dayss1[1] + "AM-";

                string[] dayss2 = tue2.Split(':');
                get_meridian(dayss2[0]);
                day_2 += dayss2[0] + " :";
                day_2 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (tue3 != "00:00:00")
            {
                string[] dayss3 = tue3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_2 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = tue4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_2 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }

            if (tue1 == "00:00:00" && tue3 == "00:00:00")
            {
                day_2 += "Holiday";
            }
        }

        foreach (DataRow dr_timing3 in dt_timing3.Rows)
        {
            wed1 = dr_timing3["s_first_from"].ToString();
            wed2 = dr_timing3["s_first_to"].ToString();
            wed3 = dr_timing3["s_second_from"].ToString();
            wed4 = dr_timing3["s_second_to"].ToString();

            if (wed1 != "00:00:00")
            {
                string[] dayss1 = wed1.Split(':');
                day_3 += dayss1[0] + ":";
                day_3 += dayss1[1] + "AM-";

                string[] dayss2 = wed2.Split(':');
                get_meridian(dayss2[0]);
                day_3 += dayss2[0] + " :";
                day_3 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (wed3 != "00:00:00")
            {
                string[] dayss3 = wed3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_3 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = wed4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_3 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }
            if (wed1 == "00:00:00" && wed3 == "00:00:00")
            {
                day_3 += "Holiday";
            }

        }

        foreach (DataRow dr_timing4 in dt_timing4.Rows)
        {
            thu1 = dr_timing4["s_first_from"].ToString();
            thu2 = dr_timing4["s_first_to"].ToString();
            thu3 = dr_timing4["s_second_from"].ToString();
            thu4 = dr_timing4["s_second_to"].ToString();

            if (thu1 != "00:00:00")
            {
                string[] dayss1 = thu1.Split(':');
                day_4 += dayss1[0] + ":";
                day_4 += dayss1[1] + "AM-";

                string[] dayss2 = thu2.Split(':');
                get_meridian(dayss2[0]);
                day_4 += dayss2[0] + " :";
                day_4 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (thu3 != "00:00:00")
            {
                string[] dayss3 = thu3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_4 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = thu4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_4 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }
            if (thu1 == "00:00:00" && thu3 == "00:00:00")
            {
                day_4 += "Holiday";
            }
        }

        foreach (DataRow dr_timing5 in dt_timing5.Rows)
        {
            fri1 = dr_timing5["s_first_from"].ToString();
            fri2 = dr_timing5["s_first_to"].ToString();
            fri3 = dr_timing5["s_second_from"].ToString();
            fri4 = dr_timing5["s_second_to"].ToString();

            if (fri1 != "00:00:00")
            {
                string[] dayss1 = fri1.Split(':');
                day_5 += dayss1[0] + ":";
                day_5 += dayss1[1] + "AM-";

                string[] dayss2 = fri2.Split(':');
                get_meridian(dayss2[0]);
                day_5 += dayss2[0] + " :";
                day_5 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (fri3 != "00:00:00")
            {
                string[] dayss3 = fri3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_5 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = fri4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_5 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }
            if (fri1 == "00:00:00" && fri3 == "00:00:00")
            {
                day_5 += "Holiday";
            }
        }

        foreach (DataRow dr_timing6 in dt_timing6.Rows)
        {
            sat1 = dr_timing6["s_first_from"].ToString();
            sat2 = dr_timing6["s_first_to"].ToString();
            sat3 = dr_timing6["s_second_from"].ToString();
            sat4 = dr_timing6["s_second_to"].ToString();

            if (sat1 != "00:00:00")
            {
                string[] dayss1 = sat1.Split(':');
                day_6 += dayss1[0] + ":";
                day_6 += dayss1[1] + "AM-";

                string[] dayss2 = sat2.Split(':');
                get_meridian(dayss2[0]);
                day_6 += dayss2[0] + " :";
                day_6 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (sat3 != "00:00:00")
            {
                string[] dayss3 = sat3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_6 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = sat4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_6 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }
            if (sat1 == "00:00:00" && sat3 == "00:00:00")
            {
                day_6 += "Holiday";
            }
        }

        foreach (DataRow dr_timing7 in dt_timing7.Rows)
        {
            sun1 = dr_timing7["s_first_from"].ToString();
            sun2 = dr_timing7["s_first_to"].ToString();
            sun3 = dr_timing7["s_second_from"].ToString();
            sun4 = dr_timing7["s_second_to"].ToString();

            if (sun1 != "00:00:00")
            {
                string[] dayss1 = sun1.Split(':');
                day_7 += dayss1[0] + ":";
                day_7 += dayss1[1] + "AM-";

                string[] dayss2 = sun2.Split(':');
                get_meridian(dayss2[0]);
                day_7 += dayss2[0] + " :";
                day_7 += dayss2[1] + "" + set_m + " &nbsp;To&nbsp; ";
            }
            if (sun3 != "00:00:00")
            {
                string[] dayss3 = sun3.Split(':');
                if (Convert.ToInt32(dayss3[0]) > 12)
                {
                    day_7 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                }

                string[] dayss4 = sun4.Split(':');
                if (Convert.ToInt32(dayss4[0]) > 12)
                {
                    day_7 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                }
            }
            if (sun1 == "00:00:00" && sun3 == "00:00:00")
            {
                day_7 += "Holiday";
            }

            clinic_day += "<h3>Timing</h3><br/><table>";


            if (day_1 != "Holiday")
                clinic_day += "<tr><td width='30%'><b>Monday </b></td><td>" + day_1+"</td></tr>";
            if (day_2 != "Holiday")
                clinic_day += "<tr><td><b>Tuesday </b></td><td>" + day_2 + "</td></tr>";
            if (day_3 != "Holiday")
                clinic_day += "<tr><td><b>Wednesday </b></td><td>" + day_3 + "</td></tr>";
            if (day_4 != "Holiday")
                clinic_day += "<tr><td><b>Thursday </b></td><td>" + day_4 + "</td></tr>";
            if (day_5 != "Holiday")
                clinic_day += "<tr><td><b>Friday </b></td><td>" + day_5 + "</td></tr>";
            if (day_6 != "Holiday")
                clinic_day += "<tr><td><b>Saturday </b></td><td>" + day_6 + "</td></tr>";
            if (day_7 != "Holiday")
                clinic_day += "<tr><td><b>Sunday </b></td><td>" + day_7 + "</td></tr>";
            clinic_day += "</table><hr/>";
            divtiming.InnerHtml = clinic_day;
        }
     }
}