using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public class Composite:IAggregate
    {
        private My_List<IAggregate> aggregates;
        private List<Composite_Iterator> iterators;

        public My_List<IAggregate> get_list() { 
            return aggregates;
        }

        public Composite()
        {
            aggregates = new My_List<IAggregate>();
            iterators = new List<Composite_Iterator>();

        }

        public void Add(IAggregate aggregate)
        {
            aggregates.Add(aggregate);
        }

       
        public void Delete(int index)
        {
            aggregates.DeleteAt(index);
            Notify();
        }

        public void Delete(IAggregate aggregate)
        {      
            aggregates.Delete(aggregate);
            Notify();
        }

        public void Add_Composite_Iterator(Composite_Iterator iterator)
        {
            iterators.Add(iterator);
        }
        private void Notify()
        {
            foreach (var iterator in iterators)
            {
                iterator.Update();
            }
        }
        public void Print()
        {
            var i = aggregates.Create_Iterator();
            for (i.Reset(); !i.IsDone(); i.MoveNext())
            {
                i.Get_Current().Print();
            }

            
        }
        public IIterator Create_Iterator()
        {
            var i = new List_Iterator(this);
            
            return i;
        }

    }
}
