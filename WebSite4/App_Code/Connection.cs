using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{
    public static SqlConnection con;
    public Connection()
    {
        //String s = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:/Users/Alistar/Documents/Visual Studio 2013/WebSites/WebSite3/App_Data/Database.mdf;Integrated Security=True";
        con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alistar\Documents\Visual Studio 2013\WebSites\WebSite4\App_Data\Database.mdf;Integrated Security=True");
        con.Open();

    }

    public static int sqlquery(string str)
    {
        SqlCommand cmd = new SqlCommand();
        cmd = Connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = str;
        int i = cmd.ExecuteNonQuery();
        return i;
    }

    public static string scalar(string str) 
    {
        string s;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd = Connection.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = str;
            s = cmd.ExecuteScalar().ToString();
            return s;
        }
        catch(Exception e)
        {
           return "0";
        }

    }

    public static SqlDataReader login(string s)
    {
        SqlCommand cmd = new SqlCommand();
        cmd = Connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = s;
        SqlDataReader dr = cmd.ExecuteReader();
        return dr;
    }

    public static DataTable dt(string s)
    {
        SqlCommand cmd = new SqlCommand();
        cmd = Connection.con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = s;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt=new DataTable();
        da.Fill(dt);
        return (dt);
    }





    }


