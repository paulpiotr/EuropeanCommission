using System.Threading.Tasks;
using Vies.Core.Models;

namespace Vies.Core.Database.Repositories.Interface
{
    public interface ICheckVatRepository
    {
        public CheckVat FindByCountryCodeAndVatNumber(string countryCode, string vatNumber, int cacheLifeTime = 0);

        public Task<CheckVat> FindByCountryCodeAndVatNumberAsync(string countryCode, string vatNumber, int cacheLifeTime = 0);

        public CheckVat Save(CheckVat checkVat);

        public Task<CheckVat> SaveAsync(CheckVat checkVat);
    }
}
