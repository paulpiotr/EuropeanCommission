#region using

using System.Threading.Tasks;
using Vies.Core.Models;

#endregion

namespace Vies.Core.Services.Interface
{
    public interface IViesService
    {
        public CheckVat CheckVat(string countryCode, string vatNumber);

        public Task<CheckVat> CheckVatAsync(string countryCode, string vatNumber);

        public CheckVatApprox CheckVatApprox(string countryCode, string vatNumber, string requesterCountryCode = null,
            string requesterVatNumber = null);

        public Task<CheckVatApprox> CheckVatApproxAsync(string countryCode, string vatNumber,
            string requesterCountryCode = null, string requesterVatNumber = null);
    }
}
