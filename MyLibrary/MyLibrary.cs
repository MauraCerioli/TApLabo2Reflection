using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace MyLibrary
{
   
    public class Foo {
        [ExecuteMe]
        public void M1() {
            Console.WriteLine("M1");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a) {
            Console.WriteLine("M2 a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string s1, string s2) {
            Console.WriteLine("M3 s1={0} s2={1}", s1, s2);
        }
    }
    public class FooPrime {
        [ExecuteMe]
        public void M1Prime() {
            Console.WriteLine("M1Prime");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2Prime(int a) {
            Console.WriteLine("M2Prime a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3Prime(string s1, string s2) {
            Console.WriteLine("M3Prime s1={0} s2={1}", s1, s2);
        }
        [ExecuteMe("hello", "reflection")]
        public void M4Prime(string s1, string s2) {
            Console.WriteLine("M4Prime s1={0} s2={1}", s1, s2);
        }
    }
}
