// See https://aka.ms/new-console-template for more information
using assignment_two.containers;
using assignment_two.utils;

ContainerUtils cu = new();
LiquidContainer liquidContainer = new(cu, 500);
LiquidContainer liquidContainer2 = new(cu, 500);
LiquidContainer liquidContainer3 = new(cu, 500);

Console.WriteLine(liquidContainer3.SerialNumber);
