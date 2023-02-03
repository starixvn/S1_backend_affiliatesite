using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public interface IAffiliateRepository
    {
        Task<bool> Exists(string userNmae);

        Task<Affiliate> Load(string userNmae);

        Task Add(Affiliate entity);
        Task UpdatePassword(Affiliate entity);
        Task UpdateInformation(Affiliate entity);
    }
}
