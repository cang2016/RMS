
namespace RMS.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IgnoreCaseDictionary : Dictionary<string, object>
    {
        public IgnoreCaseDictionary()
            : base(new comparer())
        {

        }

        private class comparer : IEqualityComparer<string>
        {
            #region IEqualityComparer<string> Members

            public bool Equals(string x, string y)
            {
                //if (x == null || y == null) return false;

                return string.Compare(x, y, true) == 0;
            }

            public int GetHashCode(string obj)
            {
                if(obj == null)
                {
                    return 0;
                }

                return obj.ToLower().GetHashCode();
            }

            #endregion
        }
    }


}
