#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetAppCommon.Helpers;
using Vies.Core.Database.Data.EntityTypeConfiguration;
using Vies.Core.Database.Models;
using Vies.Core.Models;

#endregion

namespace Vies.Core.Database.Data
{
    public class ViesCoreDatabaseContext : DbContext
    {
        #region private readonly AppSettings _appSettings

        /// <summary>
        ///     Instancja do klasy ustawień Vies.Core.Database.Models.AppSettings
        ///     Instance to the Vies.Core.Database.Models.AppSettings settings class
        /// </summary>
        private readonly AppSettings _appSettings = new();

        #endregion

        #region private readonly log4net.ILog _log4Net

        /// <summary>
        ///     Referencja klasy Log4NetLogger
        ///     Reference to the Log4NetLogger class
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        //#region public ViesCoreDatabaseContext()

        ///// <summary>
        /////     Konstruktor
        /////     Constructor
        ///// </summary>
        //public ViesCoreDatabaseContext()
        //{
        //    CheckAndMigrate();
        //}

        //#endregion

        #region public ViesCoreDatabaseContext(DbContextOptions<ViesCoreDatabaseContext> options)

        /// <summary>
        ///     Konstruktor klasy kontekstu bazy danych api wykazu podatników VAT
        ///     Constructor database context classes api list of VAT taxpayers
        /// </summary>
        /// <param name="options">
        ///     Opcje połączenia do bazy danych options jako DbContextOptions z ViesCoreDatabaseContext
        ///     Database connection options options as DbContextOptions from ViesCoreDatabaseContext
        /// </param>
        public ViesCoreDatabaseContext(DbContextOptions<ViesCoreDatabaseContext> options)
            : base(options)
        {
            CheckAndMigrate();
        }

        #endregion

        #region public virtual DbSet<CheckVat> CheckVat

        /// <summary>
        ///     Model danych Vies.Core.Models.CheckVat jako DbSet
        ///     Data model Vies.Core.Models.CheckVat as DbSet
        /// </summary>
        public virtual DbSet<CheckVat> CheckVat { get; set; }

        #endregion

        #region public virtual DbSet<CheckVatApprox> CheckVatApprox

        /// <summary>
        ///     Model danych Vies.Core.Models.CheckVatApprox jako DbSet
        ///     Data model Vies.Core.Models.CheckVatApprox as DbSet
        /// </summary>
        public virtual DbSet<CheckVatApprox> CheckVatApprox { get; set; }

        #endregion

        #region public void CheckAndMigrate()

        /// <summary>
        ///     Sprawdź ostatnią datę migracji bazy danych lub wymuś wykonanie, jeśli opcja CheckAndMigrate jest zaznaczona i
        ///     wykonaj migrację bazy danych.
        ///     Check the latest database migration date or force execution if CheckAndMigrate is selected and perform database
        ///     migration.
        /// </summary>
        public void CheckAndMigrate() =>
            Task.Run(async () =>
            {
                await CheckAndMigrateAsync();
            }).Wait();

        #endregion

        #region public async Task CheckAndMigrateAsync()

