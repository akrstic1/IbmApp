using IbmApp.Model;

namespace IbmApp.Service
{
    public interface ICatalogService
    {
        Catalog GetCatalogFromDatastore();
        Catalog UpdateCatalogInDatastore(Catalog catalog);
    }
}
