using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        const int l = 10;
        const int h = 6;
        static int[,] path = new int[h, l] //что бы массив был доступен 1 и 2 методу делаем его статичным
        {
            { 99, 44, 25, 44, 33, 34, 31, 76, 45, 99 },
            { 14, 24, 42, 99, 99, 99, 14, 78, 45, 44 },
            { 14, 24, 42, 54, 54, 44, 14, 78, 45, 44 },
            { 14, 24, 42, 54, 54, 44, 14, 78, 45, 44 },
            { 14, 24, 42, 54, 54, 44, 14, 78, 45, 44 },
            { 14, 24, 42, 54, 54, 44, 14, 78, 45, 44 }
        };

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner2);//1. Создать делегат(скафандр)
            Thread thread = new Thread(threadStart);            //2. Поместить переменную делегата в поток (нить)
            thread.Start();                                     //3. Нажать старт

            Console.WriteLine("Не вспаханный огород:");
            PrintArray();

            Console.WriteLine("Вспаханный двумя садовниками огород:");
            Console.WriteLine();
            Gardner1();
            PrintArray();

            Console.ReadKey();
        }

        static void PrintArray()
        {
            for (int i = 0; i < h; i++) //счет суммы строк
            {

                for (int j = 0; j < l; j++) //Формирование элементов строк
                {

                    Console.Write(path[i, j] + "\t"); //вывод двумерного массива

                }
                Console.WriteLine();
            }
        }

        static void Gardner1()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay); //поток освобождает оставшуюся часть своего интервала времени для
                                             //любого потока с таким же приоритетом, готовым к выполнению.
                    }
                }

            }
        }
        static void Gardner2()
        {
            for (int i = h - 1; i >= 0; i--)
            {
                for (int j = l - 1; j >= 0; j--)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }

            }
        }
    }
}
