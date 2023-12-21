using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        Hero nikita = new Hero("Bow", 10);
        nikita.Decision();
        Human Misha = new Human(new Drunk(), "Misha");
        Misha.Drip();
        Misha.Sleep();

        Alcoholic Vlada = new Alcoholic("Vlada");
        AlcoholicSave one = Vlada.SaveAlcoholic();
        Vlada.Drink();
        Vlada.Drink();
        Vlada.Drink();
        Vlada.RestoreState(one);
        Vlada.Drink();
    }
}

//Стратегия
public interface IStrategy
{
    void Attack();
}

public class Bow : IStrategy
{
    public void Attack()
    {
        Console.WriteLine("Возьму лук и пробью врагу ногу");
    }
}

public class Sword : IStrategy
{
    public void Attack()
    {
        Console.WriteLine("Возьму меч и прирублю врага");
    }
}

class Hero
{
    protected string weapon;
    protected int hp;

    public Hero(string weapon, int hp)
    {
        this.weapon = weapon;
        this.hp = hp;
        if(weapon == "Sword")
        {
            Attack = new Sword();
        }
        else
        {
            Attack = new Bow();
        }
    }

    public IStrategy Attack { get; set; } 

    public void Decision()
    {
        Attack.Attack();
    }
}

//Состояние
abstract class State
{
    public abstract void Sleep(Human context);//Спать
    public abstract void Drink(Human context);//Выпивать
    public abstract void Drip(Human context);//Капельница
}

class Drunk : State 
{
    public override void Sleep(Human context)
    {
        Console.WriteLine("На утро вы чувстуете дикую боль в голове, вам хочется пить");
        context.State = new Sober();
        context.dmgResist = false;
    }

    public override void Drink(Human context)
    {
        Console.WriteLine("Вы пригубили алкоголя, +1 к алкоголизму");
    }
    public override void Drip(Human context)
    {
        Console.WriteLine("Вы прокапались и вам стало лучше");
        context.State = new Sober();
        context.dmgResist = false;
        context.money-=5000;
    }
}

class Sober : State
{
    public override void Sleep(Human context)
    {
        Console.WriteLine("Вы отлично поспали");
    }
    public override void Drink(Human context)
    {
        Console.WriteLine("Вам стало скучно и вы захотели выпить");
        context.State = new Drunk();
        context.dmgResist = true;
    }
    public override void Drip(Human context)
    {
        Console.WriteLine("Вы просто захотели прокапаться");
        context.money-=5000;
    }
}


class Human 
{
    public int money;
    public string name;
    public bool dmgResist;
    public State State { get; set; }

    public Human(State state,string name)
    {
        State = state;
        money = 10000000;
        this.name = name;
        dmgResist = false;
    }

    public void Sleep()
    {
        State.Sleep(this);
    }

    public void Drink()
    {
        State.Drink(this);
    }

    public void Drip()
    {
        State.Drip(this);
    }
}


//Хранитель 

class Alcoholic
{
    private int hp = 100;
    public string name;

    public Alcoholic(string name)
    {
        this.name = name;
    }

    public void Drink()
    {
        if(hp > 0)
        {
            hp--;
            Console.WriteLine($"Ваше здоровье - {hp}");
        }
        else
        {
            Console.WriteLine("У вас закончилось здоровье, вы умерли");
        }
    }

    public AlcoholicSave SaveAlcoholic()
    {
        Console.WriteLine("Вы сохранили состояние Alcoholic");
        return new AlcoholicSave(hp, name);
    }

    public void RestoreState(AlcoholicSave human)
    {
        this.hp = human.hp;
        this.name = human.name;
        Console.WriteLine("Вы успешно восстановили здоровье");
    }
}

class AlcoholicSave
{
    public int hp { get; set; }
    public string name { get; set; }

    public AlcoholicSave(int hp, string name)
    {
        this.hp= hp;   
        this.name = name;
    }
}

class GameHistory
{
    public Stack<AlcoholicSave> Alcoholics { get; private set; }
    public GameHistory()
    {
        Alcoholics = new Stack<AlcoholicSave>();
    }
}