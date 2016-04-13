using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DBUtility;
using System.Data;
using System.Collections.ObjectModel;

namespace DAL
{
    public class longyuan_Category
    {
        public bool InsertCategory(L_CategoryInfo info)
        {
            string sqlStr = "insert into Category(productCategoryName,parentID,categoryDepth) values('{0}',{1},{2})";
            sqlStr = string.Format(sqlStr, info.ProductCategoryName, info.ParentID, info.CategoryDepth);
            if (SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr, null) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void GetCategory(Collection<L_CategoryInfo> allCategoryInfo,int categoryID)
        {
            Collection<L_CategoryInfo> subCategoryInfo = GetSubCategoryById(categoryID);
            if (subCategoryInfo.Count > 0)
            {
                foreach (L_CategoryInfo categoryInfo in subCategoryInfo)
                {
                    allCategoryInfo.Add(categoryInfo);
                    GetCategory(allCategoryInfo, categoryInfo.ProductCategoryID);
                }
            }
        }

        public Collection<L_CategoryInfo> GetAllCategoryByDepth(int depth)
        {
            string sqlstr = "select * from Category where categoryDepth={0}";
            sqlstr = string.Format(sqlstr, depth);
            DataTable dt = SqlHelper.ExecuteDateSet(CommandType.Text, sqlstr, null).Tables[0];
            Collection<L_CategoryInfo> allCategory = new Collection<L_CategoryInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                L_CategoryInfo categoryinfo = new L_CategoryInfo();
                categoryinfo.ProductCategoryID = Convert.ToInt32(dt.Rows[i]["productCategoryID"]);
                categoryinfo.ProductCategoryName = dt.Rows[i]["productCategoryName"].ToString();
                categoryinfo.ParentID = Convert.ToInt32(dt.Rows[i]["parentID"]);
                categoryinfo.CategoryDepth = Convert.ToInt32(dt.Rows[i]["categoryDepth"]);
                categoryinfo.CategoryDetail = dt.Rows[i]["categoryDepth"].ToString() + ',' + dt.Rows[i]["productCategoryID"];
                allCategory.Add(categoryinfo);
                GetCategory(allCategory, categoryinfo.ProductCategoryID);
            }
            return allCategory;
        }

        public Collection<L_CategoryInfo> GetSubCategoryById(int categoryID)
        {
            string sqlStr = "select * from Category where parentID={0}";
            sqlStr = string.Format(sqlStr, categoryID);
            DataTable dt = SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null).Tables[0];
            Collection<L_CategoryInfo> allCategory = new Collection<L_CategoryInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                L_CategoryInfo categoryinfo = new L_CategoryInfo();
                categoryinfo.ProductCategoryID = Convert.ToInt32(dt.Rows[i]["productCategoryID"]);
                categoryinfo.ProductCategoryName = dt.Rows[i]["productCategoryName"].ToString();
                categoryinfo.ParentID = Convert.ToInt32(dt.Rows[i]["parentID"]);
                categoryinfo.CategoryDepth = Convert.ToInt32(dt.Rows[i]["categoryDepth"]);
                categoryinfo.CategoryDetail = dt.Rows[i]["categoryDepth"].ToString() + ',' + dt.Rows[i]["productCategoryID"];
                allCategory.Add(categoryinfo);
            }
            return allCategory;
        }

        public bool GetExistProduct(int categoryId)
        {
            string sqlStr = "select * from Product where productCategoryID={0}";
            sqlStr = string.Format(sqlStr, categoryId);
            DataSet ds = SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCategoryByID(int CategoryID)
        {
            string sqlStr = "delete from Category where productCategoryID={0}";
            sqlStr = string.Format(sqlStr, CategoryID);

            int result = SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr, null);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCategoryByID(L_CategoryInfo category, int step)
        {
            Collection<L_CategoryInfo> allCategory = new Collection<L_CategoryInfo>();
            GetCategory(allCategory, category.ProductCategoryID);
            try
            {
                string sqlStr = "Update category set ProductCategoryName='{0}',parentID={1},categoryDepth={2} where ProductCategoryID={3}";
                sqlStr = string.Format(sqlStr, category.ProductCategoryName, category.ParentID, category.CategoryDepth, category.ProductCategoryID);
                SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr, null);
                foreach (L_CategoryInfo categoryinfo in allCategory)
                {
                    sqlStr = "Update category set categoryDepth={0} wher productCategoryID={1}";
                    sqlStr = string.Format(sqlStr, categoryinfo.CategoryDepth + step, categoryinfo.ProductCategoryID);
                    SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr, null);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
