#region using

using System;
using System.Reflection;
using log4net;
using Microsoft.EntityFrameworkCore.Migrations;
using NetAppCommon.Helpers.Db.Mssql;

#endregion

namespace Vies.Core.Database.Migrations
{
    public partial class _2 : Migration
    {
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            try
            {
                AuditMigration.Create(migrationBuilder, "etvc", "CheckVat");
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            try
            {
                AuditMigration.Create(migrationBuilder, "etvc", "CheckVatApprox");
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            try
            {
                AuditMigration.Drop(migrationBuilder, "etvc", "CheckVat");
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            try
            {
                AuditMigration.Drop(migrationBuilder, "etvc", "CheckVatApprox");
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
        }
    }
}
