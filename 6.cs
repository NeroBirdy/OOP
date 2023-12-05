using System;

namespace LABA_6
{
    class Program
    {
       static void Main()
	   {
			Manufacturer man1 = new PenMan("1",2);
			Chancellery pen = man1.Create();
			Manufacturer man2 = new PencilMan("2","синий");
			Chancellery pencil = man2.Create();


            ChancelleryFactory factory1 = new FirstFactory();
			Pen pen1 = factory1.CreatePen();
			Notebook notebook1 = factory1.CreateNotebook();
			pen1.Write();
			notebook1.WriteNote();

			ChancelleryFactory factory2 = new SecondFactory("крокодила","синий");
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
    public int Cnt { get; set; }

    public PenMan(string name, int cnt) : base(name)
    {
        Cnt = cnt;
    }

    public override Chancellery Create()
    {
        return new Pen1(Cnt);
    }
}

class PencilMan : Manufacturer
{
    public string Color { get; set; }

    public PencilMan(string name, string color) : base(name)
    {
        Color = color;
    }

    public override Chancellery Create()
    {
        return new Pencil(Color);
    }
}

abstract class Chancellery
{ }

class Pen1 : Chancellery
{
    public int Cnt;

    public Pen1(int cnt)
    {
        Cnt = cnt;
        Console.WriteLine($"Ручка с {Cnt} стержнями сделана");
    }
}

class Pencil : Chancellery
{
    public string Color;
    public Pencil(string color)
    {
        Color = color;
        Console.WriteLine($"Карандаш цвета {Color} сделан");
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
		public string Color { get; set; }

		public GelPen(string color)
		{
			Color = color;
		}

		public override void Write()
		{
			Console.WriteLine($"Пишет гелевой ручкой цвета {Color}");
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
		public string CoverMaterial { get; set; }

		public LeatherDiary(string coverMaterial)
		{
			CoverMaterial = coverMaterial;
		}

		public override void WriteNote()
		{
			Console.WriteLine($"Пишет в кожанный дневник с обложкой из {CoverMaterial}");
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
        public string CoverMaterial { get; set; }
        public string Color { get; set; }

        public SecondFactory(string coverMaterial, string color)
        {
            CoverMaterial = coverMaterial;
            Color = color;
        }
		public override Pen CreatePen()
		{
			return new GelPen(Color);
		}

		public override Notebook CreateNotebook()
		{
			return new LeatherDiary(CoverMaterial);
		}
	}
}