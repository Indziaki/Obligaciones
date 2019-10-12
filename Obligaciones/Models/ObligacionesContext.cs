using System;
using Microsoft.EntityFrameworkCore;

namespace Obligaciones.Models
{
    public class ObligacionesContext : DbContext
    {
        private readonly string _dbName;
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contributor> Contributors { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<Estate> Estates { get; set; }
        public virtual DbSet<Obligation> Obligations { get; set; }
        public virtual DbSet<WorkLoad> WorkLoads { get; set; }
        public virtual DbSet<WorkLoadRegistry> WorkLoadRegistries { get; set; }

        public ObligacionesContext(DbContextOptions<ObligacionesContext> options) : base(options)
        {
        }

        public ObligacionesContext(string dbName)
        {
            _dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!string.IsNullOrEmpty(_dbName)) optionsBuilder.UseSqlServer(_dbName);
        }
    }
}
