using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin : System.Web.UI.Page
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
            string a, b, c, d;
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
                d = dr[4].ToString();
                lbl_neyty.Text = d;
                dr.Close();

            }


        }
    }

    protected void btn_cpass_Click(object sender, EventArgs e)
    {
        string field_val = (string)Session["field1"];
        string str = "select password from table_SignIn where id='" + field_val + "'";
        string pass = Connection.scalar(str);

        if (txt_expass.Text == pass)
        {
            if (txt_npass.Text == txt_cpass.Text)
            {
                string nstr = "update table_SignIn set password='" + txt_npass.Text + "' where id='" + Convert.ToInt32(field_val) + "'";
                int a = Connection.sqlquery(nstr);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Successfully Changed');", true);

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Not Matching');", true);

            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Existing Password');", true);

        }

    }


    protected void btn_logout_Click(object sender, EventArgs e)
    {
        Session["log"] = "";

        /* Response.Cache.SetCacheability(HttpCacheability.NoCache);
         Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
         Response.Cache.SetNoStore();*/
        Response.Redirect("http://localhost:3263/Signup.aspx");
    }
    protected void btn_list_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        string type_val = (string)Session["type1"];
        string q = "select name as Names,srno as SRNO from table_SignIn,table_SignUp where (nto10='" + type_val + "' or tto12='" + type_val + "' or oto2='" + type_val + "' or twto3='" + type_val + "') and table_SignUp.id=table_SignIn.id";
        DataTable dt = new DataTable();
        dt = Connection.dt(q);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btn_chpass_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
   
}