using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vies.Core.Models;
using Vies.Core.Services.Interface;

namespace Vies.Core.Services
{
    public class ViesService : IViesService
    {
        #region private readonly log4net.ILog log4net
        /// <summary>
        /// Log4net Logger
        /// Log4net Logger
        /// </summary>
        private readonly log4net.ILog _log4Net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);
        #endregion

        public static ViesService GetInstance()
        {
            return new ViesService();
        }

        public CheckVat CheckVat(string countryCode, string vatNumber)
        {
            try
            {
                var checkVatRequest = new ViesServiceReference.checkVatRequest
                {
                    countryCode = countryCode,
                    vatNumber = vatNumber
                };
                var checkVatPortTypeClient = new ViesServiceReference.checkVatPortTypeClient();
                ViesServiceReference.checkVatResponse checkVatResponse = checkVatPortTypeClient.checkVat(checkVatRequest);
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(checkVatResponse.GetType());
                var textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, checkVatResponse);
                CheckVat checkVat = NetAppCommon.Helpers.Xmls.XmlHelper.DeserializeXmlFromString<CheckVat>(textWriter.ToString());
#if DEBUG
                _log4Net.Debug(JsonConvert.SerializeObject(checkVat));
#endif
                return checkVat;
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            return null;
        }

        public async Task<CheckVat> CheckVatAsync(string countryCode, string vatNumber)
        {
            return await Task.Run(() =>
            {
                return CheckVat(countryCode, vatNumber);
            });
        }

        public CheckVatApprox CheckVatApprox(string countryCode, string vatNumber, string requesterCountryCode = null, string requesterVatNumber = null)
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
                var checkVatApproxRequest = new ViesServiceReference.checkVatApproxRequest
                {
                    countryCode = countryCode,
                    vatNumber = vatNumber,
                    requesterCountryCode = countryCode,
                    requesterVatNumber = vatNumber
                };
                var checkVatPortTypeClient = new ViesServiceReference.checkVatPortTypeClient();
                ViesServiceReference.checkVatApproxResponse checkVatApproxResponse = checkVatPortTypeClient.checkVatApprox(checkVatApproxRequest);
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(checkVatApproxResponse.GetType());
                var textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, checkVatApproxResponse);
                CheckVatApprox checkVatApprox = NetAppCommon.Helpers.Xmls.XmlHelper.DeserializeXmlFromString<CheckVatApprox>(textWriter.ToString());
#if DEBUG
                _log4Net.Debug(JsonConvert.SerializeObject(checkVatApprox));
                _log4Net.Debug(JsonConvert.SerializeObject(checkVatApproxResponse));
#endif
                return checkVatApprox;
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            return null;
        }

        public async Task<CheckVatApprox> CheckVatApproxAsync(string countryCode, string vatNumber, string requesterCountryCode = null, string requesterVatNumber = null)
        {
            return await Task.Run(() =>
            {
                return CheckVatApprox(countryCode, vatNumber, requesterCountryCode, requesterVatNumber);
            });
        }
    }
}
