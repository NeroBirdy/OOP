using System;

namespace LABA2
{
    class Horse
    {
        private string name;

        public Horse(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get{return name;} 
        }
    }

    class Pegas : Horse
    {
        public Pegas(string name) : base(name)
        {
        }
        public void fly()
        {
            Console.WriteLine($"{Name} летит");
        }
    }

    class Pet
    {
        protected string name;
        protected int weight,age;
        protected bool sex;

        public string Name
        {
             get{return name;}
        }
        public int Weight
        {
             get{return weight;}
        }

        public string Sex
        {
             get{if (sex) return "M"; else return "F";}
        }

        public int Age
        {
             get{return age;}
        }

        public void info()
        {
            Console.WriteLine($"Имя: {Name} ,Вес: {Weight}, Пол: {Sex}, Возраст: {Age}");
        }
    }

    class Cat: Pet
    {

        public void SleepUnderSun()
        {
            Console.WriteLine($"{Name} спит под солнышком");
        }
        public Cat(string name, int weight, int age, bool sex)
        {
            this.name = name;
            base.weight = weight;
            base.age = age;
            base.sex = sex;
        }
    }

     class Dog: Pet
    {
        public void bone()
        {
            Console.WriteLine($"{Name} грызет косточку");
        }
        public Dog(string name, int weight, int age, bool sex)
        {
            this.name = name;
            base.weight = weight;
            base.age = age;
            base.sex = sex;
        }
    }

    class Fish
    {
        private string name;

        public Fish(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get{return name;}
        }

        protected bool gills = true;

        public void swim()
        {
            Console.WriteLine($"{Name} плывет");
        }
        public void eating()
        {
            Console.WriteLine($"{Name} кушает");
        }
        public void breatheUnderwater()
    {
        if (gills)
        {
            Console.WriteLine($"{Name} дышит через жабры");
        }
        else
        {
            Console.WriteLine($"{Name} не имеет жабр и не может дышать под водой");
        }
    }
    }

    class Animal: Fish
    {

        protected int feet = 4;
        public Animal(string name) : base(name)
        {
            gills = false;
        }
        public void breathe()
        {
            Console.WriteLine($"{Name} дышит");
        }
        public void drinking()
        {
            Console.WriteLine($"{Name} пьет");
        }
    }

    class Ape: Animal
    {
        protected int hands = 2;
        protected string furColor;

        public Ape(string name,string furColor) : base(name)
        {
            this.furColor = furColor;
            feet = 2;
        }
        public void JumpOnTree()
        {
            Console.WriteLine($"{Name} прыгает по деревьям");
        }

        public void Color()
        {
            Console.WriteLine($"У {Name} цвет волос");
        }
    }

    class Human: Ape
    {
        private string secondName;

        public Human(string name,string furColor,string secondName) : base(name, furColor)
        {
            this.secondName = secondName;
        }
        public void learn()
        {
            Console.WriteLine($"{Name} учится");
        }
        public void talking()
        {
            Console.WriteLine($"{Name} говорит внятную речь)");
        }
        public void riding()
        {
            Console.WriteLine($"{Name} катается не пегасе");
        }

        public void info()
        {
            Console.WriteLine($"Это {secondName} {Name} и у него {furColor} цвет волос");
        }
    }
    
    class World
    {
        static void Main()
        {
            Human Oleg = new Human("Oleg", "черный","Игорь");
            Console.WriteLine(Oleg.Name);
            Oleg.info();
        }
    }
}