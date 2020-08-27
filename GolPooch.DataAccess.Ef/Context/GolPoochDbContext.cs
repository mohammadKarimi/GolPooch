﻿using Elk.Core;
using Elk.EntityFrameworkCore;
using Elk.EntityFrameworkCore.Tools;
using GolPooch.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GolPooch.DataAccess.Ef
{
    public partial class GolPoochDbContext : ElkDbContext
    {
        public GolPoochDbContext() { }

        public GolPoochDbContext(DbContextOptions<GolPoochDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.OverrideDeleteBehavior();
            builder.RegisterAllEntities<IEntity>(typeof(User).Assembly);
        }
    }
}
