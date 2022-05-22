using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPatternInterfaces
{
    public interface ICatalogPattern<T>
    {
        object Get(T key);
        bool Set(T key, object value, bool autoAdd);
    }
}
