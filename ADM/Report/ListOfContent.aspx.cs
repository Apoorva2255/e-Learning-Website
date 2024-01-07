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
        strWhere = " where TblCreateContent.CreatedDate between '" + txtfrom.Text.Trim() + "' and '" + txtTo.Text.Trim() + "'";

        string sql = @"SELECT     TblCreateContent.CreatedDate,TblCreateContent.ID, TblCreateContent.SessionId, TblCreateContent.Class_ID, TblCreateContent.SemSl, TblCreateContent.Title, TblCreateContent.CreatedDate, TblCreateContent.UsrId, 
                      TblCreateContent.Upload, TblCourses.Courses_Name  AS Class_Name, tblSemester.SemName, Tblsession.SessionName
FROM         TblCreateContent INNER JOIN
                      TblCourses ON TblCreateContent.Class_ID = TblCourses.Courses_ID INNER JOIN
                      tblSemester ON TblCreateContent.SemSl = tblSemester.SemSl INNER JOIN
                      Tblsession ON TblCreateContent.SessionId = Tblsession.SessionId " + strWhere;
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