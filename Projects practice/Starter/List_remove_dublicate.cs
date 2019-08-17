using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWorck
{
    class Program
    {
        static void Main(string[] args)
        {


            List<int> ArrayInt = new List<int> { 1, 3, 4, 5, 4, 6, 1, 6, 3 };
            List<int> Dublicat = new List<int>(ArrayInt);



            for (int i = 0; i < ArrayInt.Count; i++)
            {
                if (Dublicat.Contains(ArrayInt[i]))
                {
                    Dublicat.Remove(i);
                }
            }

            foreach (var item in ArrayInt)
            {
                if (!Dublicat.Contains(item))
                {
                    Console.WriteLine(item);
                }
            }

            /////////////////////////////////////////////////////////////////
            ///
            //string str = "I am too Happy";

            //char[] mas = str.ToCharArray();



            //for (int i = 1; i < mas.Length; i++)
            //{
            //    if (i % 2 == 0 && char.IsLetter(mas[i]))
            //    {
            //        mas[i] = '0';
            //    }
            //}

            //char[] mas2 = new char[mas.Length + 3];

            //List<char> list = new List<char>();


            //while (true)
            //{
            //    list.Add(mas[i--]);
            //}



          // string str2 = new string(mas);

          //  Console.WriteLine(str2);

            Console.ReadKey();
        }
    }
}
