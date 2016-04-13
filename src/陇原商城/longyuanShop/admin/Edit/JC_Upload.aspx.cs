using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.IO;

namespace ShopAdmin.Edit
{
    public partial class JC_Upload : System.Web.UI.Page
    {
        XmlDocument doc = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //btn_upload.Attributes.Add("onclick", "parent.Loading()");
            if (!IsPostBack)
            {
                Session["FileType"] = Request.QueryString["type"];
                resultPanel.Visible = false;
            }
        }

        /// <summary>
        /// 上传操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string UpLoadPath = GetConfigInfo("UpLoadPath", "config.config");
            if (!Object.Equals(Session["FileType"], null))
            {
                if (Session["FileType"].ToString() == "image")
                {
                    SaveAs(UpLoadPath, "UpImage");
                }
                else if (Session["FileType"].ToString() == "vedio")
                {
                    SaveAs(UpLoadPath, "UpVedio");
                }
                else if (Session["FileType"].ToString() == "flash")
                {
                    SaveAs(UpLoadPath, "UpFlash");
                }
                else
                {
                    SaveAs(UpLoadPath, "UpOther");
                }
            }
            else
            {
                Response.Write("<script>alert('上传类型参数传递错误！')</script>");
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="UpLoadPath">路径</param>
        /// <param name="FileType">文件类型</param>
        private void SaveAs(string UpLoadPath, string FileType)
        {
            bool UpFileOk = false;
            string[] AllowFileExtensions = null;
            if (FileUpload1.HasFile)
            {
                string currectFileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                AllowFileExtensions = GetConfigInfo(FileType, "config.config").Split('|');
                for (int i = 0; i < AllowFileExtensions.Length; i++)
                {
                    if (currectFileExtension == AllowFileExtensions[i].ToLower())
                    {
                        UpFileOk = true;
                        break;
                    }
                }
            }
            if (UpFileOk)
            {
                if (Directory.Exists(Server.MapPath(UpLoadPath)))
                {
                    try
                    {
                        string nam = FileUpload1.FileName;
                        //取得文件名(抱括路径)里最后一个"."的索引
                        int i = nam.LastIndexOf(".");
                        //取得文件扩展名
                        string newext = nam.Substring(i);
                        //这里我自动根据日期和文件大小不同为文件命名,确保文件名不重复
                        DateTime now = DateTime.Now;
                        string newname = now.ToString("yyyyMMdd") + FileUpload1.PostedFile.ContentLength.ToString();
                        //改写区域
                        FileUpload1.SaveAs(Server.MapPath(UpLoadPath + newname + newext));
                        InsertFilePath.Value = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1) + UpLoadPath + newname + newext;
                        uploadPanel.Visible = false;
                        resultPanel.Visible = true;
                    }
                    catch
                    {
                        Response.Redirect("Error.htm");
                    }
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(Server.MapPath(UpLoadPath));
                        FileUpload1.SaveAs(Server.MapPath(UpLoadPath + FileUpload1.FileName));
                        InsertFilePath.Value = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1) + UpLoadPath + FileUpload1.FileName;
                        uploadPanel.Visible = false;
                        resultPanel.Visible = true;
                    }
                    catch
                    {
                        Response.Redirect("Error.htm");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('格式不正确');history.back(-1)</script>");
            }
        }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="NodeName">节点名</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public string GetConfigInfo(string NodeName, string path)
        {
            string temp = "";
            try
            {
                doc = new XmlDocument();
                doc.Load(Server.MapPath(path));
                XmlNode xn = doc.SelectSingleNode("/UpConfig/" + NodeName);
                temp = xn.Attributes["value"].InnerText;
            }
            catch
            {
                throw new Exception("节点配置可能有误！");
            }
            return temp;

        }
    }
}
