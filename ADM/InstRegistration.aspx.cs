using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class InstRegistration : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();

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
    void bindGrid()
    {
        string sql = @"SELECT   Name, Email, MobileNo, DOj, Cdate, CreatedBy, IsActive
        FROM         TblFacultyDetails";
        DataTable dt = cls.GetDataTable(sql);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    void clear()
    {
        txtName.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtEmail.Text = string.Empty;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text.Length == 0)
            {
                lblmsg.Text = "Enter name";
                return;
            }

            if (txtMobile.Text.Length == 0)
            {
                lblmsg.Text = "Enter Mobile";
                return;
            }
            string sql = "insert into TblFacultyDetails(Name, Email, MobileNo, DOj,CreatedBy)values('" + txtName.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtMobile.Text.Trim() + "','" + txtdoj.Text.Trim() + "','"+User.Identity.Name+"')";
            if (cls.ExecuteSql(sql) > 0)
            {
                sql = @"insert into UserLogin(UserId, Name, Password, Role,  IsActive)

                    values('" + txtMobile.Text.Trim() + "','" + txtName.Text.Trim() + "','123456','INST','Y')";
                cls.ExecuteSql(sql);
                clear();
               // Response.Write(sql);
                lblmsg.Text = "You are successfully registered";
                bindGrid();
            }

        }
        catch (Exception ex) { }

    }
}