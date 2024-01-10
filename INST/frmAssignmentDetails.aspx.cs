using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class OPT_Report_frmAssignmentDetails : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void BindData()
    {
        string sql = @"select R.Subject,substring( R.Assignment,19,150) as Assignment , Registration.ID,UserName,FatherName,ContactNo as 'MobileNo',PermanentAddress,TblCourses.Courses_Name as Class,

                case when R.RegNo is NULL then 'N' else 'Y' end as 'IsAssignment' 
,Registration.Semester

                 from Registration
                 inner join TblCourses on TblCourses.Courses_ID=Registration.Courses_ID
                left outer join(
                select distinct Assignment,RegNo,Courses_ID,SessionId,SubmitBy,Subject from TblAssignment
                ) as R on R.SubmitBy=Registration.ContactNo and R.Courses_ID=Registration.Courses_ID ";
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
            BindData();
        }
    }
}