using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public class My_List_Item<T>
    {
        public My_List_Item(My_List_Item<T> next, T data)
        {
            Next = next;
            Data = data;
        }
        public My_List_Item<T> Next { get; set; }
        public T Data { get; set; }

    }
}
