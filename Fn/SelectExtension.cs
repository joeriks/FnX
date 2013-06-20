using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public static partial class Fn
    {
        public static TOut Select<TIn, TOut>(this TIn self, Func<TIn, TOut> func)
        {
            return func(self);
        }
        public static TOut Select<TIn, TOut>(this TIn self, Func<TOut> func)
        {
            return func();
        }
        public static Func<TOut> Func<TIn, TOut>(this TIn self, Func<TIn, TOut> func)
        {
            return () => func(self);
        }
        public static Func<TOut> Func<TIn, TOut>(this TIn self, Func<TOut> func)
        {
            return func;
        }
    }
}
