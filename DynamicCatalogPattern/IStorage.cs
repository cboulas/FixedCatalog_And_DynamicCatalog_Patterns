using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCatalogPattern
{
    public interface IStorage
    {
        object Get(string key);
        bool Set(string key, object value);
        Dictionary<string, object> Load();
        void Save(Dictionary<string, object> keyvaluepair_collection);
    }
}
