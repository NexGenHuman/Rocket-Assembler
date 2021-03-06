using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketAssembler.UtilityClasses
{
    class Rocket
    {
        public string name;
        public Capsule capsule;
        public Orbital_Stage orbital_stage;
        public Main_Stage main_stage;
        public Solid_Fuel_Booster solid_fuel_booster;

        public Rocket(string _name, Capsule c, Orbital_Stage os, Main_Stage ms, Solid_Fuel_Booster sfb)
        {
            name = _name;
            capsule = c;
            orbital_stage = os;
            main_stage = ms;
            solid_fuel_booster = sfb;
        }
    }
}
