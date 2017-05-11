using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAccess.DBMySql
{
    public static class MySqlDbMapperEx
    {
        public static void SqliteTransaction<T>(this T t, OperationType opType, bool containsIdentityColumn = false,
            T newRec = default(T))
            where T : class, new()
        {
            MySqlDbMapper<T> mapper = new MySqlDbMapper<T>();

            switch (opType)
            {
                case OperationType.Select:
                    mapper.GetObjectInstance(t);
                    break;
                case OperationType.Insert:
                    mapper.Insert(t, containsIdentityColumn);
                    break;
                case OperationType.Update:
                    mapper.Update(t, newRec);
                    break;
                case OperationType.Delete:
                    mapper.Delete(t);
                    break;
                default:
                    mapper.Insert(t, containsIdentityColumn);
                    break;
            }
        }
    }
}
