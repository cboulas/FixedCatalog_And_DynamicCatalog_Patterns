using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCatalogPattern
{
    internal static class EEnumerationKeys_Default
    {
        public static object GetDefaultValue(EEnumerationKeys key)
        {
            switch (key)
            {
                case EEnumerationKeys.Key1:
                    return "1st Key";
                case EEnumerationKeys.Key2:
                    return "2nd Key";
                case EEnumerationKeys.Key3:
                    return "3rd Key";
                case EEnumerationKeys.Key4:
                    return "4th Key";
                case EEnumerationKeys.Key5:
                    return "5th Key";
            }

            throw new ArgumentException("'key' was not exists in enumeration");
        }
    }
}
