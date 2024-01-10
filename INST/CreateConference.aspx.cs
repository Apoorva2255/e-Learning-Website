using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class CreateConference : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void BindClass()
    {
        string sql = @"SELECT   Courses_ID, Courses_Name
                FROM         TblCourses";
        DataTable dt = cls.GetDataTable(sql);
        ddlclass.DataSource = dt;
        ddlclass.DataTextField = "Courses_Name";
        ddlclass.DataValueField = "Courses_ID";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, new ListItem("-select-", "0"));

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

         ddlsession.Items.Insert(0,new ListItem("-select-","0"));


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
        ddlsem.Items.Insert(0, new ListItem("-select-", "0"));

    }
    void bindgrid()
    {
        string sql = @"SELECT      TblCreateConf.ID, TblCreateConf.Date, TblCreateConf.Time_from, TblCreateConf.Time_to, TblCreateConf.Url, TblCreateConf.CreatedDate, TblCreateConf.UsrId, TblCourses.Courses_ID, 
                      tblSemester.SemName, Tblsession.SessionName
FROM         TblCreateConf INNER JOIN
                      TblCourses ON TblCreateConf.Courses_ID = TblCourses.Courses_ID INNER JOIN
                      tblSemester ON TblCreateConf.SemSl = tblSemester.SemSl INNER JOIN
                      Tblsession ON TblCreateConf.SessionId = Tblsession.SessionId where TblCreateConf.UsrId='" + Session["UserId"].ToString().Trim() + "'";

       //Response.Write(sql);
        DataTable dt = cls.GetDataTable(sql);

        DataList1.DataSource = dt;
        DataList1.DataBind();

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        string url = lnk.CommandArgument.ToString();
        Response.Redirect(url);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null || Session["UserId"].ToString() == "")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindClass(); BindSession(); BindSem(); bindgrid();
        }

    }
    void clear()
    {
        txturl.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = @"insert into TblCreateConf( Date, Time_from, Time_to, SessionId, Courses_ID, SemSl, Url,UsrId)
                    values('" +txtdate.Text.Trim()+"','"+txtTimeFrom.Text.Trim()+"','"+txtTimeto.Text.Trim()+"',"+ddlsession.SelectedValue.Trim()+","+ddlclass.SelectedValue.Trim()+","+ddlsem.SelectedValue.Trim()+",'"+txturl.Text.Trim()+"','"+User.Identity.Name+"')";

            if (cls.ExecuteSql(sql) > 0)
            {
                lblMsg.Text = "Conference saved..!!";
                bindgrid();
            }
            else
            {
                lblMsg.Text = "Please try again..!!";
            }
        }
        catch (Exception ex) { }
    }
}