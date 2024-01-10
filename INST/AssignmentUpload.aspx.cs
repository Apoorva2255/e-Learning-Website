using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class AssignmentUpload : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();

    void BindSubject()
    {


        string sql = @"SELECT     SubjectCode, SubjectName
                FROM         TblSubject";
        DataTable dt = cls.GetDataTable(sql);
        ddlSubject.DataSource = dt;
        ddlSubject.DataTextField = "SubjectName";
        ddlSubject.DataValueField = "SubjectCode";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("-select-", "0"));
        

    }
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
        ddlsession.Items.Insert(0, new ListItem("-select-", "0"));
        


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
        string sql = @"SELECT TblAssignmentUpload.ID, TblAssignmentUpload.Subject as SubjectName, substring(TblAssignmentUpload.DocumentPath,16,150) as DocumentPath, TblAssignmentUpload.Date, TblAssignmentUpload.SessionId,
 TblAssignmentUpload.Courses_ID, TblAssignmentUpload.SemSl, TblAssignmentUpload.UsrId, TblCourses.Courses_Name  AS Class_Name, 
 tblSemester.SemName,Tblsession.SessionName as SessionName FROM TblAssignmentUpload
  LEFT OUTER JOIN tblSemester ON TblAssignmentUpload.SemSl = tblSemester.SemSl
  INNER JOIN TblCourses ON TblAssignmentUpload.Courses_ID = TblCourses.Courses_ID
   INNER JOIN Tblsession ON TblAssignmentUpload.SessionId = Tblsession.SessionId  where TblAssignmentUpload.UsrId='" + Session["UserId"].ToString().Trim() + "'";
      //Response.Write(sql);
        DataTable dt = cls.GetDataTable(sql);
      
        GridView4.DataSource = dt;
        GridView4.DataBind();
    
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
            BindSubject();
        }
    }

    void insert()
    {
        if (FileUpload1.HasFile)
            UploadDoc();
        string sql = @"insert into TblAssignmentUpload(Subject, DocumentPath, SessionId, Courses_ID, SemSl, UsrId,SubjectCode)values(
                    '" + txttitle.Text.Trim() + "','" + ViewState["PhotoName"].ToString().Trim() + "'," + ddlsession.SelectedValue.Trim() + "," + ddlclass.SelectedValue.Trim() + "," + ddlsem.SelectedValue.Trim() + ",'" + Session["UserId"].ToString().Trim()+"',"+ddlSubject.SelectedValue.Trim()+")";
        if (cls.ExecuteSql(sql) > 0)
        {
            bindgrid();
            lblMsg.Text = "Assignment saved..!!";
        }
        else
        {
            lblMsg.Text = "Please tray again..!!";
        }

    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        insert();
    }

    private string InsSaveFile(string fileName, FileUpload fuFile)
    {
        string serverFileName = string.Empty;
        string uploadDirectory = string.Empty;
        try
        {
            uploadDirectory = "~//Assignment//";


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