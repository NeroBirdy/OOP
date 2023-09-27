using System;

namespace LABA1
{

    class Circle
    {
        
        public int x,y,r;
        
        public Circle(){
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
            r = int.Parse(Console.ReadLine());
        }

        public static double len(int r)
        {
            return 2 * 3.1415 * r;
        }

        public void changeCenter()
        {
            x = World.Rand(-99,99);
            y = World.Rand(-99,99);
        }

        public static double lenBetween(Circle one, Circle two)
        {
            return Math.Sqrt(Math.Pow(two.x - one.x,2) + Math.Pow(two.y - one.y,2));
        }

        public static bool IsInside(Circle one, Circle two)
        {
            return (lenBetween(one,two) + two.r) <= one.r;
        }

        public static void check(Circle one, Circle two)
        {
            double dist = lenBetween(one,two);
            if(IsInside(one,two) || IsInside(two,one))
            {
                if(dist == Math.Abs(one.r - two.r))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            else
            {
                if (dist == (one.r + two.r))
                {
                    Console.WriteLine($"True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }

    }

    class World
    {
        
        public static int Rand(int a, int b)
        {
            Random rnd = new Random();
            int c = rnd.Next(a,b);
            return c;
        }

        static void Main()
        {
            Circle one = new Circle();
            Circle two = new Circle();

            Circle.check(one,two);
        }
    }
}

