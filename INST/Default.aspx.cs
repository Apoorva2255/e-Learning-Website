using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inst_Default : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void BindGrid()
    {
        string sql = @"SELECT    Name, Email, MobileNo, DOj, Cdate, CreatedBy, IsActive
FROM         TblFacultyDetails where IsActive='Y' and MobileNo= " + Session["UserId"].ToString().Trim(); ;
        //Response.Write(sql);
        DataTable dt = cls.GetDataTable(sql);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
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