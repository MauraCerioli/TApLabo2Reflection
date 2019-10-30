using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Executor {
    class Program {
        static void Main(string[] args) {
            var a = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in a.GetTypes())
                if (type.IsClass)
                    Console.WriteLine(type.FullName);
            Console.ReadLine();
        }
    }
}
