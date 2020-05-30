using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;


public class connectionclass
{
   SqlConnection cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
   SqlCommand cmd = new SqlCommand();
   SqlCommandBuilder cb = new SqlCommandBuilder();
   DataTable dt = new DataTable();
   SqlDataAdapter adp = new SqlDataAdapter();
   SqlCommand cmd_del_update = new SqlCommand();
    
	public connectionclass()
	{
        cnn.Open();
        cmd.Connection = cnn;
        cmd_del_update.Connection = cnn;
	}
    public DataTable GetData(string tbname)
    {
        try
        {
            cmd.CommandText = tbname;
            adp.SelectCommand = cmd;
            cb.DataAdapter = adp;
            adp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            DataTable empty = new DataTable();
            return empty;

        }
    }
    public bool SaveData(params string[] str)
    {
        try
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < str.Length; i += 2)
            {
                dr[str[i]] = str[i + 1];
            }
            dt.Rows.Add(dr);
            adp.Update(dt);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateDeleteData(string qry)
    {
       
            cmd_del_update.CommandText = qry;
            if (cmd_del_update.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        
    }
}