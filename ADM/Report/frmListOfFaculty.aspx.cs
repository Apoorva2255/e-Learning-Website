using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ADM_Report_frmListOfUsersaspx : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();

    void bindGrid()
    {
        string sql = @"SELECT      Name, Email, MobileNo, DOj, Cdate, CreatedBy, IsActive
FROM         TblFacultyDetails";

        DataTable dt = new DataTable(sql);
        dt = cls.GetDataTable(sql);
        Gvdata.DataSource = dt;
        Gvdata.DataBind();
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
        }

    }
}