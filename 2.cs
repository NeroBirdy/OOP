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
        private string sex;
        
        public int Weight
        {
             get{return weight;} set{weight = value;}
        }

        public string Sex
        {
             get{return sex;} set{sex = value;}
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
        
    }

    class Animal: Fish
    {
        public void breathe()
        {
            Console.WriteLine($"{Name} дышит");
        }
    }

    class Ape: Animal
    {
        public void JumpOnTree()
        {
            Console.WriteLine($"{Name} прыгает по деревьям");
        }
    }

    class Human: Ape
    {
        public void learn()
        {
            Console.WriteLine($"{Name} учится");
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