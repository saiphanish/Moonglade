﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moonglade.Data.Entities;

namespace Moonglade.Data.Configurations
{
    [ExcludeFromCodeCoverage]
    public class BlogThemeConfiguration : IEntityTypeConfiguration<BlogThemeEntity>
    {
        public void Configure(EntityTypeBuilder<BlogThemeEntity> builder)
        {
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.ThemeName).HasMaxLength(32);
        }
    }
}
