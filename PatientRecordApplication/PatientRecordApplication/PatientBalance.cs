using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
     /// <summary>
     /// This class displays the information of any patients have a balance of "x" or greater
     /// </summary>
     class PatientBalance
     {
          public void DisplayMinimumBalance()
          {
               const char DELIM = ',';
               const string FILENAME = @"C:\Users\trey2\Documents\PatientData.txt";
               Patient patientDisplay = new Patient();
               FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
               StreamReader reader = new StreamReader(inFile);
               string recordIn;
               string[] fields;
               recordIn = reader.ReadLine();
               int minimumBalance;
               bool balanceFound = false;

               Console.Write("Enter the minimum balance due: ");
               minimumBalance = int.Parse(Console.ReadLine());

               Console.WriteLine("Printing patients with minimum balance due to screen...");
               Console.WriteLine();

               while (recordIn != null)
               {
                    fields = recordIn.Split(DELIM);
                    patientDisplay.ID = Convert.ToInt32(fields[0]);
                    patientDisplay.Name = fields[1];
                    patientDisplay.CurrentBalance = Convert.ToDecimal(fields[2]);

                    if (patientDisplay.CurrentBalance >= minimumBalance)
                    { 
                         Console.WriteLine("ID: {0}\nName: {1}\nCurrent Balance: {2}\n", patientDisplay.ID, patientDisplay.Name, patientDisplay.CurrentBalance.ToString("C"));
                         recordIn = reader.ReadLine();
                         balanceFound = true;
                    }
                    else
                    {
                         recordIn = reader.ReadLine();
                    }

                   
               }

               if (balanceFound == false)
               {
                    Console.WriteLine("Patient with minimum balance not found");
               }

               reader.Close();
               inFile.Close();
          }
     }
}
