using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class STD_Default : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void BindGrid()
    {
        string sql = @"SELECT  Registration.ID, Registration.UserName 'Name', Registration.Email, Registration.Gender,  Registration.FatherName as 'Fathers Name', 
                      Registration.MotherName as 'Mothers Name', Registration.DOB, Registration.PermanentAddress, Registration.City, Registration.Pincode 'Pin',  Registration.ContactNo,  
                      TblCourses.Courses_Name 'Course', tblSemester.SemName 'Semester', Tblsession.SessionName 'Session'
                FROM         Registration INNER JOIN
                      TblCourses ON Registration.Courses_ID = TblCourses.Courses_ID INNER JOIN
                      tblSemester ON Registration.Semester = tblSemester.SemSl INNER JOIN
                      Tblsession ON Registration.Session = Tblsession.SessionId where Registration.ID=" + Session["REGNO"].ToString().Trim(); ;
        //Response.Write(sql);
        DataTable dt = cls.GetDataTable(sql);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();

        sql = @"SELECT  TblAssignmentUpload.ID, substring(TblAssignmentUpload.DocumentPath,16,150) as DocumentPath, Tblsession.SessionName, TblSubject.SubjectName, tblSemester.SemName, TblCourses.Courses_Name, 
                      TblAssignmentUpload.Subject, TblAssignmentUpload.Courses_ID, TblAssignmentUpload.SessionId, TblAssignmentUpload.SemSl
                FROM         TblAssignmentUpload INNER JOIN
                      tblSemester ON TblAssignmentUpload.SemSl = tblSemester.SemSl INNER JOIN
                      TblSubject ON TblAssignmentUpload.SubjectCode = TblSubject.SubjectCode INNER JOIN
                      TblCourses ON TblAssignmentUpload.Courses_ID = TblCourses.Courses_ID INNER JOIN
                      Tblsession ON TblAssignmentUpload.SessionId = Tblsession.SessionId where TblAssignmentUpload.Courses_ID=" + Session["Courses_ID"].ToString() + " and  TblAssignmentUpload.SemSl=" + Session["Semester"].ToString();
         DataTable dtlassign = cls.GetDataTable(sql);
       //  Response.Write(sql);
         DataList1.DataSource = dtlassign;
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
}