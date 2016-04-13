using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Collections;

namespace DAL
{
    public class longyuan_product
    {
        public int AddProduct(L_ProductInfo productInfo)
        {
            SqlParameter[] para = new SqlParameter[26];
            para[0] = new SqlParameter("@proNumber", productInfo.Pronumber);
            para[1] = new SqlParameter("@ProductName", productInfo.ProductName);
            para[2] = new SqlParameter("@keyWord", productInfo.Keyword);
            para[3] = new SqlParameter("@productCategoryID", productInfo.ProductCategoryID);
            para[4] = new SqlParameter("@categoryName", productInfo.CategoryName);
            para[5] = new SqlParameter("@parentIDRoute", productInfo.ParentIDRoute);
            para[6] = new SqlParameter("@parentNameRoute", productInfo.ParentNameRoute);
            para[7] = new SqlParameter("@productImage", productInfo.ProductImage);
            para[8] = new SqlParameter("@currentPrice", productInfo.CurrentPrice);
            para[9] = new SqlParameter("@price", productInfo.Price);
            para[10] = new SqlParameter("@menberPrice", productInfo.MenberPrince);
            para[11] = new SqlParameter("@danwei", productInfo.Danwei);
            para[12] = new SqlParameter("@productStore", productInfo.ProducStore);
            para[13] = new SqlParameter("@productDesc", productInfo.ProductDesc);
            para[14] = new SqlParameter("@remainDay", productInfo.RemainDay);
            para[15] = new SqlParameter("@clickNum", productInfo.ClickNum);
            para[16] = new SqlParameter("@isReviewEnable", productInfo.Isreviewenable);
            para[17] = new SqlParameter("@isPost", productInfo.Ispost);
            para[18] = new SqlParameter("@isCommend", productInfo.Iscommend);
            para[19] = new SqlParameter("@addTime", productInfo.Addtime);
            para[20] = new SqlParameter("@linkQQid", productInfo.LinkQQID);
            para[21] = new SqlParameter("@linkQQName", productInfo.LinkQQName);
            para[22] = new SqlParameter("@freightType", productInfo.FreightType);
            para[23] = new SqlParameter("@freight", productInfo.Freight);
            para[24] = new SqlParameter("@AdminID", productInfo.AdminID);
            para[25] = new SqlParameter("@result", SqlDbType.Int);
            para[25].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_AddProduct", para);
            return Int32.Parse(para[25].Value.ToString());
        }

        public L_ProductInfo GetProduct(int p_productID)
        {
            L_ProductInfo productinfo = null;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@productID ", p_productID);
            param[1] = new SqlParameter("@Result", SqlDbType.Int);

            DataSet set = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_skipProduct", param);
            if (set.Tables.Count > 0)
            {
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow drv = set.Tables[0].Rows[0];
                    productinfo = new L_ProductInfo(
                        Int32.Parse(drv["productID"].ToString()),
                        drv["proNumber"].ToString(),
                        drv["productName"].ToString(),
                        drv["keyWord"].ToString(),
                        Int32.Parse(drv["productCategoryID"].ToString()),
                        drv["categoryName"].ToString(),
                        drv["parentIDRoute"].ToString(),
                        drv["parentNameRounte"].ToString(),
                        drv["productImage"].ToString(),
                        Decimal.Parse(drv["currentPrice"].ToString()),
                        Decimal.Parse(drv["price"].ToString()),
                        Decimal.Parse(drv["menberPrice"].ToString()),
                        drv["danWei"].ToString(),
                        Int32.Parse(drv["productStore"].ToString()),
                        drv["productDesc"].ToString(),
                        Int32.Parse(drv["remainDay"].ToString()),
                        Int32.Parse(drv["clickNum"].ToString()),
                        Int32.Parse(drv["isReviewEnable"].ToString()),
                        Int16.Parse(drv["isPost"].ToString()),
                        Int16.Parse(drv["isCommend"].ToString()),
                        DateTime.Parse(drv["addTime"].ToString()),
                        drv["linkQQId"].ToString(),
                        drv["linkQQName"].ToString(),
                        drv["freightType"].ToString(),
                        Decimal.Parse(drv["freight"].ToString()),
                        Int32.Parse(drv["adminID"].ToString()));
                }
            }
            return productinfo;
        }

