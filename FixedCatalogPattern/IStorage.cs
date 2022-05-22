using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedCatalogPattern
{
    public interface IStorage
    {
        object Get(EEnumerationKeys key);
        bool Set(EEnumerationKeys key, object value);
        Dictionary<EEnumerationKeys, object> Load();
        void Save(Dictionary<EEnumerationKeys, object> keyvaluepair_collection);
    }
}
