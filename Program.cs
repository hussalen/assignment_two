// See https://aka.ms/new-console-template for more information

using assignment_two;
using assignment_two.src.cargos;
using assignment_two.src.containers;
using assignment_two.utils;

ContainerUtils containerUtils = ContainerUtils.Instance;
CargoUtils cargoUtils = CargoUtils.Instance;

Ship ship = new Ship(containerUtils, cargoUtils);

LiquidContainer liquidContainer = new(ship.ContainerUtils, 500);
LiquidContainer liquidContainer2 = new(ship.ContainerUtils, 500);
LiquidContainer liquidContainer3 = new(ship.ContainerUtils, 500);

GasContainer gasContainer1 = (GasContainer)
    ship.CreateContainer(ContainerUtils.ContainerType.Gas, 750);

RefrigeratedContainer fridgedContainer =
    new(ship.ContainerUtils, ship.CargoUtils, 500, CargoUtils.CargoProductType.None, 20);

Cargo hazardousCargo1 = new(CargoUtils.CargoType.Hazardous, 251);
Cargo ordinaryCargo = new(CargoUtils.CargoType.Ordinary, 500);
Cargo gasCargo = new(CargoUtils.CargoType.Gas, 700);
Cargo fridgedCargo = new(CargoUtils.CargoType.Ordinary, 300);

gasContainer1.LoadContainer(gasCargo);
gasContainer1.EmptyCargo();
Console.WriteLine("---------------");
liquidContainer3.LoadContainer(hazardousCargo1);
Console.WriteLine("---------------");
fridgedContainer.LoadContainer(fridgedCargo);
