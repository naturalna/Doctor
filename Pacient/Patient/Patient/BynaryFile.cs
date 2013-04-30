using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/// <summary>
/// This class is making a new stream and read and write on it
/// </summary>
public static class BinaryFile
{
    public static void WriteOnBinaryFile(string fileName, DynamicList patientList)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create), Encoding.GetEncoding("windows-1251")))
        {
            for (int i = 0; i < patientList.Count; i++)
            {
                Patient patientX = patientList[i] as Patient;
                writer.Write(patientX.FullName + ",");
                writer.Write(patientX.EGN + ",");
                writer.Write(patientX.Age + ",");
                writer.Write(patientX.DoctorName + ",");
                writer.Write(patientX.Diagnosis + ".");  
            }            
        }
    }

    public static string ReadOnBinaryFile(string fileName)
    {
        FileStream fs = File.Open(fileName, FileMode.OpenOrCreate);
        StringBuilder stringBilder = new StringBuilder();
        if (File.Exists(fileName))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                char[] memoryData = new char[fs.Length - 0];
                for (int i = 0; i < memoryData.Length; i++)
                {
                    memoryData[i] = Convert.ToChar(reader.Read());
                    stringBilder.Append(memoryData[i]);
                }
            }
        }

        return stringBilder.ToString();
    }
}

