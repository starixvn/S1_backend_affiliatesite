using AffiliateSite.WebApi.Contracts;
using AffiliateSite.WebApi.Infrastructure;
using AffiliateSite.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Serilog;
using System.Data.Common;

namespace AffiliateSite.WebApi.Controllers
{
    [Route("api/Affiliate")]
    [ApiController]
    public class AffiliateQueryApi : ControllerBase
    {
        private readonly DbConnection _connection;
        private static Serilog.ILogger _log = Log.ForContext<AffiliateQueryApi>();
        public AffiliateQueryApi(DbConnection connection)
        {
            _connection = connection;
        }

        [HttpPost]
        [Route("StatementHistory")]
        public Task<ApiResult> GetStatementHistory(QueryModels.GetAffiliateStatementHistory request) 
        {
            return RequestHandler.HandleQuery(async () => await _connection.Query(request), _log);
        }
    }
}
