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
        string sql = @"SELECT     TblAssignmentUpload.ID, TblAssignmentUpload.Subject, TblAssignmentUpload.DocumentPath, TblAssignmentUpload.Date, TblAssignmentUpload.SessionId, TblAssignmentUpload.Class_ID, 
                      TblAssignmentUpload.SemSl, TblAssignmentUpload.UsrId, tblSemester.SemName, TblCourses.Courses_Name
FROM         TblAssignmentUpload INNER JOIN
                      tblSemester ON TblAssignmentUpload.SemSl = tblSemester.SemSl INNER JOIN
                      Tblsession ON TblAssignmentUpload.SessionId = Tblsession.SessionId INNER JOIN
                      TblCourses ON TblAssignmentUpload.Class_ID = TblCourses.Courses_ID";
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