using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    clsDataAccess _obj = new clsDataAccess();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Login_Click(object sender, EventArgs e)
    {
        string sql = @"SELECT     UserLogin.UserId, UserLogin.Name, UserLogin.Password, UserLogin.Role, UserLogin.CreateDate, UserLogin.IsActive, Registration.ID AS REGNO, Registration.Courses_ID, Registration.Semester, 
                      Registration.Session, Tblsession.SessionName, TblCourses.Courses_Name, Tblsession.SessionId
FROM         Tblsession INNER JOIN
                      Registration ON Tblsession.SessionId = Registration.Session left outer JOIN
                      TblCourses ON Registration.Courses_ID = TblCourses.Courses_ID RIGHT OUTER JOIN
                      UserLogin ON Registration.ContactNo = UserLogin.UserId where UserLogin.IsActive='Y' 
                        and UserLogin.UserId='" + TxtUN.Text.Trim() + "' and UserLogin.Password='" + TxtPass.Text.Trim() + "'";
        string Url = string.Empty;
        //Response.Write(sql);
        DataTable dt = _obj.GetDataTable(sql);
        if (dt.Rows.Count > 0)
        {
            Session["SessionId"] = dt.Rows[0]["SessionId"].ToString().Trim();
            Session["Courses_ID"] = dt.Rows[0]["Courses_ID"].ToString().Trim();
            Session["SessionName"] = dt.Rows[0]["SessionName"].ToString().Trim();
            Session["Courses_Name"] = dt.Rows[0]["Courses_Name"].ToString().Trim();
            Session["Semester"] = dt.Rows[0]["Semester"].ToString().Trim();
            Session["REGNO"] = dt.Rows[0]["REGNO"].ToString().Trim();
            Session["Role"] = dt.Rows[0]["Role"].ToString().Trim();
            Session["UserId"] = dt.Rows[0]["UserId"].ToString().Trim();
            Session["Name"] = dt.Rows[0]["Name"].ToString().Trim();
            Session["Semester"] = dt.Rows[0]["Semester"].ToString().Trim();
            if (Session["Role"].ToString().Trim() == "ADM")
            {
                Url = "ADM/Default.aspx";
            }
            else if (Session["Role"].ToString().Trim() == "STD")
            {
                Url = "STD/Default.aspx";
            }
            else if (Session["Role"].ToString().Trim() == "INST")
            {
                Url = "INST/Default.aspx";
            }
            else
            {
                Url = "Login.aspx";
            }

            FormsAuthentication.Initialize();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, TxtUN.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(30), false, dt.Rows[0]["Role"].ToString().Trim(), FormsAuthentication.FormsCookiePath);

            // Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); // Hashed ticket

            // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            // Add the cookie to the list for outgoing response
            Response.Cookies.Add(cookie);

            Response.Redirect(Url);
        }
    }
}