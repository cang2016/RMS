
namespace RMS.DataAccess
{
    public static class SqlServerMapperEx
    {
        public static void SqlServerTransaction<T>(this T t, OperationType opType, bool containsIdentityColumn = false, T newRec = default(T))
where T : class, new()
        {
            SqlServerDbMapper<T> mapper = new SqlServerDbMapper<T>();

            switch(opType)
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
