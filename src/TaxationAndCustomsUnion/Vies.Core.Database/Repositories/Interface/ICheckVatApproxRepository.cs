using System.Threading.Tasks;
using Vies.Core.Models;

namespace Vies.Core.Database.Repositories.Interface
{
    public interface ICheckVatApproxRepository
    {
        public CheckVatApprox FindByCountryCodeAndVatNumber(string countryCode, string vatNumber, int cacheLifeTime = 0);

        public Task<CheckVatApprox> FindByCountryCodeAndVatNumberAsync(string countryCode, string vatNumber, int cacheLifeTime = 0);

        public CheckVatApprox Save(CheckVatApprox checkVat);

        public Task<CheckVatApprox> SaveAsync(CheckVatApprox checkVat);
    }
}
