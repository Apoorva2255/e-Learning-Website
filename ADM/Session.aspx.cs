using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Session : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();

    void bindGrid()
    {
        string sql = @"SELECT     SessionId as ID, SessionName  'Session'
            FROM        Tblsession";
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
            string sql = "insert into Tblsession(SessionName)values('" + txtsession.Text.Trim() + "')";
            if (cls.ExecuteSql(sql) > 0)
            {
                txtsession.Text = "";
                lblmsg.Text = "Session details Saved..!!";
                bindGrid();
            }

        }
        catch (Exception ex) { }
    }
}