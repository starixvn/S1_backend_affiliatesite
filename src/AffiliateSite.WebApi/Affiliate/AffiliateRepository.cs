using AffiliateSite.Domain;
namespace AffiliateSite.WebApi.Affiliate
{
    public class AffiliateRepository : IAffiliateRepository
    {
        private static List<Domain.Affiliate> _affiliates = new List<Domain.Affiliate>();
        public async Task Add(Domain.Affiliate entity)
        {
            _affiliates.Add(entity);
        }

        public async Task<bool> Exists(string userNmae)
        {
            return _affiliates.Any(a => a.UserName == userNmae);
        }

        public async Task<Domain.Affiliate> Load(string userNmae)
        {
            return _affiliates.FirstOrDefault(a => a.UserName == userNmae);
        }

        public async Task UpdateInformation(Domain.Affiliate entity)
        {
            var affiliate = _affiliates.FirstOrDefault();
            _affiliates.Remove(affiliate);
            _affiliates.Add(entity);
        }

        public async Task UpdatePassword(Domain.Affiliate entity)
        {
            var affiliate = _affiliates.FirstOrDefault(a => a.UserName == entity.UserName);
        }
    }
}
