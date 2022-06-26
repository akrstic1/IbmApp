using IbmApp.Model;
using System;
using System.Collections.Generic;

namespace IbmApp.Service
{
    public class CatalogService:ICatalogService
    {
        public Catalog GetCatalogFromXml()
        {
            Catalog catalog = Catalog.SeedCatalogFromXml();

            return catalog;
        }
    }
}
