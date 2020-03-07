using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Inheritance
{
    internal sealed class NodeGeneric<T>
    {
        public T m_data;
        public NodeGeneric<T> m_next;

        public NodeGeneric(T data) : this(data, null)
        {

        }

        public NodeGeneric(T data, NodeGeneric<T> next)
        {
            this.m_data = data;
            this.m_next = next;
        }

        public override String ToString()
        {
            return m_data.ToString() + ((m_next != null) ? m_next.ToString() : string.Empty);
        }
    }
}
