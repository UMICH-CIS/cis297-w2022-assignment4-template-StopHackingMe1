using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
     /// <summary>
     /// This class displays patient data for each patient by reading it from the file that was created from user input
     /// </summary>
     class DisplayPatientData
     {
          public void ReadAndDisplay()
          {
               const char DELIM = ',';
               const string FILENAME = @"C:\Users\trey2\Documents\PatientData.txt";
               Patient patientDisplay = new Patient();
               FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
               StreamReader reader = new StreamReader(inFile);
               string recordIn;
               string[] fields;
               recordIn = reader.ReadLine();

               Console.WriteLine("Displaying all patients...");
               
               while (recordIn != null)
               {
                    fields = recordIn.Split(DELIM);
                    patientDisplay.ID= Convert.ToInt32(fields[0]);
                    if (patientDisplay.ID == 0)
                    {
                         recordIn = reader.ReadLine();
                         continue;
                    }
                    patientDisplay.Name = fields[1];
                    patientDisplay.CurrentBalance = Convert.ToDecimal(fields[2]);
                    Console.WriteLine("ID: {0}\nName: {1}\nCurrent Balance: {2}\n", patientDisplay.ID, patientDisplay.Name, patientDisplay.CurrentBalance.ToString("C"));
                    recordIn = reader.ReadLine();
               }
               reader.Close();
               inFile.Close();
          }
     }
}
