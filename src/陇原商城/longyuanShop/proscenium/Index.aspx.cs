using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using BLL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class proscenium_Index : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["longyuanConnectionString"].ConnectionString);
    longyuan_productinfo product = new longyuan_productinfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindIsCommendShopping();  
            bindBulletin();
            BindIsCommendhotShopping();
            BindGridview();
            BindShowIndexShow();
        }
    }

    private void bindBulletin()
    {
        IList iL;
        string CacheName = "cachBulletinProduct";
        if (HttpContext.Current.Cache[CacheName] == null)
        {
            iL = new longyuan_BulletionInfo().GetBulletinList();
            HttpContext.Current.Cache.Add(CacheName, iL, null, DateTime.MaxValue, new TimeSpan(0, 5, 0, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        }
        iL = (IList)HttpContext.Current.Cache.Get(CacheName);
        if (iL.Count > 0)
        {
            rpBulletinList.DataSource = iL;
            rpBulletinList.DataBind();
        }
    }

    private void BindIsCommendShopping()
    {
        IList il;
        string CacheName = "cachIscommentProduct";
        if (HttpContext.Current.Cache[CacheName] == null)
        {
            il = new longyuan_productinfo().GetIndexBindtuiJian(0, 1, "top 8");
            HttpContext.Current.Cache.Add(CacheName, il, null, DateTime.MaxValue, new TimeSpan(0, 3, 0, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        }
        il = (IList)HttpContext.Current.Cache.Get(CacheName);
        if (il.Count > 0)
        {
            rpIsComnend.DataSource = il;
            rpIsComnend.DataBind();
        }
    }

    private void BindIsCommendhotShopping()
    {
        IList il;
        string CacheName = "cachIscommentHotProduct";
        if (HttpContext.Current.Cache[CacheName] == null)
        {
            il = new longyuan_productinfo().GetIndexBindHottuiJian(0, 1, "top 10");
            HttpContext.Current.Cache.Add(CacheName, il, null, DateTime.MaxValue, new TimeSpan(0, 3, 0, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        }
        il = (IList)HttpContext.Current.Cache.Get(CacheName);
        if (il.Count > 0)
        {
            rpIsBindHot.DataSource = il;
            rpIsBindHot.DataBind();
        }
    }

    private void BindGridview()
    {
        conn.Open();
        SqlCommand comm = new SqlCommand("p_productIndexName", conn);
        comm.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = comm.ExecuteReader();
        gvBindProductName.DataSource = dr;
        gvBindProductName.DataBind();
        conn.Close();
    }

    private void BindShowIndexShow()
    {
        //绑定服装类
        rpIsCommendDress_001.DataSource = BindIsComnendRepeater(9, 8);
        rpIsCommendDress_001.DataBind();
        ddlBindProductIndexShow.DataSource = product.GetIndexBindProductShow(9, " top 12 ");
        ddlBindProductIndexShow.DataBind();

        //绑定户外健身类
        rpIsCommendSports_001.DataSource = product.GetIndexBindProductShow(8, " top 8");
        rpIsCommendSports_001.DataBind();
        ddlBindIndexSports.DataSource = product.GetIndexBindProductShow(8, " top 12");
        ddlBindIndexSports.DataBind();

        //绑定时尚商品类
        rpBindFashionJewelryBind_001.DataSource = product.GetIndexBindProductShow(2, " top 8 ");
        rpBindFashionJewelryBind_001.DataBind();

        ddlBindFashionJewelry.DataSource = product.GetIndexBindProductShow(2, " top 12 ");
        ddlBindFashionJewelry.DataBind();

        //绑定IT数码类
        rpBindIndexITFigure_001.DataSource = BindIsComnendRepeater(1, 8);
        rpBindIndexITFigure_001.DataBind();
        ddlBindIndexITfigure.DataSource = product.GetIndexBindProductShow(1, " top 12 ");
        ddlBindIndexITfigure.DataBind();

        //绑定美容护肤类
        rpBindIndexLeftSkinBeauty_001.DataSource = BindIsComnendRepeater(4, 8);
        rpBindIndexLeftSkinBeauty_001.DataBind();
        ddlBindIndexRightSkinBeauty.DataSource = product.GetIndexBindProductShow(4, " top 12 ");
        ddlBindIndexRightSkinBeauty.DataBind();

        //绑定食品保健类
        rpBindIndexleftFood_001.DataSource = BindIsComnendRepeater(6, 8);
        rpBindIndexleftFood_001.DataBind();
        ddlBindIndesFoodRight.DataSource = product.GetIndexBindProductShow(6, " top 12 ");
        ddlBindIndesFoodRight.DataBind();

        //绑定图书音像类
        rpBindindexBook_001.DataSource = BindIsComnendRepeater(7, 8);
        rpBindindexBook_001.DataBind();
        ddlBindIndexRightbook.DataSource = product.GetIndexBindProductShow(7, " top 12 ");
        ddlBindIndexRightbook.DataBind();
    }

    private IList BindIsComnendRepeater(int IsType, int topNum)
    {
        IList il;
        string CacheName = "cachByClassIDData_" + IsType;
        if (HttpContext.Current.Cache[CacheName] == null)
        {
            il = new longyuan_productinfo().GetIndexBindProductShow(Convert.ToInt16(IsType), " top " + topNum + " ");
            HttpContext.Current.Cache.Add(CacheName, il, null, DateTime.MaxValue, new TimeSpan(0, 3, 0, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        }
        il = (IList)HttpContext.Current.Cache.Get(CacheName);
        return il;
    }
}
