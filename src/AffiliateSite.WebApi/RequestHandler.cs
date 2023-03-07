using Microsoft.Extensions.Logging;

namespace AffiliateSite.WebApi
{
    public static class RequestHandler
    {
        public static async Task<ApiResult> HandleCommand<T>(T request, Func<T, Task> handler, ILogger log)
        {
            try
            {
                await handler(request);
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
            }
            catch (Exception e)
            {
                log.LogError(e, "Error handling the request");
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Failed, Message = e.Message };
            }
        }
        public static async Task<ApiResult> HandleQuery(Func<Task<ApiResult>> query, ILogger log)
        {
            try
            {
                return await query();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error handling the query");
                return new ApiResult
                {
                    ErrorCode = (int)ErrorCodeEnum.SystemError,
                    Message = ex.Message,
                };
            }
        }
    }
}
