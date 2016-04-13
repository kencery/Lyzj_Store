using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace DAL
{
    public class longyuan_OrderList
    {

        public int AddUserOrderItem(L_OrderListInfo orderlistinfo)
        {
            SqlParameter[] param=new SqlParameter[13];
            param[0]=new SqlParameter("@orderID",orderlistinfo.OrderID);
            param[1]=new SqlParameter("@userID",orderlistinfo.UserID);
            param[2]=new SqlParameter("@acceptName",orderlistinfo.AcceptName);
            param[3]=new SqlParameter("@acceptAddr",orderlistinfo.AcceptAddr);
            param[4]=new SqlParameter("@handset",orderlistinfo.HandSet);
            param[5]=new SqlParameter("@tel",orderlistinfo.Tel);
            param[6]=new SqlParameter("@zipCode",orderlistinfo.ZipCode);
            param[7]=new SqlParameter("@orderTime",orderlistinfo.OrderTime);
            param[8]=new SqlParameter("@shippedTime",orderlistinfo.ShippedTime);
            param[9]=new SqlParameter("@orderState",orderlistinfo.OrderState);
            param[10]=new SqlParameter("@isNew ",orderlistinfo.IsNew);
            param[11]=new SqlParameter("@adminID",orderlistinfo.AdminID);
            param[12]=new SqlParameter("@result",SqlDbType.Int);
            param[12].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_OrderListCreate", param);

            return Int32.Parse(param[12].Value.ToString());
        }

        public DataSet GetOrderDetails(string orderID)
        {
            string sqlStr = "Select a.ID,a.orderID,a.productID,a.proNumber,a.memberPrice,a.BugNum,a.freign,IsNull(productName,'产品已删除') as productName,ProductImage From OrderDetail as a Left Join Product as b on b.productID=a.productID where orderID='" + orderID + "'";
            
            return SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null);
        }
    }
}
