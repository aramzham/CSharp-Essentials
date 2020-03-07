using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Inheritance
{
    internal sealed class TypedNode<T> : NodeNonGeneric
    {
        public T m_data;

        public TypedNode(T data) : this(data, null)
        {

        }

        public TypedNode(T data, NodeNonGeneric next) : base(next)
        {
            m_data = data;
        }

        public override string ToString()
        {
            return m_data.ToString() + (m_next != null ? m_next.ToString() : string.Empty);
        }
    }
}
