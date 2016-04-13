using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_tool_myPagelist : System.Web.UI.UserControl
{
    private int _curpage = 0;
    private int _totalpage = 0;
    public int CurPage
    {
        set
        {
            this._curpage = value;
        }
        get
        {
            return this._curpage;
        }

    }
    public int TotalPage
    {
        set
        {
            this._totalpage = value;
        }
        get
        {
            return this._totalpage;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowPageLink();
        }
    }
    private void ShowPageLink()
    {
        string CurrUrl = "";
        string url = HttpContext.Current.Request.Url.PathAndQuery;
        int index = url.IndexOf("p=");
        int oo = url.IndexOf("?");
        int ooo = url.IndexOf("&");
        if (oo != -1)
        {
            if (ooo != -1)
            {
                if (index != -1)
                {
                    string url1 = url.Substring(0, index);
                    string url2 = url.Substring(index);
                    index = url2.IndexOf("&");
                    if (index != -1)
                        url = url1 + url2.Substring(index + 1);
                    else
                        url = url1.Substring(0, url1.Length - 1);

                }
                CurrUrl = url + "&p=";
            }
            else
            {
                if (index <= 0)
                {
                    CurrUrl = url + "&p=";
                }
                else
                {
                    string url5 = url.Substring(0, index);
                    CurrUrl = url5 + "p=";
                }
            }
        }
        else
        {
            CurrUrl = url + "?p=";
        }

        CurPageLabel.Text = this._curpage.ToString();
        PageCountLabel.Text = this._totalpage.ToString();

        if (this._curpage > this._totalpage) this._curpage = this._totalpage;
        if (this._curpage < 1) this._curpage = 1;
        if (this._curpage == 1)
        {
            IndexPage.Visible = false;
            PrevPage.Visible = false;
        }
        else
        {
            IndexPage.NavigateUrl = CurrUrl + "1";
            PrevPage.NavigateUrl = CurrUrl + (this._curpage - 1);
        }
        if (this._curpage == this._totalpage)
        {
            LastPage.Visible = false;
            NextPage.Visible = false;
        }
        else
        {
            NextPage.NavigateUrl = CurrUrl + (this._curpage + 1);
            LastPage.NavigateUrl = CurrUrl + this._totalpage.ToString();

        }

        int startPage;
        int endPage;
        int ShowPageCount = 10;
        int CurrPagePlace = 3;
        if (this._totalpage < ShowPageCount || this._curpage <= CurrPagePlace)
        {
            startPage = 1;
            endPage = ShowPageCount;
            if (endPage > this._totalpage) endPage = this._totalpage;
        }
        else
        {
            if (this._totalpage - this._curpage <= (ShowPageCount - CurrPagePlace))
            {
                startPage = this._totalpage - (ShowPageCount - 1);
                endPage = this._totalpage;
            }
            else
            {
                startPage = this._curpage - (CurrPagePlace - 1);
                endPage = this._curpage + (ShowPageCount - CurrPagePlace);
            }
        }
        for (int i = startPage; i <= endPage; i++)
        {
            if (this._curpage == i)
            {
                NumberPage.Text += "<span class=\"hui\">" + i + "</span>" + "&nbsp;&nbsp;";
            }
            else
            {
                NumberPage.Text += "<a href='" + CurrUrl + i + "'>" + i + "</a>" + "&nbsp;&nbsp;";
            }
        }
    }
}
