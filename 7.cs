using System;
using System.Runtime.InteropServices;

namespace LABA_7
{
    class Program
    {
       static void Main()
	   {
			Smatrphone XiaomiMi10 = new Smatrphone();
			XiaomiMi10.Create("Android");
			Console.WriteLine(XiaomiMi10.OS.name);
			XiaomiMi10.Create("IOS");
			Console.WriteLine(XiaomiMi10.OS.name);

			IWeapon weapon = new Glock19(10,"");
			IWeapon clone = weapon.Clone();
			weapon.GetInfo();
			clone.GetInfo();

			IWeapon weapon1 = new Knife("коготь",false);
			IWeapon clone1 = weapon1.Clone();
			weapon1.GetInfo();
			clone1.GetInfo();

            Builder builder1 = new PistolBuilder();
            Builder builder2 = new RifleBuilder();

			GunCompany company = new GunCompany(builder1);
            Weapon pistol = company.Construct("коллиматорный прицел");
            pistol.showInfo();

            company = new GunCompany(builder2);
            Weapon rifle = company.Construct("глушитель");
            rifle.showInfo();

	   }
    }
    //Синглетон
	class Smatrphone
	{
		public OS OS{ get; set;}

		public void Create(string name)
		{
			OS = OS.getInstance(name);
		}

	}

	class OS
	{
		private static OS instance;

		public string name;

		public OS(string name)
		{
			this.name = name;
		}

		public static OS getInstance(string name)
		{
			if(instance == null)
				instance = new OS(name);
			return instance;
		}
	}
    //Прототип
	interface IWeapon
	{
		IWeapon Clone();

		void GetInfo();
	}

	class Glock19 : IWeapon
	{
		int bullets;
		string kit;
		public Glock19(int bullets,string kit)
		{
			this.bullets = bullets;
			this.kit = kit;
		}

        public IWeapon Clone()
        {
            return new Glock19(this.bullets,this.kit);
        }

        public void GetInfo()
        {
            if (kit != "")
            {
                Console.WriteLine($"Glock19 с магагазином на {bullets} пуль, c обвесом {kit}\n");
            }
            else
            {
                Console.WriteLine($"Glock19 с магагазином на {bullets} пуль\n");
            }
        }
	
	}

	class Knife : IWeapon
	{
        string type;
        bool legal;

        public Knife(string type,bool legal)
        {
            this.type = type;
            this.legal = legal;
        }

        public IWeapon Clone()
        {
            return new Knife(this.type,this.legal);
        }

        public void GetInfo()
        {
            string t = legal == true ? "разрешен" : "запрещен";
            Console.WriteLine($"Нож {type}, {t} в России\n");
        }

	}
    //Билдер
    class GunCompany
    {
        Builder builder;
        public GunCompany(Builder builder)
        {
            this.builder = builder;
        }
        
        public Weapon Construct(string kit)
        {
            builder.CreateWeapon();
            builder.SetCountBullents();
            builder.SetKit(kit);
            builder.SetType();
            return builder.getResult();
        }
    }

    abstract class Builder 
    {
        protected Weapon weapon;
        public abstract void SetCountBullents();
        public abstract void SetKit(string kit);
        public abstract void SetType();
        public Weapon getResult()
        {
            return weapon;
        }

        public void CreateWeapon()
        {
            weapon = new Weapon();
        }
    }

    class Weapon
    {
        public int bullets;
        public string kit;
        public string type;

        public void showInfo()
        {
            if (kit != "")
            {
                Console.WriteLine($"{type} с магагазином на {bullets} пуль, c обвесом {kit}\n");
            }
            else
            {
                Console.WriteLine($"{type} с магагазином на {bullets} пуль\n");
            }
        }
    }

    class PistolBuilder : Builder
    {
        public override void SetCountBullents()
        {
            weapon.bullets = 15;
        }

        public override void SetKit(string kit)
        {
            weapon.kit = kit;
        }

        public override void SetType()
        {
            weapon.type = "Glock19";
        }
    }

    class RifleBuilder : Builder
    {
        public override void SetCountBullents()
        {
            weapon.bullets = 45;
        }

        public override void SetKit(string kit)
        {
            weapon.kit = kit;
        }

        public override void SetType()
        {
            weapon.type = "РПК-74M";
        }
    }
    
}


  
    
