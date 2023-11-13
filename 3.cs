using System;

namespace LABA3
{
	class Program
	{
		static public void Determinant(object obj)
		{
			Type objectType = obj.GetType();
			Console.WriteLine($"Относится к классу: {objectType.Name}");
		}

		static void Main()
		{
			Whale whale = new Whale();
			Cow cow = new Cow();

			cow.getName();
			whale.getName();


			Catt catt = new Catt("Первая", 2);
			Determinant(catt);

			Dogg dogg = new Dogg("Вторая", 3);
			Determinant(dogg);

			Bird bird = new Bird("Птичка", 4);
			Determinant(bird);

			Lamp lamp = new Lamp("Какой-то", 3);
			Determinant(lamp);

			Cat cat = new Cat("Kot", 4);
			Cat kitten = cat.GetChild();
			Console.WriteLine("Hello " + kitten.GetType().Name);

			Dog dog = new Dog("Dog", 6);
			Dog doggy = dog.GetChild();
			Console.WriteLine("Hello " + doggy.GetType().Name);


			Overload overload = new Overload();

			overload.print(1);
			overload.print("Text");
			overload.print(1.1);
			overload.print('T');
			overload.print(true);

			Console.WriteLine(Overload.min(1, 2));
			Console.WriteLine(Overload.min(1.1, 1.2));
			Console.WriteLine(Overload.min(1000000000000000001, 1000000000000000002));

			Console.WriteLine(Overload.max(1, 2));
			Console.WriteLine(Overload.max(1.3, 1.4));
			Console.WriteLine(Overload.max(1000000000000000001, 1000000000000000002));

		}
	}

	class Cow
	{
		public virtual void getName()
		{
			Console.WriteLine("Я корова");
		}
	}

	class Whale : Cow
	{
		public override void getName()
		{
			Console.WriteLine("Я не корова, Я – кит");
		}

	}


	class Catt
	{
		public string name { get; set; }
		public int age { get; set; }

		public Catt(string name, int age)
		{
			this.name = name;
			this.age = age;
		}
	}

	class Dogg : Catt
	{
		public Dogg(string name, int age) : base(name, age)
		{
		}
	}

	class Bird : Catt
	{
		public Bird(string name, int age) : base(name, age)
		{
		}
	}

	class Lamp : Catt
	{
		public Lamp(string manufacturer, int age) : base(manufacturer, age)
		{
		}
	}


	class Cat
	{
		public string name { get; set; }
		public int age { get; set; }

		public Cat(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public virtual dynamic GetChild()
		{
			Cat child = new Cat("Kitten", 0);
			return child;
		}
	}

	class Dog : Cat
	{
		public Dog(string name, int age) : base(name, age)
		{
		}

		public override dynamic GetChild()
		{
			Dog child = new Dog("Doggy", 0);
			return child;
		}
	}


	class Overload
	{
		public void print(int s)
		{
			Console.WriteLine(s);
		}

		public void print(string s)
		{
			Console.WriteLine(s);
		}

		public void print(bool s)
		{
			Console.WriteLine(s);
		}

		public void print(double s)
		{
			Console.WriteLine(s);
		}

		public void print(char s)
		{
			Console.WriteLine(s);
		}

		public static int min(int a, int b)
		{
			return Math.Min(a, b);
		}

		public static long min(long a, long b)
		{
			return Math.Min(a, b);
		}

		public static double min(double a, double b)
		{
			return Math.Min(a, b);
		}

		public static int max(int a, int b)
		{
			return Math.Max(a, b);
		}

		public static long max(long a, long b)
		{
			return Math.Max(a, b);
		}

		public static double max(double a, double b)
		{
			return Math.Max(a, b);
		}
	}
}