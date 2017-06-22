using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Signup : System.Web.UI.Page
{
    
    Connection con = new Connection();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rbl_cat.SelectedIndex = 1;
        }
        string ty = "select type from table_SignIn";
        DataTable dr;
        dr = Connection.dt(ty);
        
            int n = dr.Rows.Count;
            for (int i = 0; i < n; i++) 
            {
                for (int j = 1; j <= 11; j++)
                {

                    if (ddl_event.Items[j].Text == dr.Rows[i][0].ToString())
                    {

                        ddl_event.Items[j].Enabled = false;
                    }
                    //else
                    //{
                    //    ddl_event.Items[j].Enabled = true;
                    //}
                }
            
            
        }
        

    }
    protected void rbl_gen_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txt_srnoup_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_up_Click(object sender, EventArgs e)
    {
        if (txt_passup.Text == txt_con.Text)
        {
            string str = "select srno from table_SignIn where srno='"+txt_srnoup.Text+"'";            
            SqlDataReader sdr;
            sdr = Connection.login(str);
            
            if (sdr.Read()==true)
            {
                 
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('SrNo Already Registered');", true);

                 sdr.Close();

            }
            else
            {
                
                    //Response.Write("<script>alert('SRNo already registered');</script>");
                    sdr.Close();
                    string s = "insert into table_SignUp(name,dob,gender) values('" + txt_name.Text + "','" + txt_dob.Text + "','" + rbl_gen.Text + "')";
                    int a = Connection.sqlquery(s);

                    s = "select max(id) from table_SignUp";

                    String iden = Connection.scalar(s);
                    if (iden != null)
                    {
                        s = "insert into table_SignIn(id,srno,password) values('" + Convert.ToInt32(iden) + "','" + txt_srnoup.Text + "','" + txt_passup.Text + "')";
                        a = Connection.sqlquery(s);

                    }


                    else
                    {
                        //Response.Write("<script>alert('invalid');</script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid');", true);

                    }
                
                
                    
                
                
            }

           

           
        }
            

        else 
        {
            //Response.Write("<script>alert('Password Not Matching');</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('password not matching');", true);
       
        }

    }
    protected void txt_dob_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_in_Click(object sender, EventArgs e)
    {
        string s = "select * from table_SignIn where srno='" + txt_srno.Text + "' AND password='" + txt_pass.Text + "'";
        SqlDataReader sdr;
        sdr = Connection.login(s);

        

        if (sdr.Read())
        {

            string a=sdr[0].ToString();
            string ty = sdr[7].ToString();
            Session["type1"] = ty;
            Session["field1"] = a;
            sdr.Close();
            Session["log"] = a;
            if (ty == "")
            {
                Response.Redirect("Student.aspx");
            }
            else 
            {
                Response.Redirect("Admin.aspx");
            }
            //Page.PreviousPage.FindControl(a) as TextBox;
            //Response.Write("<script>alert('"+a+"');</script>");
                  
        }
        else
        {
            sdr.Close();
            //Response.Write("<script>alert('password invalid');</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('password Invalid');", true);
        }
       
    }





    protected void rbl_cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rbl_cat.Text=="Admin")
        {
            rbl_cat.SelectedIndex = 0;
        }
        else
        {
            rbl_cat.SelectedIndex = 1;
        }

        if (rbl_cat.SelectedIndex == 0)
        {
            
            lbl_event.Visible = true;
            lbl_key.Visible = true;
            ddl_event.Visible = true;
            txt_key.Visible = true;
            btn_adup.Visible = true;
            btn_up.Visible = false;
            
        }
        else
        {
            
            lbl_event.Visible = false;
            lbl_key.Visible = false;
            ddl_event.Visible = false;
            txt_key.Visible = false;
            btn_adup.Visible = false;
            btn_up.Visible = true;
            
        }
    }
    protected void ddl_event_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void txt_key_TextChanged(object sender, EventArgs e)
    {

        
    }
    protected void btn_adup_Click(object sender, EventArgs e)
    {
        string ty = "select type from table_SignIn where";

        if ((ddl_event.Text == "Select any event" && ddl_event.Visible == true) || (txt_key.Text == "" && txt_key.Visible == true))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Either security key or event is not defined');", true);

        }


        

        if (txt_passup.Text == txt_con.Text)
        {
            string str = "select srno from table_SignIn where srno='" + txt_srnoup.Text + "'";
            SqlDataReader sdr;
            sdr = Connection.login(str);

            if (sdr.Read() == true)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('SrNo Alraedy Registered');", true);
                sdr.Close();

            }
            else
            {               
                sdr.Close();

                if (txt_key.Text == "123")
                {
                    string s = "insert into table_SignUp(name,dob,gender,type) values('" + txt_name.Text + "','" + txt_dob.Text + "','" + rbl_gen.Text + "','" + ddl_event.Text + "')";
                    int a = Connection.sqlquery(s);


                    s = "select max(id) from table_SignUp";

                    String iden = Connection.scalar(s);
                    if (iden != null)
                    {
                        s = "insert into table_SignIn(id,srno,password,type) values('" + Convert.ToInt32(iden) + "','" + txt_srnoup.Text + "','" + txt_passup.Text + "','"+ddl_event.Text+"')";
                        a = Connection.sqlquery(s);

                    }


                    else
                    {
                        //Response.Write("<script>alert('invalid');</script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid');", true);

                    }

                }
                else 
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Security key invalid');", true);

                }



            }




        }


        else
        {
            //Response.Write("<script>alert('Password Not Matching');</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('password not matching');", true);

        }

    }
}