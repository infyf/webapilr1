using System;
using System.Reflection;

public class Car
{
    private string modelName;
    protected int year;
    public string color;
    internal decimal price;
    public static int carCount;

    public Car(string model, int year, string color, decimal price)
    {
        modelName = model;
        this.year = year;
        this.color = color;
        this.price = price;
        carCount++;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Model: {modelName}, Year: {year}, Color: {color}, Price: {price}");
    }

    private void UpdatePrice(decimal newPrice)
    {
        price = newPrice;
    }

    public static int GetCarCount()
    {
        return carCount;
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car("Tesla Model S", 2022, "Red", 79999.99m);
        Car car2 = new Car("BMW i4", 2023, "Blue", 65999.99m);

        Type carType = typeof(Car);
        TypeInfo carTypeInfo = carType.GetTypeInfo();

        Console.WriteLine($"Тип класу: {carType.Name}");
        Console.WriteLine($"Чи є тип публічним? {carTypeInfo.IsPublic}");

        Console.WriteLine("\nЧлени класу Car:");
        foreach (MemberInfo m in carType.GetMembers())
        {
            Console.WriteLine($"{m.Name} - {m.MemberType}");
        }

        Console.WriteLine("\nПоля класу Car:");
        foreach (FieldInfo f in carType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
        {
            Console.WriteLine($"{f.Name} - {f.FieldType}");
        }

        // виклик методІВ DisplayInfo, UpdatePrice через Reflection
        MethodInfo dispInfo = carType.GetMethod("DisplayInfo");
        dispInfo.Invoke(car1, null);
        dispInfo.Invoke(car2, null);

        MethodInfo updPrice = carType.GetMethod("UpdatePrice", BindingFlags.NonPublic | BindingFlags.Instance);
        updPrice.Invoke(car1, new object[] { 75000.00m });
        updPrice.Invoke(car2, new object[] { 62000.00m });

        Console.WriteLine("\nОновлена інформація після зміни ціни:");
        dispInfo.Invoke(car1, null);
        dispInfo.Invoke(car2, null);

        MethodInfo getCnt = carType.GetMethod("GetCarCount");
        var carCnt = getCnt.Invoke(null, null);
        Console.WriteLine($"\nКількість транспортних засобів: {carCnt}");
    }
}
