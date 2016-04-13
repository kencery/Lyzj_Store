using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Collections.ObjectModel;

namespace BLL
{
    public class longyuan_CategoryInfo
    {
        longyuan_Category category = new longyuan_Category();

        public bool InsertCategory(L_CategoryInfo info)
        {
            return category.InsertCategory(info);
        }

        public Collection<L_CategoryInfo> GetAllCategoryByDepth(int depth)
        {
            return category.GetAllCategoryByDepth(depth);
        }

        public Collection<L_CategoryInfo> GetSubCategoryByID(int categoryID)
        {
            return category.GetSubCategoryById(categoryID);
        }

        public bool GetExistProduct(int categoryId)
        {
            return category.GetExistProduct(categoryId);
        }

        public bool DeleteCategoryByID(int categoryID)
        {
            return category.DeleteCategoryByID(categoryID);
        }

        public bool UpdateCategoryByID(L_CategoryInfo categoryAll, int step)
        {
            return category.UpdateCategoryByID(categoryAll, step);
        }
    }
}
