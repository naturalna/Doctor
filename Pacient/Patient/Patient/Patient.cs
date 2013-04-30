using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Patient
{
    private string fullName;
    private long egn;
    private byte age;
    private string doctorName;
    private string diagnosis;

    public Patient(string fullName, long egn, byte age, string doctor, string diagnosis)
    {
        this.FullName = fullName;
        this.EGN = egn;
        this.Age = age;
        this.DoctorName = doctor;
        this.Diagnosis = diagnosis;
    }

    public Patient()
        : this("",1000000000,0,"","")
    {
    }
    public string FullName
    {
        get
        {
            return this.fullName;
        }
        set
        {
            this.fullName = value;

            if (value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Too long Patient name !!!");
            }

            string fullNameCapitalLetters = value.ToUpper();
            if (fullNameCapitalLetters != value)
            {
                throw new ArgumentException("Some of the letters are not capital");
            }
        }
    }

    public long EGN
    {
        get
        {
            return this.egn;
        }
        set
        {
            this.egn = value;
            string agnToString = value.ToString();
            if (agnToString.Length != 10)
            {
                throw new ArgumentOutOfRangeException("The EGN is not correct !!!");
            }
        }
    }

    public byte Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The age is not correct !!!");
            }
        }
    }

    public string DoctorName
    {
        get
        {
            return this.doctorName;
        }
        set
        {
            this.doctorName = value;
            if (value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Too long Doctor name !!!");
            }

            string doctorNameCapitalLetters = value.ToUpper();
            if (doctorNameCapitalLetters != value)
            {
                throw new ArgumentException("Some of the letters are not capital");
            }
        }
    }

    public string Diagnosis
    {
        get
        {
            return this.diagnosis;
        }
        set
        {
            this.diagnosis = value;
            if (value.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Too long diagnosis name !!!");
            }

            string diagnosisCapitalLetters = value.ToUpper();
            if (diagnosisCapitalLetters != value)
            {
                throw new ArgumentException("Some of the letters are not capital");
            }
        }
    }
}

