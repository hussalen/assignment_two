﻿// See https://aka.ms/new-console-template for more information
using assignment_two;
using assignment_two.containers;
using assignment_two.utils;

ContainerUtils cu = new();
LiquidContainer liquidContainer = new(cu, 500);
LiquidContainer liquidContainer2 = new(cu, 500);
LiquidContainer liquidContainer3 = new(cu, 500);

Cargo hazardousCargo1 = new(cargoutils.CargoType.Hazardous, 251);
Cargo ordinaryCargo = new(cargoutils.CargoType.Ordinary, 500);

liquidContainer.LoadContainer(ordinaryCargo);

//Console.WriteLine(liquidContainer3.SerialNumber);
