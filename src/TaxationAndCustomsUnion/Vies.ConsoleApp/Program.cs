#region using

using System.Threading.Tasks;
using Vies.Core.Services;

#endregion

namespace Vies.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args) =>
            //_ = await Vies.Core.Services.ViesService.GetInstance().CheckVatAsync(countryCode: "PL", vatNumber: "5731029185");
            _ = await ViesService.GetInstance().CheckVatApproxAsync("PL", "5731029185", "PL", "5731029185");
    }
}
