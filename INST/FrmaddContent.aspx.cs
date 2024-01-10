using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

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
        string sql = @"SELECT     TblCreateContent.ID, TblCreateContent.SessionId, TblCreateContent.Class_ID, TblCreateContent.SemSl, TblCreateContent.Title, TblCreateContent.CreatedDate, TblCreateContent.UsrId, 
                      substring( TblCreateContent.Upload,13,150)as Upload, tblSemester.SemName, Tblsession.SessionName, TblCourses.Courses_Name
FROM         TblCreateContent INNER JOIN
                      tblSemester ON TblCreateContent.SemSl = tblSemester.SemSl INNER JOIN
                      Tblsession ON TblCreateContent.SessionId = Tblsession.SessionId INNER JOIN
                      TblCourses ON TblCreateContent.Class_ID = TblCourses.Courses_ID where TblCreateContent.UsrId='" + Session["UserId"].ToString().Trim() + "'";

       // Response.Write(sql);
        DataTable dt = cls.GetDataTable(sql);

        gvdata.DataSource = dt;
        gvdata.DataBind();

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

        txttitle.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
                UploadDoc();

            string sql = @"insert into TblCreateContent(Title, SessionId, Class_ID, SemSl,   UsrId, Upload)
                    values('" + txttitle.Text.Trim() + "'," + ddlsession.SelectedValue.Trim() + "," + ddlclass.SelectedValue.Trim() + "," + ddlsem.SelectedValue.Trim() + ",'" + User.Identity.Name + "','"+ ViewState["PhotoName"].ToString().Trim() + "')";
            //Response.Write(sql);
            if (cls.ExecuteSql(sql) > 0)
            {
                lblMsg.Text = "Content saved..!!";
                bindgrid();
            }
            else
            {
                lblMsg.Text = "Please tray again..!!";
            }
        }
        catch (Exception ex) { }
    }

    private string InsSaveFile(string fileName, FileUpload fuFile)
    {
        string serverFileName = string.Empty;
        string uploadDirectory = string.Empty;
        try
        {
            uploadDirectory = "~//Content//";


            if (!Directory.Exists(Server.MapPath(uploadDirectory)))
            {
                Directory.CreateDirectory(Server.MapPath(uploadDirectory));
            }

            if (fuFile.PostedFile.FileName != "")
            {
                UploadFile(fuFile, uploadDirectory, fileName);
                string extension = Path.GetExtension(fuFile.PostedFile.FileName);

                serverFileName = Path.GetFileName(fileName + extension);

            }

        }
        catch (Exception ee)
        {

        }
        return uploadDirectory + serverFileName;
    }



    private void UploadFile(FileUpload Uploader, string uploadDirectory, string fileName)
    {
        string extension = Path.GetExtension(Uploader.PostedFile.FileName);
        string serverFileName = Path.GetFileName(fileName + extension);
        string fullUploadPath = Path.Combine(Server.MapPath(uploadDirectory), serverFileName);
        string fullUploadPathToDelete3 = Path.Combine(Server.MapPath(uploadDirectory), fileName + ".pdf");
        try
        {

            if (File.Exists(fullUploadPathToDelete3))
                File.Delete(fullUploadPathToDelete3);

            Uploader.PostedFile.SaveAs(fullUploadPath);
            string rpath = uploadDirectory + "/" + serverFileName;
        }
        catch (Exception err)
        {
            lblMsg.Text = "Oops!! error occured : " + err.Message.ToString();
        }
    }



    bool validateFile(FileUpload fuFile, string FileType)
    {
        if (fuFile.HasFile)
        {
            int contentLength = fuFile.PostedFile.ContentLength;
            string extension = Path.GetExtension(fuFile.PostedFile.FileName);
            int count = fuFile.FileName.Split('.').Length - 1;
            if (count > 1)
            {
                return false;
                // Display error message to prevent double extension...  
            }

            switch (FileType)
            {
                case "zip":
                    switch (extension.ToLower())
                    {
                        case ".zip":
                            break;
                        default:
                            lblMsg.Text = "This file type is not allowed.";
                            // ClientScript.RegisterStartupScript(this.GetType(), "msgFu", "alert('This file type is not allowed.');", true);
                            return false;
                    }

                    if (contentLength > (1 * 1024 * 1024))
                    {
                        lblMsg.Text = "File size must be less than or equal to 1 MB";
                        return false;
                    }
                    break;
                case "doc":

                    switch (extension.ToLower())
                    {
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".pdf":
                            break;
                        default:
                            lblMsg.Text = "This file type is not allowed.";
                            // ClientScript.RegisterStartupScript(this.GetType(), "msgFu", "alert('This file type is not allowed.');", true);
                            return false;
                    }
                    if (contentLength > (0.4 * 1024 * 1024))
                    {
                        lblMsg.Text = "File size must be less than or equal to 400KB";
                        return false;
                    }
                    break;

                default: lblMsg.Text = "Unknown File Type !!";
                    return false;
            }
        }
        return true;
    }





    void UploadDoc()
    {
        if (!validateFile(FileUpload1, "doc"))
            return;

        string _photoname = string.Empty;
        if (FileUpload1.HasFile)
        {
            _photoname = InsSaveFile("Photo_" + DateTime.Now.ToString("yyyyMMddhmmss").Trim() + "", FileUpload1);
            ViewState["PhotoName"] = _photoname;

        }



    }
}