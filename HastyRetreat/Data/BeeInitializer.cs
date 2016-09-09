using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HastyRetreat.Models;

namespace HastyRetreat.Data {
    class BeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BeeContext> {
        protected override void Seed(BeeContext context) {

            QueenBee elizibuzz = new QueenBee("Elizibuzz");
            QueenBee beeatrice = new QueenBee("Bee-atrice");

            var Bees = new List<Bee> {
                elizibuzz,
                beeatrice,
                new WorkerBee("Larry"),
                new DroneBee()
            };

            Bees.ForEach(s => context.Bees.Add(s));
            context.SaveChanges();

            var BeeHives = new List<BeeHive>
            {
                new BeeHive(beeatrice,enunHiveType.HIVE_TYPE_KINGSUPER,"Kingdom of Bee-A-Trice"),
                new BeeHive(elizibuzz,enunHiveType.HIVE_TYPE_NUKEBOX),
            };

            BeeHives.ForEach(s => context.BeeHives.Add(s));
            context.SaveChanges();
        }
    }
}