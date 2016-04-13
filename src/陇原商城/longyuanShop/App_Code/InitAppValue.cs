using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
///InitAppValue 的摘要说明
/// </summary>
public class InitAppValue
{
    public InitAppValue()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void BindGlobalData_app()
    {
        int YearNum = DateTime.Now.Year, stateValue = YearNum - 60;
        IList list = new ArrayList();
        for (int i = stateValue; i <= YearNum; i++)
        {
            list.Add(i);
        }
        HttpContext.Current.Application["myYearList"] = list;


        DataSet ds1 = new DataSet();
        ds1.ReadXml(HttpContext.Current.Server.MapPath("~/xml/DanWeiList.xml"));
        HttpContext.Current.Application["shopDanWeiList"] = ds1;

        DataSet ds2 = new DataSet();
        ds2.ReadXml(HttpContext.Current.Server.MapPath("~/xml/QQList.xml"));
        HttpContext.Current.Application["shopQQList"] = ds2;

        DataSet ds3 = new DataSet();
        ds3.ReadXml(HttpContext.Current.Server.MapPath("~/xml/HelpClass.xml"));
        HttpContext.Current.Application["helpInfoList"] = ds3;
    }
}
