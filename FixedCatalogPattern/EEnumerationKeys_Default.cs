using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedCatalogPattern
{
    internal static class EEnumerationKeys_Default
    {
        public static object GetDefaultValue(EEnumerationKeys key)
        {
            return new Dictionary<EEnumerationKeys, string>()
            {
                { EEnumerationKeys.Key1, "1st Key" },
                { EEnumerationKeys.Key2, "2nd Key" },
                { EEnumerationKeys.Key3, "3rd Key" },
                { EEnumerationKeys.Key4, "4th Key" },
                { EEnumerationKeys.Key5, "5th Key" }
            }[key];
        }
    }
}
