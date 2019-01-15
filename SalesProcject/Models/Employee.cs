using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesBusiness.DataContext;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalesProcject.Models
{
    public class Employee
    {
        public string MsgError { get; set; }

        public List<SelectListItem> lstCbb { get; set; }

        [Display(Name = "Mã nhân viên:")]
        //[Required(ErrorMessage ="{0} Không được để trống!")]
        //[StringLength(8,MinimumLength = 8, ErrorMessage = "{0} bắt buộc 8 ký tự")]
        public string user_cd { get; set; }

        [Display(Name = "Tên nhân viên:")]
        //[Required(ErrorMessage ="{0} Không được để trống!")]
        public string name { get; set; }

        //[Required]
        //[Remote("IsAlreadySigned", "SaveDataInDatabase", HttpMethod ="POST", ErrorMessage ="Tài khoản đã tồn tại!")]
        [Display(Name = "Tên đăng nhập:")]
        //[Required(ErrorMessage ="{0} Không được để trống!")]
        //[StringLength(10, MinimumLength = 5, ErrorMessage ="{0} phải từ {5} đến {10} ký tự!")]
        public string user_name { get; set; }

        [Display(Name = "Mật khẩu:")]
        //[Required(ErrorMessage ="{0} Không được để trống!")]
        //[StringLength(225, MinimumLength = 8, ErrorMessage ="{0} phải từ {8} đến {15} ký tự!")]
        public string pass_word { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Điện thoại:")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Hẫy nhập số!")]
        //[StringLength(15, MinimumLength = 10, ErrorMessage = "{0} phải từ {10} đến {15}!")]
        public string mobile { get; set; }

        
        [Display(Name = "Email:")]
        //[DataType(DataType.EmailAddress, ErrorMessage ="Email không hợp lệ!")]
        public string email { get; set; }

        [Display(Name = "Địa chỉ:")]
        public string adress { get; set; }

        [Display(Name = "Giới tính:")]
        //public bool? sex { get; set; }

        //public string sexStr { get; set; }
        public int sex { get; set; }

        [Display(Name = "Xóa")]
        public bool del_flg { get; set; }

        [Display(Name = "Người tạo:")]
        public string create_user { get; set; }

        [Display(Name = "Ngày tạo:")]
        public DateTime? create_date { get; set; }

        [Display(Name = "Người cập nhật:")]
        public string update_user { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public string update_date { get; set; }
    }
}