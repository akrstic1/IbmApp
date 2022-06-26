namespace IbmApp.Model
{
    public interface ICatalogDatastore
    {
        Catalog GetCatalog();
        Catalog UpdateCatalog(Catalog newCatalog);
    }
}
