using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class STD_frmAssignment : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    void bindGrid()
    {
        string sql = @"SELECT   RegNo,substring( Assignment,19,150) as Assignment, date, Subject
FROM         TblAssignment
 where RegNo='" + Session["REGNO"].ToString().Trim() + "'";
        DataTable dt = cls.GetDataTable(sql);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

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
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubject();
            bindGrid();
        }
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/Login.aspx");
          
        }

    }
    void clear()
    {

    }
    protected void lnkupload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
            UploadDoc();
        string sql = @"insert into TblAssignment( RegNo, Courses_ID, SemSl, SessionId, Subject, Assignment,  SubmitBy,SubjectCode
                ) values
                    ("+ Session["REGNO"].ToString().Trim()+"," + Session["Courses_ID"].ToString().Trim() + "," + Session["Semester"].ToString().Trim() + "," + Session["SessionId"].ToString().Trim() + ",'"+ddlSubject.SelectedItem.Text+"','" + ViewState["PhotoName"].ToString().Trim() + "','"+User.Identity.Name+"',"+ddlSubject.SelectedValue.Trim()+")";

         //Response.Write(sql);
        if (cls.ExecuteSql(sql) > 0)
        {
            clear();
            bindGrid();
            lblMsg.Text = "Student  Details Saved...!!";
        }
        else
        {
            lblMsg.Text = "Please Try Again..!!";
        }
    }

    private string InsSaveFile(string fileName, FileUpload fuFile)
    {
        string serverFileName = string.Empty;
        string uploadDirectory = string.Empty;
        try
        {
            uploadDirectory = "~//STDAssignment//";


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
                    if (contentLength > (1.0 * 1024 * 1024))
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