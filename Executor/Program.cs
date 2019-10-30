using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace Executor{
    class Program{
        static void Main(string[] args){
            var a = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in a.GetTypes())
                if (type.IsClass){
                    Console.WriteLine(type.FullName);
                    var instance = Activator.CreateInstance(type);
                    foreach (var m in type.GetMethods()){
                        foreach (var att in m.GetCustomAttributes<ExecuteMeAttribute>()){
                            m.Invoke(instance, att.Arguments);
                        }
                    }
                }

            Console.ReadLine();
        }
    }
}