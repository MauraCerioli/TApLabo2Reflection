using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace Executor{
    class Program{
        static bool VerifyParameters(ParameterInfo[] formal,object[] actual){
            var paramNumber = formal.Length;
            if (paramNumber!=actual.Length)
                return false;
            for (int i = 0; i < paramNumber; i++){
                if (null != actual[i]){
                    var type = actual[i].GetType();
                    /*NOTE IsAssignableFrom does not take into account implicit coversons.
                     Thus, it does not work for numeric types, nor for custom defined conversions
                     see motivation and discussion at
                     https://social.msdn.microsoft.com/Forums/vstudio/en-US/eb3e0a1e-1c50-40f9-8792-f44f2ac829b0/is-there-an-typeisassignablefrom-equivalent-that-works-for-numeric-types?forum=netfxbcl
                    Explicit conversion 
                    TypeDescriptor.GetConverter(type).CanConvertTo(formal[i].ParameterType)) return true for INt32 and double in 
                    both directions...mmm...need more understanding*/
                    if (!formal[i].ParameterType.IsAssignableFrom(type))
                        return false;
                }
                else if (formal[i].ParameterType.IsValueType)
                    return false;
            }
            return true;
        }

        static void Main(string[] args){
            const string mylibraryBinDebugMylibraryDll = @"..\..\..\MyLibrary\bin\Debug\MyLibrary.dll";
            var a = Assembly.LoadFrom(mylibraryBinDebugMylibraryDll);
            foreach (var type in a.GetTypes())
                if (type.IsClass){
                    Console.WriteLine(type.FullName);
                    try{
                        var instance = Activator.CreateInstance(type);
                        foreach (var m in type.GetMethods()){
                            foreach (var att in m.GetCustomAttributes<ExecuteMeAttribute>()){
                                if(VerifyParameters(m.GetParameters(),att.Arguments))
                                    m.Invoke(instance, att.Arguments);
                                else{
                                    Console.WriteLine($"Wrong parameters for method {m.Name}");
                                }
                            }
                        }
                    }
                    catch (MissingMethodException e){
                        Console.WriteLine(e.Message);
                    }
                }

            Console.ReadLine();
        }
    }
}