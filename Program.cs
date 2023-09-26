using System;

namespace LABA
{
    class World
    {
        static void one()
        {
            for(int i = 2; i <=100; i+=2)
            {
                Console.Write($"{i} ");
            }
        }

        static void two()
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(8);
                }
                Console.WriteLine();
            }
        }

        static void three()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j <= i; j ++)
                {
                    Console.Write(8);
                }
                Console.WriteLine();
            }
        }

        static int four(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        static void five()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            if (a == b)
            {
                Console.WriteLine("Имена идентичны");
            }
            else if (a.Length == b.Length)
            {
                Console.WriteLine("Длины имен равны");
            }
        }

        static int six(int a,int b,int c,int d)
        {
            return four(four(a,b), four(c,d));
        }

        static void seven(int x, int y)
        {
            if (x > 0 && y > 0)
                Console.WriteLine(1);
            else if (x < 0 && y > 0)
                Console.WriteLine(2);
            else if (x < 0 && y < 0)
                Console.WriteLine(3);
            else if (x > 0 && y < 0)
                Console.WriteLine(4);
        }

        static void eight()
        {
            int[] arr = {2, 4, 6, 8, 10, 12, 14, 16 ,18, 20};
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void nine()
        {
            int[] arr = new int[50];
            for(int i = 1,j = 0; i < 100; i +=2,j++)
            {
                arr[j] = i;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write($"{arr[i]} ");
            }
        }

        static int rand()
        {
            Random rnd = new Random();
            int c = rnd.Next(0, 9);
            return c;
        }
        static void ten()
        {
            int[] arr = new int[15];
            for(int i = 0; i < 15; i++)
            {
                arr[i] = rand();
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            int count = 0;
            for(int i = 0; i < 15; i++)
            {
                if (arr[i]%2 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static int random()
        {
            Random rnd = new Random();
            int c = rnd.Next(10, 99);
            return c;
        }
        static void eleven()
        {
            int[,] arr = new int[8,5];
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    arr[i,j] = random();
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }

        }

        static int Random()
        {
            Random rnd = new Random();
            int c = rnd.Next(-5, 5);
            return c;
        }
        static void twelve()
        {
            int[,] arr = new int[7,4];
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    arr[i,j] = random();
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }

            int ind = 0;
            int count = 0;

            for(int i = 0; i < 7; i++)
            {
                int cnt = 1;
                for(int j = 0; j < 4; j++)
                {
                    cnt *= Math.Abs(arr[i,j]);
                }
                if (cnt > count)
                {
                    ind = i;
                    count = cnt;
                }
            }
            Console.WriteLine(ind);
        }

        static int Rand(int a, int b)
        {
            Random rnd = new Random();
            int c = rnd.Next(a,b);
            return c;
        }

        static void thirteen()
        {
            int[] arr = new int[20];
            for(int i = 0; i < 20; i++)
            {
                arr[i] = Rand(-5,5);
                Console.Write($"{arr[i]} ");
            }
        }

        static void print(int[] arr)
        {
             for(int i = 0; i < 10; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }

        static void fourteen()
        {
            int[] arr1 = new int[10];
            int[] arr2 = new int[10];
            int[] arr3 = new int[10];
            int[] arr4 = new int[10];
            int[] arr5 = new int[10];
            for(int i = 0; i < 10; i++)
            {
                arr1[i] = Rand(1,10);
                arr2[i] = Rand(1,100);
                arr3[i] = Rand(1,20);
                arr4[i] = Rand(1,30);
                arr5[i] = Rand(-5,10);
            }
            print(arr1);
            print(arr2);
            print(arr3);
            print(arr4);
            print(arr5);
        }

        static void fifteen(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void Main()
        {
           fourteen();
        }
    }
}

//Python
// F(33) = 3524578, Work: 0.9002015590667725 second
// F(34) = 5702887, Work: 1.409775972366333 second
// F(35) = 9227465, Work: 2.164170503616333 second
// F(36) = 14930352, Work: 3.50441575050354 second
// F(37) = 24157817, Work: 5.726852893829346 second
// F(38) = 39088169, Work: 9.15798306465149 second
// F(39) = 63245986, Work: 14.931058168411255 second
// F(40) = 102334155, Work: 24.13309931755066 second
// F(41) = 165580141, Work: 39.15969705581665 second

//C++
// F(40) = 102334155, Время выполнения: 0,765 секунд
// F(41) = 165580141, Время выполнения: 1,294 секунд
// F(42) = 267914296, Время выполнения: 2,069 секунд
// F(43) = 433494437, Время выполнения: 3,042 секунд
// F(44) = 701408733, Время выполнения: 4,767 секунд
// F(45) = 1134903170, Время выполнения: 9,895 секунд
// F(46) = 1836311903, Время выполнения: 16,084 секунд
// F(47) = 2971215073, Время выполнения: 24,039 секунд