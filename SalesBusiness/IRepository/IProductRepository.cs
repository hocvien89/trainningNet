using SalesBusiness.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusiness.IRepository
{
    public interface IProductRepository
    {
        List<catalog> GetCatalog();
        bool Add(product model);
        bool Update(product model);
        bool Delete(int productId);
        List<product> GetLst(int? page, int numberRecord, out int totalRecord);
        List<product> GetPrdOderName(int? page, int numberRecord, out int totalRecord);
        List<product> GetPrdOderCatalog(int? page, int numberRecord, out int totalRecord);
        List<product> GetPrdOderUnit(int? page, int numberRecord, out int totalRecord);
        product GetProduct(product model);
        product GetProductById(int id);
    }
}
