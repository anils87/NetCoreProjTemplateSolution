using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjTemplateCommon.ApiResponse;
using ProjTemplateCommon.Auth;
using ProjTemplateCommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.BaseClasses
{
    //[Authorize]
    //[ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class CommonSecureController : ControllerBase , IDisposable
    {
        protected IHttpContextAccessor httpContextAccessor;
        public CoreClaimsPrincipal MyPrincipal { get; set; }
        public CommonSecureController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.MyPrincipal = httpContextAccessor.HttpContext.User as CoreClaimsPrincipal;
        }        
        protected virtual ApiItemResponseTyped<T> ExecuteAndConvertToApiResponse<T>(Func<T> func)
        {
            try
            {
                T result = func();
                return new ApiItemResponseTyped<T>
                {
                    Result = result,
                    Success = true,
                    SeverityType = Enums.SeverityType.NoErrors,
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
            catch(Exception ex)
            {
                // Log Exception here the return

                return new ApiItemResponseTyped<T>
                {
                    Message = ex.Message,
                    Success = false,
                    SeverityType = ex.GetExceptionSeverityType(),
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
        }
        protected virtual async Task<ApiItemResponseTyped<T>> ExecuteAndConvertToApiResponseAsync<T>(Func<Task<T>> func)
        {
            try
            {
                T result = await func();
                return new ApiItemResponseTyped<T>
                {
                    Result = result,
                    Success = true,
                    SeverityType = Enums.SeverityType.NoErrors,
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
            catch (Exception ex)
            {
                // Log Exception here the return

                return new ApiItemResponseTyped<T>
                {
                    Message = ex.Message,
                    Success = false,
                    SeverityType = ex.GetExceptionSeverityType(),
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
        }

        protected virtual ApiListResponseTyped<T> ExecuteAndConvertToApiListResponse<T>(Func<IEnumerable<T>> func)
        {
            try
            {
                IEnumerable<T> result = func();
                return new ApiListResponseTyped<T>
                {
                    ResultList = result.ToList(),
                    Success = true,
                    SeverityType = Enums.SeverityType.NoErrors,
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
            catch (Exception ex)
            {
                // Log Exception here the return

                return new ApiListResponseTyped<T>
                {
                    Message = ex.Message,
                    Success = false,
                    SeverityType = ex.GetExceptionSeverityType(),
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
        }

        protected virtual async Task<ApiListResponseTyped<T>> ExecuteAndConvertToApiListResponseAsync<T>(Func<Task<IEnumerable<T>>> func)
        {
            try
            {
                IEnumerable<T> result = await func();
                return new ApiListResponseTyped<T>
                {
                    ResultList = result.ToList(),
                    Success = true,
                    SeverityType = Enums.SeverityType.NoErrors,
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
            catch (Exception ex)
            {
                // Log Exception here the return

                return new ApiListResponseTyped<T>
                {
                    Message = ex.Message,
                    Success = false,
                    SeverityType = ex.GetExceptionSeverityType(),
                    TransactionId = this.Request.Headers["TransactionId"].ToString()
                };
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
