using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21._1
{
    class Program
    {
        const int n = 5;
        const int m = 5;
        static int[,] mass = new int[n, m] { { 1, 2, 0, 2, 1 }, { 1, 2, 0, 2, 1 }, { 1, 2, 0, 2, 1 }, { 1, 2, 0, 2, 1 }, { 1, 2, 0, 2, 1000 } };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{mass[i, j]}");
                }
            }
            Console.ReadKey();
        }
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mass[i, j] >= 0)
                    {
                        int delay = mass[i, j];
                        mass[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }

        }
        static void Gardner2()
        {
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (mass[i, j] >= 0)
                    {
                        int delay = mass[i, j];
                        mass[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }

            }
        }
    }
}
