using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RMS.DataAccess
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            InitialWithNull();
        }

        /// <summary>
        /// Initialize the kinds of dataType with default value
        /// </summary>
        private void InitialWithNull()
        {
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string[] propNames = new string[properties.Length];
            Dictionary<string, PropertyInfo> propNameToDic = new Dictionary<string, PropertyInfo>();
            for (int i = 0; i < properties.Length; i++)
            {
                propNames[i] = properties[i].Name;
                propNameToDic.Add(propNames[i], properties[i]);
            }

            foreach (string propName in propNames)
            {
                string propType = propNameToDic[propName].PropertyType.Name;

                object propValue = null;

                if (MapperConstants.NullValue.Keys.Contains(propType))
                {
                    propValue = MapperConstants.NullValue[propType];
                }

                type.GetProperty(propName).SetValue(this, propValue, null);
            }
        }
    }
}
