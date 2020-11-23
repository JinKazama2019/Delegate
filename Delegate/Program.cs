using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    //объявление глобального делегата
    public delegate Тип_возвращаемого_значения имя_делегата(тип_аргумента аргумент);
    class Program
    {
        //объявление делегата внутри класса
        public delegate Тип_возвращаемого_значения имя_делегата(тип_аргумента аргумент);
        static void Main(string[] args)
        {
            Console.Write("Hello World");
        }
    }
}
