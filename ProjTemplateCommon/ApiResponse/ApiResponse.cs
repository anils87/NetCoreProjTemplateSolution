using ProjTemplateCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.ApiResponse
{
    public class ApiResponse : IApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public SeverityType SeverityType { get; set; }
        public string TransactionId { get; set; }

        public ApiResponse()
        {
            Success = true;
            Message = "No Errors";
            SeverityType = SeverityType.NoErrors;
            TransactionId = null;
        }
    }
}
