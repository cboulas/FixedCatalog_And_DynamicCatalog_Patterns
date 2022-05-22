// new template : https://docs.microsoft.com/fr-fr/dotnet/core/tutorials/top-level-templates
using System;
using FixedCatalogPattern;
using DynamicCatalogPattern;
using FixedEnumerationKeys = FixedCatalogPattern.EEnumerationKeys;
using DynamicEnumerationKeys = DynamicCatalogPattern.EEnumerationKeys;

namespace ConsoleCatalogPattern
{
    internal class Program
    {
        private static FixedCatalogClass<FixedEnumerationKeys> FixedCatalog = null;
        private static DynamicCatalogClass<DynamicEnumerationKeys> DynamicCatalog = null;

        static void Main(string[] args)
        {
        }

        private static void InstanciateFixedCatalog()
        {
            // Instanciate and fill with natural default values
            FixedCatalog = new FixedCatalogClass<FixedEnumerationKeys>();

            // Get value of Key1
            FixedCatalog.Get(FixedEnumerationKeys.Key1);

            // Set value of Key1
            FixedCatalog.Set(FixedEnumerationKeys.Key1, "NoValue");
        }

        private static void InstanciateDynamicCatalog()
        {
            // Instanciate and fill with natural default values
            DynamicCatalog = new DynamicCatalogClass<DynamicEnumerationKeys>();

            // Get value of Key1
            DynamicCatalog.Get(DynamicEnumerationKeys.Key1);

            // Set value of Key1
            DynamicCatalog.Set(DynamicEnumerationKeys.Key1, "NoValue");
        }
    }
}