using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public class Aggregate: IAggregate
    {
        private int a;
        public Aggregate(int a)
        {
            this.a = a;
        }
        public void Print()
        {
            Console.Write(a+" ");
        }
        public IIterator Create_Iterator()
        {
            return new Null_Iterator();
        }
    }
}
