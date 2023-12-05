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
	   }
    }

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

}