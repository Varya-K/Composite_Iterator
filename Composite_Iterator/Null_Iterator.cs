using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Composite_Iterator_project
{
    class Null_Iterator:IIterator
    {
        
        public void Reset() { }
        public IAggregate Get_Current() => null;
        public void MoveNext() { }
        public bool IsDone()=> true;

    }
}
