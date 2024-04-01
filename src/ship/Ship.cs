using assignment_two.src.containers;
using assignment_two.utils;

namespace assignment_two
{
    public class Ship
    {
        private List<Container> containers;
        public ContainerUtils ContainerUtils { get; private set; }
        public CargoUtils CargoUtils { get; private set; }

        public Ship(ContainerUtils containerUtils, CargoUtils cargoUtils)
        {
            ContainerUtils = containerUtils;
            CargoUtils = cargoUtils;
        }

        public Container? CreateContainer(
            ContainerUtils.ContainerType containerType,
            uint maxPayLoad
        )
        {
            switch (containerType)
            {
                case ContainerUtils.ContainerType.Liquid:
                    return new LiquidContainer(ContainerUtils, maxPayLoad);
                case ContainerUtils.ContainerType.Gas:
                    return new GasContainer(ContainerUtils, maxPayLoad);
                case ContainerUtils.ContainerType.Refrigerated:
                    Console.WriteLine("Select product type for Refrigerated Container: ");
                    foreach (int i in Enum.GetValues(typeof(CargoUtils.CargoProductType)))
                    {
                        Console.WriteLine($" {i}");
                    }
                    int selection;

                    uint productType;
                    int maxTemperature;
                    if (
                        int.TryParse(Console.ReadLine(), out selection)
                        && selection <= Enum.GetNames(typeof(CargoUtils.CargoProductType)).Length
                    )
                    {
                        productType = (uint)selection;
                        Console.WriteLine("Type the max temperature for this container.");
                        if (int.TryParse(Console.ReadLine(), out selection) && selection > 0)
                        {
                            maxTemperature = selection;
                            return new RefrigeratedContainer(
                                ContainerUtils,
                                CargoUtils,
                                maxPayLoad,
                                (CargoUtils.CargoProductType)productType,
                                maxTemperature
                            );
                        }
                    }
                    Console.WriteLine(
                        "Invalid selection, returning default values  (Default product, 20 maxTemp).."
                    );
                    return new RefrigeratedContainer(ContainerUtils, CargoUtils, maxPayLoad, 0, 20);
            }
            return null;
        }

        public void LoadCargo(Container container) { }

        public void LoadShipWithContainer(Ship ship, params Container[] container) { }

        public void RemoveContainerFromShip(Ship ship, Container container) { }

        public void ReplaceContainer(Ship ship, Container c1, Container c2) { }

        public void TransferContainer(Ship ship, Container container) { }

        public void PrintContainerInfo(Container container) { }

        public void PrintShipAndCargo(Ship ship) { }
    }
}
