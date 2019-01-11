using SalesBusiness.DataContext;
using SalesBusiness.IRepository;
using SalesBusiness.Repository;
using SalesProcject.Common;
using SalesProcject.Models;
using SalesProcject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesProcject.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        private readonly IProductRepository data = new ProductRepository();
        private readonly SaleDataContext _db = new SaleDataContext();
        private const int NumberRecord = 5;
        public ActionResult Index()
        {
            return Show();
        }
        #region Show
        [HttpPost]
        public ActionResult Show()
        {

            var model = new ProductVM
            {
                input = new ProductModel(),
                Lst = data.GetLst(1, NumberRecord, out int totalRecord),
                PageNumber = 1,
                PageCount = NumberRecord,
            };
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            model.ToTalPage = (totalRecord % NumberRecord == 0) ? totalRecord / NumberRecord : totalRecord / NumberRecord + 1;
            return View(model);
        }
        #endregion

        #region LoadListCatalog
        [HttpPost]
        private List<SelectListItem> LoadListCatalog()
        {
            var lst = new List<SelectListItem>();
            var lstCatalog = data.GetCatalog();
            foreach (var item in lstCatalog)
            {
                lst.Add(new SelectListItem
                {
                    Value = item.id.ToString(),
                    Text = item.name
                });
            }
            return lst;
        }
        #endregion

        #region Action  No Sort
        [HttpPost]//Action  No Sort
        public ActionResult SearchNoSort(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetLst(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Index || NoSort
        [HttpPost]
        /*Paging for Index || SortNo*/
        public ActionResult GetLstUser(int? page)
        {
            var model = data.GetLst(page, NumberRecord, out int totalRecord);
            ViewBag.lstCbb = LoadListCatalog();
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", model)
            });
        }
        #endregion

        #region Action Sort Name
        [HttpPost]//Action Sort Name
        public ActionResult SearchSortName(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderName(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Sort Name
        [HttpPost]
        /*Paging for Sort Name*/
        public ActionResult GetLstSortName(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderName(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region Action Sort Catalog
        [HttpPost]//Action Sort Catalog
        public ActionResult SearchSortCatalog(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderCatalog(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Sort Catalog
        /*Paging for Sort Catalog*/
        public ActionResult GetLstSortCatalog(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderCatalog(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region Action SortUnit
        [HttpPost]//Action Sort Unit
        public ActionResult SearchSortUnit(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderUnit(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Sort Unit
        /*Paging for Sort Unit*/
        public ActionResult GetLstSortUnit(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderUnit(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region Action SortAmount
        [HttpPost]//Action Sort Amount
        public ActionResult SearchSortAmount(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderAmount(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Sort Amount
        /*Paging for Sort Unit*/
        public ActionResult GetLstSortAmount(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderAmount(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region Action SortPrice
        [HttpPost]//Action Sort Price
        public ActionResult SearchSortPrice(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderPrice(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion  

        #region Paging for Sort Price
        /*Paging for Sort Unit*/
        public ActionResult GetLstSortPrice(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderPrice(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region Action SortPricebuy
        [HttpPost]//Action Sort Pricebuy
        public ActionResult SearchSortPricebuy(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderPricebuy(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Sort Pricebuy
        /*Paging for Sort Unit*/
        public ActionResult GetLstSortPricebuy(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderPricebuy(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region Action SortDate
        [HttpPost]//Action Sort Date
        public ActionResult SearchSortDate(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var search = data.GetPrdOderDate(1, NumberRecord, out int totalRecord);
            return Json(new
            {
                status = true,
                view = RenderRazorViewToString(ControllerContext, "LstView", search),
            });
        }
        #endregion

        #region Paging for Sort Date
        /*Paging for Sort Unit*/
        public ActionResult GetLstSortDate(ProductVM model, int? page)
        {
            model.input.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.input.lstCbb;
            var lst = data.GetPrdOderDate(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", lst)
            });
        }
        #endregion

        #region CheckValidate
        private string ValidateCheck(product model)
        {
            if (model.catalog_id == null)
            {
                return string.Format("Vui lòng chọn nhóm sản phẩm!");
            }
            if (string.IsNullOrEmpty(model.name))
            {
                return string.Format(Constant.MsgRequiredPr, "Tên sản phẩm");
            }
            if (model.name.Length > 50)
            {
                return string.Format(Constant.MsgMaxLengthPr, "Tên sản phẩm");
            }
            if (!Utils.SpecialCharacter(model.name))
            {
                return string.Format("Tên sản phẩm không dấu và không chứa kí tự đặc biệt!");
            }
            if (model.amount == null)
            {
                return string.Format(Constant.MsgRequiredPr, Constant.MsgOnlyNumberPr, "Số lượng sản phẩm");
            }
            if (!Utils.IsNumberPhone(model.amount.Value.ToString()))
            {
                return string.Format(Constant.MsgOnlyNumberPr, "Số lượng sản phẩm");
            }
            if (string.IsNullOrEmpty(model.unit))
            {
                return string.Format(Constant.MsgRequiredPr, "Đơn vị");
            }
            if (model.price_buy.Equals(""))
            {
                return string.Format(Constant.MsgRequiredPr, "Giá nhập");
            }
            if (!Utils.IsNumberPhone(model.price_buy.Value.ToString()))
            {
                return string.Format(Constant.MsgOnlyNumberPr, "Giá nhập");
            }
            //if (Utils.IsNumberPhone(model.price_buy.Value.ToString()))
            //{
            //    return string.Format(Constant.MsgOnlyNumberPr, "Giá nhập");
            //}
            if (model.price == null)
            {
                return string.Format(Constant.MsgRequiredPr, "Giá bán");
            }
            if (!Utils.IsNumberPhone(model.price.Value.ToString()))
            {
                return string.Format(Constant.MsgOnlyNumberPr, "Giá bán");
            }
            return string.Empty;
        }
        #endregion

        #region ActionResult Add
        [HttpPost]
        public ActionResult Add(ProductVM model)
        {
            product pr = new product
            {
                id = model.input.id,
                catalog_id = model.input.catalog_id,
                name = model.input.name,
                amount = model.input.amount,
                unit = model.input.unit,
                price = model.input.price,
                price_buy = model.input.price_buy,
                del_flg = false,
                create_date = DateTime.Now,
            };
            var msgValid = ValidateCheck(pr);
            if (string.IsNullOrEmpty(msgValid))
            {
                var select = (from u in _db.products
                              where u.name.Equals(model.input.name)
                              select u).ToList();
                if (select.Count != 0)
                {
                    return Json(new { status = false, msg = "Tên sản phẩm đã tồn tại!" });
                }
                else
                {
                    var obj = data.Add(pr);
                    if (obj)
                        return Json(new { status = true, msg = "Thêm mới sản phẩm thành công!" });
                    else
                        return Json(new { status = false, msg = "Có lỗi trong quá trình xử lý, hãy kiểm tra lại!" });
                }
            }
            else
            {
                return Json(new { status = false, msg = msgValid });
            }
        }
        #endregion

        #region ActionResult Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {

            int totalRecord = 0;
            var obj = data.Delete(id);
            if (obj)
            {
                var model = data.GetLst(1, NumberRecord, out totalRecord);
                return Json(new { err = true });
            }
            else
                return Json(new { err = false, msg = "Không thấy dữ liệu phù hợp điều kiện!" });
        }
        #endregion

        #region ActionResult Update
        [HttpPost]
        public ActionResult Update(ProductVM model)
        {
            product pr = new product
            {
                id = model.input.id,
                catalog_id = model.input.catalog_id,
                name = model.input.name,
                amount = model.input.amount,
                unit = model.input.unit,
                price = model.input.price,
                price_buy = model.input.price_buy,
                del_flg = false,
                update_date = DateTime.Now.ToString("yyyy/dd/MM HH:mm"),
            };
            var msgValid = ValidateCheck(pr);
            if (string.IsNullOrEmpty(msgValid))
            {
                var selectU = (from u in _db.products
                               where (u.name.Equals(model.input.name) && u.id == model.input.id)
                               select u).ToList();

                var select = (from u in _db.products
                              where u.name.Equals(model.input.name)
                              select u).ToList();
                if (selectU.Count == 1 || select.Count == 0)
                {
                    var obj = data.Update(pr);
                    if (obj)
                        return Json(new { status = true, msg = "Cập nhật sản phẩm thành công!" });
                    else
                        return Json(new { status = false, textStatus = "Có lỗi trong quá trình xử lý, hãy kiểm tra lại!" });
                }
                else
                {
                    return Json(new { status = false, msg = "Tên sản phẩm đã tồn tại!" });
                }
            }
            else
            {
                return Json(new { status = false, msg = msgValid });
            }
        }
        #endregion

        #region Action Search
        public JsonResult GetSearchingData(string SearchBy, string IdValue, string CatalogValue, string NameValue,
                                           string AmountValue, string UnitValue, string MinPricebuyValue, string MaxPricebuyValue,
                                           string MinPriceValue, string MaxPriceValue )
        {
            List<product> LstProduct = new List<product>();
            int ID;
            int Catalog;
            int Amount;
            int MinPricebuy;
            int MaxPricebuy;
            int MinPrice;
            int MaxPrice;
            // Search DrpAmount Values
            if (SearchBy == "equal")
            {
                if (IdValue.Equals("") && CatalogValue.Equals("") && NameValue.Equals("") && AmountValue.Equals("")
                    && UnitValue.Equals("") && MinPricebuyValue.Equals("") && MaxPricebuyValue.Equals("")
                    && MinPriceValue.Equals("") && MaxPriceValue.Equals(""))
                {
                    LstProduct = (from u in _db.products
                                  where u.del_flg == false
                                  select u).ToList();
                }
                else
                {
                    //name
                    if (NameValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((u.name.Contains(NameValue) || string.IsNullOrEmpty(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //unit
                    if (UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (NameValue != "" && UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //1-id
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        ID = Convert.ToInt32(IdValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "")
                        )//12
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);

                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//13
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "")//14
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//15
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//123
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//124
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                       && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//125
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//134
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "")
                       && MaxPriceValue != "" && MinPriceValue != "")//135
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//145
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                             && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                             && MinPricebuyValue != "")//1234
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                         && (UnitValue != "" || UnitValue == "")
                         && MaxPriceValue != "" && MinPriceValue != "")//1235
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1245
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                       && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                            && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                            && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//12345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //23
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //24
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //25
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //234
                    if (CatalogValue != "" && AmountValue != "" && MinPriceValue != "" && MaxPriceValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //235
                    if (CatalogValue != "" && AmountValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //245
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2345
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //3 
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //34
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //35
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //345
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount == Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //4
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //45
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (u.price >= MinPrice && u.price <= MaxPrice)
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //5
                    if (MinPriceValue != "" && MaxPriceValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price >= MinPrice && u.price <= MaxPrice)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                }
                return Json(LstProduct, JsonRequestBehavior.AllowGet);

            }

            else if (SearchBy == "more")
            {
                if (IdValue.Equals("") && CatalogValue.Equals("") && NameValue.Equals("") && AmountValue.Equals("")
                    && UnitValue.Equals("") && MinPricebuyValue.Equals("") && MaxPricebuyValue.Equals("")
                    && MinPriceValue.Equals("") && MaxPriceValue.Equals(""))
                {
                    LstProduct = (from u in _db.products
                                  where u.del_flg == false
                                  select u).ToList();
                }
                else
                {
                    //name
                    if (NameValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((u.name.Contains(NameValue) || string.IsNullOrEmpty(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //unit
                    if (UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (NameValue != "" && UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //1-id
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        ID = Convert.ToInt32(IdValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "")
                        )//12
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);

                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//13
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "")//14
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//15
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//123
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//124
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                       && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//125
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//134
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "")
                       && MaxPriceValue != "" && MinPriceValue != "")//135
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//145
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                             && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                             && MinPricebuyValue != "")//1234
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                         && (UnitValue != "" || UnitValue == "")
                         && MaxPriceValue != "" && MinPriceValue != "")//1235
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1245
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                       && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                            && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                            && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//12345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount > Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //23
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //24
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //25
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //234
                    if (CatalogValue != "" && AmountValue != "" && MinPriceValue != "" && MaxPriceValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //235
                    if (CatalogValue != "" && AmountValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //245
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2345
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //3 
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //34
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //35
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //345
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount > Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //4
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //45
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (u.price >= MinPrice && u.price <= MaxPrice)
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //5
                    if (MinPriceValue != "" && MaxPriceValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price >= MinPrice && u.price <= MaxPrice)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                }
                return Json(LstProduct, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "moreEqual")
            {
                if (IdValue.Equals("") && CatalogValue.Equals("") && NameValue.Equals("") && AmountValue.Equals("")
                    && UnitValue.Equals("") && MinPricebuyValue.Equals("") && MaxPricebuyValue.Equals("")
                    && MinPriceValue.Equals("") && MaxPriceValue.Equals(""))
                {
                    LstProduct = (from u in _db.products
                                  where u.del_flg == false
                                  select u).ToList();
                }
                else
                {
                    //name
                    if (NameValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((u.name.Contains(NameValue) || string.IsNullOrEmpty(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //unit
                    if (UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (NameValue != "" && UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //1-id
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        ID = Convert.ToInt32(IdValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "")
                        )//12
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);

                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//13
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "")//14
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//15
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//123
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//124
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                       && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//125
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//134
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "")
                       && MaxPriceValue != "" && MinPriceValue != "")//135
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//145
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                             && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                             && MinPricebuyValue != "")//1234
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                         && (UnitValue != "" || UnitValue == "")
                         && MaxPriceValue != "" && MinPriceValue != "")//1235
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1245
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                       && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                            && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                            && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//12345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount >= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //23
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //24
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //25
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //234
                    if (CatalogValue != "" && AmountValue != "" && MinPriceValue != "" && MaxPriceValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //235
                    if (CatalogValue != "" && AmountValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //245
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2345
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //3 
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //34
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //35
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //345
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount >= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //4
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //45
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (u.price >= MinPrice && u.price <= MaxPrice)
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //5
                    if (MinPriceValue != "" && MaxPriceValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price >= MinPrice && u.price <= MaxPrice)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                }
                return Json(LstProduct, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "less")
            {
                if (IdValue.Equals("") && CatalogValue.Equals("") && NameValue.Equals("") && AmountValue.Equals("")
                     && UnitValue.Equals("") && MinPricebuyValue.Equals("") && MaxPricebuyValue.Equals("")
                     && MinPriceValue.Equals("") && MaxPriceValue.Equals(""))
                {
                    LstProduct = (from u in _db.products
                                  where u.del_flg == false
                                  select u).ToList();
                }
                else
                {
                    //name
                    if (NameValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((u.name.Contains(NameValue) || string.IsNullOrEmpty(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //unit
                    if (UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (NameValue != "" && UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //1-id
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        ID = Convert.ToInt32(IdValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "")
                        )//12
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);

                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//13
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "")//14
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//15
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//123
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//124
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                       && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//125
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//134
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "")
                       && MaxPriceValue != "" && MinPriceValue != "")//135
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//145
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                             && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                             && MinPricebuyValue != "")//1234
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                         && (UnitValue != "" || UnitValue == "")
                         && MaxPriceValue != "" && MinPriceValue != "")//1235
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1245
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                       && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                            && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                            && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//12345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount < Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //23
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //24
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //25
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //234
                    if (CatalogValue != "" && AmountValue != "" && MinPriceValue != "" && MaxPriceValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //235
                    if (CatalogValue != "" && AmountValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //245
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2345
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //3 
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //34
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //35
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //345
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount < Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //4
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //45
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (u.price >= MinPrice && u.price <= MaxPrice)
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //5
                    if (MinPriceValue != "" && MaxPriceValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price >= MinPrice && u.price <= MaxPrice)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                }
                if (LstProduct.Count != 0)
                {
                    return Json(LstProduct, JsonRequestBehavior.AllowGet);
                    //return Json(new
                    //{
                    //    status = true,
                    //    msg = "Ok",
                    //    view = RenderRazorViewToString(ControllerContext, "LstView", LstProduct)
                    //});
                }
                else
                    return Json(new { status = false, msg = "Không có dữ liệu" });
            }
            else
            {
                if (IdValue.Equals("") && CatalogValue.Equals("") && NameValue.Equals("") && AmountValue.Equals("")
                      && UnitValue.Equals("") && MinPricebuyValue.Equals("") && MaxPricebuyValue.Equals("")
                      && MinPriceValue.Equals("") && MaxPriceValue.Equals(""))
                {
                    LstProduct = (from u in _db.products
                                  where ((string.IsNullOrEmpty(IdValue) /*|| u.id == 0)
                                  && (string.IsNullOrEmpty(CatalogValue) /*|| u.catalog_id == 0*/)
                                  && (string.IsNullOrEmpty(NameValue) /*|| u.name == ""*/)
                                  && (string.IsNullOrEmpty(AmountValue) /*|| u.amount == 0*/)
                                  && (string.IsNullOrEmpty(UnitValue) /* ||u.unit.Equals("")*/)
                                  && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue)/* || u.price_buy == 0*/)
                                  && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) /*|| u.price == 0*/)
                                  && u.del_flg == false)
                                  select u).ToList();
                }
                else
                {
                    //name
                    if (NameValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((u.name.Contains(NameValue) || string.IsNullOrEmpty(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //unit
                    if (UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (NameValue != "" && UnitValue != "")
                    {
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //1-id
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        ID = Convert.ToInt32(IdValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "")
                        )//12
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);

                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//13
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "")//14
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//15
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                        && (UnitValue != "" || UnitValue == ""))//123
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//124
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                       && (UnitValue != "" || UnitValue == "") && MaxPriceValue != "" && MinPriceValue != "")//125
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != "" && MinPricebuyValue != "")//134
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "")
                       && MaxPriceValue != "" && MinPriceValue != "")//135
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//145
                    {
                        ID = Convert.ToInt32(IdValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                             && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                             && MinPricebuyValue != "")//1234
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                         && (UnitValue != "" || UnitValue == "")
                         && MaxPriceValue != "" && MinPriceValue != "")//1235
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "")
                        && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                        && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1245
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                       && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                       && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//1345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount == Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    if (IdValue != "" && CatalogValue != "" && (NameValue != "" || NameValue == "") && AmountValue != ""
                            && (UnitValue != "" || UnitValue == "") && MaxPricebuyValue != ""
                            && MinPricebuyValue != "" && MaxPriceValue != "" && MinPriceValue != "")//12345
                    {
                        ID = Convert.ToInt32(IdValue);
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(IdValue) || u.id == ID)
                                      && (string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(AmountValue) || u.amount <= Amount)
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (string.IsNullOrEmpty(MinPricebuyValue) || string.IsNullOrEmpty(MaxPricebuyValue) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(MinPriceValue) || string.IsNullOrEmpty(MaxPriceValue) || (u.price >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //23
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //24
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //25
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && ((u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //234
                    if (CatalogValue != "" && AmountValue != "" && MinPriceValue != "" && MaxPriceValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //235
                    if (CatalogValue != "" && AmountValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != ""
                         && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //245
                    if (CatalogValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //2345
                    if (CatalogValue != "" && AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Catalog = Convert.ToInt32(CatalogValue);
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPricebuyValue);
                        MaxPrice = Convert.ToInt32(MaxPricebuyValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((string.IsNullOrEmpty(CatalogValue) || u.catalog_id == Catalog)
                                      && (u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //3 
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //34
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //35
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //345
                    if (AmountValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "" && MinPricebuyValue != "" && MaxPricebuyValue != "")
                    {
                        Amount = Convert.ToInt32(AmountValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.amount <= Amount || string.IsNullOrEmpty(AmountValue))
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && ((string.IsNullOrEmpty(MinPriceValue)) || (string.IsNullOrEmpty(MaxPriceValue)) || (u.price_buy >= MinPrice && u.price_buy <= MaxPrice))
                                      && ((string.IsNullOrEmpty(MinPricebuyValue)) || (string.IsNullOrEmpty(MaxPricebuyValue)) || (u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //4
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //45
                    if (MinPricebuyValue != "" && MaxPricebuyValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == "")
                        && MinPriceValue != "" && MaxPriceValue != "")
                    {
                        MinPricebuy = Convert.ToInt32(MinPricebuyValue);
                        MaxPricebuy = Convert.ToInt32(MaxPricebuyValue);
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price_buy >= MinPricebuy && u.price_buy <= MaxPricebuy)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && (u.price >= MinPrice && u.price <= MaxPrice)
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                    //5
                    if (MinPriceValue != "" && MaxPriceValue != "" && (NameValue != "" || NameValue == "") && (UnitValue != "" || UnitValue == ""))
                    {
                        MinPrice = Convert.ToInt32(MinPriceValue);
                        MaxPrice = Convert.ToInt32(MaxPriceValue);
                        LstProduct = (from u in _db.products
                                      where ((u.price >= MinPrice && u.price <= MaxPrice)
                                      && (string.IsNullOrEmpty(NameValue) || u.name.Contains(NameValue))
                                      && (string.IsNullOrEmpty(UnitValue) || u.unit.Contains(UnitValue))
                                      && u.del_flg == false)
                                      select u).ToList();
                    }
                }
                return Json(LstProduct, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}