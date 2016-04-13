using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Collections;
using System.Data;

namespace BLL
{
    public class longyuan_productinfo
    {
        private longyuan_product product = new longyuan_product();

        public longyuan_productinfo()
        { 
            
        }

        public int InsertProduct(L_ProductInfo productinfo)
        {
            return product.AddProduct(productinfo);
        }

        public L_ProductInfo GetProduct(int p_productID)
        {
            return product.GetProduct(p_productID);
        }

        public int updateProduct(L_ProductInfo productInfo)
        {
            return product.updateProduct(productInfo);
        }

        public IList GetIndexBindtuiJian(int classID, Int16 isType, string TopNum)
        {
            return product.GetIndexBindtuiJian(classID,isType,TopNum);
        }

        public IList GetIndexBindHottuiJian(int classID, Int16 isType, string TopNum)
        {
            return product.GetIndexBindHottuiJian(classID, isType, TopNum);
        }

        public IList GetIndexBindProductShow(Int16 isType, string topNum)
        {
            return product.GetIndexBindProductShow(isType, topNum);
        }

        public L_ProductInfo GetProductInfoByProductID(int productID)
        {
            return product.GetProductInfoByProductID(productID);
        }
    }
}
