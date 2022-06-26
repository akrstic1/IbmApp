using IbmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbmApp.Service
{
    public interface ICatalogService
    {
        Catalog GetCatalogFromXml();
    }
}
