using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesProcject.Models
{
    public class ProductModel
    {
        public string MsgError { get; set; }
        public List<SelectListItem> lstCbb { get; set; }

        [Display(Name = "Mã sản phẩm:")]
        public int id { get; set; }
        public int ids { get; set; }

        [Display(Name = "Mã loại sản phẩm")]
        public int? catalog_id { get; set; }
        public int? catalog_ids { get; set; }
        public string Cname { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string name { get; set; }
        public string names { get; set; }

        [Display(Name = "Số lượng:")]
        public long? amount { get; set; }
        public long? amounts { get; set; }

        [Display(Name = "Giá bán:")]
        public double? price { get; set; }
        public double? pricemin { get; set; }
        public double? pricemax { get; set; }

        [Display(Name = "Giá nhập:")]
        public double? price_buy { get; set; }
        public double? price_buymin { get; set; }
        public double? price_buymax { get; set; }

        public bool del_flg { get; set; }

        [Display(Name = "Người tạo:")]
        public string create_user { get; set; }

        [Display(Name = "Ngày tạo:")]
        public DateTime? create_date { get; set; }

        [Display(Name = "Người cập nhật:")]
        public string update_user { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public string update_date { get; set; }
        [Display(Name = "Đơn vị")]
        public string unit { get; set; }
        public string units { get; set; }
        public ProductModel()
        {
            lstCbb = new List<SelectListItem>();
        }
    }
}