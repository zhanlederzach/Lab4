using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryFormatterExample
{
    [Serializable]
    public class Complex
    {
        int a;
        int b;
        public Complex()
        { }
        //конструктор для комплексных чисел
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        //метод сложения 
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex res = new Complex(0, 0);
            //сложение действительных частей
            res.a = c1.a + c2.a;
            //сложение мнимых частей
            res.b = c1.b + c2.b;

            return res;
        }
        public void Generate()
        {

        }
        public override string ToString()
        {
            return string.Format("{0} + {1}i", a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex s = new Complex(5,3);
            s.Generate();

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("Complex2.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                bf.Serialize(fs, s);
            }

        }
    }
}
