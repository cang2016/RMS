using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;
using  RMS.DataAccess;

namespace RMS.Business
{
    public class DishMenuBusiness : BusinessBase<DishMenu>
    {
        public DataTable GetDishMenus(int categoryId = -1)
        {
            string sql =
                  string.Format(
                      "SELECT m.id AS Id, p.Id AS UnitId, m.Code, m.Name,p.Name AS UnitName, p.Price,m.IsGq,m.Category_Id " +
                      "FROM DishMenu m INNER JOIN DishPrice p  ON p.Menu_Id = m.Id");

            if (categoryId > 0)
            {
              sql += string.Format(" AND m.Category_Id = {0}",categoryId);
            }

            return new SqlServerExecute().FillDataTable(CommandType.Text, sql);

        }




    }
}
