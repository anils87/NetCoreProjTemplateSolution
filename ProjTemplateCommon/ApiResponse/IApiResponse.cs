using ProjTemplateCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.ApiResponse
{
    public interface IApiResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
        SeverityType SeverityType { get; set; }
        string TransactionId { get; set; }

    }
}
