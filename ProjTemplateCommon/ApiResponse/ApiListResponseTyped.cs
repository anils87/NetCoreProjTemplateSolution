using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.ApiResponse
{
    public class ApiListResponseTyped<T>: ApiResponse
    {
        [JsonProperty("resultList")]
        public List<T> ResultList { get; set; }
        public ApiListResponseTyped()
        {
            ResultList = new List<T>();
        }
    }
}
