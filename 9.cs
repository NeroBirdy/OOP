using System;

class Program
{
    static void Main(string[] args)
    {
        PC WorkPlace = new PC(false, false, false);
        Handler first = new ConcreteHandler1();
        Handler second = new ConcreteHandler2();
        Handler third = new ConcreteHandler3();
        first.Successor = second;
        second.Successor = third;
        first.HandleRequest(WorkPlace);

        Console.WriteLine("");

        TeamChat teamChat = new TeamChat();
        Developer developer = new Developer(teamChat);
        Tester tester = new Tester(teamChat);
        teamChat.FirstTeamMember = developer;
        teamChat.SecondTeamMember = tester;
        developer.Send("Привет!");
        tester.Send("Ну привет!");

        Console.WriteLine("");

        WeatherStation weatherStation = new WeatherStation();
        WeatherDisplay display1 = new WeatherDisplay();
        WeatherDisplay display2 = new WeatherDisplay();
        WeatherDisplay display3 = new WeatherDisplay();
        weatherStation.AddObserver(display1);
        weatherStation.AddObserver(display2);
        weatherStation.AddObserver(display3);
        weatherStation.SetTemperature(27);

        Console.WriteLine("");

        var structure = new ObjectStructure();
        structure.Add(new Bus());
        structure.Add(new Plane());
        structure.Add(new Train());
        structure.Accept(new ServiceInspector());
    }
}

//Цепочка обязаностей
class PC
{
    private bool mouse,keyboard,monitor;
    public PC(bool mouse, bool keyboard, bool monitor)
    {
        this.mouse = mouse;
        this.keyboard = keyboard;
        this.monitor = monitor;
    }

    public void Service(string part)
    {
        if (part == "mouse")
        {
            mouse = !mouse;
        }
        else if (part == "keyboard")
        {
            keyboard = !keyboard;
        }
        else if (part == "monitor")
        {
            monitor = !monitor;
        }
        else
        {
            Console.WriteLine("Данный девайс чистый");
        }
    }

    public bool PartStatus(string part)
    {
        if (part == "mouse")
        {
            return mouse;
        }
        else if (part == "keyboard")
        {
            return keyboard;
        }
        else if (part == "monitor")
        {
            return monitor;
        }
        return true;
    }

}

abstract class Handler
{
    public Handler Successor { get; set; }
    public abstract void HandleRequest(PC WorkPlace);
}

class ConcreteHandler1 : Handler 
{
    public override void HandleRequest(PC WorkPlace)
    {
        if (!WorkPlace.PartStatus("mouse"))
        {
            WorkPlace.Service("mouse");
            Console.WriteLine("Протер мышкку");
        }
        if (Successor != null)
        {
            Successor.HandleRequest(WorkPlace);
        }
    }
}

class ConcreteHandler2 : Handler 
{
    public override void HandleRequest(PC WorkPlace)
    {
        if (!WorkPlace.PartStatus("keyboard"))
        {
            WorkPlace.Service("keyboard");
            Console.WriteLine("Протер клавиатуру");
        }
        if (Successor != null)
        {
            Successor.HandleRequest(WorkPlace);
        }
    }
}

class ConcreteHandler3 : Handler 
{
    public override void HandleRequest(PC WorkPlace)
    {
        if (!WorkPlace.PartStatus("monitor"))
        {
            Console.WriteLine("Протер монитор");
            WorkPlace.Service("monitor");
        }
        if (Successor != null)
        {
            Successor.HandleRequest(WorkPlace);
        }
    }
}

//Посредник
abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void Receive(string message);
    public abstract void Send(string message);
}

class TeamChat : Mediator
{
    public Colleague FirstTeamMember { get; set; }
    public Colleague SecondTeamMember { get; set; }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == FirstTeamMember)
        {
            SecondTeamMember.Receive(message);
        }
        else if (colleague == SecondTeamMember)
        {
            FirstTeamMember.Receive(message);
        }
    }
}

class Developer : Colleague
{
    public Developer(Mediator mediator) : base(mediator) { }

    public override void Receive(string message)
    {
        Console.WriteLine("Сообщение разработчику: " + message);
    }

    public override void Send(string message)
    {
        mediator.Send(message, this);
    }
}

class Tester : Colleague
{
public Tester(Mediator mediator) : base(mediator) { }

public override void Receive(string message)
{
    Console.WriteLine("Сообщение тестировщику: " + message);
}

public override void Send(string message)
{
    mediator.Send(message, this);
}
}
//Наблюдатель

interface IObserver
{
    void Update(int temperature);
}


interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}


class WeatherStation : IObservable
{
    private List<IObserver> observers;
    private int temperature;

    public WeatherStation()
    {
        observers = new List<IObserver>();
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(temperature);
        }
    }

    public void SetTemperature(int temp)
    {
        temperature = temp;
        NotifyObservers();
    }
}


class WeatherDisplay : IObserver
{
    public void Update(int temperature)
    {
        Console.WriteLine($"Погода обновлена. Текущая температура: {temperature}°C");
    }
}

//Посетитель
interface ITransportVisitor
{
    void VisitBus(Bus bus);
    void VisitTrain(Train train);
    void VisitPlane(Plane plane);
}

interface ITransport
{
    void Accept(ITransportVisitor visitor);
}
class Bus : ITransport
{
    public void Accept(ITransportVisitor visitor)
    {
        visitor.VisitBus(this);
    }

    public void Drive()
    {
        Console.WriteLine("Автобус едет по маршруту.");
    }
}

class Train : ITransport
{
    public void Accept(ITransportVisitor visitor)
    {
        visitor.VisitTrain(this);
    }

    public void Run()
    {
        Console.WriteLine("Поезд движется по рельсам.");
    }
}

class Plane : ITransport
{
    public void Accept(ITransportVisitor visitor)
    {
        visitor.VisitPlane(this);
    }

    public void Fly()
    {
        Console.WriteLine("Самолет летит в небе.");
    }
}

class ServiceInspector : ITransportVisitor
{
    public void VisitBus(Bus bus)
    {
        Console.WriteLine("Сервисный инспектор проверяет автобус.");
        bus.Drive();
    }

    public void VisitTrain(Train train)
    {
        Console.WriteLine("Сервисный инспектор проверяет поезд.");
        train.Run();
    }

    public void VisitPlane(Plane plane)
    {
        Console.WriteLine("Сервисный инспектор проверяет самолет.");
        plane.Fly();
    }
}

class ObjectStructure
{
    List<ITransport> elements = new List<ITransport>();
    public void Add(ITransport element)
    {
        elements.Add(element);
    }
    public void Remove(ITransport element)
    {
        elements.Remove(element);
    }
    public void Accept(ServiceInspector visitor)
    {
        foreach (ITransport element in elements)
            element.Accept(visitor);
    }
}


