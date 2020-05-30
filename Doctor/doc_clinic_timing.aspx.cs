using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Doctor_doc_clinic_timing : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con_sch = new connectionclass();
    connectionclass con3 = new connectionclass();
    connectionclass con4 = new connectionclass();
    connectionclass con5 = new connectionclass();

    
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();


    string set_null = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        dt2 = con_sch.GetData("select * from Doctor_schedule");
        string doc_session = Session["doctor_reg_id"].ToString();

        dt3 = con3.GetData("select * from Doctor_schedule");

        if (!IsPostBack)
        {
            set_data_null();

        }
        if (!IsPostBack)
        {
            dt1 = con1.GetData("select * from Doctor_clinic dc,Area_info ai where ai.area_id=dc.area_id and dc.doc_id="+Convert.ToInt64(doc_session));

            foreach (DataRow dr1 in dt1.Rows)
            {
                doc_clinic.Items.Add(new ListItem(dr1["clinic_name"].ToString()+" At "+dr1["area_name"].ToString(),dr1["dclinic_id"].ToString()));

                //if (dt1.Rows.Count == 1)
                //{
                //    doc_clinic.SelectedValue=dr1["dclinic_id"].ToString();
                    
                //}
            }
        }
    }

    

    public void set_data_null()
    {
        string first_half_1 = "09:00";
        string first_half_2 = "12:00";

        string second_half_1 = "15:00";
        string second_half_2 = "19:00";

        tb_minutes.Text = "";

        timepickermo1.Value = first_half_1;
        timepickertu1.Value = first_half_1;
        timepickerwe1.Value = first_half_1;
        timepickerthu1.Value = first_half_1;
        timepickerfri1.Value = first_half_1;
        timepickersat1.Value = first_half_1;
        timepickersun1.Value = first_half_1;

        timepickermo2.Value = first_half_2;
        timepickertu2.Value = first_half_2;
        timepickerwe2.Value = first_half_2;
        timepickerthu2.Value = first_half_2;
        timepickerfri2.Value = first_half_2;
        timepickersat2.Value = first_half_2;
        timepickersun2.Value = first_half_2;

        timepickermo3.Value = second_half_1;
        timepickertu3.Value = second_half_1;
        timepickerwe3.Value = second_half_1;
        timepickerthu3.Value = second_half_1;
        timepickerfri3.Value = second_half_1;
        timepickersat3.Value = second_half_1;
        timepickersun3.Value = second_half_1;

        timepickermo4.Value = second_half_2;
        timepickertu4.Value = second_half_2;
        timepickerwe4.Value = second_half_2;
        timepickerthu4.Value = second_half_2;
        timepickerfri4.Value = second_half_2;
        timepickersat4.Value = second_half_2;
        timepickersun4.Value = second_half_2;
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static ArrayList GetProductList(string prefixText, int count)
    {
        ArrayList al = new ArrayList();
        for (int i = 10; i <= 60; i=i+5)
        {
            
            al.Add(i);
        }

        return al;
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string clinic_id = doc_clinic.SelectedValue.ToString();
        string monday1="",monday2="",monday3="",monday4="";
        //TimeSpan spmon1 = TimeSpan.Parse(timepickermo1.Value);
        //DateTime dtmon1 = DateTime.MinValue.Add(spmon1);
        //string monday1 = dtmon1.ToShortTimeString();

        
         monday1 = timepickermo1.Value.ToString();
         monday2 = timepickermo2.Value.ToString();
         monday3 = timepickermo3.Value.ToString();
         monday4 = timepickermo4.Value.ToString();
        

        string tuesday1 = timepickertu1.Value.ToString();
        string tuesday2 = timepickertu2.Value.ToString();
        string tuesday3 = timepickertu3.Value.ToString();
        string tuesday4 = timepickertu4.Value.ToString();

        string wednesday1 = timepickerwe1.Value.ToString();
        string wednesday2 = timepickerwe2.Value.ToString();
        string wednesday3 = timepickerwe3.Value.ToString();
        string wednesday4 = timepickerwe4.Value.ToString();

        string thursday1 = timepickerthu1.Value.ToString();
        string thursday2 = timepickerthu2.Value.ToString();
        string thursday3 = timepickerthu3.Value.ToString();
        string thursday4 = timepickerthu4.Value.ToString();

        string friday1 = timepickerfri1.Value.ToString();
        string friday2 = timepickerfri2.Value.ToString();
        string friday3 = timepickerfri3.Value.ToString();
        string friday4 = timepickerfri4.Value.ToString();

        string saturday1 = timepickersat1.Value.ToString();
        string saturday2 = timepickersat2.Value.ToString();
        string saturday3 = timepickersat3.Value.ToString();
        string saturday4 = timepickersat4.Value.ToString();

        string sunday1 = timepickersun1.Value.ToString();
        string sunday2 = timepickersun2.Value.ToString();
        string sunday3 = timepickersun3.Value.ToString();
        string sunday4 = timepickersun4.Value.ToString();

        string did = Session["doctor_reg_id"].ToString();

        int avg_time =Convert.ToInt32(tb_minutes.Text);

        if (submit.Text == "Submit")
        {
            bool b1 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Monday", "s_first_from", monday1, "s_first_to", monday2, "s_second_from", monday3, "s_second_to", monday4, "s_avg_time", avg_time.ToString());
            bool b2 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Tuesday", "s_first_from", tuesday1, "s_first_to", tuesday2, "s_second_from", tuesday3, "s_second_to", tuesday4, "s_avg_time", avg_time.ToString());
            bool b3 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Wednesday", "s_first_from", wednesday1, "s_first_to", wednesday2, "s_second_from", wednesday3, "s_second_to", wednesday4, "s_avg_time", avg_time.ToString());
            bool b4 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Thursday", "s_first_from", thursday1, "s_first_to", thursday2, "s_second_from", thursday3, "s_second_to", thursday4, "s_avg_time", avg_time.ToString());
            bool b5 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Friday", "s_first_from", friday1, "s_first_to", friday2, "s_second_from", friday3, "s_second_to", friday4, "s_avg_time", avg_time.ToString());
            bool b6 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Saturday", "s_first_from", saturday1, "s_first_to", saturday2, "s_second_from", saturday3, "s_second_to", saturday4, "s_avg_time", avg_time.ToString());
            bool b7 = con_sch.SaveData("doc_id", did, "dclinic_id", clinic_id, "s_day_name", "Sunday", "s_first_from", sunday1, "s_first_to", sunday2, "s_second_from", sunday3, "s_second_to", sunday4, "s_avg_time", avg_time.ToString());

            if (b1 == true && b2 == true && b3 == true && b4 == true && b5 == true && b6 == true && b7 == true)
            {
                Response.Redirect("doc_clinic_timing.aspx");
            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Inserted');");
                Response.Write("</script>");

            }
        }
        else
        if(submit.Text=="Update")
        {

            bool b8 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + monday1 + "', s_first_to='" + monday2 + "', s_second_from='" + monday3 + "', s_second_to='" + monday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Monday'");
            bool b9 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + tuesday1 + "', s_first_to='" + tuesday2 + "', s_second_from='" + tuesday3 + "', s_second_to='" + tuesday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Tuesday'");
            bool b10 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + wednesday1 + "', s_first_to='" + wednesday2 + "', s_second_from='" + wednesday3 + "', s_second_to='" + wednesday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Wednesday'");
            bool b11 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + thursday1 + "', s_first_to='" + thursday2 + "', s_second_from='" + thursday3 + "', s_second_to='" + thursday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Thursday'");
            bool b12 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + friday1 + "', s_first_to='" + friday2 + "', s_second_from='" + friday3 + "', s_second_to='" + friday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Friday'");
            bool b13 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + saturday1 + "', s_first_to='" + saturday2 + "', s_second_from='" + saturday3 + "', s_second_to='" + saturday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Saturday'");
            bool b14 = con_sch.UpdateDeleteData("update Doctor_schedule set s_first_from='" + sunday1 + "', s_first_to='" + sunday2 + "', s_second_from='" + sunday3 + "', s_second_to='" + sunday4 + "', s_avg_time='" + Convert.ToInt32(tb_minutes.Text) + "' where dclinic_id='" + Convert.ToInt64(clinic_id) + "' and s_day_name='Sunday'");
            if (b8 == true && b9 == true && b10 == true && b11 == true && b12 == true && b13 == true && b14 == true)
            {
                Response.Redirect("doc_clinic_timing.aspx");

            }
            else
            {
                Response.Write("<script>");
                Response.Write("alert('Data Not Updated')");
                Response.Write("</script>");
            }
        }
    }
   


    protected void cb_day1_CheckedChanged1(object sender, EventArgs e)
    {
        if (cb_day1.Checked == true)
        {
            /*timepickermo1.Attributes.Add("readonly", "readonly");
            timepickermo2.Attributes.Add("readonly", "readonly");
            timepickermo3.Attributes.Add("readonly", "readonly");
            timepickermo4.Attributes.Add("readonly", "readonly");*/

            timepickermo1.Value = "00:00";
            timepickermo2.Value = "00:00";
            timepickermo3.Value = "00:00";
            timepickermo4.Value = "00:00";

            timepickermo1.Disabled = true;
            timepickermo2.Disabled = true;
            timepickermo3.Disabled = true;
            timepickermo4.Disabled = true;
           
        }
        else
            if(cb_day1.Checked==false)
            {
                timepickermo1.Value = "09:00";
                timepickermo2.Value = "12:00";
                timepickermo3.Value = "15:00";
                timepickermo4.Value = "19:00";
                timepickermo1.Disabled = false;
                timepickermo2.Disabled = false;
                timepickermo3.Disabled = false;
                timepickermo4.Disabled = false;

            }
    }
    protected void cb_day2_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_day2.Checked == true)
        {
            timepickertu1.Value = "00:00";
            timepickertu2.Value = "00:00";
            timepickertu3.Value = "00:00";
            timepickertu4.Value = "00:00";
            timepickertu1.Disabled = true;
            timepickertu2.Disabled = true;
            timepickertu3.Disabled = true;
            timepickertu4.Disabled = true;
        }
        else
            if (cb_day2.Checked == false)
            {
                timepickertu1.Value = "09:00";
                timepickertu2.Value = "12:00";
                timepickertu3.Value = "15:00";
                timepickertu4.Value = "19:00";
                timepickertu1.Disabled = false;
                timepickertu2.Disabled = false;
                timepickertu3.Disabled = false;
                timepickertu4.Disabled = false;
            }
    }
    protected void cb_day3_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_day3.Checked == true)
        {
            timepickerwe1.Value = "00:00";
            timepickerwe2.Value = "00:00";
            timepickerwe3.Value = "00:00";
            timepickerwe4.Value = "00:00";

            timepickerwe1.Disabled = true;
            timepickerwe2.Disabled = true;
            timepickerwe3.Disabled = true;
            timepickerwe4.Disabled = true;
           
        }
        else
            if (cb_day3.Checked == false)
            {
                timepickerwe1.Value = "09:00";
                timepickerwe2.Value = "12:00";
                timepickerwe3.Value = "15:00";
                timepickerwe4.Value = "19:00";

                timepickerwe1.Disabled = false;
                timepickerwe2.Disabled = false;
                timepickerwe3.Disabled = false;
                timepickerwe4.Disabled = false;
               
            }
    }
    protected void cb_day4_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_day4.Checked == true)
        {
            timepickerthu1.Value = "00:00";
            timepickerthu2.Value = "00:00";
            timepickerthu3.Value = "00:00";
            timepickerthu4.Value = "00:00";
            timepickerthu1.Disabled = true;
            timepickerthu2.Disabled = true;
            timepickerthu3.Disabled = true;
            timepickerthu4.Disabled = true;
        }
        else
            if (cb_day4.Checked == false)
            {
                timepickerthu1.Value = "09:00";
                timepickerthu2.Value = "12:00";
                timepickerthu3.Value = "15:00";
                timepickerthu4.Value = "19:00";
                timepickerthu1.Disabled = false;
                timepickerthu2.Disabled = false;
                timepickerthu3.Disabled = false;
                timepickerthu4.Disabled = false;
            }
    }
    protected void cb_day5_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_day5.Checked == true)
        {
            timepickerfri1.Value = "00:00";
            timepickerfri2.Value = "00:00";
            timepickerfri3.Value = "00:00";
            timepickerfri4.Value = "00:00";
            timepickerfri1.Disabled = true;
            timepickerfri2.Disabled = true;
            timepickerfri3.Disabled = true;
            timepickerfri4.Disabled = true;
           
        }
        else
            if (cb_day5.Checked == false)
            {
                timepickerfri1.Value = "09:00";
                timepickerfri2.Value = "12:00";
                timepickerfri3.Value = "15:00";
                timepickerfri4.Value = "19:00";
                timepickerfri1.Disabled = false;
                timepickerfri2.Disabled = false;
                timepickerfri3.Disabled = false;
                timepickerfri4.Disabled = false;
            }
    }
    protected void cb_day6_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_day6.Checked == true)
        {
            timepickersat1.Value = "00:00";
            timepickersat2.Value = "00:00";
            timepickersat3.Value = "00:00";
            timepickersat4.Value = "00:00";
            timepickersat1.Disabled = true;
            timepickersat2.Disabled = true;
            timepickersat3.Disabled = true;
            timepickersat4.Disabled = true;

        }
        else
            if (cb_day6.Checked == false)
            {
                timepickersat1.Value = "09:00";
                timepickersat2.Value = "12:00";
                timepickersat3.Value = "15:00";
                timepickersat4.Value = "19:00";
                timepickersat1.Disabled = false;
                timepickersat2.Disabled = false;
                timepickersat3.Disabled = false;
                timepickersat4.Disabled = false;
            }
    }
    protected void cb_day7_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_day7.Checked == true)
        {
            timepickersun1.Value = "00:00";
            timepickersun2.Value = "00:00";
            timepickersun3.Value = "00:00";
            timepickersun4.Value = "00:00";

            timepickersun1.Disabled = true;
            timepickersun2.Disabled = true;
            timepickersun3.Disabled = true;
            timepickersun4.Disabled = true;

        }
        else
            if (cb_day7.Checked == false)
            {
                timepickersun1.Value = "09:00";
                timepickersun2.Value = "12:00";
                timepickersun3.Value = "15:00";
                timepickersun4.Value = "19:00";

                timepickersun1.Disabled = false;
                timepickersun2.Disabled = false;
                timepickersun3.Disabled = false;
                timepickersun4.Disabled = false;
            }
    }
    protected void doc_clinic_SelectedIndexChanged(object sender, EventArgs e)
    {
        string doc_clinic_name = doc_clinic.SelectedValue.ToString();

        dt3.Clear();
        if (doc_clinic_name != "SELECT CLINIC")
        {
            dt3 = con3.GetData("select * from Doctor_schedule where dclinic_id=" + Convert.ToInt64(doc_clinic_name));

            if (dt3.Rows.Count > 1)
            {
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Monday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickermo1.Value = dr4["s_first_from"].ToString();
                    timepickermo2.Value = dr4["s_first_to"].ToString();
                    timepickermo3.Value = dr4["s_second_from"].ToString();
                    timepickermo4.Value = dr4["s_second_to"].ToString();
                }

                dt4.Clear();
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Tuesday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickertu1.Value = dr4["s_first_from"].ToString();
                    timepickertu2.Value = dr4["s_first_to"].ToString();
                    timepickertu3.Value = dr4["s_second_from"].ToString();
                    timepickertu4.Value = dr4["s_second_to"].ToString();
                }
               
                dt4.Clear();
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Wednesday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickerwe1.Value = dr4["s_first_from"].ToString();
                    timepickerwe2.Value = dr4["s_first_to"].ToString();
                    timepickerwe3.Value = dr4["s_second_from"].ToString();
                    timepickerwe4.Value = dr4["s_second_to"].ToString();
                }

                dt4.Clear();
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Thursday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickerthu1.Value = dr4["s_first_from"].ToString();
                    timepickerthu2.Value = dr4["s_first_to"].ToString();
                    timepickerthu3.Value = dr4["s_second_from"].ToString();
                    timepickerthu4.Value = dr4["s_second_to"].ToString();
                }

                dt4.Clear();
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Friday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickerfri1.Value = dr4["s_first_from"].ToString();
                    timepickerfri2.Value = dr4["s_first_to"].ToString();
                    timepickerfri3.Value = dr4["s_second_from"].ToString();
                    timepickerfri4.Value = dr4["s_second_to"].ToString();
                }

                dt4.Clear();
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Saturday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickersat1.Value = dr4["s_first_from"].ToString();
                    timepickersat2.Value = dr4["s_first_to"].ToString();
                    timepickersat3.Value = dr4["s_second_from"].ToString();
                    timepickersat4.Value = dr4["s_second_to"].ToString();
                }

                dt4.Clear();
                dt4 = con4.GetData("select * from Doctor_schedule where s_day_name='Sunday' and dclinic_id=" + Convert.ToInt64(doc_clinic_name));
                foreach (DataRow dr4 in dt4.Rows)
                {
                    timepickersun1.Value = dr4["s_first_from"].ToString();
                    timepickersun2.Value = dr4["s_first_to"].ToString();
                    timepickersun3.Value = dr4["s_second_from"].ToString();
                    timepickersun4.Value = dr4["s_second_to"].ToString();
                    tb_minutes.Text=dr4["s_avg_time"].ToString();
                }

                if (timepickermo1.Value.ToString().Equals("00:00:00") && timepickermo2.Value.ToString().Equals("00:00:00") && timepickermo3.Value.ToString().Equals("00:00:00") && timepickermo4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day1.Checked = true;
                    timepickermo1.Disabled = true;
                    timepickermo2.Disabled = true;
                    timepickermo3.Disabled = true;
                    timepickermo4.Disabled = true;
                }
                else
                {
                    cb_day1.Checked = false;
                    timepickermo1.Disabled = false;
                    timepickermo2.Disabled = false;
                    timepickermo3.Disabled = false;
                    timepickermo4.Disabled = false;
                }

                if (timepickertu1.Value.ToString().Equals("00:00:00") && timepickertu2.Value.ToString().Equals("00:00:00") && timepickertu3.Value.ToString().Equals("00:00:00") && timepickertu4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day2.Checked = true;
                    timepickertu1.Disabled = true;
                    timepickertu2.Disabled = true;
                    timepickertu3.Disabled = true;
                    timepickertu4.Disabled = true;
                }
                else
                {
                    cb_day2.Checked = false;
                    timepickertu1.Disabled = false;
                    timepickertu2.Disabled = false;
                    timepickertu3.Disabled = false;
                    timepickertu4.Disabled = false;
                }

                if (timepickerwe1.Value.ToString().Equals("00:00:00") && timepickerwe2.Value.ToString().Equals("00:00:00") && timepickerwe3.Value.ToString().Equals("00:00:00") && timepickerwe4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day3.Checked = true;
                    timepickerwe1.Disabled = true;
                    timepickerwe2.Disabled = true;
                    timepickerwe3.Disabled = true;
                    timepickerwe4.Disabled = true;
                }
                else
                {
                    cb_day3.Checked = false;
                    timepickerwe1.Disabled = false;
                    timepickerwe2.Disabled = false;
                    timepickerwe3.Disabled = false;
                    timepickerwe4.Disabled = false;
                }

                if (timepickerthu1.Value.ToString().Equals("00:00:00") && timepickerthu2.Value.ToString().Equals("00:00:00") && timepickerthu3.Value.ToString().Equals("00:00:00") && timepickerthu4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day4.Checked = true;
                    timepickerthu1.Disabled = true;
                    timepickerthu2.Disabled = true;
                    timepickerthu3.Disabled = true;
                    timepickerthu4.Disabled = true;
                }
                else
                {
                    cb_day4.Checked = false;
                    timepickerthu1.Disabled = false;
                    timepickerthu2.Disabled = false;
                    timepickerthu3.Disabled = false;
                    timepickerthu4.Disabled = false;
                }

                if (timepickerfri1.Value.ToString().Equals("00:00:00") && timepickerfri2.Value.ToString().Equals("00:00:00") && timepickerfri3.Value.ToString().Equals("00:00:00") && timepickerfri4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day5.Checked = true;
                    timepickerfri1.Disabled = true;
                    timepickerfri2.Disabled = true;
                    timepickerfri3.Disabled = true;
                    timepickerfri4.Disabled = true;
                }
                else
                {
                    cb_day5.Checked = false;
                    timepickerfri1.Disabled = false;
                    timepickerfri2.Disabled = false;
                    timepickerfri3.Disabled = false;
                    timepickerfri4.Disabled = false;
                }

                if (timepickersat1.Value.ToString().Equals("00:00:00") && timepickersat2.Value.ToString().Equals("00:00:00") && timepickersat3.Value.ToString().Equals("00:00:00") && timepickersat4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day6.Checked = true;
                    timepickersat1.Disabled = true;
                    timepickersat2.Disabled = true;
                    timepickersat3.Disabled = true;
                    timepickersat4.Disabled = true;
                }
                else
                {
                    cb_day6.Checked = false;
                    timepickersat1.Disabled = false;
                    timepickersat2.Disabled = false;
                    timepickersat3.Disabled = false;
                    timepickersat4.Disabled = false;
                }

                if (timepickersun1.Value.ToString().Equals("00:00:00") && timepickersun2.Value.ToString().Equals("00:00:00") && timepickersun3.Value.ToString().Equals("00:00:00") && timepickersun4.Value.ToString().Equals("00:00:00"))
                {
                    cb_day7.Checked = true;
                    timepickersun1.Disabled = true;
                    timepickersun2.Disabled = true;
                    timepickersun3.Disabled = true;
                    timepickersun4.Disabled = true;

                }
                else
                {
                    cb_day7.Checked = false;
                    timepickersun1.Disabled = false;
                    timepickersun2.Disabled = false;
                    timepickersun3.Disabled = false;
                    timepickersun4.Disabled = false;
                }
                submit.Text = "Update";
            }
            else
            {
                set_data_null();
                submit.Text = "Submit";
            }
        }
    }
}