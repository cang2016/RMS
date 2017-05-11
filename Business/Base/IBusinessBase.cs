using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business
{
    public interface IBusinessBase<T>
    {
        IList<T> GetInstanceList();

        T GetInstanceObj(T instance);

        void InsertInstanceObj(T instance);

        void UpdateInstanceObj(T instance, T newInstance);

        void DeleteInstanceObj(T instance);
    }
}
