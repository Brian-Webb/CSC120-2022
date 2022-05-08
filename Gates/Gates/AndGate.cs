using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gates
{
    public class AndGate
    {

        public static bool InPut(bool x, bool y)//ctrl+K+C
        {
            //if( x && y )
            //{
            //    return false;
            //}
            //if (x.Equals( false) && y.Equals( true))
            //{
            //    return false;
            //}
            //if (x.Equals(true) 
            //        && y.Equals(false))
            //{
            //    return false;
            //}
            //if (x.Equals(true) 
            //        && y.Equals(true))
            //{
            //    return true;
            //}

            return (x && y);
        }
    }
}
