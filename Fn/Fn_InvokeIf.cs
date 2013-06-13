using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public static partial class Fn
    {

        public static bool InvokeIf(bool condition, Action func) 
        {
            if (condition) func();
            return condition;
        }
        public static bool InvokeIf(Func<bool> condition, Action func)
        {
            return InvokeIf(condition(), func);
        }
    }
}
