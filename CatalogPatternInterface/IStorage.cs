using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPatternInterfaces
{
    public interface IStorage<T>
    {
        object Get(T key);
        bool Set(T key, object value);
        Dictionary<T, object> Load();
        void Save(Dictionary<T, object> keyvaluepair_collection);
    }
}
