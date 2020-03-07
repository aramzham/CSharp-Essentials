using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Inheritance
{
    internal class NodeNonGeneric
    {
        protected NodeNonGeneric m_next;

        public NodeNonGeneric(NodeNonGeneric next)
        {
            m_next = next;
        }
    }
}
