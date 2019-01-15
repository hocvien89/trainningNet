using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesBusiness.DataContext;
using SalesProcject.Models;

namespace SalesProcject.ViewModels
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            lst = new List<staff>();
            
        }
        
        public Employee search { get; set; }
        public List<staff> lst { get; set; }
        public SelectList list { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}