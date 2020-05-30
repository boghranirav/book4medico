using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Doctor_doc_clinic_photodelete : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();

    DataTable dt2 = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
       int id= Convert.ToInt32( Request.QueryString["pid"]);

       string img_src = "";
       dt2 = con2.GetData("select * from Clinic_photos where photos_id=" + id);
        foreach(DataRow dr2 in dt2.Rows){
           img_src = dr2["src_name"].ToString();
        }

        string path = Server.MapPath(@"Clinic_Photos\" + img_src);
        Response.Write(path);
        FileInfo fi  = new FileInfo(path);
        if(fi.Exists){
            File.Delete(path);
        }

        bool b = con1.UpdateDeleteData("delete from Clinic_photos where photos_id=" + id);


        string msg;
        if (b == true)
        {
            msg = "success";
        }
        else
        {
            msg = "error";
        }
        Response.Redirect("doc_clinic_photos.aspx?ermsg=" + msg);
       
    }
}