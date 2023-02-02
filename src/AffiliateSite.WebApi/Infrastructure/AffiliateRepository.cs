using AffiliateSite.Domain;

namespace AffiliateSite.WebApi.Infrastructure
{
    public class AffiliateRepository : IAffiliateRepository
    {
        private List<Affiliate> _affiliates;

        public AffiliateRepository()
        {
            _affiliates = new List<Affiliate>();
        }

        public async Task Add(Affiliate entity)
        {
            _affiliates.Add(entity);
        }

        public async Task<bool> Exists(string userNmae)
        {
            return _affiliates.Any(a=> a.UserName == userNmae);
        }

        public async Task<Affiliate> Load(string userNmae)
        {
            return _affiliates.FirstOrDefault(a=>a.UserName == userNmae);
        }

        public async Task UpdatePassword(Affiliate entity)
        {
            var affiliate = _affiliates.FirstOrDefault(a => a.UserName == entity.UserName);
        }
    }
}
