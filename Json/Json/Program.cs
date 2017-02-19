using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Json
{
    [Serializable]
    public class Complex
    {
        public int a;
        public int b;

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
            Complex s = new Complex(5, 3);
            // сериализация Json конвертирует в строку типа комплекса
            string res = JsonConvert.SerializeObject(s);

            // открываем поток для записи, указываем необходимые условия
            using (FileStream ds = new FileStream("complex.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(ds)) //записывает наши данные 
                {
                    sw.WriteLine(res);//выводит результат
                }
            }

            /*
            using (FileStream ds = new FileStream("student.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sw = new StreamReader(ds))
                {
                    string text = sw.ReadToEnd();
                    Console.WriteLine(text);
                    Student s2 = JsonConvert.DeserializeObject<Student>(text);
                    Console.WriteLine(s2.name);
                    Console.WriteLine(s2.sname);
                    Console.WriteLine(s2.gpa);
                }
            }*/

        }
    }
}
