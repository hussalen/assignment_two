using assignment_two.src.cargos;
using assignment_two.src.containers;
using assignment_two.utils;

namespace assignment_two
{
    public class Ship
    {
        private Dictionary<uint, Container> containers;
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

        public void LoadCargo(Cargo cargo, Container container)
        {
            container.LoadContainer(cargo);
        }

        public void LoadShipWithContainer(params Container[] container)
        {
            foreach (Container i in container)
            {
                containers.Add(i.SnUniqueNum, i);
            }
            Console.WriteLine("Added container(s)!");
        }

        public void RemoveContainerFromShip(Container container)
        {
            containers.Remove(container.SnUniqueNum);
            Console.WriteLine("Removed " + container.SerialNumber);
            Console.WriteLine("Current container(s) stored on ship: " + containers);
        }

        public void UnloadContainer(Container container)
        {
            container.EmptyCargo();
        }

        public void ReplaceContainer(Container c1, Container c2)
        {
            if (c1.GetType() == c2.GetType())
            {
                Container currentContainerInShip = containers[c1.SnUniqueNum];
                if (currentContainerInShip != null)
                {
                    RemoveContainerFromShip(containers[c1.SnUniqueNum]);
                    LoadShipWithContainer(c2);
                    return;
                }
                Console.WriteLine("Ship does not have " + c1.SerialNumber);
                return;
            }
            Console.WriteLine(
                "Uh oh, the containers (c1: "
                    + c1.SerialNumber
                    + ", c2: + "
                    + c2.SerialNumber
                    + ") are not of the same type"
            );
        }

        public void TransferContainerToOtherShip(Ship ship, Container container)
        {
            Container currentContainerInShip = containers[container.SnUniqueNum];
            if (currentContainerInShip != null)
            {
                RemoveContainerFromShip(containers[container.SnUniqueNum]);
                ship.LoadShipWithContainer(container);
                return;
            }
            Console.WriteLine("Ship does not have " + container.SerialNumber);
        }

        public void PrintContainerInfo(Container container)
        {
            Console.WriteLine(container);
        }

        public void PrintShipAndCargoInfo()
        {
            Console.WriteLine("Containers in ship: " + containers);
            string cargos = "";
            foreach (KeyValuePair<uint, Container> entry in containers)
            {
                if (entry.Value.cargo != null)
                    cargos += " [" + entry.Value.cargo.Type + "]";
            }
            Console.WriteLine("Cargos within the containers: " + cargos);
        }
    }
}
