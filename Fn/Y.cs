using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnX
{
    public static partial class Fn
    {
        delegate Action<A> RecursiveAction<A>(RecursiveAction<A> r);

        public static Action<A> Y<A>(Func<Action<A>, Action<A>> f)
        {

            RecursiveAction<A> rec = r => a => f(r(r))(a);

            return rec(rec);

        }
        delegate Func<A,R> Recursive<A,R>(Recursive<A,R> r);

        public static Func<A,R> Y<A,R>(Func<Func<A,R>, Func<A,R>> f)
        {

            Recursive<A,R> rec = r => a => f(r(r))(a);

            return rec(rec);

        }
    }
}
