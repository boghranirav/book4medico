using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class index2 : System.Web.UI.Page
{
    connectionclass conspe = new connectionclass();
    DataTable dtspe = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dtspe = conspe.GetData("select * from Specializations_info");
        string str_spe = "";

        
        foreach (DataRow dr1 in dtspe.Rows)
        {
            if (dr1["spe_name"].ToString() == "Dentist" || dr1["spe_name"].ToString() == "Gastroenterologist" || dr1["spe_name"].ToString() == "Ayurveda" || dr1["spe_name"].ToString() == "Homeopath" || dr1["spe_name"].ToString() == "Cardiologist" || dr1["spe_name"].ToString() == "Ear-nose-throat" || dr1["spe_name"].ToString() == "Gynecologist" || dr1["spe_name"].ToString() == "Ophthalmologist" || dr1["spe_name"].ToString() == "Dermatologist")
            {
                str_spe += "<div class='item'>";
                str_spe += "<div class='product-item hvr-underline-from-cente'>";
                str_spe += "<a class='product-item_footer' href='user_doctor_disp.aspx?srnm=" + dr1["spe_name"] + "'>";
                str_spe += "<div class='product-item_body product-border'>";
                str_spe += "<img alt='Product' src='user_side_assets/image/" + dr1["spe_name"] + ".jpg' class='product-item_image' width='5px' height='150'>";
                str_spe += "</div>";
                
                str_spe += "<div class='product-item_title font-additional font-weight-bold text-center text-uppercase'>" + dr1["spe_name"] + "</div>";
                str_spe += "</a></div></div>";
            }
        }
       
        divslider.InnerHtml = str_spe;
        
    }
}