using assignment_two.utils;

namespace assignment_two.src.cargos
{
    public class Cargo(CargoUtils.CargoType type, uint mass)
    {
        public uint Mass { get; } = mass;
        public CargoUtils.CargoType Type { get; set; } = type;
    }
}
