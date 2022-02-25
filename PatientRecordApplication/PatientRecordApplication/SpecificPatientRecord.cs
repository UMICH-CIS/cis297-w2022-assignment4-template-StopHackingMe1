using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
     /// <summary>
     /// This class displays the information of a specific patient after receiving the patient's ID 
     /// from user input
     /// </summary>
     class SpecificPatientRecord
     {
          public void DisplaySpecificPatient()
          {
               const char DELIM = ',';
               const string FILENAME = @"C:\Users\trey2\Documents\PatientData.txt";
               Patient patientDisplay = new Patient();
               FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
               StreamReader reader = new StreamReader(inFile);
               string recordIn;
               string[] fields;
               recordIn = reader.ReadLine();
               int userId;

               Console.Write("Enter user ID of patient you would like to display: ");
               userId = int.Parse(Console.ReadLine());
               Console.WriteLine();

               Console.WriteLine("Printing patient data to screen...");

               while (recordIn != null)
               {
                    fields = recordIn.Split(DELIM);
                    patientDisplay.ID = Convert.ToInt32(fields[0]);

                    if (patientDisplay.ID == userId)
                    {
                         patientDisplay.Name = fields[1];
                         patientDisplay.CurrentBalance = Convert.ToDecimal(fields[2]);
                         Console.WriteLine("ID: {0}\nName: {1}\nCurrent Balance: {2}\n", patientDisplay.ID, patientDisplay.Name, patientDisplay.CurrentBalance.ToString("C"));
                         break;
                    }
                    else
                    {
                         recordIn = reader.ReadLine();
                    }
                    
                    
               }

               if (recordIn == null)
               {
                    Console.WriteLine("Patient was not found");
               }

               reader.Close();
               inFile.Close();
          }
     }
}
