using System;

class Program
{
    static void Main()
    {
        Base es = new Espresso();
        Console.WriteLine($"Напиток: {es.Description}, Цена: ${es.Cost()}");
        Base esWMilk = new Milk(es);
        Console.WriteLine($"Напиток: {esWMilk.Description}, Цена: ${esWMilk.Cost()}");
        ((Milk)esWMilk).HeatMilk(); 
        Base esWMilkAChocolate = new Chocolate(esWMilk);
        Console.WriteLine($"Напиток: {esWMilkAChocolate.Description}, Цена: ${esWMilkAChocolate.Cost()}");
        ((Chocolate)esWMilkAChocolate).AddChocolateSyrup(); 

        Console.WriteLine("");

        var company = new Department("Company");
        var hrDepartment = new Department("HR");
        hrDepartment.Add(new Employee("Влада"));
        hrDepartment.Add(new Employee("Егор"));
        var itDepartment = new Department("IT");
        itDepartment.Add(new Employee("Миша"));
        itDepartment.Add(new Employee("Никита"));
        company.Add(hrDepartment);
        company.Add(itDepartment);
        company.Print();

        Console.WriteLine("");

        FileFacade fileFacade = new FileFacade();
        fileFacade.CopyFile("source.txt", "destination.txt");
        fileFacade.MoveFile("test.txt", "newLocation/test.txt");
    }
}
//Декоратор
abstract class Base
{
    public abstract string Description { get; }
    public abstract double Cost();
}

class Espresso : Base
{
    public override string Description => "Эспрессо";

    public override double Cost()
    {
        return 1.99;
    }
}

abstract class CondimentDecorator : Base
{
    protected Base Base;

    public CondimentDecorator(Base Base)
    {
        this.Base = Base;
    }

    public override string Description => Base.Description;
}

class Milk : CondimentDecorator
{
    public Milk(Base Base) : base(Base) { }

    public override string Description => Base.Description + ", с молоком";

    public override double Cost()
    {
        return Base.Cost() + 1;
    }

    public void HeatMilk()
    {
        Console.WriteLine("Подогреть молоко");
    }
}

class Chocolate : CondimentDecorator
{
    public Chocolate(Base Base) : base(Base) { }

    public override string Description => Base.Description + ", с шоколадом";

    public override double Cost()
    {
        return Base.Cost() + 0.5;
    }

    public void AddChocolateSyrup()
    {
        Console.WriteLine("Добавить шоколадный сироп");
    }
}
//Компановщик
abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public virtual void Add(Component component)
    {
        Console.WriteLine("Операция не поддерживается");
    }

    public virtual void Remove(Component component)
    {
        Console.WriteLine("Операция не поддерживается");
    }

    public virtual void Print()
    {
        Console.WriteLine(name);
    }
}

class Employee : Component
{
    public Employee(string name) : base(name) { }
}

class Department : Component
{
    private List<Component> components = new List<Component>();

    public Department(string name) : base(name) { }

    public override void Add(Component component)
    {
        components.Add(component);
    }

    public override void Remove(Component component)
    {
        components.Remove(component);
    }

    public override void Print()
    {
        Console.WriteLine("Отдел: " + name);
        Console.WriteLine("Работники:");
        foreach (var component in components)
        {
            component.Print();
        }
    }
}
//Фасад
class FileService
{
    public void ReadFile(string fileName)
    {
        Console.WriteLine($"Чтение файла '{fileName}'");
    }

    public void WriteFile(string fileName)
    {
        Console.WriteLine($"Запись в файл '{fileName}'");
    }

    public void DeleteFile(string fileName)
    {
        Console.WriteLine($"Удаление файла '{fileName}'");
    }
}

class FileFacade
{
    private FileService fileService;

    public FileFacade()
    {
        fileService = new FileService();
    }

    public void CopyFile(string sourceFile, string destinationFile)
    {
        fileService.ReadFile(sourceFile);
        fileService.WriteFile(destinationFile);
        Console.WriteLine($"Файл '{sourceFile}' скопирован в '{destinationFile}'");
    }

    public void MoveFile(string sourceFile, string destinationFile)
    {
        fileService.ReadFile(sourceFile);
        fileService.WriteFile(destinationFile);
        fileService.DeleteFile(sourceFile);
        Console.WriteLine($"Файл '{sourceFile}' перемещен в '{destinationFile}'");
    }
}