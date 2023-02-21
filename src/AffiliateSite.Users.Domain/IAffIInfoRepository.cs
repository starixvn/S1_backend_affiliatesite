using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users.Domain
{
    public interface IAffIInfoRepository
    {
        Task<bool> IsEmailExists(string userNmae);

        Task<AffInfo> Load(string userNmae);

        Task Add(AffInfo entity, DbTransaction transaction);
        Task UpdatePassword(AffInfo entity);
    }
}
