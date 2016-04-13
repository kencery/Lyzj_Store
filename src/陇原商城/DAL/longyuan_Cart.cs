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
    public class longyuan_Cart
    {
        public int addCart(L_CartInfo cartinfo)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@userID", cartinfo.UserID);
            param[1] = new SqlParameter("@CartID", cartinfo.CartID);
            param[2] = new SqlParameter("@productID", cartinfo.ProductID);
            param[3] = new SqlParameter("@buyNum", cartinfo.BugNum);
            param[4] = new SqlParameter("@buyTime", cartinfo.bugTime);
            param[5] = new SqlParameter("@result", SqlDbType.Int);
            param[5].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_CartCreat", param);

            return Int32.Parse(param[5].Value.ToString());
        }

        public DataSet GetShoppingCartList(int userID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userID", userID);

            return SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_DisplayShoppingCartInfo", param);
        }

        public int GetCartListDelete(L_CartInfo cinfo)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@userID", cinfo.UserID);
            param[1] = new SqlParameter("@cartID", cinfo.CartID);
            param[2] = new SqlParameter("@productID", cinfo.ProductID);

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_DeleteShoppingCartItem", param);
        }

        public DataSet GetUpdateShoppingNumMoney(L_CartInfo cartinfo)  //修改购买商品的数量
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@userID", cartinfo.UserID);
            param[1] = new SqlParameter("@productID", cartinfo.ProductID);
            param[2] = new SqlParameter("@buyNum", cartinfo.BugNum);
            param[3] = new SqlParameter("@MoneyTotal", SqlDbType.SmallMoney);
            param[3].Direction = ParameterDirection.Output;

            return SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_UpdateShoppingNumMoney", param);
        }
    }
}
