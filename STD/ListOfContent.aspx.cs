using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class STD_ListOfAsignemnt : System.Web.UI.Page
{

    clsDataAccess cls = new clsDataAccess();
    void BindGrid()
    {
        string sql = @"SELECT     TblCreateContent.ID, TblCreateContent.SessionId, TblCreateContent.Class_ID, TblCreateContent.SemSl, TblCreateContent.Title, TblCreateContent.CreatedDate, TblCreateContent.UsrId, 
                     substring( TblCreateContent.Upload,13,150)as Upload ,tblSemester.SemName, Tblsession.SessionName, TblCourses.Courses_Name
                FROM         TblCreateContent INNER JOIN
                      tblSemester ON TblCreateContent.SemSl = tblSemester.SemSl INNER JOIN
                      Tblsession ON TblCreateContent.SessionId = Tblsession.SessionId INNER JOIN
                      TblCourses ON TblCreateContent.Class_ID = TblCourses.Courses_ID where TblCreateContent.Class_ID=" + Session["Courses_ID"].ToString().Trim() + " and Tblsession.SessionId=" + Session["SessionId"].ToString().Trim() + " and TblCreateContent.SemSl =" + Session["Semester"].ToString().Trim();
        DataTable dt = cls.GetDataTable(sql);
        DataList1.DataSource = dt;
        DataList1.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {

            BindGrid();
        }

    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}