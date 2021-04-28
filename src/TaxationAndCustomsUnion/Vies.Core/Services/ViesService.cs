#region using

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using log4net;
using NetAppCommon.Helpers.Xmls;
using Newtonsoft.Json;
using Vies.Core.Models;
using Vies.Core.Services.Interface;
using ViesServiceReference;

#endregion

namespace Vies.Core.Services
{
    public class ViesService : IViesService
    {
        #region private readonly log4net.ILog log4net

        /// <summary>
        ///     Log4net Logger
        ///     Log4net Logger
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        public CheckVat CheckVat(string countryCode, string vatNumber)
        {
            try
            {
                var checkVatRequest = new checkVatRequest {countryCode = countryCode, vatNumber = vatNumber};
                var checkVatPortTypeClient = new checkVatPortTypeClient();
                checkVatResponse checkVatResponse = checkVatPortTypeClient.checkVat(checkVatRequest);
                var xmlSerializer = new XmlSerializer(checkVatResponse.GetType());
                var textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, checkVatResponse);
                CheckVat checkVat = XmlHelper.DeserializeXmlFromString<CheckVat>(textWriter.ToString());
//#if DEBUG
//                _log4Net.Debug(JsonConvert.SerializeObject(checkVat));
//#endif
                return checkVat;
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            return null;
        }

        public async Task<CheckVat> CheckVatAsync(string countryCode, string vatNumber) =>
            await Task.Run(() =>
            {
                return CheckVat(countryCode, vatNumber);
            });

        public CheckVatApprox CheckVatApprox(string countryCode, string vatNumber, string requesterCountryCode = null,
            string requesterVatNumber = null)
        {
            try
            {
                //var checkVatApproxRequest = new ViesServiceReference.checkVatApproxRequest
                //{
                //    countryCode = countryCode,
                //    vatNumber = vatNumber,
                //    requesterCountryCode = requesterCountryCode,
                //    requesterVatNumber = requesterVatNumber
                //};
                var checkVatApproxRequest = new checkVatApproxRequest
                {
                    countryCode = countryCode,
                    vatNumber = vatNumber,
                    requesterCountryCode = countryCode,
                    requesterVatNumber = vatNumber
                };
                var checkVatPortTypeClient = new checkVatPortTypeClient();
                checkVatApproxResponse checkVatApproxResponse =
                    checkVatPortTypeClient.checkVatApprox(checkVatApproxRequest);
                var xmlSerializer = new XmlSerializer(checkVatApproxResponse.GetType());
                var textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, checkVatApproxResponse);
                CheckVatApprox checkVatApprox =
                    XmlHelper.DeserializeXmlFromString<CheckVatApprox>(textWriter.ToString());
//#if DEBUG
//                _log4Net.Debug(JsonConvert.SerializeObject(checkVatApprox));
//                _log4Net.Debug(JsonConvert.SerializeObject(checkVatApproxResponse));
//#endif
                return checkVatApprox;
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            return null;
        }

        public async Task<CheckVatApprox> CheckVatApproxAsync(string countryCode, string vatNumber,
            string requesterCountryCode = null, string requesterVatNumber = null) =>
            await Task.Run(() =>
            {
                return CheckVatApprox(countryCode, vatNumber, requesterCountryCode, requesterVatNumber);
            });

        public static ViesService GetInstance() => new();
    }
}
