using System.Data.SqlTypes;
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

        protected static uint nextId;
        public uint Id { get; private set; }

        public Ship(ContainerUtils containerUtils, CargoUtils cargoUtils)
        {
            containers = [];
            ContainerUtils = containerUtils;
            CargoUtils = cargoUtils;
            Id = ++nextId;
        }

        public Container CreateContainer(
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
            Console.WriteLine("Something went wrong! Returning liquid..");
            return new LiquidContainer(ContainerUtils, maxPayLoad);
        }

        public void LoadCargo(Container container, Cargo cargo)
        {
            container.LoadContainer(cargo);
        }

        public void LoadShipWithContainer(params Container[] container)
        {
            foreach (Container i in container)
            {
                try
                {
                    containers.Add(i.SnUniqueNum, i);
                }
                catch (Exception)
                {
                    Console.WriteLine(
                        "Container " + i.SerialNumber + " is already loaded in the ship."
                    );
                    continue;
                }
            }
            Console.WriteLine("Added container(s) to ship with ID " + Id + "!");
        }

        public void RemoveContainerFromShip(Container container)
        {
            containers.Remove(container.SnUniqueNum);
            Console.WriteLine("Removed " + container.SerialNumber + " from ship with ID " + Id);
        }

        public void UnloadContainer(Container container)
        {
            container.EmptyCargo();
            Console.WriteLine("Unloaded " + container.SerialNumber + " from the ship");
        }

        public void ReplaceContainer(Container c1, Container c2)
        {
            if (c1 == null || c2 == null)
            {
                Console.WriteLine("Ship does not exist, ReplaceContainer failed..");
                return;
            }
            if (c1 == c2)
            {
                Console.WriteLine(
                    "Same container was provided twice in ReplaceContainer method, nothing is done.."
                );
                return;
            }

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
            Console.WriteLine(container.ToString());
        }

        public void PrintShipAndCargoInfo()
        {
            Console.WriteLine("Ship ID: " + Id);
            Console.WriteLine("Containers in ship: " + GetContainersList());
            string cargos = "[ ";

            foreach (Container entry in containers.Values)
            {
                try
                {
                    cargos += entry.cargo.Type;
                }
                catch
                {
                    Console.WriteLine("Missing cargo from " + entry.SerialNumber);
                    continue;
                }
                cargos += ", ";
            }
            cargos += "]";
            Console.WriteLine("Cargos within the containers: " + cargos);
        }

        private string GetContainersList()
        {
            string str = "";
            foreach (KeyValuePair<uint, Container> entry in containers)
            {
                str += string.Format(
                    "ID = {0}, Container = {1}" + Environment.NewLine,
                    entry.Key,
                    entry.Value.SerialNumber
                );
            }
            return str;
        }
    }
}
