using System;

namespace LABA2
{
    class Hourse
    {
        private string name;

        public string Name
        {
            get{return name;} set{name = value;}
        }
    }

    class Pegas : Hourse
    {
        public void fly()
        {
            Console.WriteLine($"{Name} летит");
        }
    }

    class Pet
    {
        private int weight,age;
        private bool sex;
        
        public int Weight
        {
             get{return weight;} set{weight = value;}
        }

        public string Sex
        {
             get{if (sex) return "M"; else return "F";} set{if (value == "0") sex = true; else if (value == "1") sex = false;}
        }

        public int Age
        {
             get{return age;} set{age = value;}
        }
    }

    class Cat: Pet
    {
        private string name;

        public string Name
        {
            get{return name;} set{name = value;}
        }

        public void info()
        {
            Console.WriteLine($"Имя: {Name} ,Вес: {Weight}, Пол: {Sex}, Возраст: {Age}");
        }
    }

     class Dog: Pet
    {
        private string name;

        public string Name
        {
            get{return name;} set{name = value;}
        }

        public void info()
        {
            Console.WriteLine($"Имя: {Name} ,Вес: {Weight}, Пол: {Sex}, Возраст: {Age}");
        }
    }

    class Fish
    {
        private string name;

        public string Name
        {
            get{return name;} set{name = value;}
        }

        public void swim()
        {
            Console.WriteLine($"{Name} плывет");
        }
        public void eating()
        {
            Console.WriteLine($"{Name} кушает");
        }
        
    }

    class Animal: Fish
    {
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

        public void JumpOnTree()
        {
            Console.WriteLine($"{Name} прыгает по деревьям");
        }
        public void walking()
        {
            Console.WriteLine($"{Name} учит команды");
        }
    }

    class Human: Ape
    {
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
    }
    
    class World
    {
        static void Main()
        {
            Human Oleg = new Human();
            Oleg.Name = "Oleg";
            Oleg.learn();
            Console.WriteLine(Oleg.Name);
        }
    }
}