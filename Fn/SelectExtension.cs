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
        public static Func<T1, TOut> FuncFromAnonymous<T1, TOut>(this T1 type, Func<T1, TOut> constructor)
        {
            return constructor;
        }
        public static T SelectIf<T>(this T self, Func<T, bool> cont, Func<T, T> func)
        {
            if (cont(self)) return func(self);
            return self;
        }
        public static T SelectIf<T>(this T self, Func<T, bool> cont, Func<T> func)
        {
            if (cont(self)) return func();
            return self;
        }
        public static T SelectIfNullAnd<T>(this T self, Func<T, bool> cont, Func<T> func)
        {
            if (self == null && cont(self)) return func();
            return self;
        }
        public static T SelectIfNull<T>(this T self, Func<T> func)
        {
            if (self == null) return func();
            return self;
        }

        public static IEnumerable<T> SelectIfEmpty<T>(this IEnumerable<T> self, Func<IEnumerable<T>> func)
        {
            if (self == null || !self.Any()) return func();
            return self;
        }
        public static IEnumerable<T> SelectIfEmptyAnd<T>(this IEnumerable<T> self, Func<IEnumerable<T>, bool> cont, Func<IEnumerable<T>> func)
        {
            if ((self == null || !self.Any()) && cont(self)) return func();
            return self;
        }

        public static bool SelectIf(this bool self, Func<bool> func)
        {
            if (self) return func();
            return self;
        }

        public static T SelectIf<T>(this T self, bool cont, Func<T, T> func)
        {
            if (cont) return func(self);
            return self;
        }

    }
}
