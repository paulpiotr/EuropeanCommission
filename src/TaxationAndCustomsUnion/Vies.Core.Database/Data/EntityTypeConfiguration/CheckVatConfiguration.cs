using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vies.Core.Models;

namespace Vies.Core.Database.Data.EntityTypeConfiguration
{
    internal class CheckVatConfiguration : IEntityTypeConfiguration<CheckVat>
    {
        public void Configure(EntityTypeBuilder<CheckVat> builder)
        {
            builder.HasIndex(e => e.Id)
                .HasDatabaseName("IX_CheckVatId")
                .IsUnique(true);
            builder.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

            builder.HasIndex(e => e.UniqueIdentifierOfTheLoggedInUser)
                .HasDatabaseName("IX_CheckVatUniqueIdentifierOfTheLoggedInUser")
                .IsUnique(false);

            builder.HasIndex(e => e.Name)
                .HasDatabaseName("IX_CheckVatName")
                .IsUnique(false);

            builder.HasIndex(e => e.VatNumber)
                .HasDatabaseName("IX_CheckVatNumber")
                .IsUnique(false);

            builder.HasIndex(e => e.RequestDate)
                .HasDatabaseName("IX_CheckVatRequestDate")
                .IsUnique(false);

            builder.HasIndex(e => e.DateOfCreate)
                .HasDatabaseName("IX_CheckVatDateOfCreate")
                .IsUnique(false);

            builder.HasIndex(e => e.DateOfModification)
                .HasDatabaseName("IX_CheckVatDateOfModification")
                .IsUnique(false);

            builder.Property(e => e.DateOfCreate).HasDefaultValueSql("(getdate())");
        }
    }
}