        public int updateProduct(L_ProductInfo productInfo)
        {
            SqlParameter[] para = new SqlParameter[27];
            para[0] = new SqlParameter("@productID", productInfo.ProductID);
            para[1] = new SqlParameter("@proNumber", productInfo.Pronumber);
            para[2] = new SqlParameter("@ProductName", productInfo.ProductName);
            para[3] = new SqlParameter("@keyWord", productInfo.Keyword);
            para[4] = new SqlParameter("@productCategoryID", productInfo.ProductCategoryID);
            para[5] = new SqlParameter("@categoryName", productInfo.CategoryName);
            para[6] = new SqlParameter("@parentIDRoute", productInfo.ParentIDRoute);
            para[7] = new SqlParameter("@parentNameRounte", productInfo.ParentNameRoute);
            para[8] = new SqlParameter("@productImage", productInfo.ProductImage);
            para[9] = new SqlParameter("@currentPrice", productInfo.CurrentPrice);
            para[10] = new SqlParameter("@price", productInfo.Price);
            para[11] = new SqlParameter("@menberPrice", productInfo.MenberPrince);
            para[12] = new SqlParameter("@danwei", productInfo.Danwei);
            para[13] = new SqlParameter("@productStore", productInfo.ProducStore);
            para[14] = new SqlParameter("@productDesc", productInfo.ProductDesc);
            para[15] = new SqlParameter("@remainDay", productInfo.RemainDay);
            para[16] = new SqlParameter("@clickNum", productInfo.ClickNum);
            para[17] = new SqlParameter("@isReviewEnable", productInfo.Isreviewenable);
            para[18] = new SqlParameter("@isPost", productInfo.Ispost);
            para[19] = new SqlParameter("@isCommend", productInfo.Iscommend);
            para[20] = new SqlParameter("@addTime", productInfo.Addtime);
            para[21] = new SqlParameter("@linkQQid", productInfo.LinkQQID);
            para[22] = new SqlParameter("@linkQQName", productInfo.LinkQQName);
            para[23] = new SqlParameter("@freightType", productInfo.FreightType);
            para[24] = new SqlParameter("@freight", productInfo.Freight);
            para[25] = new SqlParameter("@AdminID", productInfo.AdminID);
            para[26] = new SqlParameter("@result", SqlDbType.Int);
            para[26].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_UpdateShopping", para);
            return Int32.Parse(para[26].Value.ToString());
        }

        public IList GetIndexBindtuiJian(int classID, Int16 isType, string TopNum)
        {
            IList list = new ArrayList();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@classID", classID);
            param[1] = new SqlParameter("@isType", isType);
            param[2] = new SqlParameter("@TopNum", TopNum);

            DataSet dSet = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_indexBindtuijian", param);

            for (int i = 0; i < dSet.Tables[0].Rows.Count; i++)
            {
                DataRow drv = dSet.Tables[0].Rows[i];
                L_ProductInfo pinfo = new L_ProductInfo();
                pinfo.ProductID = Int32.Parse(drv["productID"].ToString());
                pinfo.ProductName = drv["productName"].ToString();
                pinfo.ProductImage = drv["productImage"].ToString();
                pinfo.CurrentPrice = decimal.Parse(drv["currentPrice"].ToString());
                pinfo.MenberPrince = decimal.Parse(drv["menberprice"].ToString());
                pinfo.Danwei = drv["danWei"].ToString();
                pinfo.RemainDay = Int32.Parse(drv["remainDay"].ToString());
                pinfo.Addtime = DateTime.Parse(drv["addTime"].ToString());

                list.Add(pinfo);
            }

            return list;
        }

