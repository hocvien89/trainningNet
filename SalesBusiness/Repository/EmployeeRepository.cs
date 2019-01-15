using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesBusiness.DataContext;
using SalesBusiness.IRepository;

namespace SalesBusiness.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        SaleDataContext _db = new SaleDataContext();
        public bool Add(staff model)
        {
            try
            {
                _db.staffs.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            var a = (from u in _db.staffs
                     where u.user_cd.Equals(id)
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

        public List<staff> GetList(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.staffs
                     where u.del_flg == false
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }


        public staff GetStaff(staff model)
        {
            var a = (from u in _db.staffs
                     where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
                     && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                     && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
                     && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
                     && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
                     && (string.IsNullOrEmpty(model.email) || u.email.Equals(model.email))
                     && (string.IsNullOrEmpty(model.adress) || u.email.Equals(model.adress))
                     //&& (model.sex == null || u.sex == model.sex)
                     && u.del_flg == false
                     select u).FirstOrDefault();
            return a;
        }

        //public List<staff> NoSearch(staff model, int? page, int numberRecord, out int totalRecord)
        //{
        //    var a = (from u in _db.staffs
        //             where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
        //             && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
        //             && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
        //             && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
        //             && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
        //             && (string.IsNullOrEmpty(model.email) || u.email.Equals(model.email))
        //             && (string.IsNullOrEmpty(model.adress) || u.adress.Equals(model.adress))
        //             && (model.sex == null || u.sex == model.sex)
        //             && u.del_flg == false
        //             select u).ToList();
        //    totalRecord = a.Count();
        //    return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        //}

        public List<staff> OrderByAdress(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.staffs
                     where u.del_flg.Equals(false)
                     orderby u.adress
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public List<staff> OrderByName(int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.staffs
                     where u.del_flg.Equals(false)
                     orderby u.name
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public List<staff> OrderByUserName(int? page, int numberRecord, out int totalRecord)
        {
            //throw new NotImplementedException();
            var a = (from u in _db.staffs
                     where u.del_flg.Equals(false)
                     orderby u.user_name
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();

        }

        public List<staff> Search(staff model, int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.staffs
                     where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
                     && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                     && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
                     && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
                     && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
                     && (string.IsNullOrEmpty(model.email) || u.email.Equals(model.email))
                     && (string.IsNullOrEmpty(model.adress) || u.adress.Equals(model.adress))
                     && (model.sex == 0 || u.sex == model.sex)
                     && u.del_flg == false
                     select u);
            totalRecord = a.Count();
            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public List<staff> SearchCancel(staff model)
        {
            var a = (from u in _db.staffs
                     where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
                     && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                     && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
                     && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
                     && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
                     && (string.IsNullOrEmpty(model.email) || u.email.Equals(model.email))
                     && (string.IsNullOrEmpty(model.adress) || u.adress.Equals(model.adress))
                     //&& (model.sex == null || u.sex == model.sex)
                     && u.del_flg == false
                     select u).ToList();
            return a;
        }


        //public List<staff> SearchStaff(int? page)
        //{
        //    throw new NotImplementedException();
        //}

        public bool Update(staff model)
        {
            try
            {
                var data = (from u in _db.staffs
                            where u.user_cd.Equals(model.user_cd)
                            select u).FirstOrDefault();
                if (data == null)
                {
                    return false;
                }
                else
                {
                    data.name = model.name;
                    data.user_name = model.user_name;
                    data.pass_word = model.pass_word;
                    data.mobile = model.mobile;
                    data.email = model.email;
                    data.adress = model.adress;
                    data.sex = model.sex;
                    data.update_date = DateTime.Now.ToString("yyyy/dd/MM HH:mm");
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
