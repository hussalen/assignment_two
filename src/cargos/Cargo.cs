using assignment_two.utils;

namespace assignment_two.src.cargos
{
    public class Cargo(cargoutils.CargoType type, uint mass)
    {
        public uint Mass { get; } = mass;
        public cargoutils.CargoType Type { get; set; } = type;
        public string Name { get; private set; } = type.ToString();
    }
}
