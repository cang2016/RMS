using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;

namespace RMS.Business
{
    public class MenuRootCategoryBusiness : BusinessBase<MenuRootCategory>
    {
        public IList<MenuRootCategory> GetAllrootCategories()
        {
            IList<MenuRootCategory> rootCategories = GetInstanceList();

            return rootCategories;
        }
    }
}
