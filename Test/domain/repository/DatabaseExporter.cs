using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.repository
{
    internal interface DatabaseExporter
    {
        public void export(string filePath);
    }
}
