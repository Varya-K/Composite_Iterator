using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Iterator_project
{
    public interface IIterator
    {
        void Reset();
        IAggregate Get_Current();
        void MoveNext();
        bool IsDone();
        

    }
}
