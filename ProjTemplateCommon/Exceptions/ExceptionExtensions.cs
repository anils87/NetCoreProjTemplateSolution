using ProjTemplateCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Exceptions
{
    public static class ExceptionExtensions
    {
        public static SeverityType GetExceptionSeverityType(this Exception ex)
        {
            if(ex == null)
            {
                return SeverityType.NoErrors;
            }
            return SeverityType.InternalError;
        }
    }
}
