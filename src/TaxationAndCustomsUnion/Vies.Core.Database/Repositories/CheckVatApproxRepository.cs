using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vies.Core.Database.Data;
using Vies.Core.Database.Models;
using Vies.Core.Database.Repositories.Interface;
using Vies.Core.Models;

#nullable enable annotations

namespace Vies.Core.Database.Repositories
{
    public class CheckVatApproxRepository : ICheckVatApproxRepository
    {
        #region private readonly log4net.ILog _log4Net
        /// <summary>
        /// Referencja klasy Log4NetLogger
        /// Reference to the Log4NetLogger class
        /// </summary>
        private readonly log4net.ILog _log4Net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);
        #endregion

        #region private readonly AppSettings _appSettings
        /// <summary>
        /// Instancja do klasy ustawień Vies.Core.Database.Models.AppSettings
        /// Instance to the Vies.Core.Database.Models.AppSettings settings class
        /// </summary>
        private readonly AppSettings _appSettings = new AppSettings();
        #endregion

        #region private readonly ViesCoreDatabaseContext _context
        /// <summary>
        /// Instancja do klasy ustawień Vies.Core.Database.Models.ViesCoreDatabaseContext
        /// Instance to the Vies.Core.Database.Models.ViesCoreDatabaseContext settings class
        /// </summary>
        private readonly ViesCoreDatabaseContext _context = null;
        #endregion

        public CheckVatApproxRepository()
        {
            _context = new ViesCoreDatabaseContext(_appSettings.GetDbContextOptions<ViesCoreDatabaseContext>());
        }

        public CheckVatApproxRepository(ViesCoreDatabaseContext context)
        {
            _context = context;
        }

        public CheckVatApproxRepository(IServiceProvider serviceProvider)
        {
            IServiceScope serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            ViesCoreDatabaseContext context = serviceScope.ServiceProvider.GetService<ViesCoreDatabaseContext>();
            _context = context;
            //#if DEBUG
            //            _log4Net.Debug($" { _context.Database.GetConnectionString() }, { _context.Database.CanConnect() }");
            //#endif
        }

        public CheckVatApproxRepository(IServiceScopeFactory serviceScopeFactory)
        {
            IServiceScope serviceScope = serviceScopeFactory.CreateScope();
            ViesCoreDatabaseContext context = serviceScope.ServiceProvider.GetService<ViesCoreDatabaseContext>();
            _context = context;
            //#if DEBUG
            //            _log4Net.Debug($" { _context.Database.GetConnectionString() }, { _context.Database.CanConnect() }");
            //#endif
        }

        public static CheckVatApproxRepository GetInstance()
        {
            return new CheckVatApproxRepository();
        }

        public static CheckVatApproxRepository GetInstance(ViesCoreDatabaseContext context)
        {
            return new CheckVatApproxRepository(context);
        }

        public static CheckVatApproxRepository GetInstance(IServiceProvider serviceProvider)
        {
            return new CheckVatApproxRepository(serviceProvider);
        }

        public static CheckVatApproxRepository GetInstance(IServiceScopeFactory serviceScopeFactory)
        {
            return new CheckVatApproxRepository(serviceScopeFactory);
        }

        public async Task<CheckVatApprox> FindByCountryCodeAndVatNumberAsync(string countryCode, string vatNumber, int cacheLifeTime = 0)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return FindByCountryCodeAndVatNumber(countryCode, vatNumber, cacheLifeTime);
                }
                catch (Exception e)
                {
                    _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                }
                return null;
            });
        }

        public CheckVatApprox FindByCountryCodeAndVatNumber(string countryCode, string vatNumber, int cacheLifeTime = 0)
        {
            try
            {
                //_context.CheckVatApprox.RemoveRange(_context.CheckVatApprox.ToList());
                //_context.SaveChanges();
                CheckVatApprox checkVat = cacheLifeTime > 0
                    ? _context.CheckVatApprox.Where(w => w.CountryCode == countryCode && w.VatNumber == vatNumber && w.DateOfModification >= DateTime.Now.AddSeconds((double)cacheLifeTime * -1))/*.FromCache(_context.GetMemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(cacheLifeTime)), countryCode, vatNumber, cacheLifeTime.ToString())*/.FirstOrDefault()
                    : _context.CheckVatApprox.Where(w => w.CountryCode == countryCode && w.VatNumber == vatNumber).FirstOrDefault();
                if (null != checkVat)
                {
                    return checkVat;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            return null;
        }

        public CheckVatApprox Save(CheckVatApprox checkVat)
        {
            try
            {
                if (_context.CheckVatApprox.Where(w => null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber && null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode).Any())
                {
                    CheckVatApprox checkVatWhere = _context.CheckVatApprox.Where(w => null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber && null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode).FirstOrDefault();
                    if (null != checkVatWhere)
                    {
                        checkVat.Id = checkVatWhere.Id;
                        checkVat.DateOfCreate = checkVatWhere.DateOfCreate;
                        _context.Entry(checkVatWhere).State = EntityState.Detached;
                    }
                }
                checkVat.DateOfModification = DateTime.Now;
                _context.Entry(checkVat).State = "00000000-0000-0000-0000-000000000000" != checkVat.Id.ToString() ? EntityState.Modified : EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            return checkVat;
        }

        public async Task<CheckVatApprox> SaveAsync(CheckVatApprox checkVat)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (await _context.CheckVatApprox.Where(w => null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber && null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode).AnyAsync())
                    {
                        CheckVatApprox checkVatWhere = await _context.CheckVatApprox.Where(w => null != checkVat.VatNumber && w.VatNumber == checkVat.VatNumber && null != checkVat.CountryCode && w.CountryCode == checkVat.CountryCode).FirstOrDefaultAsync();
                        if (null != checkVatWhere)
                        {
                            checkVat.Id = checkVatWhere.Id;
                            //checkVat.DateOfCreate = checkVatWhere.DateOfCreate;
                            _context.Entry(checkVatWhere).State = EntityState.Detached;
                        }
                    }
                    //checkVat.DateOfModification = DateTime.Now;
                    _context.Entry(checkVat).State = "00000000-0000-0000-0000-000000000000" != checkVat.Id.ToString() ? EntityState.Modified : EntityState.Added;
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                }
                return checkVat;
            });
        }
    }
}
