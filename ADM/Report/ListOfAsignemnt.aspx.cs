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
        string strWhere = string.Empty;
        strWhere = " where TblAssignmentUpload.date between '"+txtfrom.Text.Trim()+"' and '"+txtTo.Text.Trim()+"'";
        string sql = @"SELECT TblAssignmentUpload.ID, TblAssignmentUpload.Subject, substring(TblAssignmentUpload.DocumentPath,16,150) as DocumentPath, TblAssignmentUpload.Date, TblAssignmentUpload.SessionId,
 TblAssignmentUpload.Courses_ID, TblAssignmentUpload.SemSl, TblAssignmentUpload.UsrId, TblCourses.Courses_Name  AS Class_Name, 
 tblSemester.SemName FROM TblAssignmentUpload
  LEFT OUTER JOIN tblSemester ON TblAssignmentUpload.SemSl = tblSemester.SemSl
  INNER JOIN TblCourses ON TblAssignmentUpload.Courses_ID = TblCourses.Courses_ID
   INNER JOIN Tblsession ON TblAssignmentUpload.SessionId = Tblsession.SessionId 
 " + strWhere;

       // Response.Write(sql);
        DataTable dt = cls.GetDataTable(sql);
        gvData.DataSource = dt;
        gvData.DataBind();

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
    protected void lnkserach_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}