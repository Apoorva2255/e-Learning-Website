using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Registration : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void BindClass()
    {
        string sql = @"SELECT  Courses_ID, Courses_Name
FROM         TblCourses";
        DataTable dt = cls.GetDataTable(sql);
        ddlclass.DataSource = dt;
        ddlclass.DataTextField = "Courses_Name";
        ddlclass.DataValueField = "Courses_ID";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, new ListItem("-Select-", "0"));

    }
    void BindSession()
    {
        string sql = @"SELECT     SessionId, SessionName
            FROM         Tblsession";
        DataTable dt = cls.GetDataTable(sql);
        ddlsession.DataSource = dt;
        ddlsession.DataTextField = "SessionName";
        ddlsession.DataValueField = "SessionId";
        ddlsession.DataBind();

        ddlsession.Items.Insert(0, new ListItem("-Select-", "0"));


    }
    void BindSem()
    {

        string sql = @"SELECT  SemSl, SemName
            FROM         tblSemester";
        DataTable dt = cls.GetDataTable(sql);
        ddlsem.DataSource = dt;
        ddlsem.DataTextField = "SemName";
        ddlsem.DataValueField = "SemSl";
        ddlsem.DataBind();
        ddlsem.Items.Insert(0, new ListItem("-Select-", "0"));

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindSession();
            BindSem();

            BindClass();
         
        }
    }
    void clear()
    {
        txtpin.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["eLearningConStr"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from Registration where UserName='" + TextBoxUN.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                Response.Write("User already Exists");
            }

            string sql = @"insert into Registration (UserName,Email,Gender,Session, Semester,Courses_ID,FatherName,MotherName,DOB,PermanentAddress,City,Pincode,ContactNo) values 
                                ('" + TextBoxUN.Text.Trim() + "','" + txtemail.Text.Trim() + "','" + ddlgender.SelectedValue.Trim() + "'," + ddlsession.SelectedValue.Trim() + "," + ddlsem.SelectedValue.Trim() + "," + ddlclass.SelectedValue.Trim() + ",'" + txtfnm.Text.Trim() + "','" + txtmnm.Text.Trim() + "','" + txtdob.Text.Trim() + "','" + txtperadd.Text.Trim() + "','" + txtcity.Text.Trim() + "','" + txtpin.Text.Trim() + "','" + txtContactno.Text.Trim() + "')";
           // Response.Write(sql);
           if(cls.ExecuteSql(sql)>0)
            {
               
                BindSem();
                BindSession();
               sql = @"insert into UserLogin(UserId, Name, Password, Role,  IsActive)

                    values('" + txtContactno.Text.Trim() + "','" + TextBoxUN.Text.Trim() + "','" + txtpass.Text.Trim() + "','STD','Y')";
                cls.ExecuteSql(sql);
                clear();
                lblmsg.Text = "You are successfully registered";
            }
            
          
        }
        catch (Exception ex)
        {
            Response.Write("Error:"+ex.ToString());
        }
       
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}