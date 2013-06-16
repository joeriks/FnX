

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public static partial class Fn
    {
		public static Func<T2, TOut> New<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1)
        {
            return (t2) => func(t1, t2);
        }
		public static Func<T3, TOut> New<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1, T2 t2)
        {
            return (t3) => func(t1, t2, t3);
        }
		public static Func<T2, T3, TOut> New<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1)
        {
            return (t2, t3) => func(t1, t2, t3);
        }
		public static Func<T4, TOut> New<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> func, T1 t1, T2 t2, T3 t3)
        {
            return (t4) => func(t1, t2, t3, t4);
        }
		public static Func<T3, T4, TOut> New<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> func, T1 t1, T2 t2)
        {
            return (t3, t4) => func(t1, t2, t3, t4);
        }
		public static Func<T2, T3, T4, TOut> New<T1, T2, T3, T4, TOut>(this Func<T1, T2, T3, T4, TOut> func, T1 t1)
        {
            return (t2, t3, t4) => func(t1, t2, t3, t4);
        }
		public static Func<T5, TOut> New<T1, T2, T3, T4, T5, TOut>(this Func<T1, T2, T3, T4, T5, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return (t5) => func(t1, t2, t3, t4, t5);
        }
		public static Func<T4, T5, TOut> New<T1, T2, T3, T4, T5, TOut>(this Func<T1, T2, T3, T4, T5, TOut> func, T1 t1, T2 t2, T3 t3)
        {
            return (t4, t5) => func(t1, t2, t3, t4, t5);
        }
		public static Func<T3, T4, T5, TOut> New<T1, T2, T3, T4, T5, TOut>(this Func<T1, T2, T3, T4, T5, TOut> func, T1 t1, T2 t2)
        {
            return (t3, t4, t5) => func(t1, t2, t3, t4, t5);
        }
		public static Func<T2, T3, T4, T5, TOut> New<T1, T2, T3, T4, T5, TOut>(this Func<T1, T2, T3, T4, T5, TOut> func, T1 t1)
        {
            return (t2, t3, t4, t5) => func(t1, t2, t3, t4, t5);
        }
		public static Func<T6, TOut> New<T1, T2, T3, T4, T5, T6, TOut>(this Func<T1, T2, T3, T4, T5, T6, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return (t6) => func(t1, t2, t3, t4, t5, t6);
        }
		public static Func<T5, T6, TOut> New<T1, T2, T3, T4, T5, T6, TOut>(this Func<T1, T2, T3, T4, T5, T6, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return (t5, t6) => func(t1, t2, t3, t4, t5, t6);
        }
		public static Func<T4, T5, T6, TOut> New<T1, T2, T3, T4, T5, T6, TOut>(this Func<T1, T2, T3, T4, T5, T6, TOut> func, T1 t1, T2 t2, T3 t3)
        {
            return (t4, t5, t6) => func(t1, t2, t3, t4, t5, t6);
        }
		public static Func<T3, T4, T5, T6, TOut> New<T1, T2, T3, T4, T5, T6, TOut>(this Func<T1, T2, T3, T4, T5, T6, TOut> func, T1 t1, T2 t2)
        {
            return (t3, t4, t5, t6) => func(t1, t2, t3, t4, t5, t6);
        }
		public static Func<T2, T3, T4, T5, T6, TOut> New<T1, T2, T3, T4, T5, T6, TOut>(this Func<T1, T2, T3, T4, T5, T6, TOut> func, T1 t1)
        {
            return (t2, t3, t4, t5, t6) => func(t1, t2, t3, t4, t5, t6);
        }
		public static Func<T7, TOut> New<T1, T2, T3, T4, T5, T6, T7, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return (t7) => func(t1, t2, t3, t4, t5, t6, t7);
        }
		public static Func<T6, T7, TOut> New<T1, T2, T3, T4, T5, T6, T7, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return (t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
        }
		public static Func<T5, T6, T7, TOut> New<T1, T2, T3, T4, T5, T6, T7, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return (t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
        }
		public static Func<T4, T5, T6, T7, TOut> New<T1, T2, T3, T4, T5, T6, T7, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, TOut> func, T1 t1, T2 t2, T3 t3)
        {
            return (t4, t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
        }
		public static Func<T3, T4, T5, T6, T7, TOut> New<T1, T2, T3, T4, T5, T6, T7, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, TOut> func, T1 t1, T2 t2)
        {
            return (t3, t4, t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
        }
		public static Func<T2, T3, T4, T5, T6, T7, TOut> New<T1, T2, T3, T4, T5, T6, T7, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, TOut> func, T1 t1)
        {
            return (t2, t3, t4, t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
        }
		public static Func<T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return (t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T7, T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return (t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T6, T7, T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return (t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T5, T6, T7, T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return (t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T4, T5, T6, T7, T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1, T2 t2, T3 t3)
        {
            return (t4, t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T3, T4, T5, T6, T7, T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1, T2 t2)
        {
            return (t3, t4, t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T2, T3, T4, T5, T6, T7, T8, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TOut> func, T1 t1)
        {
            return (t2, t3, t4, t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
		public static Func<T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return (t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return (t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T7, T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return (t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T6, T7, T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return (t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T5, T6, T7, T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return (t5, t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T4, T5, T6, T7, T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2, T3 t3)
        {
            return (t4, t5, t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T3, T4, T5, T6, T7, T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1, T2 t2)
        {
            return (t3, t4, t5, t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
		public static Func<T2, T3, T4, T5, T6, T7, T8, T9, TOut> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> func, T1 t1)
        {
            return (t2, t3, t4, t5, t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
	
    }
}
