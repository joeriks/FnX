
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public static partial class Fn
    {
        public static TOut Select<TOut>(Func<TOut> func)
        {
            return func();
        }

		public static TOut Select<T1,TOut>(Func<T1,TOut> func, T1 t1)
		{
			return func(t1);
		}

		public static TOut Select<T1,T2,TOut>(Func<T1,T2,TOut> func, T1 t1,T2 t2)
		{
			return func(t1, t2);
		}

		public static TOut Select<T1,T2,T3,TOut>(Func<T1,T2,T3,TOut> func, T1 t1,T2 t2,T3 t3)
		{
			return func(t1, t2, t3);
		}

		public static TOut Select<T1,T2,T3,T4,TOut>(Func<T1,T2,T3,T4,TOut> func, T1 t1,T2 t2,T3 t3,T4 t4)
		{
			return func(t1, t2, t3, t4);
		}

		public static TOut Select<T1,T2,T3,T4,T5,TOut>(Func<T1,T2,T3,T4,T5,TOut> func, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5)
		{
			return func(t1, t2, t3, t4, t5);
		}

		public static TOut Select<T1,T2,T3,T4,T5,T6,TOut>(Func<T1,T2,T3,T4,T5,T6,TOut> func, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6)
		{
			return func(t1, t2, t3, t4, t5, t6);
		}

		public static TOut Select<T1,T2,T3,T4,T5,T6,T7,TOut>(Func<T1,T2,T3,T4,T5,T6,T7,TOut> func, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6,T7 t7)
		{
			return func(t1, t2, t3, t4, t5, t6, t7);
		}

		public static TOut Select<T1,T2,T3,T4,T5,T6,T7,T8,TOut>(Func<T1,T2,T3,T4,T5,T6,T7,T8,TOut> func, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6,T7 t7,T8 t8)
		{
			return func(t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public static TOut Select<T1,T2,T3,T4,T5,T6,T7,T8,T9,TOut>(Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,TOut> func, T1 t1,T2 t2,T3 t3,T4 t4,T5 t5,T6 t6,T7 t7,T8 t8,T9 t9)
		{
			return func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		
    }
}
