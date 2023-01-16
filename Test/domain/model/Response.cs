using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.domain.model
{
    interface Response<T>
    {
        class Success : Response<T>
        {
            public Success(T data)
            {
                this.data = data;
            }

            public T data { get; }
        }

        class Error : Response<T>
        {
            public Error(string message)
            {
                this.message = message;
            }

            public string message { get; }
        }

    }
}
