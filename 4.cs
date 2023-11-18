using System;

namespace LABA4
{
    class Program
    {
        static void Main()
        {

        }

        abstract class Pet
        {
            public string name;
            public int age;
            public bool hungry;

            public Pet(string name, int age, bool hungry)
            {
                this.name = name;
                this.age = age;
                this.hungry = hungry;
            }

            public abstract void voice();
        }

        class Snake : Pet
        {
            public Snake(string name, int age, bool hungry) : base(name, age, hungry)
            {
            }

            public override void voice()
            {
                Console.WriteLine($"Пшшшшш, Я {name}");
            }
        }

        class  Dog: Pet
        {
            public Dog(string name, int age, bool hungry) : base(name, age, hungry)
            {
            }

            public override void voice()
            {
                Console.WriteLine($"Гаф, Я {name}");
            }
        }

        class PatrolDog : Pet
        {
            public PatrolDog(string name, int age, bool hungry) : base(name, age, hungry)
            {
            }

            public override void voice()
            {
                Console.WriteLine($"ВиуВиу, Я {name}");
            }
        }

        class Cat : Pet
        {
            public Cat(string name, int age, bool hungry) : base(name, age, hungry)
            {
            }

            public override void voice()
            {
                Console.WriteLine($"Мяу, Я {name}");
            }
        }

        class Fish : Pet
        {
            public Fish(string name, int age, bool hungry) : base(name, age, hungry)
            {
            }

            public override void voice()
            {
                Console.WriteLine($"Бульк, Я {name}");
            }
        }

        interface PassengersAuto
        {
            void Pas();
        }

        interface Cargo
        {
            void Car();
        }

        class Truck : CargoAuto
        {
            private int weight;

            public Trunk(int weight)
            {
                whis.weight = weight;
            }
            public void Car()
            {
                Console.WriteLine($"Перевозит: {weight} кг");
            }
        }

        class Sedan : PassengersAuto
        {
            private int count;

            public Sedan(int count)
            {
                this.count = count;
            }
            public void Pas()
            {
                Console.WriteLine($"Перевозит {count} человек");
            }
        }

        class Pickup : PassengersAuto, CargoAuto
        {
            private int weight;
            private int count;

            public Pickup(int weight, int count)
            {
                this.weight = weight;
                this.count = count;
            }

            public void Car()
            {
                Console.WriteLine($"Перевозит: {weight} кг");
            }
            
            public void Pas()
            {
                Console.WriteLine($"Перевозит {count} человек");
            }
        }
    }
}