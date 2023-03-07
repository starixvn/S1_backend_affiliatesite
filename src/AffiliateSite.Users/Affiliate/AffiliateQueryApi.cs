using AffiliateSite.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace AffiliateSite.Users.Affiliate
{
    [Authorize, ApiController, Route("api/Affiliate")]
    public class AffiliateQueryApi : ControllerBase
    {
        private readonly DbConnection _connection;
        private readonly ILogger _log;
        public AffiliateQueryApi(DbConnection connection, ILoggerFactory logger)
        {
            _log = logger.CreateLogger(GetType());
            _connection = connection;
        }

        [HttpPost, Route("StatementHistory")]
        public Task<ApiResult> GetStatementHistory(QueryModels.GetAffiliateStatementHistory request)
        {
            return RequestHandler.HandleQuery(async () => await _connection.Query(request), _log);
        }
    }
}
