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
        //private FooPrime(){}
        //public FooPrime(int i){}
        [ExecuteMe(true)]
        public void M1Prime(bool b) {
            Console.WriteLine($"M1Prime b= {b}");
        }

        [ExecuteMe(45.5)]
        [ExecuteMe(0)]
        [ExecuteMe(3.2)]
        public void M2Prime(double a) {
            Console.WriteLine("M2Prime a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3Prime(string s1, string s2) {
            Console.WriteLine("M3Prime s1={0} s2={1}", s1, s2);
        }
        [ExecuteMe("hello", null)]
        public void M4Prime(string s1, List<int> l) {
            Console.WriteLine("M4Prime s1={0} l.Count={1}", s1, null!=l?l.Count.ToString():"null");
        }
    }
    public class FooSecond {
        [ExecuteMe(true)]
        public void M1Second(bool b) {
            Console.WriteLine($"M1Second b= {b}");
        }

        [ExecuteMe(45.5)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2Second(int a) {
            Console.WriteLine("M2Second a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3Second(string s1, string s2) {
            Console.WriteLine("M3Second s1={0} s2={1}", s1, s2);
        }
        [ExecuteMe("hello", null)]
        public void M4Second(string s1, IEnumerable<int> l) {
            Console.WriteLine("M4Second s1={0} l.Count={1}", s1, null != l ? l.Count().ToString() : "null");
        }
    }
}
