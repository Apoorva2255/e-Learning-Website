using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
            if (Session["Role"].ToString().Trim() == "STD")
            {
                lblMsg.Text = "Welcome :" + Session["Name"].ToString() + "|Course :" + Session["Courses_Name"].ToString().Trim() + "|Semester :" + Session["Semester"].ToString().Trim() + " |Session :" + Session["SessionName"].ToString().Trim() + "| Dated.:" + System.DateTime.Now.ToShortDateString();
            }
            else
            {
                lblMsg.Text = "Welcome :" + Session["Name"].ToString() + " | Dated.:" + System.DateTime.Now.ToShortDateString();
            }
        

    }
}
