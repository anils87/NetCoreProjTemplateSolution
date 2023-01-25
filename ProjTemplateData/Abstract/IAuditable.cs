using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateData.Abstract
{
    public interface IAuditableCreated
    {
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
    public interface IAuditable : IAuditableCreated
    {        
        public DateTime CreatedDate { get;set;}
        public DateTime ModifiedDate { get;set;}
    }
}
