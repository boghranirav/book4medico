using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_index2 : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    connectionclass con3 = new connectionclass();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();


    string str_disp = "";
    int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        dt1 = con1.GetData("select * from Doctor_registration dr, Doctor_basic_info dbi, Country_info cf where dr.doc_id=dbi.doc_id and cf.country_id=dbi.country");

        foreach (DataRow dr1 in dt1.Rows)
        {
            string doc_id= dr1["doc_id"].ToString();
            string name=dr1["first_name"].ToString()+ " " +dr1["last_name"].ToString();

            string spe = string.Empty;
            dt2.Clear();
            dt2 = con2.GetData("select si.spe_name from Specializations_info si,Doctor_specialization ds where ds.sep_id=si.spe_id and ds.doc_id="+doc_id);
            foreach(DataRow dr2 in dt2.Rows)
            {
                spe += dr2["spe_name"].ToString()+"<br>";
            }

            string mobile=dr1["doc_r_mobile_no"].ToString();
            string country=dr1["country_name"].ToString();

            string city = "";
            dt3.Clear();
            dt3 = con3.GetData("select  distinct dc.city_id, ci.city_name from Doctor_clinic dc,City_info ci where dc.city_id=ci.city_id and dc.doc_id=" + doc_id);
            foreach (DataRow dr3 in dt3.Rows)
            {
                city+=dr3["city_name"]+"<br>";
            }

            DateTime cdate = DateTime.Parse(dr1["doc_r_date_time"].ToString());
            string dateonly = cdate.ToString("dd/MM/yyyy");

            //dateonly.ToString("mm/dd/yyyy");

            i++;
            string doc_status = "";
            if (dr1["d_status"].ToString().Equals("B"))
            {
                doc_status = "Block";
            }
            else
                if (dr1["d_status"].ToString().Equals("A"))
                { 
                    doc_status = "A-Block"; 
                }
                else
            {
                doc_status = "Un-Block";
            }
            str_disp += "<tr><td width='7%'>" + i + "</td><td width='17%'>" + name + "</td><td width='32%'>" + spe + "</td><td width='10%'>" + country + "</td><td width='15%'>" + city + "</td><td width='9%'>" + dateonly + "</td><td width='10%'>" + doc_status + "</td><td width='8%'><a href='admin_doctor_deatils.aspx?dcid=" + doc_id + "'>Detail</a></td></tr>";
            
        }
        tbl_disp.InnerHtml = str_disp;
    }
}