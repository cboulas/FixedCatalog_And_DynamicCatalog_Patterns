using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCatalogPattern
{
    public static class EEnumerationKeys_Relations
    {
        public static string Get(EEnumerationKeys key)
        {
            // Sample 1
            return key.ToString(); // for example

            // Sample 2 -- Comment Sample 1 to use
            switch (key)
            {
                case EEnumerationKeys.Key1:
                    return "MyKey1";
                case EEnumerationKeys.Key2:
                    return "MyKey2";
                case EEnumerationKeys.Key3:
                    return "MyKey3";
                case EEnumerationKeys.Key4:
                    return "MyKey4";
                case EEnumerationKeys.Key5:
                    return "MyKey5";
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
        }
    }
}
