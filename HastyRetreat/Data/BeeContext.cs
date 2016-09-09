using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HastyRetreat.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace HastyRetreat.Data {
    class BeeContext:DbContext {
        public BeeContext():base("name=HastyRetreatDB") {}

        public DbSet<BeeHive> BeeHives { get; set; }
        public DbSet<Bee> Bees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
