using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example2
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
        public override string ToString()
        {
            return string.Format("{0} + {1}i", a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex s = new Complex(5, 3);
            FileStream fs = new FileStream("complexXML.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, s);
            fs.Close();


            Complex s2 = new Complex();
            FileStream fs2 = new FileStream("complexXML.txt", FileMode.Open, FileAccess.Read);
            s2 = xs.Deserialize(fs2) as Complex;
            Console.WriteLine(s);
            Console.WriteLine(s2);

            fs2.Close();
        }
    }
}