using IbmApp.Model;

namespace IbmApp.Service
{
    public class CatalogService : ICatalogService
    {
        private ICatalogDatastore _catalogDatastore;

        public CatalogService(ICatalogDatastore catalogDatastore)
        {
            _catalogDatastore = catalogDatastore;
        }

        public Catalog GetCatalogFromDatastore()
        {
            Catalog catalog = _catalogDatastore.GetCatalog();

            return catalog;
        }

        public Catalog UpdateCatalogInDatastore(Catalog catalog)
        {
            Catalog updatedCatalog = _catalogDatastore.UpdateCatalog(catalog);

            return updatedCatalog;
        }
    }
}