        public IList GetIndexBindHottuiJian(int classID, Int16 isType, string TopNum)
        {
            IList list = new ArrayList();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@classID", classID);
            param[1] = new SqlParameter("@isType", isType);
            param[2] = new SqlParameter("@TopNum", TopNum);

            DataSet dSet = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_indexBindhottuijian", param);

            for (int i = 0; i < dSet.Tables[0].Rows.Count; i++)
            {
                DataRow drv = dSet.Tables[0].Rows[i];
                L_ProductInfo pinfo = new L_ProductInfo();
                pinfo.ProductID = Int32.Parse(drv["productID"].ToString());
                pinfo.ProductName = drv["productName"].ToString();
                pinfo.ProductImage = drv["productImage"].ToString();
                pinfo.CurrentPrice = decimal.Parse(drv["currentPrice"].ToString());
                pinfo.MenberPrince = decimal.Parse(drv["menberprice"].ToString());
                pinfo.Danwei = drv["danWei"].ToString();
                pinfo.RemainDay = Int32.Parse(drv["remainDay"].ToString());
                pinfo.Addtime = DateTime.Parse(drv["addTime"].ToString());

                list.Add(pinfo);
            }

            return list;
        }

        public IList GetIndexBindProductShow(Int16 isType, string topNum)
        {
            IList list = new ArrayList();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IsType", isType);
            param[1] = new SqlParameter("@topNum", topNum);

            DataSet Set = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "L_ProductListByIsTypeIndexShow", param);

            for (int i = 0; i < Set.Tables[0].Rows.Count; i++)
            {
                DataRow drv = Set.Tables[0].Rows[i];
                L_ProductInfo pInfo = new L_ProductInfo();

                pInfo.ProductID = Int32.Parse(drv["productID"].ToString());
                pInfo.ProductName = drv["productName"].ToString();
                pInfo.ProductImage = drv["productImage"].ToString();
                pInfo.Price = decimal.Parse(drv["price"].ToString());
                pInfo.CurrentPrice = decimal.Parse(drv["currentPrice"].ToString());
                pInfo.MenberPrince = decimal.Parse(drv["menberprice"].ToString());
                pInfo.Danwei = drv["danwei"].ToString();
                pInfo.RemainDay = Int32.Parse(drv["remainDay"].ToString());
                pInfo.Addtime = DateTime.Parse(drv["addTime"].ToString());

                list.Add(pInfo);
            }
            return list;
        }

        public L_ProductInfo GetProductInfoByProductID(int productID)
        {
            L_ProductInfo productinfo = null;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@productID ", productID);
            param[1] = new SqlParameter("@result", SqlDbType.Int);
            param[1].Direction = ParameterDirection.Output;

            DataSet set = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_ProductGetInfoByProduct", param);

            if (set.Tables.Count > 0)
            {
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow drv = set.Tables[0].Rows[0];
                    productinfo = new L_ProductInfo(
                            Int32.Parse(drv["productID"].ToString()),
                            drv["ProNumber"].ToString(),
                            drv["productName"].ToString(),
                            drv["keyWord"].ToString(),
                            Int32.Parse(drv["productCategoryID"].ToString()),
                            drv["categoryName"].ToString(),
                            drv["parentIDRoute"].ToString(),
                            drv["parentNameRounte"].ToString(),
                            drv["productImage"].ToString(),
                            Decimal.Parse(drv["currentPrice"].ToString()),
                            Decimal.Parse(drv["price"].ToString()),
                            Decimal.Parse(drv["menberPrice"].ToString()),
                            drv["danwei"].ToString(),
                            Int32.Parse(drv["productStore"].ToString()),
                            drv["productDesc"].ToString(),
                            Int32.Parse(drv["remainDay"].ToString()),
                            Int32.Parse(drv["clickNum"].ToString()),
                            Int32.Parse(drv["isReviewEnable"].ToString()),
                            Int16.Parse(drv["isPost"].ToString()),
                            Int16.Parse(drv["isCommend"].ToString()),
                            DateTime.Parse(drv["addTime"].ToString()),
                            drv["linkQQID"].ToString(),
                            drv["linkQQName"].ToString(),
                            drv["freightType"].ToString(),
                            Decimal.Parse(drv["freight"].ToString()),
                            Int32.Parse(drv["adminID"].ToString()));
                }
            }
            return productinfo;
        }
    }
}