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
                int cancel;
                cancel=event1("Long Jump");
                if (cancel == 0)
                {
                    rbl_9to10.Items[0].Enabled=false;
                }
                cancel=event1("Cricket");
                if (cancel == 0)
                {
                    rbl_10to12.Items[1].Enabled = false;
                }
                cancel=event1("Pole Vault");
                if (cancel == 0)
                {
                    rbl_9to10.Items[2].Enabled = false;
                }
                cancel=event1("Carroms");
                if (cancel == 0)
                {
                    rbl_2to3.Items[0].Enabled = false;
                }
                cancel=event1("Football");
                if (cancel == 0)
                {
                    rbl_10to12.Items[0].Enabled = false;
                }
                cancel=event1("Hockey");
                if (cancel == 0)
                {
                    rbl_10to12.Items[2].Enabled = false;
                }
                cancel=event1("Tennis");
                if (cancel == 0)
                {
                    rbl_1to2.Items[1].Enabled = false;
                }
                cancel=event1("Chess");
                if (cancel == 0)
                {
                    rbl_2to3.Items[1].Enabled = false;
                }
                cancel=event1("Table Tennis");
                if (cancel == 0)
                {
                    rbl_2to3.Items[2].Enabled = false;
                }
                cancel=event1("Badminton");
                if (cancel == 0)
                {
                    rbl_1to2.Items[0].Enabled = false;
                }
                cancel = event1("High Jump");
                if (cancel == 0)
                {
                    rbl_9to10.Items[1].Enabled = false;
                }

                MultiView1.ActiveViewIndex = 0;
                string m;
                m = "select type from table_SignIn where sub=1";
                DataTable dtem = Connection.dt(m);
                
                    for (int i = 0; i < dtem.Rows.Count ; i++)
                    {
                        string ty = dtem.Rows[i][0].ToString();
                        event2(ty);
                    }

              
            }
        
        
    }
    public void event2(string ev2)
    {
        if (ev2 == "Long Jump")
        {
            rbl_9to10.Items[0].Enabled = false;
        }
        if (ev2 == "High Jump")
        {
            rbl_9to10.Items[1].Enabled = false;
        }
        if (ev2 == "Pole Vault")
        {
            rbl_9to10.Items[2].Enabled = false;
        }
        if (ev2 == "Chess")
        {
            rbl_2to3.Items[1].Enabled = false;
        }
        if (ev2 == "Badminton")
        {
            rbl_1to2.Items[0].Enabled = false;
        }
        if (ev2 == "Table Tennis")
        {
            rbl_2to3.Items[2].Enabled = false;
        }
        if (ev2 == "Tennis")
        {
            rbl_1to2.Items[1].Enabled = false;
        }
        if(ev2=="Football")
        {
            rbl_10to12.Items[0].Enabled = false;
        }
        if (ev2 == "Cricket")
        {
            rbl_10to12.Items[1].Enabled = false;
        }
        if (ev2 == "Hockey")
        {
            rbl_10to12.Items[2].Enabled = false;
        }
        if (ev2 == "Carroms")
        {
            rbl_2to3.Items[0].Enabled = false;
        }
    }

    public int event1(string ev)
    {
        try
        {
            string s = "select count(Id) from table_SignIn where (nto10='" + ev + "' or tto12='" + ev + "' or oto2='" + ev + "' or twto3='" + ev + "')";
            string a = Connection.scalar(s);
            int cn = Convert.ToInt32(a);
            s = "select total from table_SignIn where type='" + ev + "'";
            string t = Connection.scalar(s);
            int cn1 = Convert.ToInt32(t);
            cn = cn1 - cn;
            s = "update table_SignIn set count='" + cn + "' where type='" + ev + "'";
            int ab = Connection.sqlquery(s);
            s = "select count from table_SignIn where type='" + ev + "'";
            string fcn = Connection.scalar(s);
            int b = Convert.ToInt32(fcn);
            if (b == 0)
            {
                return 0;

            }
            else
            {
                return 1;
            }
        }
        catch (Exception e)
        {
            return 0;
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
            //string sl = "select count from table_SignIn where type='"+nine+"'";
            //string c = Connection.scalar(sl);
            //if (Convert.ToInt32(c) == 0)
            //{
                
            //}
            //else
            //{
                string s = "update table_SignIn set nto10='" + nine + "'where id='" + Convert.ToInt32(field_val) + "'";
                int a = Connection.sqlquery(s);
            //    s = "update table_SignIn set count='" + (Convert.ToInt32(c) - 1) + "' where type='"+nine+"'";
            //    a = Connection.sqlquery(s);
                
            //}

        }
        if (ten != null)
        {
            //string sl = "select count from table_SignIn where type='" + ten + "'";
            //string c = Connection.scalar(sl);
            //if (Convert.ToInt32(c) == 0)
            //{

    //           }
            //else
            //{
                
                string s = "update table_SignIn set tto12='" + ten + "' where id='" + Convert.ToInt32(field_val) + "'";
                int a = Connection.sqlquery(s);
            //    s = "update table_SignIn set count='" + (Convert.ToInt32(c) - 1) + "' where type='"+ten+"'";
            //    a = Connection.sqlquery(s);
            //}
        }
        if (one != null)
        {
            //string sl = "select count from table_SignIn where type='" + one + "'";
            //string c = Connection.scalar(sl);
            //if (Convert.ToInt32(c) == 0)
            //{

            //}
            //else
            //{
                string s = "update table_SignIn set oto2='" + one + "' where id='" + Convert.ToInt32(field_val) + "'";
                int a = Connection.sqlquery(s);
            //    s = "update table_SignIn set count='" + (Convert.ToInt32(c) - 1) + "' where type='"+one+"'";
            //    a = Connection.sqlquery(s);
            //}
        }
        if (two != null)
        {
            //string sl = "select count from table_SignIn where type='" + two + "'";
            //string c = Connection.scalar(sl);
            //if (Convert.ToInt32(c) == 0)
            //{

            //}
            //else
            //{
                string s = "update table_SignIn set twto3='" + two + "' where id='" + Convert.ToInt32(field_val) + "'";
                int a = Connection.sqlquery(s);
            //    s = "update table_SignIn set count='" + (Convert.ToInt32(c) - 1) + "' where type='"+two+"'";
            //    a = Connection.sqlquery(s);
            //}
        }

        Response.Redirect("Student.aspx");

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