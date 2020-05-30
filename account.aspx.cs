using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class account1 : System.Web.UI.Page
{
    connectionclass con1 = new connectionclass();
    DataTable dt1 = new DataTable();
    connectionclass con2 = new connectionclass();
    DataTable dt2 = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string useremail = Session["usermobile"].ToString();
        dt1 = con1.GetData("select user_id from User_registration where user_mobile='" + useremail + "'");
        string uid = "";
        foreach (DataRow dr1 in dt1.Rows)
        {
            uid = dr1["user_id"].ToString();
        }
        Session["userid"] = uid;
        if (!IsPostBack)
        {
            dt2 = con2.GetData("select * from User_registration where user_id='" + uid + "'");
            foreach (DataRow dr2 in dt2.Rows)
            {

                pt_name.Text = dr2["user_name"].ToString();
                u_email.Text = dr2["user_email"].ToString();
                u_mobile.Text = dr2["user_mobile"].ToString();
                if (dr2["user_dob"].ToString() == "")
                {
                    birth_date.Text = "";
                }
                else
                {
                    DateTime d1;
                    d1 = Convert.ToDateTime(dr2["user_dob"]);

                    birth_date.Text = d1.ToShortDateString();
                }
                if (dr2["user_gender"].ToString() == "Male")
                {
                    rbmale.Checked = true;

                }
                else if (dr2["user_gender"].ToString() == "Female")
                {
                    rbfemale.Checked = true;
                }
            }
        }


    }
    protected void done_Click(object sender, EventArgs e)
    {
        string uid = Session["userid"].ToString();
        string gender = "";
        if (rbmale.Checked == true)
        {
            gender = "Male";
        }
        else if (rbfemale.Checked == true)
        {
            gender = "Female";
        }
        bool b;
        if (birth_date.Text == "")
        {
            b = con2.UpdateDeleteData("update User_registration set user_gender='" + gender + "' where user_id='" + uid + "'");
        }
        else
        {
            b = con2.UpdateDeleteData("update User_registration set user_gender='" + gender + "',user_dob='" + birth_date.Text + "' where user_id='" + uid + "'");
        }
        if (b == true)
        {
            Response.Redirect("account.aspx");
        }
        else
        {
            
          Label1.Text="*Data not updated";
        }
    }
}