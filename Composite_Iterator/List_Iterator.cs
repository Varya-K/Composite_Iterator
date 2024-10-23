using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    class List_Iterator:IIterator
    {
        private My_List_Iterator<IAggregate> iter;
        private Composite composite;
        
        public List_Iterator(Composite composite)
        {
            this.composite = composite;
            iter = composite.get_list().Create_Iterator();
            
        }
        public void Reset() => iter.Reset();
        public IAggregate Get_Current() => iter.Get_Current();
        public void MoveNext()=> iter.MoveNext();
        public bool IsDone()=> iter.IsDone();

        public Composite get_composite()
        {
            return composite;
        }

    }
}
