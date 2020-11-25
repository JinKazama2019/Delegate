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
        public delegate int ValueDelegate(int i);// делегат с аргументом(параметром)

       
        static void Main(string[] args)
        {
            MyDelegate myDelegate = Method1;// определили переменную делегата и присваиваем имя метода
            // теперь мы можем вызывать делегат, вызывая Method1(дергая делегат, мы дергаем Method1)
            // Делегат -это указатель на метод(контейнер в который складываются ссылки на методы)
            // Делегат является коллекцией - содержащей набор методов одинаковой сигнатуры
            // Один раз обращаясь к делегату, мы обращаемся ко всем добавленных в него методам
            myDelegate += Method4;// добавление метода в делегат
            myDelegate();// вызов делегата, который в свою очередб вызывает метод(ы) на которые от указывает
            Console.WriteLine("-----------------------------------------");
            //альтернативный вызов делегата и добавления в него метода
            //один и тот же метод может быть добавлен в делегат несколько раз
            MyDelegate myDelegate1 = new MyDelegate(Method4);// в делегат добавили Method4
            myDelegate1 += Method4;// добавляет в делегает еще раз Method4
            myDelegate1 -= Method4;//удаление из делегаета  Method4
            myDelegate1.Invoke();
            Console.WriteLine("-----------------------------------------");
            MyDelegate myDelegate2 = myDelegate + myDelegate1;// создаем новый делегат, который объединяет два других
            myDelegate2.Invoke();
            Console.WriteLine("-----------------------------------------");
            // если делегат будет содержать несколько методов возвращающих значения, из делегата будет возвращено последнее значение метода(т.к методы помещаются в делегат последовательно)
            var valueDelegate = new ValueDelegate(Method2);
            // случайное число от 10 до 50 будет передано во все методы делегата, но возвращено только последнее
            valueDelegate += Method2;//17
            valueDelegate += Method2;//17
            valueDelegate += Method2;//17
            valueDelegate += Method2;// значение будет возвращено только от этого(если например здесь число 17 то и в других методах будет 17)
            valueDelegate((new Random()).Next(10, 50));// передаем в делегат случайное значение от 10 до 50
            Console.WriteLine("-----------------------------------------");
            // шаблонный делегат(не возращает значения)
            // по сигнатуре полностью совпадает с  public delegate void MyDelegate();
            // Action - это заготовка делегата
            //public delegate void Action(); можно не объявлять вручную, а сразу обращаться по имени Action(он уже по умолчанию создан)
            //Action - это делегат который не возвращает значения, но может принимать от 0 до 16 аргументов(параметров)
            Action actionDelegate = Method1;
            // если хотим сделать  Action с аргументом(параметром), то мы указываем тип
            //public delegate void Action(int i);
            //Action<int> actionDelegate = Method1;// не возвращает ни одного значения, но принимает один параметр
            //public delegate void Action(int i, int j, string H);
            //Action<int, int, string> actionDelegate = Method1;// не возвращает ни одного значения, но принимает три параметра
            actionDelegate();
            Console.WriteLine("-----------------------------------------");
            //public delegate bool Predicate<T>(T value)
            //Делегат Predicate<T>, как правило, используется для сравнения, сопоставления некоторого объекта T определенному условию. 
            //В качестве выходного результата возвращается значение true, если условие соблюдено, и false, если не соблюдено
            //public delegate bool Predicate(int value) используется уже сокращенная форма как ниже
            Predicate<int> predicate= Method5;
            predicate(5);
            Console.WriteLine("-----------------------------------------");
            Predicate<int> isPositive = delegate (int x) { return x > 0; };

            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));
            Console.WriteLine("-----------------------------------------");

            //public delegate int Func(); ниже сокращенная форма по умолчанию, может не принимать параметров, а может до 16
            // Func в любом случае возвращает какое-то значение
            Func<int> func;
            //public delegate int Func(string value); ниже сокращенная форма по умолчанию
            // последним параметром задается возвращаемый тип
            Func<string,int> func1;
            //public delegate int Func(string str, char c); ниже сокращенная форма по умолчанию
            Func<string, char, int> func2;

            Func<int, int> func3 = Method2;
            // 2 строчки ниже можно сократить
            //if(func3!=null) // проверка есть ли в нем какие-то методы
            //func3(7);
            func3?.Invoke(7);


            Console.ReadLine();
        }

        public static void Method1()
        {
            Console.WriteLine("Method1");
        }

        public static int Method2(int i)
        {
            Console.WriteLine(i);
            return i;
        } 
        public static bool Method5(int i)
        {
            Console.WriteLine(i);
            return i>0;
        }
        public static void Method3(int i)
        {
            Console.WriteLine("Method4");
        }
        public static void Method4()
        {
            Console.WriteLine("Method4");
        }


    }
}
