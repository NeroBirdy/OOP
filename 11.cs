using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // ICTemperature celsiusSensor = new CSensor();
        // Console.WriteLine($"Текущая температура в градусах Цельсия: {celsiusSensor.GetTemperature()}");
        // IFTemperature fahrenheitAdapter = new FahrenheitAdapter(celsiusSensor);
        // Console.WriteLine($"Текущая температура в градусах Фаренгейта: {fahrenheitAdapter.GetTemperatureInFahrenheit()}");

        // Console.WriteLine("");

        // IOutput monitor = new Monitor();
        // Device tv = new TV(monitor);
        // tv.Print();
        // IOutput projector = new Projector();
        // Device computer = new Computer(projector);
        // computer.Print();

        // Console.WriteLine("");

        // DocumentFactory documentFactory = new DocumentFactory();
        // IDocument document1 = documentFactory.GetDocument("1");
        // IDocument document2 = documentFactory.GetDocument("2");
        // IDocument document3 = documentFactory.GetDocument("2");
        // document1.Open();
        // document1.Close();

        // Console.WriteLine("");

        IAdditionOperation proxy = new AdditionProxy();

        Console.WriteLine(proxy.Add(2, 3)); 
        Console.WriteLine(proxy.Add(2, 3));
        Console.WriteLine(proxy.Add(2, 4));
        Console.WriteLine(proxy.Add(2, 5));
        Console.WriteLine(proxy.Add(2, 5));
    }
}
//Адаптер
interface ICTemperature
{
    double GetTemperature(); 
}

class CSensor : ICTemperature
{
    public double GetTemperature()
    {
        return 27.0;
    }
}

interface IFTemperature
{
    double GetTemperatureInFahrenheit(); 
}

class FahrenheitAdapter : IFTemperature
{
    private readonly ICTemperature cSensor;

    public FahrenheitAdapter(ICTemperature cSensor)
    {
        this.cSensor = cSensor;
    }

    public double GetTemperatureInFahrenheit()
    {
        double CTemperature = cSensor.GetTemperature();
        double FTemperature = (CTemperature * 9 / 5) + 32;

        return FTemperature;
    }
}

//Мост
abstract class Device
{
    protected IOutput output;

    public Device(IOutput output)
    {
        this.output = output;
    }

    public abstract void Print();
}

class TV : Device
{
    public TV(IOutput output) : base(output) { }

    public override void Print()
    {
        output.Write("Отображено на телевизоре");
    }
}

class Computer : Device
{
    public Computer(IOutput output) : base(output) { }

    public override void Print()
    {
        output.Write("Отображено на компьютере");
    }
}

interface IOutput
{
    void Write(string message);
}

class Monitor : IOutput
{
    public void Write(string message)
    {
        Console.WriteLine($"Отображено на мониторе: {message}");
    }
}

class Projector : IOutput
{
    public void Write(string message)
    {
        Console.WriteLine($"Отображено на проекторе: {message}");
    }
}

//Приспособленец
interface IDocument
{
    void Open();
    void Close();
}

class TextDocument : IDocument
{
    private string content;

    public TextDocument(string content)
    {
        this.content = content;
    }

    public void Open()
    {
        Console.WriteLine("Текстовый документ открыт");
    }

    public void Close()
    {
        Console.WriteLine("Текстовый документ закрыт");
    }
}

class DocumentFactory
{
    private Hashtable documents = new Hashtable();

    public IDocument GetDocument(string content)
    {
        if (!documents.ContainsKey(content))
        {
            Console.WriteLine("Создание нового текстового документа");
            documents.Add(content,new TextDocument(content));
        }

        return documents[content] as IDocument;
    }
}
//Заместитель
interface IAdditionOperation
{
    int Add(int a, int b);
}

class Addition : IAdditionOperation
{
    public int Add(int a, int b)
    {
        Console.WriteLine($"Выполнено сложение {a} и {b}");
        return a + b;
    }
}

class AdditionProxy : IAdditionOperation
{
    private Hashtable cache = new Hashtable();
    private Addition Addition = new Addition();


    public int Add(int a, int b)
    {
        string key = $"{a}+{b}";
        if (cache.ContainsKey(key))
        {
            Console.WriteLine($"Результат сложения {key} взят из кэша");
            return Convert.ToInt32(cache[key]);
        }
        else
        {
            int result = Addition.Add(a, b);
            cache.Add(key, result);
            return result;
        }
    }
}