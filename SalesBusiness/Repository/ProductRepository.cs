using SalesBusiness.DataContext;
using SalesBusiness.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBusiness.Repository
{
    public class ProductRepository : IProductRepository
    {
        SaleDataContext _db = new SaleDataContext();
        public product GetProductById(int id)
        {
            var a = (from u in _db.products
                     where u.id.Equals(id)
                     && u.del_flg.Equals(false)
                     select u).FirstOrDefault();
            return a;
        }
        public List<catalog> GetCatalog()
        {
            var a = (from u in _db.catalogs
                     where u.del_flg == false
                     select u).ToList();

            return a;
        }
        public List<product> GetLst(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.products
                     where u.del_flg.Equals(false)
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }
        public product GetProduct(product model)
        {
            var a = (from u in _db.products
                     where (model.id == 0 || u.id == model.id)
                     && (model.catalog_id == null || u.catalog_id.Equals(model.catalog_id))
                     && (string.IsNullOrEmpty(model.name) || u.name.Equals(model.name))
                     && ((model.amount == null) || u.amount.Equals(model.amount))
                     && ((model.price == null) || u.price.Equals(model.price))
                     && ((model.price_buy == null) || u.price_buy.Equals(model.price_buy))
                     select u).FirstOrDefault();
            return a;
        }

        public bool Update(product model)
        {
            try
            {
                var a = (from u in _db.products
                         where u.id == model.id
                         && u.del_flg == false
                         select u).FirstOrDefault();
                if (a == null)
                {
                    return false;
                }
                else
                {
                    a.id = model.id;
                    a.catalog_id = model.catalog_id;
                    a.name = model.name;
                    a.amount = model.amount;
                    a.unit = model.unit;
                    a.price = model.price;
                    a.price_buy = model.price_buy;
                    a.update_user = model.update_user;
                    a.update_date = model.update_date;
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Add(product model)
        {
            try
            {
                _db.products.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int productId)
        {
            var a = (from u in _db.products
                     where u.id == productId
                     && u.del_flg == false
                     select u).FirstOrDefault();
            if (a != null)
            {
                a.del_flg = true;
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<product> GetPrdOderName(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.products
                     where u.del_flg.Equals(false)
                     orderby u.name
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public List<product> GetPrdOderCatalog(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.products
                     where u.del_flg.Equals(false)
                     orderby u.catalog_id
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }
        public List<product> GetPrdOderUnit(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.products
                     where u.del_flg.Equals(false)
                     orderby u.unit
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }
    }
}
