using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public class My_List<T>
    {
        private My_List_Item<T> head;
        private List<My_List_Iterator<T>> iters;
        private int elements_count;
        public My_List()
        {
            head = null;
            elements_count = 0;
            iters = new List<My_List_Iterator<T>>();
        }
        public int length() { return elements_count; }
        public My_List_Item<T> get_head() { return head; }

        public void DeleteAt(int index)
        {
            
            if (index>=0 && index < elements_count)
            {
                if (index == 0)
                {
                    head = head.Next;
                }
                else
                {
                    My_List_Item<T> prev = null;
                    var current = head;
                    int i = 0;
                    while (index != i)
                    {
                        prev = current;
                        current = current.Next;
                        i++;
                    }
                    prev.Next = current.Next;
                }
                Notify();
                elements_count--;

            }
            else throw new ArgumentOutOfRangeException(nameof(My_List<T>), "Index is out bounds");
        }
        public bool Delete(T value)
        {
            My_List_Item<T> prev = null;
            var current = head;
            while (current != null&&!current.Data.Equals(value))
            {
                prev = current;
                current = current.Next;
            }
            if (current == null)
            {
                return false;
            }
            else
            {
                if(prev== null) head = head.Next;
                else prev.Next = current.Next;
                elements_count--;
                Notify();
                return true;
            }
            
            
        }
        public void Insert(int index, T data)
        {
            if (index >= 0 && index <= elements_count)
            {
                if (index == 0) head = new My_List_Item<T>(head, data);
                else {
                    var current = head;
                    int i = 0;
                    while (index-1 != i || index < elements_count)
                    {
                        current = current.Next;
                        i++;
                    }
                    current.Next = new My_List_Item<T>(current.Next, data);
                }
                elements_count++;

            }
            else throw new ArgumentOutOfRangeException(nameof(My_List<T>), "Index is out bounds");
        }

        public void Add(T data)
        {
            Insert(elements_count, data);
        }

        private void Notify()
        {
            foreach(var iter in iters)
            {
                iter.Update();
            }
        }
        public My_List_Iterator<T> Create_Iterator()
        {
            var i = new My_List_Iterator<T>(this);
            iters.Add(i);
            return i;
        }
    }
}
