using System;
using Microsoft.EntityFrameworkCore;
using penca.lb.data.Model;

namespace penca.lb.data.Context
{
    public class PencaContext : DbContext
    {
        public PencaContext(DbContextOptions<PencaContext> options) : base(options)
        {
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Stage> Stages{ get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
        public DbSet<Team> Teams { get; set; }
    }

}

