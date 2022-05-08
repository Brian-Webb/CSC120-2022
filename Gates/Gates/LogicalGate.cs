using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gates
{
    public class LogicalGate
    {
        /// <summary>
        /// Result Stores the intermediat value
        /// </summary>
        /// 
        //Chaining
        //fluent
        public  bool Result { get; set; } 
        public LogicalGate And(bool x, bool y)//ctrl+K+C
        {
            Result = (x && y);
            return this;
        }
        public LogicalGate Or(bool x, bool y)//ctrl+K+C
        {
            Result = (x || y);
            return this;
        }

        public LogicalGate Or( bool y)//ctrl+K+C
        {
            Result = (Result || y);
            return this;
        }
        public LogicalGate Not(bool x)
        {
            Result = !x;
            return this;
        }
    }
}
