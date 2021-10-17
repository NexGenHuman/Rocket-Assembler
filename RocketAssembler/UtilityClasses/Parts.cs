using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocketAssembler.UtilityClasses
{
    public class Part
    {
        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Propolsion : Part
    {
        [JsonProperty("empty_mass")]
        public int empty_mass { get; set; }
        [JsonProperty("fuel_mass")]
        public int fuel_mass { get; set; }
        [JsonProperty("thrust")]
        public int thrust { get; set; }
        [JsonProperty("specific_impulse")]
        public int specific_impulse { get; set; }
        [JsonProperty("burn_time")]
        public int burn_time { get; set; }
    }

    public class Solid_Fuel_Booster : Propolsion { }

    public class Main_Stage : Propolsion { }

    public class Orbital_Stage : Propolsion { }

    public class Capsule : Part
    {
        [JsonProperty("crew")]
        public int crew { get; set; }
        [JsonProperty("design_life")]
        public int design_life { get; set; }
    }

    class Parts
    {
        [JsonProperty("solid_fuel_boosters")]
        public List<Solid_Fuel_Booster> solid_fuel_booster { get; set; }
        [JsonProperty("main_stages")]
        public List<Main_Stage> main_stage { get; set; }
        [JsonProperty("orbital_stages")]
        public List<Orbital_Stage> orbital_stage { get; set; }
        [JsonProperty("capsules")]
        public List<Capsule> capsule { get; set; }
    }
}
