using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <Name> Aaron Willis </Name>
/// <Class> CIS 297 </Class>
/// <Semester> Winter 2022 </Semester>

namespace PatientRecordApplication
{
    class Program
    {
        static void Main(string[] args)
        {

               Patient patients = new Patient();
               DisplayPatientData patientData = new DisplayPatientData();
               SpecificPatientRecord specificPatient = new SpecificPatientRecord();
               PatientBalance patientWithBalance = new PatientBalance();

               patients.WriteToFile();
               patientData.ReadAndDisplay();
               specificPatient.DisplaySpecificPatient();
               patientWithBalance.DisplayMinimumBalance();

               Console.ReadKey();
               





        }
    }
}
