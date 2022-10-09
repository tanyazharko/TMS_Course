using System;
using System.Reflection;

public class Example
{
    [ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", false)]
    public static string OldProperty
    { get { return "The old property value."; } }

    public static string NewProperty
    { get { return "The new property value."; } }

    [ObsoleteAttribute("This method is obsolete. Call CallNewMethod instead.", true)]
    public static void OldMethod()
    {
        Console.WriteLine("You have called CallOldMethod.");
    }

    public static void NewMethod()
    {
        Console.WriteLine("You have called CallNewMethod.");
    }

    public static void Main()
    {
        OldMethod();
    }
}