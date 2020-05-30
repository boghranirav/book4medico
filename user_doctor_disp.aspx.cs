using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;   
using System.Linq;   
using System.Threading;
using System.Collections;

public partial class user_doctor_disp : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();

    connectionclass con3 = new connectionclass();
    connectionclass con4 = new connectionclass();
    connectionclass con5 = new connectionclass();
    connectionclass con6 = new connectionclass();
    connectionclass con7 = new connectionclass();
    connectionclass con_clinic_photo = new connectionclass();
    connectionclass con_services = new connectionclass();
    connectionclass con_address = new connectionclass();
    connectionclass con_timing1 = new connectionclass();
    connectionclass con_timing2= new connectionclass();
    connectionclass con_timing3 = new connectionclass();
    connectionclass con_timing4 = new connectionclass();
    connectionclass con_timing5 = new connectionclass();
    connectionclass con_timing6 = new connectionclass();
    connectionclass con_timing7 = new connectionclass();


    connectionclass con_degree = new connectionclass();
    connectionclass con_clinic_info = new connectionclass();
    connectionclass con_clinic_area = new connectionclass();


    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();

    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable dt7 = new DataTable();
    DataTable dt_clinic_photo = new DataTable();
    DataTable dt_services = new DataTable();
    DataTable dt_address = new DataTable();
    DataTable dt_timing1 = new DataTable();
    DataTable dt_timing2 = new DataTable();
    DataTable dt_timing3 = new DataTable();
    DataTable dt_timing4 = new DataTable();
    DataTable dt_timing5 = new DataTable();
    DataTable dt_timing6 = new DataTable();
    DataTable dt_timing7 = new DataTable();


    DataTable dt_degree = new DataTable();
    DataTable dt_clinic_info = new DataTable();
    DataTable dt_clinic_area = new DataTable();


    string str_city = "";
    int i = 0;
    string html_display_doc="";

    string min_p = "";
    string max_p = "";

    string mon1 = "", mon2 = "", mon3 = "", mon4 = "";
    string tue1 = "", tue2 = "", tue3 = "", tue4 = "";
    string wed1 = "", wed2 = "", wed3 = "",wed4 = "";
    string thu1 = "", thu2 = "", thu3 = "", thu4 = "";
    string fri1 = "", fri2 = "", fri3 = "", fri4 = "";
    string sat1 = "", sat2 = "", sat3 = "", sat4 = "";
    string sun1 = "", sun2 = "", sun3 = "", sun4 = "";
    string day_1 = "", day_2 = "", day_3 = "", day_4 = "", day_5 = "", day_6 = "",day_7="";
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

    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        test.Text = "";
        foreach (Control control in select_catagory.Controls)
        {
            if (control is CheckBox)
            {
                if (((CheckBox)(control)).Checked)
                {
                    //test.InnerHtml += ((CheckBox)(control)).ID;
                    
                    test.Text += ((CheckBox)(control)).ID + ",";
                    //test.InnerHtml += ((CheckBox)(control)).Text;
                }
            }
        }
        test.Text += "0";
        display_panel();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = test_slider.Value;
        string[] words = s.Split('-');
        Label1.Text = words[0] + "," + words[1];

        display_panel();
    }

    public void slider_value(){
        
        if (Label1.Text == "")
        {
            min_p = 50 + "";
            max_p = 350 + "";
            slider_div.Attributes.Add("data-default-min", min_p);
            slider_div.Attributes.Add(" data-default-max", max_p);
            Label1.Text=50+","+350;
        }
        else
            if (Label1.Text != "")
            {
                string s = test_slider.Value;

                string[] words = s.Split('-');
                min_p = words[0];
                max_p = words[1];
                slider_div.Attributes.Add("data-default-min", min_p);
                slider_div.Attributes.Add(" data-default-max", max_p);

            }
    }

    public void display_panel()
    {
        if (Request.QueryString.Count != 0)
        {
            if (Request.QueryString["srnm"].ToString() != "")
            {
                string qry_string = Request.QueryString["srnm"].ToString();

                // test.Text = city;

                if (test.Text == "" || test.Text == "0")
                {
                    dt3.Clear();
                    dt3 = con3.GetData("select * from doctor_clinic dc,Doctor_registration dr where dr.doc_id=dc.doc_id and dr.d_status='U' and dc.fees between " + min_p + " and " + max_p + " and dc.clinic_name='" + qry_string + "'");
                    
                }
                else
                {
                    dt3.Clear();
                    dt3 = con3.GetData("select * from doctor_clinic dc,Doctor_registration dr where dr.doc_id=dc.doc_id and dr.d_status='U' and dc.fees between " + min_p + " and " + max_p + " and dc.area_id in (" + test.Text + ") and dc.clinic_name='" + qry_string + "'");
                    
                }
                foreach (DataRow dr3 in dt3.Rows)
                {
                    dt6.Clear();
                    dt6 = con6.GetData("select DISTINCT dc.doc_id,dbi.profile_picture,dbi.first_name,dbi.last_name,dc.clinic_name,dc.dclinic_id from Doctor_basic_info dbi,Doctor_clinic dc where dc.doc_id=dbi.doc_id and dclinic_id='" + dr3["dclinic_id"].ToString() + "'");

                    foreach (DataRow dr6 in dt6.Rows)
                    {
                        dt7.Clear();
                        string doc_specialization = "";
                        dt7 = con7.GetData("select * from Doctor_specialization ds,Specializations_info si where ds.sep_id=spe_id and ds.doc_id='" + dr6["doc_id"] + "'");
                        int count1 = dt7.Rows.Count;
                        foreach (DataRow dr7 in dt7.Rows)
                        {
                            count1--;
                            if (count1 != 0)
                                doc_specialization += dr7["spe_name"] + ", ";
                            else
                                doc_specialization += dr7["spe_name"];
                        }
                        dt_clinic_photo.Clear();
                        string doc_clinic_p = "";
                        dt_clinic_photo = con_clinic_photo.GetData("select * from Clinic_photos where dclinic_id='" + dr3["dclinic_id"] + "'");

                        doc_clinic_p += "<div id='gallery' class='gallery'>";
                        doc_clinic_p += "<div class='image gallery-group-1'>";
                        doc_clinic_p += "<div class='image-inner'>";
                        foreach (DataRow dr_clinic_photo in dt_clinic_photo.Rows)
                        {
                            doc_clinic_p += "<a href='Doctor/Clinic_Photos/" + dr_clinic_photo["src_name"] + "' data-lightbox='gallery-group-1'>";
                            doc_clinic_p += "<img src='Doctor/Clinic_Photos/" + dr_clinic_photo["src_name"] + "' alt='' width='50' height='50'/>";
                            doc_clinic_p += "</a>&nbsp;";
                        }
                        doc_clinic_p += "</div>";
                        doc_clinic_p += "</div>";
                        doc_clinic_p += "</div>";

                        dt_services.Clear();
                        dt_services = con_services.GetData("select * from services s,Doctor_services ds where s.service_id=ds.service_id and ds.doc_id='" + dr6["doc_id"] + "'");
                        string doc_services = "";
                        int counti2 = dt_services.Rows.Count;
                        foreach (DataRow dr_service in dt_services.Rows)
                        {
                            counti2--;
                            if (counti2 != 0)
                                doc_services += dr_service["service_name"].ToString() + ", ";
                            else
                                doc_services += dr_service["service_name"].ToString();
                        }

                        dt_address.Clear();
                        dt_address = con_address.GetData("select * from Doctor_clinic dc,Area_info ai where ai.area_id=dc.area_id and dc.dclinic_id='" + dr3["dclinic_id"] + "'");
                        string doc_c_address = "";
                        string doc_fees = "";
                        string doc_phone = "";
                        string doc_email = "";
                        foreach (DataRow dr_address in dt_address.Rows)
                        {
                            doc_c_address += dr_address["address"].ToString();
                            doc_c_address += ", " + dr_address["area_name"].ToString();
                            doc_fees = dr_address["fees"].ToString();
                            doc_phone = dr_address["phone_no"].ToString();
                            doc_email = dr_address["email_id"].ToString();
                        }

                        //dt_timing1 = con_timing1.GetData("select * from Doctor_schedule where s_day_name='Monday' and dclinic_id='" + dr3["dclinic_id"] + "'");
                        //dt_timing2 = con_timing2.GetData("select * from Doctor_schedule where s_day_name='Tuesday' and dclinic_id='" + dr3["dclinic_id"] + "'");
                        //dt_timing3 = con_timing3.GetData("select * from Doctor_schedule where s_day_name='Wednesday' and dclinic_id='" + dr3["dclinic_id"] + "'");
                        //dt_timing4 = con_timing4.GetData("select * from Doctor_schedule where s_day_name='Thursday' and dclinic_id='" + dr3["dclinic_id"] + "'");
                        //dt_timing5 = con_timing5.GetData("select * from Doctor_schedule where s_day_name='Friday' and dclinic_id='" + dr3["dclinic_id"] + "'");
                        //dt_timing6 = con_timing6.GetData("select * from Doctor_schedule where s_day_name='Saturday' and dclinic_id='" + dr3["dclinic_id"] + "'");
                        //dt_timing7 = con_timing7.GetData("select * from Doctor_schedule where s_day_name='Sunday' and dclinic_id='" + dr3["dclinic_id"] + "'");

                        //foreach (DataRow dr_timing1 in dt_timing1.Rows)
                        //{
                        //    mon1 = dr_timing1["s_first_from"].ToString();
                        //    mon2 = dr_timing1["s_first_to"].ToString();
                        //    mon3 = dr_timing1["s_second_from"].ToString();
                        //    mon4 = dr_timing1["s_second_to"].ToString();

                        //    if (mon1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = mon1.Split(':');
                        //        day_1 += dayss1[0] + ":";
                        //        day_1 += dayss1[1] + "AM-";

                        //        string[] dayss2 = mon2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_1 += dayss2[0] + " :";
                        //        day_1 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (mon3 != "00:00:00")
                        //    {

                        //        string[] dayss3 = mon3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_1 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = mon4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_1 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }

                        //    if (mon1 == "00:00:00" && mon3 == "00:00:00")
                        //    {
                        //        day_1 += "Holiday";
                        //    }

                        //}

                        //foreach (DataRow dr_timing2 in dt_timing2.Rows)
                        //{
                        //    tue1 = dr_timing2["s_first_from"].ToString();
                        //    tue2 = dr_timing2["s_first_to"].ToString();
                        //    tue3 = dr_timing2["s_second_from"].ToString();
                        //    tue4 = dr_timing2["s_second_to"].ToString();

                        //    if (tue1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = tue1.Split(':');
                        //        day_2 += dayss1[0] + ":";
                        //        day_2 += dayss1[1] + "AM-";

                        //        string[] dayss2 = tue2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_2 += dayss2[0] + " :";
                        //        day_2 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (tue3 != "00:00:00")
                        //    {
                        //        string[] dayss3 = tue3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_2 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = mon4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_2 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }

                        //    if (tue1 == "00:00:00" && tue3 == "00:00:00")
                        //    {
                        //        day_2 += "Holiday";
                        //    }
                        //}

                        //foreach (DataRow dr_timing3 in dt_timing3.Rows)
                        //{
                        //    wed1 = dr_timing3["s_first_from"].ToString();
                        //    wed2 = dr_timing3["s_first_to"].ToString();
                        //    wed3 = dr_timing3["s_second_from"].ToString();
                        //    wed4 = dr_timing3["s_second_to"].ToString();

                        //    if (wed1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = wed1.Split(':');
                        //        day_3 += dayss1[0] + ":";
                        //        day_3 += dayss1[1] + "AM-";

                        //        string[] dayss2 = wed2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_3 += dayss2[0] + " :";
                        //        day_3 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (wed3 != "00:00:00")
                        //    {
                        //        string[] dayss3 = wed3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_3 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = mon4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_3 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }
                        //    if (wed1 == "00:00:00" && wed3 == "00:00:00")
                        //    {
                        //        day_3 += "Holiday";
                        //    }

                        //}

                        //foreach (DataRow dr_timing4 in dt_timing4.Rows)
                        //{
                        //    thu1 = dr_timing4["s_first_from"].ToString();
                        //    thu2 = dr_timing4["s_first_to"].ToString();
                        //    thu3 = dr_timing4["s_second_from"].ToString();
                        //    thu4 = dr_timing4["s_second_to"].ToString();

                        //    if (thu1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = thu1.Split(':');
                        //        day_4 += dayss1[0] + ":";
                        //        day_4 += dayss1[1] + "AM-";

                        //        string[] dayss2 = thu2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_4 += dayss2[0] + " :";
                        //        day_4 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (thu3 != "00:00:00")
                        //    {
                        //        string[] dayss3 = thu3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_4 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = thu4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_4 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }
                        //    if (thu1 == "00:00:00" && thu3 == "00:00:00")
                        //    {
                        //        day_4 += "Holiday";
                        //    }
                        //}

                        //foreach (DataRow dr_timing5 in dt_timing5.Rows)
                        //{
                        //    fri1 = dr_timing5["s_first_from"].ToString();
                        //    fri2 = dr_timing5["s_first_to"].ToString();
                        //    fri3 = dr_timing5["s_second_from"].ToString();
                        //    fri4 = dr_timing5["s_second_to"].ToString();

                        //    if (fri1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = fri1.Split(':');
                        //        day_5 += dayss1[0] + ":";
                        //        day_5 += dayss1[1] + "AM-";

                        //        string[] dayss2 = fri2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_5 += dayss2[0] + " :";
                        //        day_5 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (fri3 != "00:00:00")
                        //    {
                        //        string[] dayss3 = fri3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_5 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = fri4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_5 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }
                        //    if (fri1 == "00:00:00" && fri3 == "00:00:00")
                        //    {
                        //        day_5 += "Holiday";
                        //    }
                        //}

                        //foreach (DataRow dr_timing6 in dt_timing6.Rows)
                        //{
                        //    sat1 = dr_timing6["s_first_from"].ToString();
                        //    sat2 = dr_timing6["s_first_to"].ToString();
                        //    sat3 = dr_timing6["s_second_from"].ToString();
                        //    sat4 = dr_timing6["s_second_to"].ToString();

                        //    if (sat1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = sat1.Split(':');
                        //        day_6 += dayss1[0] + ":";
                        //        day_6 += dayss1[1] + "AM-";

                        //        string[] dayss2 = sat2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_6 += dayss2[0] + " :";
                        //        day_6 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (sat3 != "00:00:00")
                        //    {
                        //        string[] dayss3 = sat3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_6 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = sat4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_6 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }
                        //    if (sat1 == "00:00:00" && sat3 == "00:00:00")
                        //    {
                        //        day_6 += "Holiday";
                        //    }
                        //}

                        //foreach (DataRow dr_timing7 in dt_timing7.Rows)
                        //{
                        //    sun1 = dr_timing7["s_first_from"].ToString();
                        //    sun2 = dr_timing7["s_first_to"].ToString();
                        //    sun3 = dr_timing7["s_second_from"].ToString();
                        //    sun4 = dr_timing7["s_second_to"].ToString();

                        //    if (sun1 != "00:00:00")
                        //    {
                        //        string[] dayss1 = sun1.Split(':');
                        //        day_7 += dayss1[0] + ":";
                        //        day_7 += dayss1[1] + "AM-";

                        //        string[] dayss2 = sun2.Split(':');
                        //        get_meridian(dayss2[0]);
                        //        day_7 += dayss2[0] + " :";
                        //        day_7 += dayss2[1] + "" + set_m + ",";
                        //    }
                        //    if (sun3 != "00:00:00")
                        //    {
                        //        string[] dayss3 = sun3.Split(':');
                        //        if (Convert.ToInt32(dayss3[0]) > 12)
                        //        {
                        //            day_7 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                        //        }

                        //        string[] dayss4 = sun4.Split(':');
                        //        if (Convert.ToInt32(dayss4[0]) > 12)
                        //        {
                        //            day_7 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                        //        }
                        //    }
                        //    if (sun1 == "00:00:00" && sun3 == "00:00:00")
                        //    {
                        //        day_7 += "Holiday";
                        //    }
                        //}


                      
                        html_display_doc += "<div class='product-list_item row'>";
                        html_display_doc += "<div class='product-list_item_img col-lg-3 col-md-3 col-sm-3 col-xs-12 clearfix'>";
                        html_display_doc += "<a href='clinic_detail.aspx?cid=" + dr3["dclinic_id"] + "'>";
                        html_display_doc += "<img src='Doctor/profile_pictures/" + dr6["profile_picture"] + "' class='product-list_item_img' alt='Dr. Profile Picture' title='Dr. " + dr6["first_name"] + " " + dr6["last_name"] + "&#39s" + " Profile Picture.' height='150' width='130'>";
                        html_display_doc += "</a></div>";
                        html_display_doc += "<div class='col-lg-5 col-md-5 col-sm-5 col-xs-12 clearfix'>";
                        html_display_doc += "<div class='product-list-info'>";
                        html_display_doc += "<div class='product-list_item_title'>";
                        html_display_doc += "<a href='clinic_detail.aspx?cid=" + dr3["dclinic_id"] + "'>";
                        html_display_doc += "<h3 class='font-additional font-weight-bold text-uppercase' title='Name Of Clinic.'>";
                        html_display_doc += dr6["clinic_name"] + "&nbsp;</h3></a>";
                        html_display_doc += "</div>";
                        html_display_doc += "<div class='product-item_price font-additional font-weight-normal' title='Specializations'>" + doc_specialization;
                        html_display_doc += "</div>";
                        html_display_doc += "<div class='product-item_price font-additional font-weight-normal'>";

                        html_display_doc += doc_clinic_p;

                        html_display_doc += "<br /></div>";

                        html_display_doc += "<div class='font-main font-weight-normal color-third' title='Service'>" + doc_services + "</div>";
                        html_display_doc += "</div></div>";
                        html_display_doc += "<div class='col-lg-4 col-md-4 col-sm-4 col-xs-12 clearfix'>";
                        html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                        html_display_doc += doc_c_address + "</div>";
                        html_display_doc += "<div class='font-additional font-weight-normal customColor'>";
                        html_display_doc += "Fees : Rs. ";
                        html_display_doc += doc_fees;
                        html_display_doc += "</div><br />";
                        //html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                        //html_display_doc += "<span class='icon-clock'></span>";
                        //html_display_doc += "Time" + clinic_day;
                        //html_display_doc += "</div>";
                        html_display_doc += "<div class='font-additional font-weight-normal'>";
                        html_display_doc += "Contact Info   <br>";
                        html_display_doc += "Phone No : " + doc_phone + "<br>Email Id :" + doc_email;
                        html_display_doc += "</div><br />";
                        html_display_doc += "</div></div>";
                    }
                }


                if (test.Text == "" || test.Text == "0")
                {
                    dt4.Clear();
                    dt4 = con4.GetData("select * from Doctor_basic_info dbi,Doctor_clinic dc,Doctor_registration dr where dbi.doc_id=dr.doc_id and dr.doc_id=dc.doc_id and dr.d_status='U' and dc.fees between " + min_p + " and " + max_p + " and dc.doc_id=dbi.doc_id and dbi.first_name='" + qry_string + "'");
                }
                else
                {
                    dt4.Clear();
                    dt4 = con4.GetData("select * from Doctor_basic_info dbi,Doctor_clinic dc,Doctor_registration dr where dbi.doc_id=dr.doc_id and dr.doc_id=dc.doc_id and dr.d_status='U' and dc.area_id in (" + test.Text + ") and dc.fees between " + min_p + " and " + max_p + " and dc.doc_id=dbi.doc_id and dbi.first_name='" + qry_string + "'");
                    
                }
                
                foreach (DataRow dr4 in dt4.Rows)
                {
                    //dt_timing1 = con_timing1.GetData("select * from Doctor_schedule where s_day_name='Monday' and dclinic_id='" + dr4["dclinic_id"] + "'");
                    //dt_timing2 = con_timing2.GetData("select * from Doctor_schedule where s_day_name='Tuesday' and dclinic_id='" + dr4["dclinic_id"] + "'");
                    //dt_timing3 = con_timing3.GetData("select * from Doctor_schedule where s_day_name='Wednesday' and dclinic_id='" + dr4["dclinic_id"] + "'");
                    //dt_timing4 = con_timing4.GetData("select * from Doctor_schedule where s_day_name='Thursday' and dclinic_id='" + dr4["dclinic_id"] + "'");
                    //dt_timing5 = con_timing5.GetData("select * from Doctor_schedule where s_day_name='Friday' and dclinic_id='" + dr4["dclinic_id"] + "'");
                    //dt_timing6 = con_timing6.GetData("select * from Doctor_schedule where s_day_name='Saturday' and dclinic_id='" + dr4["dclinic_id"] + "'");
                    //dt_timing7 = con_timing7.GetData("select * from Doctor_schedule where s_day_name='Sunday' and dclinic_id='" + dr4["dclinic_id"] + "'");

                    //foreach (DataRow dr_timing1 in dt_timing1.Rows)
                    //{
                    //    mon1 = dr_timing1["s_first_from"].ToString();
                    //    mon2 = dr_timing1["s_first_to"].ToString();
                    //    mon3 = dr_timing1["s_second_from"].ToString();
                    //    mon4 = dr_timing1["s_second_to"].ToString();

                    //    if (mon1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = mon1.Split(':');
                    //        day_1 += dayss1[0] + ":";
                    //        day_1 += dayss1[1] + "AM-";

                    //        string[] dayss2 = mon2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_1 += dayss2[0] + " :";
                    //        day_1 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (mon3 != "00:00:00")
                    //    {

                    //        string[] dayss3 = mon3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_1 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = mon4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_1 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }

                    //    if (mon1 == "00:00:00" && mon3 == "00:00:00")
                    //    {
                    //        day_1 += "Holiday";
                    //    }

                    //}

                    //foreach (DataRow dr_timing2 in dt_timing2.Rows)
                    //{
                    //    tue1 = dr_timing2["s_first_from"].ToString();
                    //    tue2 = dr_timing2["s_first_to"].ToString();
                    //    tue3 = dr_timing2["s_second_from"].ToString();
                    //    tue4 = dr_timing2["s_second_to"].ToString();

                    //    if (tue1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = tue1.Split(':');
                    //        day_2 += dayss1[0] + ":";
                    //        day_2 += dayss1[1] + "AM-";

                    //        string[] dayss2 = tue2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_2 += dayss2[0] + " :";
                    //        day_2 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (tue3 != "00:00:00")
                    //    {
                    //        string[] dayss3 = tue3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_2 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = mon4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_2 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }

                    //    if (tue1 == "00:00:00" && tue3 == "00:00:00")
                    //    {
                    //        day_2 += "Holiday";
                    //    }
                    //}

                    //foreach (DataRow dr_timing3 in dt_timing3.Rows)
                    //{
                    //    wed1 = dr_timing3["s_first_from"].ToString();
                    //    wed2 = dr_timing3["s_first_to"].ToString();
                    //    wed3 = dr_timing3["s_second_from"].ToString();
                    //    wed4 = dr_timing3["s_second_to"].ToString();

                    //    if (wed1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = wed1.Split(':');
                    //        day_3 += dayss1[0] + ":";
                    //        day_3 += dayss1[1] + "AM-";

                    //        string[] dayss2 = wed2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_3 += dayss2[0] + " :";
                    //        day_3 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (wed3 != "00:00:00")
                    //    {
                    //        string[] dayss3 = wed3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_3 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = mon4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_3 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }
                    //    if (wed1 == "00:00:00" && wed3 == "00:00:00")
                    //    {
                    //        day_3 += "Holiday";
                    //    }

                    //}

                    //foreach (DataRow dr_timing4 in dt_timing4.Rows)
                    //{
                    //    thu1 = dr_timing4["s_first_from"].ToString();
                    //    thu2 = dr_timing4["s_first_to"].ToString();
                    //    thu3 = dr_timing4["s_second_from"].ToString();
                    //    thu4 = dr_timing4["s_second_to"].ToString();

                    //    if (thu1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = thu1.Split(':');
                    //        day_4 += dayss1[0] + ":";
                    //        day_4 += dayss1[1] + "AM-";

                    //        string[] dayss2 = thu2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_4 += dayss2[0] + " :";
                    //        day_4 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (thu3 != "00:00:00")
                    //    {
                    //        string[] dayss3 = thu3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_4 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = thu4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_4 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }
                    //    if (thu1 == "00:00:00" && thu3 == "00:00:00")
                    //    {
                    //        day_4 += "Holiday";
                    //    }
                    //}

                    //foreach (DataRow dr_timing5 in dt_timing5.Rows)
                    //{
                    //    fri1 = dr_timing5["s_first_from"].ToString();
                    //    fri2 = dr_timing5["s_first_to"].ToString();
                    //    fri3 = dr_timing5["s_second_from"].ToString();
                    //    fri4 = dr_timing5["s_second_to"].ToString();

                    //    if (fri1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = fri1.Split(':');
                    //        day_5 += dayss1[0] + ":";
                    //        day_5 += dayss1[1] + "AM-";

                    //        string[] dayss2 = fri2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_5 += dayss2[0] + " :";
                    //        day_5 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (fri3 != "00:00:00")
                    //    {
                    //        string[] dayss3 = fri3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_5 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = fri4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_5 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }
                    //    if (fri1 == "00:00:00" && fri3 == "00:00:00")
                    //    {
                    //        day_5 += "Holiday";
                    //    }
                    //}

                    //foreach (DataRow dr_timing6 in dt_timing6.Rows)
                    //{
                    //    sat1 = dr_timing6["s_first_from"].ToString();
                    //    sat2 = dr_timing6["s_first_to"].ToString();
                    //    sat3 = dr_timing6["s_second_from"].ToString();
                    //    sat4 = dr_timing6["s_second_to"].ToString();

                    //    if (sat1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = sat1.Split(':');
                    //        day_6 += dayss1[0] + ":";
                    //        day_6 += dayss1[1] + "AM-";

                    //        string[] dayss2 = sat2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_6 += dayss2[0] + " :";
                    //        day_6 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (sat3 != "00:00:00")
                    //    {
                    //        string[] dayss3 = sat3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_6 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = sat4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_6 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }
                    //    if (sat1 == "00:00:00" && sat3 == "00:00:00")
                    //    {
                    //        day_6 += "Holiday";
                    //    }
                    //}

                    //foreach (DataRow dr_timing7 in dt_timing7.Rows)
                    //{
                    //    sun1 = dr_timing7["s_first_from"].ToString();
                    //    sun2 = dr_timing7["s_first_to"].ToString();
                    //    sun3 = dr_timing7["s_second_from"].ToString();
                    //    sun4 = dr_timing7["s_second_to"].ToString();

                    //    if (sun1 != "00:00:00")
                    //    {
                    //        string[] dayss1 = sun1.Split(':');
                    //        day_7 += dayss1[0] + ":";
                    //        day_7 += dayss1[1] + "AM-";

                    //        string[] dayss2 = sun2.Split(':');
                    //        get_meridian(dayss2[0]);
                    //        day_7 += dayss2[0] + " :";
                    //        day_7 += dayss2[1] + "" + set_m + ",";
                    //    }
                    //    if (sun3 != "00:00:00")
                    //    {
                    //        string[] dayss3 = sun3.Split(':');
                    //        if (Convert.ToInt32(dayss3[0]) > 12)
                    //        {
                    //            day_7 += (Convert.ToInt32(dayss3[0]) - 12) + ":" + dayss3[1] + "PM-";
                    //        }

                    //        string[] dayss4 = sun4.Split(':');
                    //        if (Convert.ToInt32(dayss4[0]) > 12)
                    //        {
                    //            day_7 += (Convert.ToInt32(dayss4[0]) - 12) + ":" + dayss4[1] + "PM";
                    //        }
                    //    }
                    //    if (sun1 == "00:00:00" && sun3 == "00:00:00")
                    //    {
                    //        day_7 += "Holiday";
                    //    }
                    //}



                    //if (day_1 == day_2)
                    //{
                    //    if (day_2 == day_3)
                    //    {
                    //        if (day_3 == day_4)
                    //        {
                    //            if (day_4 == day_5)
                    //            {
                    //                if (day_5 == day_6)
                    //                {
                    //                    if (day_6 == day_7)
                    //                    {
                    //                        clinic_day += "<br>Mon-Sun : <br>" + day_1;
                    //                    }
                    //                    else
                    //                    {
                    //                        clinic_day += "<br>Mon-Sat : <br>" + day_1;
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    clinic_day += "<br>Mon-Fri : <br>" + day_1;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                clinic_day += "<br>Mon-Thu : <br>" + day_1;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            clinic_day += "<br>Mon-Wed : <br>" + day_1;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        clinic_day += "<br>Mon-Tue : <br>" + day_1;

                    //    }
                    //}
                    //else
                    //{
                    //    if (day_1 != "Holiday")
                    //        clinic_day += "<br>Mon :" + day_1;
                    //    if (day_2 != "Holiday")
                    //        clinic_day += "<br>Tue &nbsp;:" + day_2;
                    //    if (day_3 != "Holiday")
                    //        clinic_day += "<br>Wed:" + day_3;
                    //    if (day_4 != "Holiday")
                    //        clinic_day += "<br>Thu&nbsp;:" + day_4;
                    //    if (day_5 != "Holiday")
                    //        clinic_day += "<br>Fri &nbsp; :" + day_5;
                    //    if (day_6 != "Holiday")
                    //        clinic_day += "<br>Sat &nbsp;:" + day_6;
                    //    if (day_7 != "Holiday")
                    //        clinic_day += "<br>Sun &nbsp;:" + day_7;
                    //}

                    dt7.Clear();
                    string doc_specialization1 = "";
                    dt7 = con7.GetData("select * from Doctor_specialization ds,Specializations_info si where ds.sep_id=spe_id and ds.doc_id='" + dr4["doc_id"] + "'");
                    int count3 = dt7.Rows.Count;
                    foreach (DataRow dr7 in dt7.Rows)
                    {
                        count3--;
                        if (count3 != 0)
                            doc_specialization1 += dr7["spe_name"] + ", ";
                        else
                            doc_specialization1 += dr7["spe_name"];
                    }

                    dt_degree.Clear();
                    dt_degree = con_degree.GetData("select * from Degree_info di,Doctor_education de where di.degree_id=de.degree_id and de.doc_id='" + dr4["doc_id"] + "'");
                    string doc_degrees = "";
                    int count4 = dt_degree.Rows.Count;
                    foreach (DataRow dr_degree in dt_degree.Rows)
                    {
                        count4--;
                        if (count4 != 0)
                            doc_degrees += dr_degree["degree_name"] + ", ";
                        else
                            doc_degrees += dr_degree["degree_name"];

                    }

                    dt_clinic_info.Clear();
                    dt_clinic_info = con_clinic_info.GetData("select * from doctor_clinic dc,area_info ai,city_info ci where ai.area_id=dc.area_id and ci.city_id=dc.city_id and dc.doc_id='" + dr4["doc_id"] + "'");
                    string clinic_names = "";
                    int count5 = dt_clinic_info.Rows.Count;
                    string fees = "";
                    string address = "";
                    foreach (DataRow dr_clinic_info in dt_clinic_info.Rows)
                    {
                        count5--;
                        if (count5 != 0)
                            clinic_names += dr_clinic_info["clinic_name"] + ", ";
                        else
                            clinic_names += dr_clinic_info["clinic_name"];

                        fees = dr_clinic_info["fees"] + "";

                    }

                    //dt_services.Clear();
                    //dt_services = con_services.GetData("select * from services s,Doctor_services ds where s.service_id=ds.service_id and ds.doc_id='" + dr4["doc_id"] + "'");
                    //string doc_services = "";
                    //int counti2 = dt_services.Rows.Count;
                    //foreach (DataRow dr_service in dt_services.Rows)
                    //{
                    //    counti2--;
                    //    if (counti2 != 0)
                    //        doc_services += dr_service["service_name"].ToString() + ", ";
                    //    else
                    //        doc_services += dr_service["service_name"].ToString();
                    //}


                    dt_clinic_area.Clear();
                    dt_clinic_area = con_clinic_area.GetData("select * from Area_info ai, City_info ci where ai.city_id=ci.city_id and ai.area_id='" + dr4["area_id"] + "'");
                    foreach (DataRow dr_clinic_address in dt_clinic_area.Rows)
                    {
                        address = dr_clinic_address["area_name"] + "," + dr_clinic_address["city_name"];
                    }

                    html_display_doc += "<div class='product-list_item row'>";
                    html_display_doc += "<div class='product-list_item_img col-lg-3 col-md-3 col-sm-3 col-xs-12 clearfix'>";
                    html_display_doc += "<img src='Doctor/profile_pictures/" + dr4["profile_picture"] + "' class='product-list_item_img' AlternateText='Dr. Profile Picture'  height='150' width='130'>";
                    html_display_doc += "</div>";
                    html_display_doc += "<div class='col-lg-5 col-md-5 col-sm-5 col-xs-12 clearfix'>";
                    html_display_doc += "<div class='product-list-info'>";
                    html_display_doc += "<div class='product-list_item_title'>";
                    html_display_doc += "<h3 class='font-additional font-weight-bold text-uppercase'>";
                    html_display_doc += "Dr. " + dr4["first_name"] + " " + dr4["last_name"] + "</h3>";
                    html_display_doc += "</div>";
                    html_display_doc += "<div class='font-additional font-weight-normal' title='Specializations'>" + doc_degrees + "</div>";
                    html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                    html_display_doc += dr4["experience"] + " Years Experience</div>";
                    html_display_doc += "<div class='font-main font-weight-normal color-third' title='Specializations'>" + doc_specialization1 + "</div>";
                    html_display_doc += "<br><div class='font-main font-weight-normal color-third'>Clinic Name : " + clinic_names + "</div><br />";
                    //html_display_doc += "<div class='font-main font-weight-normal color-third' title='Services'>" + doc_services + "</div>";
                    html_display_doc += "</div></div>";
                    html_display_doc += "<div class='col-lg-4 col-md-4 col-sm-4 col-xs-12 clearfix'>";
                    html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                    html_display_doc += address + "</div><br />";
                    html_display_doc += "<div class='font-additional font-weight-normal customColor'>";
                    html_display_doc += "Fees : Rs. " + dr4["fees"];
                    html_display_doc += "</div><br />";
                    //html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                    //html_display_doc += "<span class='icon-clock'></span>";
                    //html_display_doc += clinic_day;
                    //html_display_doc += "</div><br />";
                    html_display_doc += "<a href='doctor_detail.aspx?did=" + dr4["doc_id"] + "' class='btn button-additional font-additional font-weight-normal text-uppercase hvr-rectangle-out hover-focus-bg before-bg'>";
                    html_display_doc += "Book Appointment";
                    html_display_doc += "</a></div></div>";
                }

                if (test.Text == "" || test.Text == "0")
                {
                    dt5.Clear();
                    dt5 = con5.GetData("select * from Doctor_specialization ds,Specializations_info si where si.spe_id=ds.sep_id and si.spe_name='" + qry_string + "'");
                }
                else
                {
                    dt5.Clear();
                    dt5 = con5.GetData("select * from Doctor_clinic dc,Doctor_specialization ds,Specializations_info si where dc.area_id in (" + test.Text + ") and dc.doc_id=ds.doc_id and si.spe_id=ds.sep_id and si.spe_name='" + qry_string + "'");

                }
                foreach (DataRow dr5 in dt5.Rows)
                {
                    dt4.Clear();
                    dt4 = con4.GetData("select * from Doctor_basic_info dbi,Doctor_registration dr where dr.doc_id=dbi.doc_id and dr.d_status='U' and dbi.doc_id=" + dr5["doc_id"]);
                    foreach (DataRow dr4 in dt4.Rows)
                    {
                        dt7.Clear();
                        string doc_specialization1 = "";
                        dt7 = con7.GetData("select * from Doctor_specialization ds,Specializations_info si where ds.sep_id=spe_id and ds.doc_id='" + dr4["doc_id"] + "'");
                        int count3 = dt7.Rows.Count;
                        foreach (DataRow dr7 in dt7.Rows)
                        {
                            count3--;
                            if (count3 != 0)
                                doc_specialization1 += dr7["spe_name"] + ", ";
                            else
                                doc_specialization1 += dr7["spe_name"];
                        }

                        dt_degree.Clear();
                        dt_degree = con_degree.GetData("select * from Degree_info di,Doctor_education de where di.degree_id=de.degree_id and de.doc_id='" + dr4["doc_id"] + "'");
                        string doc_degrees = "";
                        int count4 = dt_degree.Rows.Count;
                        foreach (DataRow dr_degree in dt_degree.Rows)
                        {
                            count4--;
                            if (count4 != 0)
                                doc_degrees += dr_degree["degree_name"] + ", ";
                            else
                                doc_degrees += dr_degree["degree_name"];

                        }

                        dt_clinic_info.Clear();
                        dt_clinic_info = con_clinic_info.GetData("select * from doctor_clinic dc,area_info ai,city_info ci where ai.area_id=dc.area_id and ci.city_id=dc.city_id and dc.doc_id='" + dr4["doc_id"] + "'");


                        string clinic_names = "";
                        int count5 = dt_clinic_info.Rows.Count;
                        string fees = "";
                        string address = "";
                        foreach (DataRow dr_clinic_info in dt_clinic_info.Rows)
                        {
                            count5--;
                            if (count5 != 0)
                                clinic_names += dr_clinic_info["clinic_name"] + ", ";
                            else
                                clinic_names += dr_clinic_info["clinic_name"];

                            fees = dr_clinic_info["fees"] + "";
                            address = dr_clinic_info["area_name"] + "," + dr_clinic_info["city_name"];
                        }

                        //dt_services.Clear();
                        //dt_services = con_services.GetData("select * from services s,Doctor_services ds where s.service_id=ds.service_id and ds.doc_id='" + dr4["doc_id"] + "'");
                        //string doc_services = "";
                        //int counti2 = dt_services.Rows.Count;
                        //foreach (DataRow dr_service in dt_services.Rows)
                        //{
                        //    counti2--;
                        //    if (counti2 != 0)
                        //        doc_services += dr_service["service_name"].ToString() + ", ";
                        //    else
                        //        doc_services += dr_service["service_name"].ToString();
                        //}

                        html_display_doc += "<div class='product-list_item row'>";
                        html_display_doc += "<div class='product-list_item_img col-lg-3 col-md-3 col-sm-3 col-xs-12 clearfix'>";
                        html_display_doc += "<img src='Doctor/profile_pictures/" + dr4["profile_picture"] + "' class='product-list_item_img' AlternateText='Dr. Profile Picture'  height='150' width='130'>";
                        html_display_doc += "</div>";
                        html_display_doc += "<div class='col-lg-5 col-md-5 col-sm-5 col-xs-12 clearfix'>";
                        html_display_doc += "<div class='product-list-info'>";
                        html_display_doc += "<div class='product-list_item_title'>";
                        html_display_doc += "<h3 class='font-additional font-weight-bold text-uppercase'>";
                        html_display_doc += "Dr. " + dr4["first_name"] + " " + dr4["last_name"] + "</h3>";
                        html_display_doc += "</div>";
                        html_display_doc += "<div class='font-main font-weight-normal' title='Degree Of Doctor'>" + doc_degrees + "</div>";
                        html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                        html_display_doc += dr4["experience"] + " Years Experience</div>";
                        html_display_doc += "<div class='font-additional font-weight-normal color-third' title='Specializations'>" + doc_specialization1 + "</div>";
                        html_display_doc += "<br><div class='font-main font-weight-normal color-third'>Clinic Name : " + clinic_names + "</div><br />";
                        //html_display_doc += "<div class='font-main font-weight-normal color-third' title='Services'>" + doc_services + "</div>";
                        html_display_doc += "</div></div>";
                        html_display_doc += "<div class='col-lg-4 col-md-4 col-sm-4 col-xs-12 clearfix'>";
                        html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                        html_display_doc += address + "</div><br />";
                        html_display_doc += "<div class='font-additional font-weight-normal customColor'>";
                        html_display_doc += "Fees : Rs. " + fees;
                        html_display_doc += "</div><br />";
                        //html_display_doc += "<div class='font-main font-weight-normal color-third'>";
                        //html_display_doc += "<span class='icon-clock'></span>";
                        //html_display_doc += clinic_day;
                        //html_display_doc += "</div><br />";
                        html_display_doc += "<a href='doctor_detail.aspx?did=" + dr5["doc_id"] + "' class='btn button-additional font-additional font-weight-normal text-uppercase hvr-rectangle-out hover-focus-bg before-bg'>";
                        html_display_doc += "Book Appointment";
                        html_display_doc += "</a></div></div>";
                    }
                }

            }

        }
        if(html_display_doc=="")
        {
            html_display_doc += "<h2>No Record Found.</h2>";
        }
        display_doctor_info.InnerHtml = html_display_doc;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = con1.GetData("select * from Area_info ai, City_info ci where ai.city_id=ci.city_id");

        slider_value();

        CheckBox[] cbl = new CheckBox[dt1.Rows.Count+2];
        foreach(DataRow dr1 in dt1.Rows)
        {
            i++;
            
            cbl[i]=new CheckBox();
            cbl[i].CssClass = "font-additional font-weight-normal hover-focus-color color-third text-uppercase";
            cbl[i].Text="&nbsp;"+dr1["area_name"].ToString();
            cbl[i].ID=dr1["area_id"].ToString();
            cbl[i].CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            cbl[i].AutoPostBack = true;
            select_catagory.Controls.Add(cbl[i]);
            select_catagory.Controls.Add(new LiteralControl("<br>"));
            
        }

        if (!IsPostBack)
        {
            display_panel();
        }
        
    }
    protected override void InitializeCulture()
    {
        CultureInfo ci = new CultureInfo("en-IN");
        ci.NumberFormat.CurrencySymbol = "₹";
        Thread.CurrentThread.CurrentCulture = ci;

        base.InitializeCulture();
    }
  
}
