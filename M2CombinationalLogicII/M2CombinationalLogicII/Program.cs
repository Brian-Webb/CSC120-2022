using System;
using System.Runtime.CompilerServices;

namespace M2CombinationalLogicII
{
    class Program
    {
        static void Main(string[] args)
        {
            generateTruthTable("AND");
            generateTruthTable("OR");
        }

        private static void generateTruthTable(string gateType)
        {
            generateTruthTableHeader(gateType);
            
            for (int i = 1; i >= 0; i--)
            {
                for (int j = 1; j >= 0; j--)
                {
                    generateTruthTableRow(i, j, gateType);
                }
            }
            
            Console.WriteLine(" ");
        }
        
        private static void generateTruthTableHeader(string gateType)
        {
            Console.WriteLine("Truth table for {0} gate:", gateType);
            Console.WriteLine("   -----|-----|-----");
            Console.WriteLine("     X  |  Y  | Out ");
            Console.WriteLine("   -----|-----|-----");
        }
        
        private static void generateTruthTableRow(int x, int y, string gateType)
        {
            int? output = null;

            switch (gateType)
            {
                case "AND":
                    output = AND(x, y);
                    break;
                case "NAND":
                    output = NAND(x, y);
                    break;
                case "OR":
                    output = OR(x, y);
                    break;
                case "NOR":
                    output = NOR(x, y);
                    break;
            }
            
            Console.WriteLine("     {0}  |  {1}  |  {2}  ", x, y, output);
            Console.WriteLine("   -----|-----|-----");
        }
        
    // Gates from my M1 project.
    
        // nMOS conducts when control input is 1.
        private static int nMOS(int control)
        {
            // return control
            return control;
        }

        // pMOS conducts when control input is 0.
        // return the inverse of control
        private static int pMOS(int control)
        {
            // return the inverse of control
            return control == 0 ? 1 : 0;
        }

        // NOT gate (inverter)
        private static int NOT(int input)
        {
            return pMOS(input);
        }

        // AND gate
        private static int AND(int a, int b)
        {
            validateGateInput(a, b);

            return a * b;
        }

        // NAND gate
        private static int NAND(int a, int b)
        {
            validateGateInput(a, b);

            return pMOS(a * b);
        }

        // OR gate
        private static int OR(int a, int b)
        {
            validateGateInput(a, b);

            int NANDa = NAND(a, a);
            int NANDb = NAND(b, b);


            return NAND(NANDa, NANDb);
        }

        // NOR gate
        private static int NOR(int a, int b)
        {
            validateGateInput(a, b);

            return pMOS(OR(a, b));
        }

        private static void validateGateInput(int a, int b)
        {
            if (a != 0 && a != 1)
                throw new ArgumentException("Argument 'a' must be 0 or 1.");

            if (b != 0 && b != 1)
                throw new ArgumentException("Argument 'b' must be 0 or 1.");
        }
    }
}