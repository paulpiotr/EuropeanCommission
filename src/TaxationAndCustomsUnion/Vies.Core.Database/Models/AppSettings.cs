#region using

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Reflection;
using log4net;
using NetAppCommon.AppSettings.Models;
using NetAppCommon.AppSettings.Models.Base;
using NetAppCommon.Helpers.Cache;

#endregion

#nullable enable annotations

namespace Vies.Core.Database.Models
{
    #region public partial class AppSettings

    /// <summary>
    ///     Klasa modelu ustawień aplikacji
    ///     The settings model class of the
    /// </summary>
    [NotMapped]
    public sealed class AppSettings : AppSettingsBaseModel
    {
        // Important !!!

        #region AppSettingsModel()

        public AppSettings()
        {
            try
            {
                var memoryCacheProvider = MemoryCacheProvider.GetInstance();
                var declaringTypeFullName = MethodBase.GetCurrentMethod()?.DeclaringType?.FullName;
                var filePathKey = $"{declaringTypeFullName}{@".FilePath"}";
                var filePath = (object)memoryCacheProvider.Get(filePathKey);
                if (null == filePath)
                {
                    AppSettingsRepository?.MergeAndCopyToUserDirectory(this);
                    memoryCacheProvider.Put(filePathKey, FilePath, TimeSpan.FromDays(1));
                }

                if (null != FileName && null != UserProfileDirectory)
                {
                    FilePath = (string)(filePath ?? Path.Combine(UserProfileDirectory, FileName));
                }

                var useGlobalDatabaseConnectionSettingsKey =
                    $"{declaringTypeFullName}{@".UseGlobalDatabaseConnectionSettings"}";
                var useGlobalDatabaseConnectionSettings =
                    (object)memoryCacheProvider.Get(useGlobalDatabaseConnectionSettingsKey);
                if (null == useGlobalDatabaseConnectionSettings)
                {
                    memoryCacheProvider.Put(useGlobalDatabaseConnectionSettingsKey, UseGlobalDatabaseConnectionSettings,
                        TimeSpan.FromDays(1));
                    if (UseGlobalDatabaseConnectionSettings)
                    {
                        var appSettingsModel = new AppSettingsModel();
                        ConnectionString = appSettingsModel.ConnectionString;
                        AppSettingsRepository?.MergeAndSave(this);
                    }
                }
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
        }

        #endregion

        // Important !!!

        #region public static AppSettingsBaseModel GetInstance()

        /// <summary>
        ///     Pobierz statyczną referencję do instancji AppSettingsBaseModel
        ///     Get a static reference to the AppSettingsBaseModel instance
        /// </summary>
        /// <returns>
        ///     Statyczna referencja do instancji AppSettingsBaseModel
        ///     A static reference to the AppSettingsBaseModel instance
        /// </returns>
        public static AppSettings GetInstance() => new();

        #endregion

        #region private readonly log4net.ILog log4net

        /// <summary>
        ///     Instancja do klasy Log4netLogger
        ///     Instance to Log4netLogger class
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        #region protected new string _fileName = FILENAME;

#if DEBUG
        private const string Filename = "europeancommission.taxationandcustomsunion.vies.core.dbcontext.json";
#else
        private const string Filename = "europeancommission.taxationandcustomsunion.vies.core.dbcontext.json";
#endif

        private new string? _fileName = Filename;

        public override string? FileName
        {
            get => _fileName;
            protected set
            {
                if (value != _fileName)
                {
                    _fileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        #endregion

        #region protected new string _connectionStringName = CONNECTIONSTRINGNAME;

#if DEBUG
        private const string Connectionstringname = "ViesCoreDatabaseContext";
#else
        private const string Connectionstringname = "ViesCoreDatabaseContext";
#endif

        private new string _connectionStringName = Connectionstringname;

        public override string ConnectionStringName
        {
            get => _connectionStringName;
            set
            {
                if (value != _connectionStringName)
                {
                    _connectionStringName = value;
                }
            }
        }

        #endregion

        //#region private string _requesterCountryCode; public string RequesterCountryCode

        //private string? _requesterCountryCode;

        //[JsonProperty(nameof(RequesterCountryCode))]
        //[Display(Name = "Domyślny kod kraju wnioskodawcy", Prompt = "Wpisz lub wybierz domyślny kod kraju wnioskodawcy", Description = "Domyślny kod kraju wnioskodawcy")]
        //[Required]
        //public string? RequesterCountryCode
        //{
        //    get =>
        //        _requesterCountryCode ??= AppSettingsRepository?.GetValue<string>(this, nameof(RequesterCountryCode));
        //    set
        //    {
        //        if (value != _requesterCountryCode)
        //        {
        //            _requesterCountryCode = value;
        //            OnPropertyChanged(nameof(RequesterCountryCode));
        //        }
        //    }
        //}
        //#endregion

        //#region private string _requesterVatNumber; public string RequesterVatNumber

        //private string? _requesterVatNumber;

        //[JsonProperty(nameof(RequesterVatNumber))]
        //[Display(Name = "Domyślny numer VAT wnioskodawcy", Prompt = "Wpisz domyślny numer VAT wnioskodawcy", Description = "Domyślny numer VAT wnioskodawcy")]
        //[Required]
        //public string? RequesterVatNumber
        //{
        //    get =>
        //        _requesterVatNumber ??= AppSettingsRepository?.GetValue<string>(this, nameof(RequesterVatNumber));
        //    set
        //    {
        //        if (value != _requesterVatNumber)
        //        {
        //            _requesterVatNumber = value;
        //            OnPropertyChanged(nameof(RequesterVatNumber));
        //        }
        //    }
        //}
        //#endregion
    }

    #endregion
}
