﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleIdServer.Domains;

namespace SimpleIdServer.Store.Configurations
{
    public class ScopeClaimConfiguration : IEntityTypeConfiguration<ScopeClaim>
    {
        public void Configure(EntityTypeBuilder<ScopeClaim> builder)
        {
            builder.Property<int>("Id").ValueGeneratedOnAdd();
            builder.HasKey("Id");
        }
    }
}
