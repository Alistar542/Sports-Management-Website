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
    
    public static DataTable dtr = new DataTable();
    public static int[] vis=new int[20];
    
    

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

            string su = "select total from table_SignIn where id='"+Convert.ToInt32(field_val)+"'";
            string flag = Connection.scalar(su);
          //  int fl = Convert.ToInt32(flag);
            if (flag=="")
            {
                Label4.Visible = true;
                txt_slots.Visible = true;
                btn_sub.Visible = true;
               
            }
            else 
            {
                Label4.Visible = false;
                txt_slots.Visible = false;
                btn_sub.Visible = false;
                
            }
            try
            {
                dtr.Columns.Add("Srno");
                dtr.Columns.Add("Name");
                dtr.Columns.Add("Type");
                dtr.Columns.Add("Prize");
            }
            catch (Exception ex)
            { 
            
            }
            string type_val=Session["type1"].ToString();
            string sw = "select count(srno) from table_Prize where type='"+type_val+"'";
            int nu = Convert.ToInt32(Connection.scalar(sw));
            if (nu > 0)
            {
                sw = "select srno,name,type,prize from table_Prize where type='"+type_val+"'";
                DataTable dtm = new DataTable();
                dtm = Connection.dt(sw);
                GridView3.DataSource = dtm;
                GridView3.DataBind();
                
                GridView2.Visible = false;
                btn_subprize.Visible = false;
                btn_undo.Visible = false;
            }

            //string mal;
            //int ab;
            //string type_val = (string)Session["type1"];
            string m = "select sub from table_SignIn where type='" + type_val + "'";
            string s = Connection.scalar(m);
            if (s == "1")
            {
                //mal = "update table_SignIn set sub=0 where type='" + type_val + "'";
                //a = Connection.sqlquery(mal);
                btn_out.Text = "Time In";
            }

            if (s == "0" || s == "")
            {
                //mal = "update table_SignIn set sub=1 where type='" + type_val + "'";
                //a = Connection.sqlquery(mal);
                btn_out.Text = "Time Out";
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

    protected void txt_slots_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_sub_Click(object sender, EventArgs e)
    {
        int slots;
        string field_val = (string)Session["field1"];
        slots = Convert.ToInt32(txt_slots.Text);
        string sl = "update table_SignIn set total='"+slots+"' where( id='"+Convert.ToInt32(field_val)+"')";
        int a = Connection.sqlquery(sl);
        Response.Redirect("Admin.aspx");

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_pr_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        string type_val = (string)Session["type1"];
        
        string q = "select name,srno from table_SignIn,table_SignUp where (nto10='" + type_val + "' or tto12='" + type_val + "' or oto2='" + type_val + "' or twto3='" + type_val + "') and table_SignUp.id=table_SignIn.id";
        DataTable dt = new DataTable();
        dt = Connection.dt(q);
        GridView2.DataSource = dt;
        GridView2.DataBind();
        for (int i = 0; i < GridView2.Rows.Count; i++)
        { 

            if(vis[i]==1)
            {
                GridView2.Rows[i].Visible = false;
                //vis[i] = 0;
                
            }
        
        }
            
            
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iden=0;
        int index = Convert.ToInt32(e.CommandArgument);
        int srno=Convert.ToInt32(GridView2.DataKeys[index].Values[0].ToString());
        string na = "select srno,type,Id from table_SignIn where srno='"+srno+"'";
        SqlDataReader dr;
        dr = Connection.login(na);
        string type_val = (string)Session["type1"];
        
        if (dr.Read())
        {
            int srn=Convert.ToInt32(dr[0].ToString());


            iden = Convert.ToInt32(dr[2].ToString());
            dr.Close();
            na = "select name from table_SignUp where Id='" + iden + "'";
            SqlDataReader nm = Connection.login(na);
            if (nm.Read())
            {

                dtr.Rows.Add(srn, nm[0].ToString(), type_val, e.CommandName);
            }
            nm.Close();

        }
        

        
        //string pr = e.CommandName;
        //Session["pro"] = pr;
        
        //int fl=visbtn(pr); 
        GridView3.DataSource = dtr;
        GridView3.DataBind();
        try
        {

            if (e.CommandName == "First")
            {
                GridView2.Columns[1].Visible = false;
                GridView2.Rows[index].Visible = false;
                vis[index] = 1;
            }
            if (e.CommandName == "Second")
            {
                GridView2.Columns[2].Visible = false;
                GridView2.Rows[index].Visible = false;
                vis[index] = 1;
            }
            if (e.CommandName == "Third")
            {
                GridView2.Columns[3].Visible = false;
                GridView2.Rows[index].Visible = false;
                vis[index] = 1;
            }
        }

        catch (Exception ex)
        { 
        
        }
       
    
    
    }


    protected void btn_undo_Click(object sender, EventArgs e)
    {
        int gvHasRows = GridView3.Rows.Count;
        if (gvHasRows > 0)
        {
            GridView3.Columns.Clear();
            GridView3.DataBind();
            
            
            dtr.Clear();
            for (int i = 0; i < GridView2.Columns.Count; i++)
            {
                GridView2.Columns[i].Visible = true;
                vis[i] = 0;
            }
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                GridView2.Rows[i].Visible = true;
            }

                

            
        }
 
    }


    protected void btn_subprize_Click(object sender, EventArgs e)
    {
        DataTable dm;
        //dm = GridView3.DataSource;
        string str;
        
        for(int i=0;i<dtr.Rows.Count;i++)
        {
            str = "insert into table_Prize values('" + GridView3.Rows[i].Cells[0].Text + "','" + GridView3.Rows[i].Cells[1].Text + "','" + GridView3.Rows[i].Cells[2].Text + "','"+ GridView3.Rows[i].Cells[3].Text +"')";
            int a = Connection.sqlquery(str);
        }
        Response.Redirect("Admin.aspx");




        //foreach( row in )
        
    }
    protected void btn_out_Click(object sender, EventArgs e)
    {
        string mal;
        int a;
        string type_val=(string)Session["type1"];
        string m = "select sub from table_SignIn where type='"+type_val+"'";
        string s =  Connection.scalar(m);
        if (s == "1")
        {
            mal = "update table_SignIn set sub=0 where type='" + type_val + "'";
            a = Connection.sqlquery(mal);
            //btn_out.Text = "Time Out";
        }

        if (s == "0" || s=="")
        {
            mal = "update table_SignIn set sub=1 where type='" + type_val + "'";
            a = Connection.sqlquery(mal);
            //btn_out.Text = "Time In";
        }
        Response.Redirect("Admin.aspx");
        
        //string m = "insert into table_SignIn (sub) values('"+1+"') where type='"+type_val+"' ";
        

    }
}