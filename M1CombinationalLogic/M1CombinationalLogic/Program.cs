using System;

namespace M1CombinationalLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            OhmsLawTester();
            CmosTester();
            GateTester();
            AirbagTester();
        }

        // sample of how this was used to test my results of ohms law calculations
        private static void OhmsLawTester()
        {
            Console.WriteLine("Run Tests for: 1.1.3: Voltage, current, and resistance.");
            
            // 3) If V is 6 V and R is 2 Ohms, I = ?
            OhmsLawCalculator(6, null, 2);
            
            // 4) If V is 6 V and R is 1 Ohm, I = ?
            OhmsLawCalculator(6, null, 1);
            
            // 5) If V is 6 V and R is 0 Ohms, I = ?
            OhmsLawCalculator(10, null, 0);
            
            // 6) If V is 6 V and R is infinite, I = ?
            OhmsLawCalculator(6, null, 99999);
        }

        // sample of how this was used to test my results the CMOS sections
        private static void CmosTester()
        {
            Console.WriteLine("Run Tests for: 1.1.9: pMOS and nMOS transistors.");
            
            Console.WriteLine("  1) Does a pMOS conduct if the control input is 0?");
            Console.WriteLine("    Result = {0}\n", pMOS(0));
            
            Console.WriteLine("  2) Does an nMOS conduct if the control input is 0?");
            Console.WriteLine("    Result = {0}\n", nMOS(0));
            
            Console.WriteLine("  3) Does a pMOS conduct if the control input is 1?");
            Console.WriteLine("    Result = {0}\n", pMOS(1));
            
            Console.WriteLine("  4) Does an nMOS conduct if the control input is 1?");
            Console.WriteLine("    Result = {0}\n", nMOS(1));
        }

        // sample of how this was used to test the gate sections
        private static void GateTester()
        {
            Console.WriteLine("  OR truth table");
            Console.WriteLine("    OR(0,0) Result = {0}", OR(0, 0));
            Console.WriteLine("    OR(0,1) Result = {0}", OR(0, 1));
            Console.WriteLine("    OR(1,0) Result = {0}", OR(1, 0));
            Console.WriteLine("    OR(1,1) Result = {0}\n", OR(1, 1));
            
            Console.WriteLine("  NOR truth table");
            Console.WriteLine("    NOR(0,0) Result = {0}", NOR(0, 0));
            Console.WriteLine("    NOR(0,1) Result = {0}", NOR(0, 1));
            Console.WriteLine("    NOR(1,0) Result = {0}", NOR(1, 0));
            Console.WriteLine("    NOR(1,1) Result = {0}\n", NOR(1, 1));
            
            Console.WriteLine("  AND truth table");
            Console.WriteLine("    AND(0,0) Result = {0}", AND(0, 0));
            Console.WriteLine("    AND(0,1) Result = {0}", AND(0, 1));
            Console.WriteLine("    AND(1,0) Result = {0}", AND(1, 0));
            Console.WriteLine("    AND(1,1) Result = {0}\n", AND(1, 1));
            
            Console.WriteLine("  NAND truth table");
            Console.WriteLine("    NAND(0,0) Result = {0}", NAND(0, 0));
            Console.WriteLine("    NAND(0,1) Result = {0}", NAND(0, 1));
            Console.WriteLine("    NAND(1,0) Result = {0}", NAND(1, 0));
            Console.WriteLine("    NAND(1,1) Result = {0}\n", NAND(1, 1));
        }
        
        // 1.6.3: Airbag example. Solved via gates
        private static void AirbagTester()
        {
            Console.WriteLine("  What is e if h = 1, w = 1, and d = 1?");
            Console.WriteLine("    AirbagEnablerCircuit(1,1,1) Result = {0}\n", AirbagEnablerCircuit(1,1,1));
            
            Console.WriteLine("  What is e if h = 1, w = 1, and d = 1?");
            Console.WriteLine("    AirbagDeploymentCircuit(1,1,1,1) Result = {0}", AirbagDeploymentCircuit(1,1,1,1));
        }
        
        // 1.6.3: Airbag example. Enabler Circuit as gates
        private static int AirbagEnablerCircuit(int h, int w, int d)
        {
            int sensorOutput = AND(h, w);

            return AND(sensorOutput, NOT(d));
        }
        
        // 1.6.3: Airbag example. Deployment Circuit as gates
        private static int AirbagDeploymentCircuit(int h, int w, int d, int c)
        {
            return AND(AirbagEnablerCircuit(h, w, d), c);
        }
        
        
        // this function will take in voltage, current, and resistance... determine which is the missing value
        //    and then write the result to the console
        //    note: 99999 == infinity
        private static void OhmsLawCalculator(int? voltage = null, int? current = null, int? resistance = null)
        {
            // if all arguments are null, terminate early
            if (voltage == null && current == null && resistance == null)
                throw new ArgumentException("Only one argument can be null.");
            
            // setup the variables we need
            const int infinity = 99999;
            string equation = "";
            string resultString;
            string resultLabel = "";
            
            if (voltage == null) // calculate voltage (V=I*R)
            {
                double result = (double) (current * resistance);
                
                equation = String.Format("V=I*R (V={0}*{1})", current, resistance);
                resultString = result.ToString();
                resultLabel = "Voltage";
            }
            else if (current == null) // calculate current (I=V/R)
            {
                string resistanceString = resistance.ToString();
                resultString = "Infinity";
                
                // if we can do the calculation, override the outputs
                if (resistance != 0)
                {
                    double result = (double) (voltage / resistance);
                    resultString = result.ToString();
                    
                    if(resistance == infinity)
                        resistanceString = "Infinity";
                }

                resultLabel = "Current";
                equation = String.Format("I=V/R (V={0}/{1})", voltage, resistanceString);
            }
            else if (resistance == null) // calculate resistance (R=V/I)
            {
                string currentString = current.ToString();
                resultString = "Infinity";
                
                // if we can do the calculation, override the outputs
                if (current != 0)
                {
                    double result = (double) (voltage / current);
                    resultString = result.ToString();
                    
                    if(current == infinity)
                        currentString = "Infinity";
                }
                
                resultLabel = "Resistance";
                equation = String.Format("R=V/I (V={0}/{1})", voltage, currentString);
            }
            else
            {
                // potentially just return true/false if the variables provided are accurate?
                //   for now, just return to cancel execution
                return;
            }

            Console.WriteLine("  Calculating: {0}", equation);
            Console.WriteLine("     {0} = {1}\n", resultLabel, resultString);
        }
        
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
