
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public static partial class Fn
    {
		public static Func<TOut> New<TOut>(Func<TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,TOut> New<T1,TOut>(Func<T1,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,TOut> New<T1,T2,TOut>(Func<T1,T2,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,TOut> New<T1,T2,T3,TOut>(Func<T1,T2,T3,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,T4,TOut> New<T1,T2,T3,T4,TOut>(Func<T1,T2,T3,T4,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,T4,T5,TOut> New<T1,T2,T3,T4,T5,TOut>(Func<T1,T2,T3,T4,T5,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,T4,T5,T6,TOut> New<T1,T2,T3,T4,T5,T6,TOut>(Func<T1,T2,T3,T4,T5,T6,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,T4,T5,T6,T7,TOut> New<T1,T2,T3,T4,T5,T6,T7,TOut>(Func<T1,T2,T3,T4,T5,T6,T7,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,T4,T5,T6,T7,T8,TOut> New<T1,T2,T3,T4,T5,T6,T7,T8,TOut>(Func<T1,T2,T3,T4,T5,T6,T7,T8,TOut> constructor)
		{
			return constructor;
		}

		public static Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,TOut> New<T1,T2,T3,T4,T5,T6,T7,T8,T9,TOut>(Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,TOut> constructor)
		{
			return constructor;
		}

		
    }
}
