using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class longyuan_CartInfo
    {
        longyuan_Cart cart = new longyuan_Cart();

        public int addCart(L_CartInfo cartinfo)
        {
            return cart.addCart(cartinfo);
        }

        public DataSet GetShoppingCartList(int userID)
        {
            return cart.GetShoppingCartList(userID);
        }

        public int GetCartListDelete(L_CartInfo cinfo)
        {
            return cart.GetCartListDelete(cinfo);
        }

        public DataSet GetUpdateShoppingNumMoney(L_CartInfo cartinfo)  //修改购买商品的数量
        {
            return cart.GetUpdateShoppingNumMoney(cartinfo);
        }

    }
}
