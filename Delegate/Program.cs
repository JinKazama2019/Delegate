using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    //объявление глобального делегата
    // public delegate Тип_возвращаемого_значения имя_делегата(тип_аргумента аргумент);
    public delegate void MyDelegate();
    class Program
    {
        //объявление делегата внутри класса
       // public delegate Тип_возвращаемого_значения имя_делегата(тип_аргумента аргумент);
         void Main(string[] args)
        {
            MyDelegate myDelegate = Method1;// определили переменную делегата и присваиваем имя метода
        }

        public void Method1()
        {
            Console.WriteLine("Method1");
        }

        public int Method2()
        {
            Console.WriteLine("Method2");
            return 0;
        } 
        public void Method3(int i)
        {
            Console.WriteLine("Method4");
        }
        public void Method4()
        {
            Console.WriteLine("Method4");
        }


    }
}
