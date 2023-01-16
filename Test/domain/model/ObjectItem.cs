using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.model
{
    internal class ObjectItem
    {
        public int id { get; private set; }
        public string type { get; private set; }
        public string product { get; private set; }

        public ObjectItem (int id, string type, string product)
        {
            this.id = id;
            this.type = type;
            this.product = product;
        }
    }
}
