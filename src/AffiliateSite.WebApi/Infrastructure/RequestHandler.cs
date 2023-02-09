using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AffiliateSite.WebApi.Infrastructure
{
    public static class RequestHandler
    {
        public static async Task<ApiResult> HandleCommand<T>(T request, Func<T, Task> handler, Serilog.ILogger log)
        {
            try
            {
                await handler(request);
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
            }
            catch (Exception e)
            {
                Log.Error(e, "Error handling the request");
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Failed, Message = e.Message };
            }
        }
        public static async Task<ApiResult> HandleQuery(Func<Task<ApiResult>> query, Serilog.ILogger log) 
        {
			try
			{
				return await query();
			}
			catch (Exception ex)
			{
                log.Error(ex, "Error handling the query");
                return new ApiResult 
                {
                    ErrorCode = (int)ErrorCodeEnum.SystemError,
                    Message = ex.Message,
                };
            }
        }
    }
}
