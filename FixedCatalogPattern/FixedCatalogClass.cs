using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogPatternInterfaces;

namespace FixedCatalogPattern
{
    public class FixedCatalogClass<T>
    {
        private Dictionary<T, object> keyValuePairs =
            new Dictionary<T, object>();

        private IStorage<T>? storage { get; init; }

        public FixedCatalogClass(IStorage<T> _storage = null)
        {
            storage = _storage;

            if (storage != null)
            {
                keyValuePairs = _storage.Load();
                return;
            }

            foreach (string key in Enum.GetNames(typeof(T)))
            {
                keyValuePairs.Add(
                    (T)Enum.Parse(typeof(T), key, true),
                    EEnumerationKeys_Default.GetDefaultValue(
                        (EEnumerationKeys)Enum.Parse(
                            typeof(T), key, true)));
            }
        }

        public object Get(T key)
        {
            if (!keyValuePairs.ContainsKey(key))
                throw new Exception("'key' in argument was not find");

            return keyValuePairs[key];
        }

        public bool Set(T key, object value)
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
