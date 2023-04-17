﻿using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class ActorCRUDContext : DbContext
	{
		public ActorCRUDContext(DbContextOptions<ActorCRUDContext> options) : base(options) { }
		public DbSet<Actor> Actor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
