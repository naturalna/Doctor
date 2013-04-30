using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Meniu();
    }
    static void Meniu()
    {

        Console.WriteLine("For adding a new pasient press 1");
        Console.WriteLine("For changing a pasient info press 2");
        Console.WriteLine("For deleteing a pasient press 3");
        Console.WriteLine("For getting all pasient of a doctor press 4");
        Console.WriteLine("To see all pasients in age range press 5");
        int userChoise = 0;
        
        //DynamicList dinamicList = new DynamicList();
        do
        {
            userChoise = int.Parse(Console.ReadLine());
            switch (userChoise)
            {
                case 1:
                    AddToPatientList();
                    break;
                case 2:
                    ChangeProperty();
                    break;
                case 3:
                    RemovePatient();
                    break;
                case 4:
                    printAllPatientOfDoctor();
                    break;
                case 5:
                    printByPatientAge();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Your command is not valid");
            }
        } while (userChoise != 6);
    }

    private static void RemovePatient()
    {
        Console.WriteLine("Write the egn of the patient you want to change.");
        long egn = long.Parse(Console.ReadLine());
        Patient userChoisePatient = new Patient();
        string binFileToStr = BinaryFile.ReadOnBinaryFile("listOFPatient");

        DynamicList dinamicList = new DataArranger(binFileToStr).ListOfPatients;

        for (int i = 0; i < dinamicList.Count; i++)
        {
            Patient patient = dinamicList[i] as Patient;
            if (patient.EGN == egn)
            {
                userChoisePatient = patient;
                dinamicList.Remove(i);
                break;
            }
        }

        BinaryFile.WriteOnBinaryFile("listOFPatient", dinamicList);
    }

    private static void ChangeProperty()
    {
        Console.WriteLine("Write the egn of the patient you want to change.");
        long egn = long.Parse(Console.ReadLine());
        Patient userChoisePatient = new Patient();
        string binFileToStr = BinaryFile.ReadOnBinaryFile("listOFPatient");

        DynamicList dinamicList = new DataArranger(binFileToStr).ListOfPatients;

        for (int i = 0; i < dinamicList.Count; i++)
        {
            Patient patient = dinamicList[i] as Patient;
            if (patient.EGN == egn)
            {
                userChoisePatient = patient;
                dinamicList.Remove(i);
                break;
            }
        }

        Console.WriteLine("Properties that you can change are :");
        Console.WriteLine("-name");
        Console.WriteLine("-age");
        Console.WriteLine("-egn");
        Console.WriteLine("-doctor");
        Console.WriteLine("-diagnosis");
        Console.WriteLine("If you want to change name write name ...");

        string choise = Console.ReadLine();
        if (choise == "name")
        {
            Console.WriteLine("Write the new name");
            userChoisePatient.FullName = Console.ReadLine();
        }
        else if (choise == "age")
        {
            Console.WriteLine("Write the new age");
            userChoisePatient.FullName = Console.ReadLine();
        }
        else if (choise == "egn")
        {
            Console.WriteLine("Write the new egn");
            userChoisePatient.EGN = int.Parse(Console.ReadLine());
        }
        else if (choise == "doctor")
        {
            Console.WriteLine("Write the new doctor");
            userChoisePatient.DoctorName = Console.ReadLine();
        }
        else if (choise == "diagnosis")
        {
            Console.WriteLine("Write the new diagnosis");
            userChoisePatient.Diagnosis = Console.ReadLine();
        }
        else
        {
            throw new ArgumentOutOfRangeException("There is no such property");
        }

        dinamicList.Add(userChoisePatient);
        BinaryFile.WriteOnBinaryFile("listOFPatient", dinamicList);
    }

    private static void printByPatientAge()
    {
        Console.WriteLine("Put min age of patient");
        byte minAge = byte.Parse(Console.ReadLine());
        Console.WriteLine("Put max age of patient");
        byte maxAge = byte.Parse(Console.ReadLine());
        string binFileToString = BinaryFile.ReadOnBinaryFile("listOFPatient");
        DataArranger dataA = new DataArranger(binFileToString);
        dataA.ArrangeDependingOnAge(minAge, maxAge);
    }

    private static void printAllPatientOfDoctor()
    {
        Console.WriteLine("Put doctor's name");
        string docName = Console.ReadLine();
        string binFileToString = BinaryFile.ReadOnBinaryFile("listOFPatient");
        DataArranger dataA = new DataArranger(binFileToString);
        dataA.ArrangeDependingOnDoctorsName(docName);
    }

    private static void AddToPatientList()
    {
        Patient patient = new Patient();
        Console.WriteLine("Enter patient name only capital letters");
        string name = Console.ReadLine();
        patient.FullName = name;
        Console.WriteLine("Enter patient egn ");
        long egn = long.Parse(Console.ReadLine());
        patient.EGN = egn;
        Console.WriteLine("Enter patient age");
        byte age = byte.Parse(Console.ReadLine());
        patient.Age = age;
        Console.WriteLine("Enter doctor name only capital letters");
        string dname = Console.ReadLine();
        patient.DoctorName = dname;
        Console.WriteLine("Enter diagnoses name only capital letters");
        string diagnoses = Console.ReadLine();
        patient.Diagnosis = diagnoses;

        string binFileToStr = BinaryFile.ReadOnBinaryFile("listOFPatient");
        DynamicList dinamicList = new DataArranger(binFileToStr).ListOfPatients;
        IsEGNCorrect(dinamicList, patient);
        dinamicList.Add(patient);
        BinaryFile.WriteOnBinaryFile("listOFPatient", dinamicList);
    }

    private static void IsEGNCorrect(DynamicList patients, Patient newPatient)
    {
        for (int i = 0; i < patients.Count; i++)
        {
            Patient otherPatient = patients[i] as Patient;
            if (otherPatient.EGN == newPatient.EGN)
            {
                throw new ArgumentException("Patient EGN is already in the list");
            }
        }
    }
}

