using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public interface IUsernameAutoIncrementRepository
    {
        Task<int> Generate(string prefixName, DbTransaction transaction);
    }
}
