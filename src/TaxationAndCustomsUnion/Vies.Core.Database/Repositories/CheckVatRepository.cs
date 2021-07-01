#region using

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vies.Core.Database.Data;
using Vies.Core.Database.Models;
using Vies.Core.Database.Repositories.Interface;
using Vies.Core.Models;

#endregion

#nullable enable annotations

namespace Vies.Core.Database.Repositories
{
    public class CheckVatRepository : ICheckVatRepository
    {
        #region private readonly AppSettings _appSettings

        /// <summary>
        ///     Instancja do klasy ustawień Vies.Core.Database.Models.AppSettings
        ///     Instance to the Vies.Core.Database.Models.AppSettings settings class
        /// </summary>
        private readonly AppSettings _appSettings = new();

        #endregion

        #region private readonly ViesCoreDatabaseContext _context

        /// <summary>
        ///     Instancja do klasy ustawień Vies.Core.Database.Models.ViesCoreDatabaseContext
        ///     Instance to the Vies.Core.Database.Models.ViesCoreDatabaseContext settings class
        /// </summary>
        private readonly ViesCoreDatabaseContext _context;

        #endregion

        #region private readonly log4net.ILog _log4Net

        /// <summary>
        ///     Referencja klasy Log4NetLogger
        ///     Reference to the Log4NetLogger class
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        public CheckVatRepository()
        {
            _context = new ViesCoreDatabaseContext(_appSettings.GetDbContextOptions<ViesCoreDatabaseContext>());
        }

        public CheckVatRepository(ViesCoreDatabaseContext context)
        {
            _context = context;
        }

        public CheckVatRepository(IServiceProvider serviceProvider)
        {
            try
            {
                IServiceScope serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
                ViesCoreDatabaseContext context = serviceScope.ServiceProvider.GetService<ViesCoreDatabaseContext>();
                if (null != context)
                {
                    _context = context;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }
        }

        public CheckVatRepository(IServiceScopeFactory serviceScopeFactory)
        {
            try
            {
                IServiceScope serviceScope = serviceScopeFactory.CreateScope();
                ViesCoreDatabaseContext context = serviceScope.ServiceProvider.GetService<ViesCoreDatabaseContext>();
                if (null != context)
                {
                    _context = context;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }
        }

        public async Task<CheckVat?> FindByCountryCodeAndVatNumberAsync(string countryCode, string vatNumber,
            int cacheLifeTime = 0) =>
            await Task.Run(() =>
            {
                try
                {
                    return FindByCountryCodeAndVatNumber(countryCode, vatNumber, cacheLifeTime);
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }

                return null;
            });

        public CheckVat? FindByCountryCodeAndVatNumber(string countryCode, string vatNumber, int cacheLifeTime = 0)
        {
            try
            {
                CheckVat checkVat = cacheLifeTime > 0
                    ? _context.CheckVat.FirstOrDefault(w =>
                        w.CountryCode == countryCode && w.VatNumber == vatNumber && w.DateOfModification >=
                        DateTime.Now.AddSeconds((double)cacheLifeTime * -1))
                    : _context.CheckVat.FirstOrDefault(w => w.CountryCode == countryCode && w.VatNumber == vatNumber);
                if (null != checkVat)
                {
                    return checkVat;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            return null;
        }

        public CheckVat Save(CheckVat checkVat)
        {
            try
            {
                if (_context.CheckVat.Any(w =>
                    null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber && null != checkVat.CountryCode &&
                    w.CountryCode == checkVat.CountryCode))
                {
                    CheckVat checkVatWhere = _context.CheckVat.FirstOrDefault(w => null != checkVat.VatNumber &&
                        w.VatNumber == checkVat.VatNumber &&
                        null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode);
                    if (null != checkVatWhere)
                    {
                        checkVat.Id = checkVatWhere.Id;
                        checkVat.DateOfCreate = checkVatWhere.DateOfCreate;
                        _context.Entry(checkVatWhere).State = EntityState.Detached;
                    }
                }

                checkVat.DateOfModification = DateTime.Now;
                _context.Entry(checkVat).State = "00000000-0000-0000-0000-000000000000" != checkVat.Id.ToString()
                    ? EntityState.Modified
                    : EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }
            }

            return checkVat;
        }

        public async Task<CheckVat> SaveAsync(CheckVat checkVat) =>
            await Task.Run(async () =>
            {
                try
                {
                    if (await _context.CheckVat.Where(w =>
                        null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber &&
                        null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode).AnyAsync())
                    {
                        CheckVat checkVatWhere = await _context.CheckVat.Where(w =>
                                null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber &&
                                null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode)
                            .FirstOrDefaultAsync();
                        if (null != checkVatWhere)
                        {
                            checkVat.Id = checkVatWhere.Id;
                            _context.Entry(checkVatWhere).State = EntityState.Detached;
                        }
                    }

                    _context.Entry(checkVat).State = "00000000-0000-0000-0000-000000000000" != checkVat.Id.ToString()
                        ? EntityState.Modified
                        : EntityState.Added;

                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    _log4Net.Error(e);
                    if (null != e.InnerException)
                    {
                        _log4Net.Error(e.InnerException);
                    }
                }

                return checkVat;
            });

        public static CheckVatRepository GetInstance() => new();

        public static CheckVatRepository GetInstance(ViesCoreDatabaseContext context) => new(context);

        public static CheckVatRepository GetInstance(IServiceProvider serviceProvider) => new(serviceProvider);

        public static CheckVatRepository GetInstance(IServiceScopeFactory serviceScopeFactory) =>
            new(serviceScopeFactory);
    }
}
