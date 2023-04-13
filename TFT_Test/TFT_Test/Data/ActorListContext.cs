﻿using Microsoft.EntityFrameworkCore;
using TFT_Test.Models;

namespace TFT_Test.Data
{
	public class ActorListContext : DbContext
	{
		public ActorListContext(DbContextOptions<ActorListContext> options) : base(options) { }
		public DbSet<Actor> Actors { get; set; }
	}
}