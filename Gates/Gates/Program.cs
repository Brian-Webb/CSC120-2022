using System;
using System.Collections.Generic;

namespace Gates
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = false;
            var c = false;
            var a = false;
            // 0,0,0  => 0
            // 1,0,0  => ?
            // 1,1,0 = > ??

            //CombinedGates(b, c, a);

            var logicGate = new LogicalGate();
            var result = logicGate.And(b, c).Or(c).Result;

            Console.WriteLine(result);

        }



        private static void CombinedGates(bool b, bool c, bool a)
        {
            var bc = OrGate.InPut(b, c);
            var z = AndGate.InPut(bc, a);

            Console.WriteLine($"The result of AndGate for inputs:" +
                $" B = {b}  ,  C = {c} , A ={a} the result = {z}");
        }

        private static void NotGateTest()
        {
            var x = true;
            var result = NotGate.InPut(x);
            Console.WriteLine($"The result of AndGate for inputs:" +
                $" X = {x} the result = {result}");
        }

        static void AndGateTest()
        {
            var x = true;
            var y = false;
            var result = AndGate.InPut(x, y);
            Console.WriteLine($"The result of AndGate for inputs:" +
                $" X = {x} and Y = {y} and the result = {result}");
        }

        static void ComlexGateTest()
        {
            var truthTable = new List<GateInputs>();
            truthTable.Add(new GateInputs { X = false, Y = false });
            truthTable.Add(new GateInputs { X = false, Y = true });
            truthTable.Add(new GateInputs { X = true, Y = false });
            truthTable.Add(new GateInputs { X = true, Y = true });

            Console.WriteLine($"X Y | Z ");
            Console.WriteLine($"________ ");
            foreach (var row in truthTable)
            {
                var result = AndGate.InPut(row.X, row.Y);
                //Console.WriteLine($"The result of AndGate for inputs:" +
                //    $" X = {row.X} and Y = {row.Y} and the result = {result}");
                var xas = row.X ? "1" : "0";
                var yas = row.Y ? "1" : "0";
                var resultas = result ? "1" : "0";
                Console.WriteLine($"{xas} {yas} |  {resultas} ");
            }
        }
    }
}
