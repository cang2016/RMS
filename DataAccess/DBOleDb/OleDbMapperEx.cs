
namespace RMS.DataAccess
{
    public static class OleDbMapperEx
    {
        public static void OleDbTransaction<T>(this T t,OperationType opType, bool containsIdentityColumn = false, T newRec = default(T))
        where T : class, new()
        {
            OleDbMapper<T> mapper = new OleDbMapper<T>();

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
