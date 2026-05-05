using StructuralPatternsDemo.Adapter;
using StructuralPatternsDemo.Bridge;
using StructuralPatternsDemo.Composite;
using StructuralPatternsDemo.Decorator;
using StructuralPatternsDemo.Facade;
using StructuralPatternsDemo.Flyweight;
using StructuralPatternsDemo.Proxy;

PrintHeader("Adapter");
AdapterDemo.Run();

PrintHeader("Bridge");
BridgeDemo.Run();

PrintHeader("Composite");
CompositeDemo.Run();

PrintHeader("Decorator");
DecoratorDemo.Run();

PrintHeader("Facade");
FacadeDemo.Run();

PrintHeader("Flyweight");
FlyweightDemo.Run();

PrintHeader("Proxy");
ProxyDemo.Run();

static void PrintHeader(string patternName)
{
    Console.WriteLine();
    Console.WriteLine("======================================");
    Console.WriteLine($"Executing {patternName} Pattern");
    Console.WriteLine("======================================");
}