using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedCatalogPattern
{
    public class FixedCatalogClass
    {
        private Dictionary<EEnumerationKeys, object> keyValuePairs =
            new Dictionary<EEnumerationKeys, object>();

        private IStorage? storage { get; init; }

        public FixedCatalogClass(IStorage _storage = null)
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
                    keyParsed,
                    EEnumerationKeys_Default.GetDefaultValue(keyParsed));
            }
        }

        public object Get(EEnumerationKeys key)
        {
            if (!keyValuePairs.ContainsKey(key))
                throw new Exception("'key' in argument was not find");

            return keyValuePairs[key];
        }

        public bool Set(EEnumerationKeys key, object value)
        {
            if (!keyValuePairs.ContainsKey(key))
                throw new Exception("'key' in argument was not find");

            keyValuePairs[key] = value;
            return true;
        }

        ~FixedCatalogClass()
        {
            if (storage != null) storage.Save(keyValuePairs);
        }
    }
}
