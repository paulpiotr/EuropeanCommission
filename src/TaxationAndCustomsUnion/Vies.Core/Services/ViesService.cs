#region using

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using log4net;
using NetAppCommon.Helpers.Xmls;
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
                if (null != checkVatResponse)
                {
                    var xmlSerializer = new XmlSerializer(checkVatResponse.GetType());
                    var textWriter = new StringWriter();
                    xmlSerializer.Serialize(textWriter, checkVatResponse);
                    CheckVat checkVat = XmlHelper.DeserializeXmlFromString<CheckVat>(textWriter.ToString());
                    return checkVat;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e.Message, e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException.Message, e.InnerException);
                }
            }

            return null;
        }

        public async Task<CheckVat> CheckVatAsync(string countryCode, string vatNumber) =>
            await Task.Run(() => CheckVat(countryCode, vatNumber));

        public CheckVatApprox CheckVatApprox(string countryCode, string vatNumber, string requesterCountryCode = null,
            string requesterVatNumber = null)
        {
            try
            {
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
                if (null != checkVatApproxResponse)
                {
                    var xmlSerializer = new XmlSerializer(checkVatApproxResponse.GetType());
                    var textWriter = new StringWriter();
                    xmlSerializer.Serialize(textWriter, checkVatApproxResponse);
                    CheckVatApprox checkVatApprox =
                        XmlHelper.DeserializeXmlFromString<CheckVatApprox>(textWriter.ToString());
//#if DEBUG
//                    _log4Net.Debug(JsonConvert.SerializeObject(checkVatApprox));
//                    _log4Net.Debug(JsonConvert.SerializeObject(checkVatApproxResponse));
//#endif
                    return checkVatApprox;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e.Message, e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException.Message, e.InnerException);
                }
            }

            return null;
        }

        public async Task<CheckVatApprox> CheckVatApproxAsync(string countryCode, string vatNumber,
            string requesterCountryCode = null, string requesterVatNumber = null) =>
            await Task.Run(() => CheckVatApprox(countryCode, vatNumber, requesterCountryCode, requesterVatNumber));

        public static ViesService GetInstance() => new();
    }
}
