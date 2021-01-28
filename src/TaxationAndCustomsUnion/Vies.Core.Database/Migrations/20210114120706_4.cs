using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using NetAppCommon.Helpers.Db.Mssql;

namespace Vies.Core.Database.Migrations
{
    public partial class _4 : Migration
    {
        private readonly log4net.ILog _log4Net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                AuditMigration.Drop(migrationBuilder, "etvc", "CheckVatApprox");
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
        }
    }
}
