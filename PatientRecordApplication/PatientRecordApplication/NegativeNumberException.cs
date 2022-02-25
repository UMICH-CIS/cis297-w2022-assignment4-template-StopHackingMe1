using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
     /// <summary>
     /// This class is for showing a message for an exception if the user enters a negative balance
     /// </summary>
     public class NegativeNumberException: Exception
     {
          public NegativeNumberException(string message) : base(message)
          {
          }
     }
}
