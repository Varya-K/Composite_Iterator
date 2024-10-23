using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public class Composite_Iterator:IIterator
    {
        private Stack<IIterator> iterators;
        private Composite root;

        public Composite_Iterator(Composite root)
        {
            this.root = root;
            iterators = new Stack<IIterator>();
            var i = root.Create_Iterator();
            root.Add_Composite_Iterator(this);
         
            iterators.Push(i);
        }

        public void Reset()
        {
            iterators.Clear();
            IIterator i = root.Create_Iterator();
            i.Reset();
            iterators.Push(i);
        }
        public IAggregate Get_Current()
        {
            if (IsDone())
                throw new ArgumentOutOfRangeException(nameof(Composite_Iterator), "Iterator is out bounds");
            return iterators.Peek().Get_Current();
        }
        public void MoveNext()
        {
            if(!IsDone())
            {
                IIterator i = iterators.Peek().Get_Current().Create_Iterator();
                if (iterators.Peek().Get_Current() is Composite)
                {
                    var composite = (Composite)iterators.Peek().Get_Current();
                    composite.Add_Composite_Iterator(this);
                }
                i.Reset();
                iterators.Push(i);

                while (iterators.Count > 0 && iterators.Peek().IsDone())
                {
                    iterators.Pop();
                    if (iterators.Count > 0)
                        iterators.Peek().MoveNext();
                }
                
            }
        }
        public bool IsDone() => iterators.Count == 0;
        public void Update() 
        {
            List_Iterator j = null;
            IIterator changed_iter = null;
            foreach(var i in iterators)
            {
                if (j != null)
                {
                    
                    if (i.IsDone()||i.Get_Current() != j.get_composite())
                    {
                        changed_iter = i;
                        break;
                    }
                }
                j = (List_Iterator)i;
            }
            
            if (changed_iter !=null)
            {
                while (iterators.Peek() != changed_iter)
                {
                    iterators.Pop();
                }
                
            }
            while (iterators.Count > 0 && iterators.Peek().IsDone())
            {
                iterators.Pop();
                if (iterators.Count > 0)
                    iterators.Peek().MoveNext();
            }
        }
    }
}
