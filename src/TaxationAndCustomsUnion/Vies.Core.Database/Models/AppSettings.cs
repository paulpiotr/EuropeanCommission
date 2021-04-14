#region using

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Reflection;
using log4net;
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
    public sealed class AppSettings : AppSettingsWithDatabase
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
                        var appSettingsModel = new NetAppCommon.AppSettings.Models.AppSettings();
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

        private string? _fileName = Filename;

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

        private string _connectionStringName = Connectionstringname;

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

    }

    #endregion
}
