using SalesBusiness.DataContext;
using SalesProcject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesProcject.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            Lst = new List<product>();
        }

        public ProductModel input { get; set; }
        public List<product> Lst { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
        public SelectList list { get; set; }
    }
}