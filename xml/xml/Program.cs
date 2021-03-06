﻿using System;
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
       
        //конструктор для комплексных чисел
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public Complex()
        {
            this.a = 5;
            this.b = 3;
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
            //создаем сериализатор типа комплекс
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            
            Complex s = new Complex();// создаем объект класса комплекс
            FileStream fs = new FileStream("complexXML.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//открываем поток для записи
            xs.Serialize(fs, s);//записываем куда-в тхт документ,что - данные
            fs.Close();//закрываем поток


            Complex s2 = new Complex();//создаем пустой объект класса комплекс
            FileStream fs2 = new FileStream("complexXML.txt", FileMode.Open, FileAccess.Read);//открываем поток для чтения
            s2 = xs.Deserialize(fs2) as Complex;//переписываем данные в виде комплекса
            
            Console.WriteLine(s);
            Console.WriteLine(s2);

            fs2.Close();//закрываем поток чтения
        }
    }
}