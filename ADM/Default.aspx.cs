using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class OPT_Default : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void bindgrid()
    {
        string sql = @"select TblCourses.Courses_Name Class,isNull(R.M,0) as Male

,isNull(R.F,0) as Female,isNull(R.T,0) as Transgender,isNull(R.Total,0) as Total
 from TblCourses left outer join (
select Courses_ID,COUNT(*) as Total,

sum(case gender when 'M' then 1 else 0  end)as M ,
sum(case gender when 'F' then 1 else 0  end)as F ,
sum(case gender when 'T' then 1 else 0  end)as T 
from Registration group by Courses_ID

) as R on R.Courses_ID=TblCourses.Courses_ID";

        DataTable dt = cls.GetDataTable(sql);
        gvdata.DataSource = dt;
        gvdata.DataBind();
       

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
}