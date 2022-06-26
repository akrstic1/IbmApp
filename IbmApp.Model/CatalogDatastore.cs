namespace IbmApp.Model
{
    public class CatalogDatastore : ICatalogDatastore
    {
        private Catalog Catalog = Catalog.SeedCatalogFromXml();

        public Catalog GetCatalog()
        {
            return Catalog;
        }

        public Catalog UpdateCatalog(Catalog newCatalog)
        {
            Catalog = newCatalog;

            return Catalog;
        }
    }
}
