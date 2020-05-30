using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


public partial class Doctor_doc_clinic_photos : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    connectionclass con2 = new connectionclass();
    connectionclass con3 = new connectionclass();
    connectionclass con4 = new connectionclass();
    connectionclass con5 = new connectionclass();


    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();


     string str_img2 = "";
     
    protected void Page_Load(object sender, EventArgs e)
    {
        string msg1 = Request.QueryString["ermsg"];
        if (msg1 == "error")
        {
            Response.Write("<script>");
            Response.Write("alert('Degree Not Deleted');");
            Response.Write("</script>");
        }

        dt1 = con1.GetData("select * from Doctor_basic_info where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString()));

        dt2 = con2.GetData("select * from Doctor_clinic where doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString()));

        if (!IsPostBack)
        {
            foreach (DataRow dr2 in dt2.Rows)
            {
                doc_clinic.Items.Add(new ListItem(dr2["clinic_name"].ToString(), dr2["dclinic_id"].ToString()));
                DropDownList1.Items.Add(new ListItem(dr2["clinic_name"].ToString(), dr2["dclinic_id"].ToString()));
            }
        }

        dt3 = con3.GetData("select * from Clinic_photos");

        dt4 = con4.GetData("select * from Clinic_photos cp,Doctor_clinic dc where cp.dclinic_id=dc.dclinic_id and dc.doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString()) );
        foreach (DataRow dr4 in dt4.Rows)
        {
            string disp_img= "Clinic_Photos/" + dr4["src_name"].ToString();
            string photo_id = dr4["photos_id"].ToString();
    
            str_img2 += "<div class='superbox-list' ><img src=" + disp_img + " data-img=" + disp_img + " class='superbox-img' height='150' width='150'/><a href='doc_clinic_photodelete.aspx?pid="+photo_id+"'><div class='stylish-button'>Delete</div></a></div>";
        }
    
        img_g.InnerHtml=str_img2;

        
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("~/Doctor/Clinic_Photos/");
        string photo_not_uploaded="";
          HttpFileCollection uploadedFiles = Request.Files;
           
          for(int i = 0;i < uploadedFiles.Count;i++) {
              HttpPostedFile userPostedFile = uploadedFiles[i];

              try {
                  if (userPostedFile.ContentLength > 0)
                  {
                      if ((userPostedFile.ContentType == "image/jpeg") || (userPostedFile.ContentType == "image/jpg") || (userPostedFile.ContentType == "image/png"))
                      {
                          string user_file_name=doc_clinic.SelectedItem.Value.ToString()+userPostedFile.FileName;
                          bool b = con3.SaveData("dclinic_id",doc_clinic.SelectedValue.ToString(),"src_name",user_file_name,"date_time",System.DateTime.Now.ToString());
                          if (b == true)
                          {
                              userPostedFile.SaveAs(filepath + "\\" + Path.GetFileName(user_file_name));
                          }
                          else
                          {
                             
                              photo_not_uploaded += userPostedFile.FileName.ToString() + "\n";
                              Label1.Text = photo_not_uploaded + "Not Uploaded.";
                          }
                      }
                      else
                      {
                          Label1.Text = "Only Jpg,Png and Jpeg File Allowed.";
                      }
                  }
                  else
                  {
                      Label1.Text = "Please, Select Photo.";
                  }
              } catch(Exception Ex) {
                 
              }
           }

          Response.Redirect("doc_clinic_photos.aspx");
     
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        str_img2 = "";
        img_g.InnerHtml = null;
        if (DropDownList1.SelectedValue.ToString() == "ALL")
        {
            dt5 = con5.GetData("select * from Clinic_photos cp,Doctor_clinic dc where cp.dclinic_id=dc.dclinic_id and dc.doc_id=" + Convert.ToInt64(Session["doctor_reg_id"].ToString()));
        }
        else
        {
            dt5 = con5.GetData("select * from Clinic_photos where dclinic_id=" + Convert.ToInt32(DropDownList1.SelectedValue.ToString()));
        }

       
        foreach (DataRow dr5 in dt5.Rows)
        {
            string disp_img = "Clinic_Photos/" + dr5["src_name"].ToString();
            string photo_id = dr5["photos_id"].ToString();

            str_img2 += "<div class='superbox-list' ><img src=" + disp_img + " data-img=" + disp_img + " class='superbox-img' height='150' width='150'/><a href='doc_clinic_photodelete.aspx?pid=" + photo_id + "'><div class='stylish-button'>Delete</div></a></div>";
        }

        img_g.InnerHtml = str_img2;
        
    }
}
