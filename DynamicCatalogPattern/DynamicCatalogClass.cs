using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCatalogPattern
{
    public class DynamicCatalogClass
    {
        private Dictionary<string, object> keyValuePairs =
            new Dictionary<string, object>();

        private IStorage? storage { get; init; }

        public DynamicCatalogClass(IStorage _storage = null)
        {
            storage = _storage;

            if (storage != null)
            {
                keyValuePairs = _storage.Load();
                return;
            }

            foreach (string key in Enum.GetNames(typeof(EEnumerationKeys)))
            {
                EEnumerationKeys keyParsed =
                    (EEnumerationKeys)Enum.Parse(typeof(EEnumerationKeys), key, true);

                keyValuePairs.Add(
                    EEnumerationKeys_Relations.Get(keyParsed),
                    EEnumerationKeys_Default.GetDefaultValue(keyParsed));
            }
        }

        public object Get(string key)
        {
            if (!keyValuePairs.ContainsKey(key))
                throw new Exception("'key' in argument was not find");

            return keyValuePairs[key];
        }

        public bool Set(string key, object value, bool autoAdd = true)
        {
            if (!keyValuePairs.ContainsKey(key) && autoAdd)
            {
                keyValuePairs.Add(key, value);
                return true;
            }

            if (!keyValuePairs.ContainsKey(key))
                throw new Exception("'key' in argument was not find");

            keyValuePairs[key] = value;
            return true;
        }

        ~DynamicCatalogClass()
        {
            if (storage != null) storage.Save(keyValuePairs);
        }
    }
}
