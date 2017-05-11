using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;

namespace RMS.Business
{
    public class MenuSubCategoryBusiness : BusinessBase<MenuSubCategory>
    {
        public IList<MenuSubCategory> GetSubCategoriesByParentId(int parentId)
        {
            return GetInstanceList().Where(c => c.RootCategory_Id == parentId).ToList();
        }
    }
}
