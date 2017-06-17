using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Student : System.Web.UI.Page
{
    Connection con = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
           if (Session["log"].ToString() == "")
           {
               Response.Redirect("http://localhost:3263/Signup.aspx");
           }
           else

            {
                string a, b, c;
                string field_val = (string)Session["field1"];
                string str = "select * from table_SignUp where id='" + Convert.ToInt32(field_val) + "' ";
                SqlDataReader dr;
                dr = Connection.login(str);
                if (dr.Read())
                {

                    a = dr[1].ToString();
                    lbl_nname.Text = a;
                    b = dr[2].ToString();
                    lbl_ndob.Text = b;
                    c = dr[3].ToString();
                    lbl_ngen.Text = c;
                    dr.Close();

                }

                MultiView1.ActiveViewIndex = 0;
            }
        
        
    }
    protected void btn_event_Click(object sender, EventArgs e)
    {
        if (btn_event.Text == "View My Events")
        {
            MultiView1.ActiveViewIndex = 1;
            btn_event.Text = "Go Back";
        }
        else if (btn_event.Text == "Go Back")
        {
            MultiView1.ActiveViewIndex = 0;
            btn_event.Text = "View My Events";
        }

        string field_val = (string)Session["field1"];
        string s = "select nto10,tto12,oto2,twto3 from table_SignIn where id='"+field_val+"' ";
        SqlDataReader sdr;
        sdr = Connection.login(s);
        string nine, ten, one, two;


        if (sdr.Read())
        {



             nine = sdr[0].ToString();
             ten = sdr[1].ToString();
             one = sdr[2].ToString();
             two = sdr[3].ToString();

             if (nine != "")
             {
                 if (nine != "None")
                 {
                     lbl_r9to10.Text = nine;
                 }
                 else
                 {
                     lbl_r9to10.Text = "No events";
                 }
             }
             else
             {
                 lbl_r9to10.Text = "No events";
             }
             if (ten != "")
             {
                 if (ten != "None")
                 {
                     lbl_r10to12.Text = ten;
                 }
                 else
                 {
                     lbl_r10to12.Text = "No events";
                 }
             }
             else
             {
                 lbl_r10to12.Text = "No events";
             }
             if (one != "")
             {
                 if (one != "None")
                 {
                     lbl_r1to2.Text = one;
                 }
                 else 
                 {
                     lbl_r1to2.Text = "No events";
                 }
             }
             else
             {
                 lbl_r1to2.Text = "No events";
             }
             if (two != "")
             {
                 if (two != "None")
                 {
                     lbl_r2to3.Text = two;
                 }
                 else 
                 {
                     lbl_r2to3.Text = "No events";
                 }
             }
             else
             {
                 lbl_r2to3.Text = "No events";
             }
             
             

             sdr.Close();
            

        }




    }
    protected void btn_sub_Click(object sender, EventArgs e)
    {
        string nine=null,ten=null,one=null,two=null;
         string field_val = (string)Session["field1"];
         nine = rbl_9to10.Text;
         ten = rbl_10to12.Text;
         one = rbl_1to2.Text;
         two = rbl_2to3.Text;
        if (nine != null)
        {
            string s = "update table_SignIn set nto10='" + nine + "' where id='"+Convert.ToInt32(field_val)+"'";
            int a = Connection.sqlquery(s);

        }
        if (ten != null)
        {
            string s = "update table_SignIn set tto12='" + ten + "'where id='" + Convert.ToInt32(field_val) + "'";
            int a = Connection.sqlquery(s);
        }
        if (one != null)
        {
            string s = "update table_SignIn set oto2='" + one + "'where id='" + Convert.ToInt32(field_val) + "'";
            int a = Connection.sqlquery(s);
        }
        if (two != null)
        {
            string s = "update table_SignIn set twto3='" + two + "'where id='" + Convert.ToInt32(field_val) + "'";
            int a = Connection.sqlquery(s);
        }

        

    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void btn_logout_Click(object sender, EventArgs e)
    {
        Session["log"]="";
       
       /* Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();*/
        Response.Redirect("http://localhost:3263/Signup.aspx");
    }
}