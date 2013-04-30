using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This class is making arrangements on class Patient
/// </summary>
public class DataArranger
{
    //private DynamicList listOfPatients;
    public DynamicList ListOfPatients { get; set; }
    private string binFileToString = null;

    public DataArranger(string binFileToString)
    {
        this.binFileToString = binFileToString;
        this.ListOfPatients = new DynamicList();
        ArrangeData();
    }

    private void ArrangeData()
    {
        if (this.binFileToString != "")
        {          
            string[] patients = this.binFileToString.Split(new char[] { '.' });

            for (int i = 0; i < patients.Length; i++)
            {
                Patient currentPatient = new Patient();
                if (patients[i] != "")
                {
                    string[] patientInfo = patients[i].Split(new char[] { ',' });
                    currentPatient.FullName = patientInfo[0].Substring(1, patientInfo[0].Length - 1);
                    currentPatient.EGN = long.Parse(patientInfo[1].Substring(1, patientInfo[1].Length - 1));
                    currentPatient.Age = byte.Parse(patientInfo[2].Substring(1, patientInfo[2].Length - 1));
                    currentPatient.DoctorName = patientInfo[3].Substring(1, patientInfo[3].Length - 1);
                    currentPatient.Diagnosis = patientInfo[4].Substring(1, patientInfo[4].Length - 1);
                    this.ListOfPatients.Add(currentPatient);
                }
            }
        }
    }

    public void ArrangeDependingOnDoctorsName(string doctorsName)
    {
        IList<Patient> doctorXPatient = new List<Patient>();
        DynamicList result = new DynamicList();
        for (int i = 0; i < ListOfPatients.Count; i++)
        {
            Patient patient = ListOfPatients[i] as Patient;
            if (patient.DoctorName == doctorsName)
            {
                doctorXPatient.Add(patient);
            }
        }

        var ordered =
        doctorXPatient.OrderByDescending(x => x.Age);
        foreach (var item in ordered)
        {
            result.Add(item);
        }

        ConsolePrinter.Print(result);
    }

    public void ArrangeDependingOnAge(byte smallestPatientAge, byte biggestPatientAge)
    {
        IList<Patient> doctorXPatient = new List<Patient>();
        DynamicList result = new DynamicList();
        for (int i = 0; i < ListOfPatients.Count; i++)
        {
            Patient patient = ListOfPatients[i] as Patient;
            if (patient.Age >= smallestPatientAge && patient.Age <= biggestPatientAge)
            {
                doctorXPatient.Add(patient);
            }
        }

        var ordered =
        doctorXPatient.OrderByDescending(x => x.Age);
        foreach (var item in ordered)
        {
            result.Add(item);
        }

        ConsolePrinter.Print(result);
    }
}

