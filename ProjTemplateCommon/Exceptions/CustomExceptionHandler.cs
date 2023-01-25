using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjTemplateCommon.Exceptions
{
    public class CustomExceptionHandler
    {
        public virtual ApplicationException HandleException(Exception ex, object payload=null , object additionalInfo = null)
        {
            var exception = new ApplicationException();
            if(ex != null)
            {
                WriteToLog(ex, exception,additionalInfo);
            }
            return exception;
        }
        private void WriteToLog(Exception ex, object payload = null, object additionalInfo = null)
        {

        }
    }
}
