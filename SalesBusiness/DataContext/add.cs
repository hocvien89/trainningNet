namespace SalesBusiness.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("add")]
    public partial class add
    {
        [StringLength(10)]
        public string id { get; set; }

        [StringLength(10)]
        public string nam { get; set; }
    }
}
