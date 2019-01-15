using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesBusiness.DataContext;

namespace SalesBusiness.IRepository
{
    public interface IEmployeeRepository
    {
        bool Add(staff model);
        bool Delete(string id);
        bool Update(staff model);
        List<staff> GetList(int? page, int numberRecord, out int totalRecord);
        staff GetStaff(staff model);

        List<staff> OrderByUserName(int? page, int numberRecord, out int totalRecord);

        List<staff> OrderByName(int? page, int numberRecord, out int totalRecord);

        List<staff> OrderByAdress(int? page, int numberRecord, out int totalRecord);

        List<staff> Search(staff model, int? page, int numberRecord, out int totalRecord);
        //List<staff> NoSearch(staff model,int? page, int numberRecord, out int totalRecord);

        List<staff> SearchCancel(staff model);

        //List<staff> GetLstStaff(int? page);

        //List<staff> SearchStaff(int? page);

    }
}
