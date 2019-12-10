using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c=>c.Id);

            builder.Property(c => c.ISIN).HasMaxLength(20);

            builder.Property(c => c.Name).HasMaxLength(255);

            builder.Property(c => c.Ticker).HasMaxLength(255);

            builder.Property(c => c.WebSite).HasMaxLength(255);

        }
    }
}
