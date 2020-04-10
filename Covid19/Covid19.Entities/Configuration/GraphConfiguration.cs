﻿using Covid19.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Entities.Configuration
{
    public class GraphConfiguration : IEntityTypeConfiguration<Graph>
    {
        public void Configure(EntityTypeBuilder<Graph> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UpdatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}
