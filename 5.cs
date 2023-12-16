using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;


class Program
{
    delegate double Function(double x);
    delegate double Integral (double a, double b, int n,Function Y);
    delegate double Sum(double a, double b, int n, Function Y);
    delegate double Sum2(List<double> x);
    delegate double Sum3(List<double> x, Sum2 S);
    delegate double Sum4(List<double> x, List<double> y, Sum2 S);

    static void Main()
    {
        List<Function> examples = new List<Function>() { first, second, third };
        List<double> g = new List<double>();
        List<double> z = new List<double>();
        Function F1;
        F1 = x => 3 * x - Math.Sin(2 * x);
        Function F2;
        F2 = x => Math.Exp(-2 * x) - 2 * x + 1;

        Sum S1 = (a,b,n,Y) => {
            double sum = 0;
            for(int i = 0; i < n - 1; i++)
            {
                sum += Y(a + i * (b - a) / n);
            }
            return sum;
        };
        Sum2 S2 = (List<double> x) => {
            double sum = 0;
            for(int i = 0;i < x.Count; i++)
            {
                sum += x[i];
            }
            return sum;
        };
        Sum3 S3 = (List<double> x,Sum2 S) => {
            double sum = 0;
            for(int i = 0; i < x.Count; i++)
            {
                sum += Math.Pow(x[i] - S(x),2);
            }
            return sum;
        };
        Sum4 S4 = (List<double> x, List<double> y, Sum2 S) => {
            double sum = 0;
            for(int i = 0; i < x.Count; i++)
            {
                sum += (x[i] - S(x)) * (y[i] - S(y));
            }
            return sum;
        };
        double temp;
        int p;
        while (true)
        {
            Console.WriteLine("Введите номер задания");
            int number = int.Parse(Console.ReadLine());
            if(number <= 3) 
            {
                Console.WriteLine("Введите x:");
                double x = double.Parse(Console.ReadLine());
                result(x, examples[number - 1]);
            }
            else if(number == 4) 
            {
                Console.WriteLine("Введите n:");
                p=int.Parse(Console.ReadLine());
                Integral I1;
                I1 = (a,b,n,Y) => (b-a)/n*S1(a,b,n,Y);
                Console.WriteLine(I1(0,2*Math.PI,p,F1)-I1(0,Math.PI,p,F2));
            }
            else if (number == 5)
            {
                Console.WriteLine("Задайте размерность выборок:");
                int size = int.Parse(Console.ReadLine());
                for(int i=0; i < size; i++)
                {
                    g.Add(double.Parse(Console.ReadLine()));
                    z.Add(double.Parse(Console.ReadLine()));
                }
                Console.WriteLine(S4(g, z, S2) / S3(g, S2) * S3(z, S2));
            }

            Console.WriteLine("Продолжим решать?");
            string answer = Console.ReadLine();
            if(answer != "1")
            {
                break;
            }
        }
    }

    static void result(double x, Function operation)
    {
        Console.WriteLine(operation(x));
    }

    static double first(double x)
    {
        if(x < 1)
        {
            return Math.Tan(2 * x);
        }
        else
        {

            return Math.Pow((2 * x + 10), 3);
        }
    }
    static double second(double x)
    {
        int temp = 1;
        for (int i = 2; i <= x; i = i + 2)
        {
            temp *= i;
        }
        return x * x * temp;
    }

    static double third(double x)
    {
        if (x < -7)
        {
            return -3 * Math.Sin(2 * x);
        }
        else if(x>=-7 && x < 0)
        {
            return Complex.Pow(x, 0.5).Magnitude;
        }
        else
        {
            return 1 / x;
        }
    }
}

