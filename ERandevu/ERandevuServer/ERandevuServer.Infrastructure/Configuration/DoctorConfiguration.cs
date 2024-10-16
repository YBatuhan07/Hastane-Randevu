﻿using ERandevuServer.Domain.Entities;
using ERandevuServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERandevuServer.Infrastructure.Configuration
{
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");

            builder.Property(p => p.Department).HasConversion(v => v.Value,
                v => DepartmentEnum.FromValue(v))
                .HasColumnName("Department");
        }
    }
}
