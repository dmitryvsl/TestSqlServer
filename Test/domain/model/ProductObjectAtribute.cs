using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.model
{
    public class ProductObjectAtribute
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string value { get; private set; }

        public ProductObjectAtribute(int id, string name, string value)
        {
            this.id = id;
            this.name = name;
            this.value = value;
        }
    }
}
