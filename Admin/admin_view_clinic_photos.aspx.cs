using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_admin_view_clinic_photos : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();

    DataTable dt1 = new DataTable();

    string str_photo = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string id=Request.QueryString["dclid"];
        dt1 = con1.GetData("select * from Clinic_photos where dclinic_id="+id);

        foreach (DataRow dr1 in dt1.Rows)
        {
            string img_src = "../Doctor/Clinic_Photos/" + dr1["src_name"].ToString();
           
            str_photo += "<div class='superbox-list' ><img src=" + img_src + " data-img=" + img_src + " class='superbox-img' height='150' width='150'/></div>";
        }
        img_g.InnerHtml = str_photo;

       
    }
    
}