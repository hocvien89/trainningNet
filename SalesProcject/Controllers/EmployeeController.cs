using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesBusiness.DataContext;
using SalesBusiness.IRepository;
using SalesBusiness.Repository;
using SalesProcject.Models;
using SalesProcject.ViewModels;
using SalesProcject.Cm;
using System.IO;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace SalesProcject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository Em = new EmployeeRepository();
        SaleDataContext st = new SaleDataContext();
        private const int NumberRecord = 5;
        // GET: Employee

            
        //}
        //private string ValidateModel(staff model)
        //{
        //    if (string.IsNullOrEmpty(model.user_cd))
        //    {
        //        return string.Format(Constant.MsgRequired, "Mã nhân viên");
        //    }
        //    if (string.IsNullOrEmpty(model.user_name))
        //    {
        //        return string.Format(Constant.MsgRequired, "Tên đăng nhập");
        //    }
        //    if (string.IsNullOrEmpty(model.pass_word))
        //    {
        //        return string.Format(Constant.MsgRequired, "Mật khẩu");
        //    }
        //    if (!Utils.IsNumber(model.mobile))
        //    {
        //        return string.Format(Constant.Msg010, "Điện thoại");
        //    }
        //    return string.Empty;
        //}
        public ActionResult Index()
        {
            int totalRecord = 0;
            var model = new EmployeeVM
            {

                search = new Employee(),
                lst = Em.GetList(1, NumberRecord, out totalRecord),
                PageNumber = 1,
                PageCount = NumberRecord
            };
            model.search.lstCbb = LoadListEmployee();
            ViewBag.lstCbb = model.search.lstCbb;

            model.ToTalPage = (totalRecord % NumberRecord == 0) ? totalRecord / NumberRecord : totalRecord / NumberRecord + 1;
            return View(model);
        }

        public ActionResult GstBySortUserName (EmployeeVM model, int? page)
        {
            var lst = Em.OrderByUserName(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "_ListView", lst)
            });

        }
        public ActionResult NoSort (EmployeeVM model, int? page)
        {
            staff s = new staff();
            var lst = Em.Search(s,page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "_ListView", lst)
            });

        }

        public ActionResult NoSearch(EmployeeVM model, int? page)
        {
            staff s = new staff();
            var lst = Em.Search(s,page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "_ListView", lst)
            });

        }

        public ActionResult GstBySortName(EmployeeVM model, int? page)
        {
            var lst = Em.OrderByName(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RederRazorViewToString(ControllerContext, "_ListView", lst)
            });
        }

        public ActionResult GstBySortAdress(EmployeeVM model, int? page)
        {
            var lst = Em.OrderByAdress(page, NumberRecord, out int totalRecord);
            return Json(new
            {
                view = RederRazorViewToString(ControllerContext, "_ListView", lst)
            });
        }

        public static string RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }



        private List<SelectListItem> LoadListEmployee()
        {
            var lst = new List<SelectListItem>();
            lst.Add(new SelectListItem
            {
                Value = "1",
                Text = "Nam"
            });
            lst.Add(new SelectListItem
            {
                Value = "2",
                Text = "Nữ"
            });
            lst.Add(new SelectListItem
            {
                Value = "3",
                Text = "Không xác định"
            });
            return lst;
        }

        //[HttpPost]
        //public ActionResult Add(EmployeeVM model)
        //{
        //    try
        //    {
        //        staff data = new staff();
        //        data.user_cd = model.search.user_cd;
        //        data.user_name = model.search.user_name;
        //        data.pass_word = model.search.pass_word;
        //        data.name = model.search.name;
        //        data.mobile = model.search.mobile;
        //        data.email = model.search.email;
        //        data.adress = model.search.adress;
        //        data.sex = model.search.sex;
        //        if (model.search.sexStr == "0")
        //            data.sex = false;
        //        else if (model.search.sexStr == "1")
        //            data.sex = true;
        //        else
        //            data.sex = null;
        //        data.update_date = DateTime.Now.ToString("yyyy/dd/MM HH:mm");

        //        //var msgVaild = ValidateModel(data);
        //        //if (string.IsNullOrEmpty(msgVaild))
        //        //{
        //            var obj = Em.Add(data);
        //            if (obj)
        //                return Json(new { status = true });
        //        //    else
        //        //        return Json(new { status = false, msg = "Thêm thất bại" });
        //        //}
                
              
        //        else
        //        {
        //            return Json(new { status = false, msg = "Thêm thất bại" });
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        //return RedirectToAction("Index", "Error");
        //        throw ex;
        //    }
        //}
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                int totalRecord = 0;
                var obj = Em.Delete(id);
                if (obj)
                {
                    var model = Em.GetList(1, NumberRecord, out totalRecord);
                    return Json(new { err = true, view = RederRazorViewToString(ControllerContext, "_ListView", model) });
                }
                else
                    return Json(new { err = false, msg = "Dữ liệu không tồn tại!" });
                    //return Json(new { err = false, msg = "Không tìm thấy dữ liệu phù hợp điều kiện!" });
            }
            catch (Exception ex)
            {

                return Json(new { err = false, msg = ex.ToString() });
            }
        }

        [HttpPost]
        public ActionResult Update(EmployeeVM model)
        {
            try
            {
                staff data = new staff();
                data.user_cd = model.search.user_cd;
                data.user_name = model.search.user_name;
                data.pass_word = model.search.pass_word;
                data.name = model.search.name;
                data.mobile = model.search.mobile;
                data.adress = model.search.adress;
                data.email = model.search.email;
                data.sex = model.search.sex;
                //if (model.search.sexStr == "0")
                //    data.Sex = true;
                //else if (model.search.sexStr == "1")
                //    data.Sex = false;
                //else
                //    data.Sex = null;
                data.update_date = DateTime.Now.ToString("yyyy/dd/MM HH:mm");
                var result = Em.Update(data);
                if (result)
                    return Json(new { status = true });
                else
                    return Json(new { status = false, msg = "Sửa thất bại" });
            }
            catch (Exception)
            {
                return Json(new { status = false, msg = "Sửa thất bại" });
            }
        }

        [HttpPost]
        public ActionResult Search(EmployeeVM model)
        {
            int totalRecord = 0;
            staff data = new staff();
            data.user_cd = model.search.user_cd;
            data.user_name = model.search.user_name;
            data.pass_word = model.search.pass_word;
            data.name = model.search.name;
            data.mobile = model.search.mobile;
            data.email = model.search.email;
            data.adress = model.search.adress;
            data.sex = model.search.sex;
            //if (model.search.sexStr == "0")
            //    data.Sex = true;
            //else if (model.search.sexStr == "1")
            //    data.Sex = false;
            //else
            //    data.Sex = null;

            var result = Em.Search(data, 1, NumberRecord, out totalRecord);
            if (result.Count() == 0)
            {
                return Json(new { status = false, msg = "Không tìm thấy dữ liệu phù hợp điều kiện!" });
            }
            else
            {
                return Json(new
                {
                    status = true,
                    view = RederRazorViewToString(ControllerContext, "_ListView", result)
                });
            }
        }

        //[HttpPost]
        //public ActionResult SearchCancel(EmployeeVM model)
        //{
        //    int totalRecord = 0;
        //    staff data = new staff();
        //    data.user_cd = model.search.user_cd;
        //    data.user_name = model.search.user_name;
        //    data.pass_word = model.search.pass_word;
        //    data.name = model.search.name;
        //    data.mobile = model.search.mobile;
        //    data.email = model.search.email;
        //    data.adress = model.search.adress;
        //    data.sex = model.search.sex;
        //    if (model.search.sexStr == "0")
        //        data.sex = true;
        //    else if (model.search.sexStr == "1")
        //        data.sex = false;
        //    else
        //        data.sex = null;

        //    var result = Em.SearchCancel(data);
        //    if (result.Count() == 0)
        //    {
        //        return Json(new { status = false, msg = "Không tìm thấy dữ liệu phù hợp điều kiện!" });
        //    }
        //    else
        //    {
        //        return Json(new
        //        {
        //            status = true,
        //            view = RederRazorViewToString(ControllerContext, "_ListView", result)
        //        });
        //    }
        //}

        [HttpPost]

        public ActionResult GetLstUser(int? page)
        {
            int totalRecord = 0;
            var model = Em.GetList(page, NumberRecord, out totalRecord);

            return Json(new
            {
                view = RederRazorViewToString(ControllerContext, "_ListView", model)
            });
        }


        public JsonResult SaveDataInDatabase(EmployeeVM model)
        {
            var result = false;
            try
            {

                staff data = new staff();
                data.user_cd = model.search.user_cd;
                data.user_name = model.search.user_name;
                data.pass_word = model.search.pass_word;
                data.name = model.search.name;
                data.mobile = model.search.mobile;
                data.email = model.search.email;
                data.adress = model.search.adress;
                data.sex = model.search.sex;
                //if (model.search.sexStr == "0")
                //    data.Sex = true;
                //else if (model.search.sexStr == "1")
                //    data.Sex = false;
                //else
                //    data.Sex = null;
                //if (model.search.sexStr == "0")
                //    data.sex = true;
                //else if (model.search.sexStr == "1")
                //    data.sex = false;
                //else
                //    data.sex = null;

                data.update_date = DateTime.Now.ToString("yyyy/dd/MM HH:mm");
                


                var select = (from u in st.staffs where u.user_name.Equals(model.search.user_name) select u).ToList();
                if (select.Count != 0)
                {
                    return Json(new { result = false, msg = "Tên đăng nhập đã tồn tại" });
                    
                }
                else
                {
                    //var obj = data.Add(model);

                    st.staffs.Add(data);
                    st.SaveChanges();
                    result = true;


                    // }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }



















        private object RederRazorViewToString(ControllerContext controllerContext, string viewName, List<staff> model)
        {
            controllerContext.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}