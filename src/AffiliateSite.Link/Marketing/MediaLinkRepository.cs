using AffiliateSite.Framework;
using AffiliateSite.Link.Domain;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Transactions;
using static Dapper.SqlMapper;

namespace AffiliateSite.Link.Marketing
{
    public class MediaLinkRepository : IMediaLinkRepository
    {
        private readonly DbConnection _connection;

        public MediaLinkRepository(DbConnection connection)
        {
            _connection = connection;
        }
        public async Task<AffMediaLink> Load(int affId, string channelCode, string languageCode, string affLink)
        {
            return await _connection.QueryFirstOrDefaultAsync<AffMediaLink>("Affiliate_AffMediaLink_Get", new
            {
                _AffId = affId,
                _ChannelCode = channelCode,
                _LanguageCode = languageCode,
                _AffMediaLink = affLink,
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task Add(AffMediaLink entity)
        {
            await _connection.ExecuteAsync("Affiliate_AffMediaLink_Ins", new
            {
                _AffId = (int)entity.AffId,
                _ChannelCode = entity.ChannelCode,
                _LanguageCode = entity.LanguageCode,
                _AffMediaLink = entity.AffLink,
                _IsShow = (int)entity.Status,
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task Update(AffMediaLink entity)
        {
            await _connection.ExecuteAsync("Affiliate_AffMediaLinkIsShow_Set", new
            {
                _AffId = (int)entity.AffId,
                _ChannelCode = entity.ChannelCode,
                _LanguageCode = entity.LanguageCode,
                _AffMediaLink = entity.AffLink,
                _IsShow = entity.Status,
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
