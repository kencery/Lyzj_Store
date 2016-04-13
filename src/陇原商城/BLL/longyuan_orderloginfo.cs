using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class longyuan_orderloginfo
    {
        longyuan_orderLog orderlog = new longyuan_orderLog();

        public int InsertOrderLog(L_OrderLogInfo orderloginfo)
        {
            return orderlog.InsertOrderLog(orderloginfo);
        }
    }
}
