using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vies.Core.Models;

namespace Vies.Core.Database.Data.EntityTypeConfiguration
{
    internal class CheckVatApproxConfiguration : IEntityTypeConfiguration<CheckVatApprox>
    {
        public void Configure(EntityTypeBuilder<CheckVatApprox> builder)
        {
            builder.HasIndex(e => e.Id)
                .HasDatabaseName("IX_CheckVatApproxId")
                .IsUnique(true);
            builder.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

            builder.HasIndex(e => e.UniqueIdentifierOfTheLoggedInUser)
                .HasDatabaseName("IX_CheckVatApproxUniqueIdentifierOfTheLoggedInUser")
                .IsUnique(false);

            builder.HasIndex(e => e.TraderName)
                .HasDatabaseName("IX_CheckVatApproxTraderName")
                .IsUnique(false);

            builder.HasIndex(e => e.VatNumber)
                .HasDatabaseName("IX_CheckVatApproxNumber")
                .IsUnique(false);

            builder.HasIndex(e => e.RequestDate)
                .HasDatabaseName("IX_CheckVatApproxRequestDate")
                .IsUnique(false);

            builder.HasIndex(e => e.DateOfCreate)
                .HasDatabaseName("IX_CheckVatApproxDateOfCreate")
                .IsUnique(false);

            builder.HasIndex(e => e.DateOfModification)
                .HasDatabaseName("IX_CheckVatApproxDateOfModification")
                .IsUnique(false);

            builder.Property(e => e.DateOfCreate).HasDefaultValueSql("(getdate())");
        }
    }
}
