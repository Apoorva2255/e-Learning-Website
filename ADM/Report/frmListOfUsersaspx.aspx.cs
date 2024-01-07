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

        string sql=@"SELECT     UserId, Name, Password, Role, CreateDate, IsActive
FROM          UserLogin";

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