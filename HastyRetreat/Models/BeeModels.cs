using System;
using System.Collections;
using System.Collections.Generic;

namespace HastyRetreat.Models {

    #region Bee Related enumeratedtypes
    public enum enunBeeRoles { BEE_ROLE_QUEEN, BEE_ROLE_DRONE, BEE_ROLE_WORKER }
    public enum enunBeeSpecies { BEE_SPECIES_HONEY }
    public enum enunHiveType{ HIVE_TYPE_NUKEBOX, HIVE_TYPE_SUPER, HIVE_TYPE_KINGSUPER }
    #endregion

    public class BeeHive:IEnumerable<BeeHive> {
        #region BeeHive constructors
        public BeeHive() { }
        public BeeHive(QueenBee queen, enunHiveType hiveType, string hiveName="Not Named") {
            Queen = queen;
            this.AddBee(queen);
            Type = hiveType;
            DateStarted = System.DateTime.UtcNow;
            Name = hiveName;
        }
        #endregion

        #region BeeHive properties
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public QueenBee Queen { get; set; }
        public enunHiveType Type { get; set; }
        public virtual ICollection<Bee> Bees { get; set; }


    #endregion

    #region Beehive methods
        public Bee AddBee(Bee newBee) {
            return newBee;
        }

        public void swarm() { }
        #endregion

    #region IEnumerable plumbing

    public IEnumerator<BeeHive> GetEnumerator() {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
    }
    #endregion
    }

    public abstract class Bee {
        #region Bee constructors
        public Bee() {}

        public Bee(string name="no name")  {
            isAngry = false;
            Name = name;
            Species = enunBeeSpecies.BEE_SPECIES_HONEY;
            if (string.IsNullOrEmpty(Sound)) { Sound = "Buzz"; };
        }
        #endregion

        #region Bee property definitions
        #region Bee base class implemented properties
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isAngry { get; protected set; }
        #endregion

        #region derrived class implemented properties
        public enunBeeRoles Role { get; protected set; }
        public enunBeeSpecies Species { get; protected set; }
        public string Sound { get; protected set; }
        public bool  canSting { get; protected set; }
        #endregion
        #endregion

        #region methods
        public string makeNoise() {
            string response = this.Sound + (this.isAngry ? "!" : "");
            return response;
        }
        public void poke() { this.isAngry = true; }
        public void smoke() { this.isAngry = false; }
        #endregion
    }

    #region Base classes for types of Bees

    public class QueenBee : Bee {
        public QueenBee() { }
        public QueenBee(string name = "no name"): base(name) {
            Sound = "Squeak";
            Role = enunBeeRoles.BEE_ROLE_QUEEN;
            canSting = false;
        }                 
    }

    public class WorkerBee : Bee {
        public WorkerBee() { }
        public WorkerBee(string name = "no name") : base(name) {
            Role = enunBeeRoles.BEE_ROLE_WORKER;
            canSting = false;
        }
    }

    public class DroneBee : Bee {
        public DroneBee() { }
        public DroneBee(string name = "no name") : base(name) {
            Role = enunBeeRoles.BEE_ROLE_DRONE;
            canSting = false;
        }
    }
    #endregion
}
