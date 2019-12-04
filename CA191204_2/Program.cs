using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191204_2
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            //BekeremATeglalapOldalait();
            //HaromSzTeszt();
            //TombTeszt();
            //PermutacioTeszt();
            //TeglalapTeszt();
            //TeglalapTeszt2();
            OTeszt();

            if (PrimE(11))
            {

            }
            else
            {

            }


            Console.ReadKey();
        }

        private static void TeglalapTeszt2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = (ConsoleColor)rnd.Next(1, 16);
                Teglalap(
                    rnd.Next(2, Console.WindowWidth) - 2,
                    rnd.Next(2, Console.WindowHeight) - 2);
            }
        }
        private static void TombTeszt()
        {
            for (int i = 0; i < 10; i++)
            {
                int[] t = new int[rnd.Next(50, 101)];
                TombFeltolt(t, rnd.Next(5000));
                TombKiir(t);
                Console.WriteLine("\n----------------");
            }
        }
        static void KerTer(int a, int b)
        {
            Console.WriteLine($"Kerület: {2 * (a + b)} cm");
            Console.WriteLine($"Tetület: {a * b} cm^2");
        }
        static void BekeremATeglalapOldalait()
        {
            Console.Write("add meg a téglalap 'a' oldalhosszát: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("add meg a téglalap 'b' oldalhosszát: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Kerület: {2 * (a + b)} cm");
            Console.WriteLine($"Tetület: {a * b} cm^2");
        }
        static bool HaromSzE(int a, int b, int c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
        static void HaromSzTeszt()
        {
            for (int i = 0; i < 15; i++)
            {
                int a = rnd.Next(10);
                int b = rnd.Next(10);
                int c = rnd.Next(10);

                Console.Write($"{a}-{b}-{c} ");

                if (HaromSzE(a, b, c))
                {
                    Console.WriteLine("háromszög");
                }
                else Console.WriteLine("NEM háromszög");
            }
        }
        static void TombFeltolt(int[] t, int max)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = rnd.Next(max) + 1;
            }
        }
        static void TombKiir(int[] t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write("{0, 4} ", t[i]);

                if ((i + 1) % 10 == 0) Console.Write("\n");
            }
        }
        static int[] PermutacioN(int n)
        {
            int[] t = new int[n];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = i + 1;
            }

            for (int i = 0; i < t.Length; i++)
            {
                int x = rnd.Next(t.Length);
                int y = rnd.Next(t.Length);

                int cs = t[x];
                t[x] = t[y];
                t[y] = cs;
            }

            return t;
        }
        static void PermutacioTeszt()
        {
            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(3, 11);
                Console.WriteLine("\n");
                Console.WriteLine($"1...{x} permutációja pl:");
                TombKiir(PermutacioN(x));
                Console.WriteLine("\n-------------------");
            }
        }
        static void Teglalap(int sz, int m)
        {
            int hk = Console.WindowHeight / 2;
            int vk = Console.WindowWidth / 2;

            //teteje + alja
            for (int i = 0; i < sz; i++)
            {
                Console.SetCursorPosition(vk - sz / 2 + i, hk - (m / 2));
                Console.Write('*');
                Console.SetCursorPosition(vk - sz / 2 + i, hk + (m / 2));
                Console.Write('*');
            }

            //bal + jobb oldala
            for (int i = 0; i < m; i++)
            {
                Console.SetCursorPosition(vk - (sz / 2), hk - m / 2 + i);
                Console.WriteLine('*');
                Console.SetCursorPosition(vk + (sz / 2), hk - m / 2 + i);
                Console.WriteLine('*');
            }

        }
        static void TeglalapTeszt()
        {
            Teglalap(78, 23);
            Teglalap(74, 19);
            Teglalap(70, 15);
            Teglalap(66, 11);
            Teglalap(62, 7);
            Teglalap(58, 3);
        }
        static int[] Osztok(int n)
        {
            if (n < 1) return new int[0];

            if (n == 1) return new int[] { 1, };

            int[] osztok = new int[100];
            osztok[0] = 1;
            int sz = 1;
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    osztok[sz] = i;
                    sz++;
                }
            }
            osztok[sz] = n;
            Array.Resize(ref osztok, sz + 1);
            return osztok;
        }
        static void OTeszt()
        {
            Console.Write("Írj be egy természetes számot: ");
            int x = int.Parse(Console.ReadLine());
            int[] o = Osztok(x);
            Console.WriteLine($"{x} osztói: ");
            for (int i = 0; i < o.Length; i++)
            {
                Console.WriteLine(o[i]);
            }
            Console.WriteLine($"{x}-nek {DbOszto(x)} db osztója van");

            if (PrimE(x)) Console.WriteLine($"{x} PRÍMSZÁM");
            else Console.WriteLine($"{x} NEM prím");

            Console.WriteLine("-----");
        }

        static int DbOszto(int n)
        {
            return Osztok(n).Length;
        }

        static bool PrimE(int n)
        {
            return DbOszto(n) == 2;
        }

    }
}
