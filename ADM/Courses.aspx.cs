using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Courses : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();

    void bindGrid()
    { 
        string sql=@"SELECT     Courses_ID as 'Course ID', Courses_Name 'Course'
            FROM         TblCourses";
        DataTable dt = cls.GetDataTable(sql);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null || Session["UserId"].ToString() == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            bindGrid();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "insert into TblCourses(Courses_Name)values('"+txtCourse.Text.Trim()+"')";
            if (cls.ExecuteSql(sql) > 0)
            {
                txtCourse.Text = "";
                lblmsg.Text = "You are successfully registered";
                bindGrid();
            }
            
        }
        catch (Exception ex) { }
    }
}