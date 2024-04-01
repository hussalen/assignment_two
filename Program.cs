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
GasContainer gasContainer2 = (GasContainer)
    ship.CreateContainer(ContainerUtils.ContainerType.Gas, 300);
GasContainer gasContainer3 = (GasContainer)
    ship.CreateContainer(ContainerUtils.ContainerType.Gas, 250);
GasContainer gasContainer4 = (GasContainer)
    ship.CreateContainer(ContainerUtils.ContainerType.Gas, 100);

RefrigeratedContainer fridgedContainer =
    new(ship.ContainerUtils, ship.CargoUtils, 500, CargoUtils.CargoProductType.None, 20);

Cargo hazardousCargo1 = new(CargoUtils.CargoType.Hazardous, 251);
Cargo ordinaryCargo = new(CargoUtils.CargoType.Ordinary, 500);
Cargo gasCargo = new(CargoUtils.CargoType.Gas, 700);
Cargo fridgedCargo = new(CargoUtils.CargoType.Ordinary, 300);

ship.LoadCargo(gasContainer1, gasCargo);
ship.LoadCargo(gasContainer2, new(CargoUtils.CargoType.Gas, 100));
ship.LoadCargo(gasContainer3, new(CargoUtils.CargoType.Gas, 100));
ship.LoadCargo(liquidContainer, new(CargoUtils.CargoType.Hazardous, 100));

ship.LoadShipWithContainer(gasContainer1);
ship.LoadShipWithContainer(gasContainer1, gasContainer2, gasContainer3, gasContainer4);
ship.RemoveContainerFromShip(gasContainer1);
ship.UnloadContainer(gasContainer1);
ship.ReplaceContainer(gasContainer2, liquidContainer);
Console.WriteLine("----- New Ship ------");
Ship ship2 = new Ship(containerUtils, cargoUtils);
ship.TransferContainerToOtherShip(ship2, gasContainer3);
ship2.PrintShipAndCargoInfo();
ship2.PrintContainerInfo(gasContainer3);
ship.PrintShipAndCargoInfo();
Console.WriteLine("---------------");
liquidContainer3.LoadContainer(hazardousCargo1);
Console.WriteLine("---------------");
fridgedContainer.LoadContainer(fridgedCargo);
