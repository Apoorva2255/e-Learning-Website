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
        string sql = @"SELECT    Date, Time_from, Time_to, SessionId, Courses_ID, SemSl, Url, CreatedDate, UsrId
FROM         TblCreateConf";
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