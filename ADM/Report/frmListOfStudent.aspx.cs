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
        strWhere = " where Registration.Cdate between '" + txtfrom.Text.Trim() + "' and '" + txtTo.Text.Trim() + "'";

        string sql = @"SELECT     Registration.UserName, Registration.Email, Registration.Gender, Registration.Semester, Registration.FatherName, Registration.MotherName, Registration.DOB, Registration.PermanentAddress, 
                      Registration.City, Registration.Pincode, Registration.Password, Registration.ContactNo, Tblsession.SessionName, TblCourses.Courses_Name
FROM         Registration INNER JOIN
                      Tblsession ON Registration.Session = Tblsession.SessionId INNER JOIN
                      TblCourses ON Registration.Courses_ID = TblCourses.Courses_ID " + strWhere;
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