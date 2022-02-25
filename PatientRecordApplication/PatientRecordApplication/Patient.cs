using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
     /// <summary>
     /// This class holds the information of each patient (ID, Name, and currentBalance)
     /// </summary>
     class Patient
     {
          int Id;
          string name;
          decimal currentBalance;

          public int ID { get; set; }
          public string Name { get; set; }
          public decimal CurrentBalance { get; set; }

          /// <summary>
          /// This function writes the information input by the user to a file. I specified my own file destination,
          /// but the destination may be different for other users (They would just have to set their own destination)
          /// </summary>
          public void WriteToFile()
          {
               Patient patients = new Patient();
               const int END = 999;
               const string DELIM = ",";
               const string FILENAME = @"C:\Users\trey2\Documents\PatientData.txt";
               FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
               StreamWriter writer = new StreamWriter(outFile);
               writer.WriteLine(patients.ID + DELIM + patients.Name + DELIM + patients.CurrentBalance);

               Console.Write("Enter patient Id or " + END + " to quit: ");

               bool continueLoop = true;

               //This is for throwing an exception when the patient ID isn't numbers (format exception)

               do
               {
                    try
                    {
                         patients.ID = int.Parse(Console.ReadLine());
                         continueLoop = false;
                    }
                    catch (FormatException formatException)
                    {
                         Console.WriteLine($"\n{formatException.Message}");
                         Console.Write("Please enter numbers as the ID: ");
                    }
               }
               while (continueLoop);
               
              

               while (patients.ID != END)
               {

                    bool loop = true;

                    //If the user enters a negative balance, an exception is thrown as the balance should be positive
                    do
                    {
                         try
                         {
                              Console.Write("Enter name: ");
                              patients.Name = Console.ReadLine();

                              Console.Write("Enter balance: ");
                              patients.CurrentBalance = decimal.Parse(Console.ReadLine());

                              if (patients.CurrentBalance < 0)
                              {
                                   throw (new NegativeNumberException("Negative Number Exception Generated: Balance cannot be negative. Please try again"));
                              }

                              loop = false;
                         }
                         catch (FormatException formatException)
                         {
                              Console.WriteLine($"\n{formatException.Message}");
                              Console.WriteLine("A balance can only exist as numbers");
                         }
                         catch(NegativeNumberException negative)
                         {
                              Console.WriteLine(negative.Message.ToString());
                         }
                         finally
                         {
                              Console.WriteLine("Processing Data...");
                              Console.WriteLine();
                              
                         }


                    }
                    while (loop);


                    writer.WriteLine(patients.ID + DELIM + patients.Name + DELIM + patients.CurrentBalance);
                    Console.WriteLine("Patient succesfully added");
                    Console.WriteLine();

                    Console.Write("Enter next patient Id or " + END + " to quit:  ");
                    
                    patients.ID = int.Parse(Console.ReadLine());
               }

               Console.WriteLine();
               writer.Close();
               outFile.Close();
          }

     }
}
