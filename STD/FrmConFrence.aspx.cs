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
        string sql = @"SELECT     TblCreateConf.Date, TblCreateConf.Time_from, TblCreateConf.Time_to, TblCreateConf.SemSl, TblCreateConf.Url, TblCreateConf.CreatedDate, TblCreateConf.UsrId, Tblsession.SessionName, 
                      TblCourses.Courses_Name
FROM         TblCreateConf INNER JOIN
                      Tblsession ON TblCreateConf.SessionId = Tblsession.SessionId INNER JOIN
                      TblCourses ON TblCreateConf.Courses_ID = TblCourses.Courses_ID where  TblCreateConf.Courses_ID=" + Session["Courses_ID"].ToString().Trim() + " and TblCreateConf.SessionId=" + Session["SessionId"].ToString().Trim() + " and TblCreateConf.SemSl =" + Session["Semester"].ToString().Trim();
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
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        LinkButton lnk=(LinkButton)sender;
        string url = lnk.CommandArgument.ToString();
        Response.Redirect(url);
    }
}