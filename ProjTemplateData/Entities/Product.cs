using ProjTemplateData.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateData.Entities
{
    public class Product : BaseEntityRecord, IAuditable
    {        
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public virtual Category Category { get; set; }
    }
}
