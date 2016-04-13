using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class longyuan_OrderListInfo
    {
        longyuan_OrderList order = new longyuan_OrderList();

        public int AddUserOrderItem(L_OrderListInfo orderlistinfo)
        {
            return order.AddUserOrderItem(orderlistinfo);
        }

        public DataSet GetOrderDetails(string orderID)
        {
            return order.GetOrderDetails(orderID);
        }
    }
}
