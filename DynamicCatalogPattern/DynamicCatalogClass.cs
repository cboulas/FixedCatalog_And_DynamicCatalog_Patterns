using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogPatternInterfaces;

namespace DynamicCatalogPattern
{
    public class DynamicCatalogClass<T>
    {
        private Dictionary<string, object> keyValuePairs =
            new Dictionary<string, object>();

        private IStorage<string>? storage { get; init; }

        public DynamicCatalogClass(IStorage<string> _storage = null)
        {
            storage = _storage;

            if (storage != null)
            {
                keyValuePairs = _storage.Load();
                return;
            }

            foreach (string key in Enum.GetNames(typeof(EEnumerationKeys)))
            {
                keyValuePairs.Add(
                    key,
                    EEnumerationKeys_Default.GetDefaultValue(
                        (EEnumerationKeys)Enum.Parse(
                            typeof(T), key, true)));
            }
        }

        public object Get(T key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return Get(EEnumerationKeys_Relations<T>.Get(key));
        }

        public object Get(string key)
        {
            if (!keyValuePairs.ContainsKey(key))
                throw new Exception("'key' in argument was not find");

            return keyValuePairs[key];
        }

        public bool Set(T key, object value, bool autoAdd = true)
        {
            return Set(EEnumerationKeys_Relations<T>.Get(key), value, autoAdd);
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
