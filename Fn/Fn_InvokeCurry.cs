using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public partial class Fn
    {
        public static TOut CInvoke<T1, TOut>(this Func<T1, TOut> func, T1 t1)
        {
            return func(t1);
        }
        public static Func<T2, TOut> CInvoke<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1)
        {
            return t2 => func(t1, t2);
        }
        public static Func<T3, TOut> CInvoke<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1, T2 t2)
        {
            return t3 => func(t1, t2, t3);
        }
        public static Func<T2, T3, TOut> CInvoke<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1)
        {
            return (t2, t3) => func(t1, t2, t3);
        }
        public static TOut CInvoke<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1, T2 t2)
        {
            return func(t1, t2);
        }
        //public static Func<TOut> CInvoke<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1, T2 t2)
        //{
        //    return ()=>func(t1, t2);
        //}
    }
}
