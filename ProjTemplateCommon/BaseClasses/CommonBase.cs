using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.BaseClasses
{
    public class CommonBase : IDisposable
    {
        private readonly ILogger _logger;
        public CommonBase(ILogger logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
