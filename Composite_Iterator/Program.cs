using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;

namespace Composite_Iterator_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aggregate a1 = new Aggregate(1);
            Aggregate a2 = new Aggregate(2);
            Aggregate a3 = new Aggregate(3);
            Composite c1 = new Composite();
            c1.Add(a1);
            c1.Add(a2);
            c1.Add(a3);
            Aggregate a4 = new Aggregate(4);
            Composite c2 = new Composite();
            c2.Add(c1);
            c2.Add(a4);
            Aggregate a5 = new Aggregate(5);
            Aggregate a6 = new Aggregate(6);
            Composite c3 = new Composite();
            c3.Add(c2);
            Composite c4 = new Composite();
            c4.Add(a5);
            c4.Add(a6);
            c3.Add(c4);

            var i = new Composite_Iterator(c3);
            i.Reset();

            Console.WriteLine(i.Get_Current().Equals(c2));

            i.MoveNext();
            Console.WriteLine(i.Get_Current().Equals(c1));


            i.MoveNext();
            Console.WriteLine(i.Get_Current().Equals(a1));


            i.MoveNext();
            Console.WriteLine(i.Get_Current().Equals(a2));

            c1.Delete(a1);
            Console.WriteLine(i.Get_Current().Equals(a2));

            c2.Delete(c1);
            Console.WriteLine(i.Get_Current().Equals(a4));

            c4.Delete(a6);
            Console.WriteLine(i.Get_Current().Equals(a4));

            i.MoveNext();
            Console.WriteLine(i.Get_Current().Equals(c4));

            i.MoveNext();
            Console.WriteLine(i.Get_Current().Equals(a5));

            c3.Delete(c4);
            Console.WriteLine(i.IsDone());
            
        }
    }
}