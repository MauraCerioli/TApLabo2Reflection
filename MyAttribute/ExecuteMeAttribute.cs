using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = true)]
    public class ExecuteMeAttribute:Attribute{
        public object[] Arguments{ get; private set; }
        public ExecuteMeAttribute(params object[] arguments){
            Arguments = arguments;
        }
    }
}
