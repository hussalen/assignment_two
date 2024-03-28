using assignment_two.utils;

namespace assignment_two
{
    public abstract class Cargo
    {
        public int Mass {get;}
        public string Name {get;}
        public cargoutils.CargoType Type {get; set;}

        public Cargo(string name)
        {
            Name = name;
             
        }
    }
}