        /// <summary>
        ///     Sprawdź ostatnią datę migracji bazy danych lub wymuś wykonanie, jeśli opcja CheckAndMigrate jest zaznaczona i
        ///     wykonaj migrację bazy danych.
        ///     Check the latest database migration date or force execution if CheckAndMigrate is selected and perform database
        ///     migration.
        /// </summary>
        /// <returns>
        ///     async Task
        ///     async Task
        /// </returns>
        public async Task CheckAndMigrateAsync()
        {
            DateTime? lastMigrateDateTime = null;
            try
            {
                if (_appSettings.AppSettingsRepository != null)
                {
                    lastMigrateDateTime =
                        await _appSettings.AppSettingsRepository.GetValueAsync<DateTime>(_appSettings,
                            "LastMigrateDateTime");
                    var isCheckAndMigrate =
                        await _appSettings.AppSettingsRepository.GetValueAsync<bool>(_appSettings, "CheckAndMigrate");
                    var dateTimeDiffDays = (DateTime.Now - (DateTime)lastMigrateDateTime).Days;
                    if ((isCheckAndMigrate || dateTimeDiffDays >= 1) &&
                        (await Database.GetPendingMigrationsAsync()).Any())
                    {
                        try
                        {
#if DEBUG
                            _log4Net.Debug("Try CheckAndMigrateAsync...");
#endif
                            await EntityContextHelper.RunMigrationAsync(this);
#if DEBUG
                            _log4Net.Debug("Ok");
#endif
                        }
                        catch (Exception e)
                        {
                            _log4Net.Warn(
                                $"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n",
                                e);
                        }

                        _appSettings.LastMigrateDateTime = DateTime.Now;
                        await _appSettings.AppSettingsRepository.MergeAndSaveAsync(_appSettings);
                    }
                }
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            finally
            {
                if (null == lastMigrateDateTime || lastMigrateDateTime == DateTime.MinValue)
                {
                    _appSettings.LastMigrateDateTime = DateTime.Now;
                    if (_appSettings.AppSettingsRepository != null)
                    {
                        await _appSettings.AppSettingsRepository.MergeAndSaveAsync(_appSettings);
                    }
                }
            }
        }

        #endregion

        #region public override int SaveChanges(bool acceptAllChangesOnSuccess)

        /// <summary>
        ///     Przeciążona metoda SaveChanges
        ///     Overloaded SaveChanges method
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">
        ///     bool acceptAllChangesOnSuccess
        /// </param>
        /// <returns>
        ///     int
        /// </returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetDateOfCreateAndDateOfModification();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        #endregion

        public override int SaveChanges()
        {
            SetDateOfCreateAndDateOfModification();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            SetDateOfCreateAndDateOfModification();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDateOfCreateAndDateOfModification();
            return base.SaveChangesAsync(cancellationToken);
        }

        #region private void SetDateOfCreateAndDateOfModification()

        /// <summary>
        ///     Ustaw datę utworzenia i datę modyfikacji
        ///     Set creation date and modification date
        /// </summary>
        private void SetDateOfCreateAndDateOfModification()
        {
            IEnumerable<EntityEntry> iEnumerableEntityEntry = ChangeTracker.Entries().Where(x =>
                x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (EntityEntry entity in iEnumerableEntityEntry)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateOfCreate = DateTime.Now;
                    ((BaseEntity)entity.Entity).DateOfModification = DateTime.Now;
                }

                ((BaseEntity)entity.Entity).DateOfModification = DateTime.Now;
            }
        }

        #endregion

        #region protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        /// <summary>
        ///     Zdarzenie wyzwalające konfigurację bazy danych
        ///     Database configuration triggering event
        /// </summary>
        /// <param name="optionsBuilder">
        ///     Fabryka budowania połączenia do bazy danych optionsBuilder jako DbContextOptionsBuilder
        ///     Factory building connection to the database optionsBuilder AS DbContextOptionsBuilder
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(_appSettings.GetConnectionString(), x => x.MigrationsHistoryTable("__EFMigrationsHistory", "etvc"));
                }
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
        }

        #endregion

        #region protected override void OnModelCreating(ModelBuilder modelBuilder)

        /// <summary>
        ///     Zdarzenie wyzwalające tworzenie modelu bazy danych
        ///     The event that triggers the creation of the database model
        /// </summary>
        /// <param name="modelBuilder">
        ///     Fabryka budowania modelu bazy danych modelBuilder jako ModelBuilder
        ///     ModelBuilder database model building as ModelBuilder
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CheckVatConfiguration());
            modelBuilder.ApplyConfiguration(new CheckVatApproxConfiguration());
        }

        #endregion

        #region public object GetConnectionString()

        /// <summary>
        ///     Pobierz łańcuch połączenia do bazy danych
        ///     Get the connection string to the database
        /// </summary>
        /// <returns>
        ///     Łańcuch połączenia do bazy danych jako string
        ///     Database connection string as string
        /// </returns>
        public object GetConnectionString() => Database.GetConnectionString();

        #endregion
    }
}
