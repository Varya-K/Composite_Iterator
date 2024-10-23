using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public class My_List_Iterator<T>
    {
        private My_List<T> list;
        private My_List_Item<T> current_item;

        public Composite_Iterator composite_iterator { set; get; }

        public My_List_Iterator(My_List<T> list)
        {
            this.list = list;
            current_item = list.get_head();
            this.composite_iterator = composite_iterator;
        }
        public void Reset() => current_item = list.get_head();
        public T Get_Current()
        {
            if (IsDone())
                throw new ArgumentOutOfRangeException(nameof(My_List_Iterator<T>), "Iterator is out bounds");
            return (current_item.Data);
        }
        public void MoveNext() {
            current_item = current_item.Next;
        }
        public bool IsDone()=> current_item==null;
        public void Update() 
        {
            var curr = list.get_head();
            while(curr!=null)
            {
                if (current_item == curr) break;
                curr = curr.Next;
            }
            if (curr == null)
            {
                MoveNext();
            }
        }
    }
}
