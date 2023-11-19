using System;

namespace LABA_6
{
    class Program
    {
       static void Main()
	   {
			Manufacturer man1 = new PenMan("1");
			Chancellery pen = man1.Create();
			Manufacturer man2 = new PencilMan("2");
			Chancellery pencil = man2.Create();


            ChancelleryFactory factory1 = new FirstFactory();
			Pen pen1 = factory1.CreatePen();
			Notebook notebook1 = factory1.CreateNotebook();
			pen1.Write();
			notebook1.WriteNote();

			ChancelleryFactory factory2 = new SecondFactory();
			Pen pen2 = factory2.CreatePen();
			Notebook notebook2 = factory2.CreateNotebook();
			pen2.Write();
			notebook2.WriteNote();
	   }
    }

    abstract class Manufacturer
    {
        public string Name { get; set; }

        public Manufacturer(string name)
        {
            Name = name;
        }

        abstract public Chancellery Create();
    }

    class PenMan : Manufacturer
    {
		public PenMan(string name) : base(name)
		{}
        public override Chancellery Create()
        {
            return new Pen1();
        }
    }

    class PencilMan : Manufacturer
    {
		public PencilMan(string name) : base(name)
		{}
        public override Chancellery Create()
        {
            return new Pencil();
        }
    }

abstract class Chancellery
{}

class Pen1 : Chancellery
{
    public Pen1()
    {
        Console.WriteLine("Ручка сделана");
    }
}

class Pencil : Chancellery
{
    public Pencil()
    {
        Console.WriteLine("Карандаш сделан");
    }
}



//Абстрактная фабрика

	abstract class Pen
	{
		public abstract void Write();
	}

	abstract class Notebook
	{
		public abstract void WriteNote();
	}
	class BallpointPen : Pen
	{
		public override void Write()
		{
			Console.WriteLine("Пишет шариковой ручкой");
		}
	}

	class GelPen : Pen
	{
		public override void Write()
		{
			Console.WriteLine("Пишет гелевой ручкой");
		}
	}

	class UsualNotebook : Notebook
	{
		public override void WriteNote()
		{
			Console.WriteLine("Пишет в  обычный блокнот");
		}
	}

	class LeatherDiary : Notebook
	{
		public override void WriteNote()
		{
			Console.WriteLine("Пишет в  кожанный дневник");
		}
	}
	abstract class ChancelleryFactory
	{
		public abstract Pen CreatePen();
		public abstract Notebook CreateNotebook();
	}

	class FirstFactory : ChancelleryFactory
	{
		public override Pen CreatePen()
		{
			return new BallpointPen();
		}

		public override Notebook CreateNotebook()
		{
			return new UsualNotebook();
		}
	}

	class SecondFactory : ChancelleryFactory
	{
		public override Pen CreatePen()
		{
			return new GelPen();
		}

		public override Notebook CreateNotebook()
		{
			return new LeatherDiary();
		}
	}
}