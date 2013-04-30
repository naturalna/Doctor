
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This class is printing on the console
/// </summary>
public static class ConsolePrinter
{
    public static void Print(DynamicList list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Patient patient = list[i] as Patient;
            Console.WriteLine("Patient name : " + patient.FullName);
            Console.WriteLine("Patient egn : " + patient.EGN);
            Console.WriteLine("Patient age : " + patient.Age);
            Console.WriteLine("Doc name : " + patient.DoctorName);
            Console.WriteLine("Patient diagnosis : " + patient.Diagnosis);
            Console.WriteLine("-----------------------------------------");
        }
    }
}

